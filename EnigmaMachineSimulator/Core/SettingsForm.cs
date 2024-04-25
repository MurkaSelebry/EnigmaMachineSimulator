using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace Enigma2
{
    public partial class SettingsForm : Form
    {
        GameMain main;
        public SettingsForm(GameMain game)
        {
            InitializeComponent();
            main = game;
            this.FormClosing += (o, e) =>
            {
                e.Cancel = true;
                main.CloseSettings();

                bool custom = useCustomReflector.Checked;
                string reflector = custom ? textBoxReflector.Text : comboBoxReflector.SelectedItem.ToString().Split(' ')[2];
                float sound = trackBarSound.Value / 10f;

                int[] ring, rotors, key;

                if (useM4.Checked)
                {
                    key = new int[] { main.enigma.key[0], main.enigma.key[1], main.enigma.key[2], main.enigma.key.Length > 3 ? main.enigma.key[3] : 0 };
                    ring = new int[] { getRing(oneRing), getRing(twoRing), getRing(threeRing), getRing(fourRing) };
                    rotors = new int[] { rotor1.SelectedIndex, rotor2.SelectedIndex, rotor3.SelectedIndex, 8 + rotor4.SelectedIndex };
                }
                else
                {
                    key = new int[] { main.enigma.key[0], main.enigma.key[1], main.enigma.key[2] };
                    rotors = new int[] { rotor1.SelectedIndex, rotor2.SelectedIndex, rotor3.SelectedIndex };
                    ring = new int[] { getRing(oneRing), getRing(twoRing), getRing(threeRing) };
                }

                main.SetSettings(new Settings() { key = key, ring = ring, customReflector = custom, reflector = reflector, sound = sound, rotors = rotors, useM4 = useM4.Checked, replace = main.replace });
                this.Hide();
            };
            oneRing.SelectedIndex = 1;
            twoRing.SelectedIndex = 1;
            threeRing.SelectedIndex = 1;
            fourRing.SelectedIndex = 1;

            comboBoxReflector.SelectedIndex = 0;
        }

        int getRing(DomainUpDown ring)
        {
            if (ring.SelectedItem == null || ring.SelectedItem.ToString().Length <= 0)
                return 0;
            return BaseEnigma.code(ring.SelectedItem.ToString().ToCharArray()[0]);
        }

        public void Copy()
        {
            string msg = main.message;
            if (checkBoxCopy.Checked)
            {
                int i = 0;
                int cur = 4;
                int.TryParse(textBoxGroups.Text, out cur);
                msg = string.Join("", msg.Select(x => i++ % cur == 0 ? " " + x.ToString() : x.ToString()).ToArray()).Trim();
            }
            Clipboard.SetText(msg);
        }

        private void oneRing_SelectedItemChanged(object sender, EventArgs e)
        {
            setRing(oneRing);
        }

        private void twoRing_SelectedItemChanged(object sender, EventArgs e)
        {
            setRing(twoRing);
        }

        private void threeRing_SelectedItemChanged(object sender, EventArgs e)
        {
            setRing(threeRing);
        }

        void setRing(DomainUpDown dom)
        {
            if (dom.SelectedIndex == 0)
                dom.SelectedIndex = 25;
            else if (dom.SelectedIndex == 26)
                dom.SelectedIndex = 1;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();


            s.useM4 = useM4.Checked;
            s.customReflector = useCustomReflector.Checked;
            s.reflector = useCustomReflector.Checked ? textBoxReflector.Text : comboBoxReflector.SelectedItem.ToString().Split(' ')[2];
            s.sound = trackBarSound.Value / 10f;

            int[] ring, rotors, key;

            if (useM4.Checked)
            {
                key = new int[] { main.enigma.key[0], main.enigma.key[1], main.enigma.key[2], main.enigma.key.Length > 3 ? main.enigma.key[3] : 0 };
                ring = new int[] { getRing(oneRing), getRing(twoRing), getRing(threeRing), getRing(fourRing) };
                rotors = new int[] { rotor1.SelectedIndex, rotor2.SelectedIndex, rotor3.SelectedIndex, 8 + rotor4.SelectedIndex };
            }
            else
            {
                key = new int[] { main.enigma.key[0], main.enigma.key[1], main.enigma.key[2] };
                ring = new int[] { getRing(oneRing), getRing(twoRing), getRing(threeRing) };
                rotors = new int[] { rotor1.SelectedIndex, rotor2.SelectedIndex, rotor3.SelectedIndex };
            }

            s.key = key;
            s.ring = ring;
            s.rotors = rotors;
            s.replace = main.replace;

            s.reflIndex = comboBoxReflector.SelectedIndex;


            byte[] toSave = ObjectToByteArray(s);

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "rotpos";
            dlg.DefaultExt = ".end";
            dlg.Filter = "Enigma rotors position (.end)|*.end";

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string filename = dlg.FileName;
                    File.WriteAllBytes(filename, toSave);
                }
                catch { }
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "rotpos";
            dlg.DefaultExt = ".end";
            dlg.Filter = "Enigma rotors position (.end)|*.end";

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string filename = dlg.FileName;
                    Settings s = (Settings)ByteArrayToObject(File.ReadAllBytes(filename));

                    oneRing.SelectedIndex = s.ring[0] + 1;
                    twoRing.SelectedIndex = s.ring[1] + 1;
                    threeRing.SelectedIndex = s.ring[2] + 1;
                    fourRing.SelectedIndex = s.ring.Length > 3 ? s.ring[3] + 1 : 1;

                    rotor1.SelectedIndex = s.rotors[0];
                    rotor2.SelectedIndex = s.rotors[1];
                    rotor3.SelectedIndex = s.rotors[2];
                    rotor4.SelectedIndex = (s.rotors.Length > 3 ? s.rotors[3] : 8) - 8;

                    /*main.enigma._rotors = s.rotors;
                    main.enigma.key = s.key;
                    main.enigma.ring = s.ring;*/

                    trackBarSound.Value = (int)(s.sound * 10);
                    useM4.Checked = s.useM4;
                    useCustomReflector.Checked = s.customReflector;
                    textBoxReflector.Text = s.reflector;
                    comboBoxReflector.SelectedIndex = s.reflIndex;

                    main.SetSettings(s);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
        private Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.message = "";
        }

        private void textBoxGroups_TextChanged(object sender, EventArgs e)
        {
            int res;
            if(!int.TryParse(textBoxGroups.Text, out res))
            {
                textBoxGroups.Text = 4.ToString();
            }
        }
    }


    [Serializable]
    public struct Settings
    {
        public int[] key;
        public int[] ring;
        public int[] rotors;
        public bool customReflector;
        public string reflector;
        public float sound;
        public bool useM4;
        public Dictionary<char, char> replace;
        public int reflIndex;
    }

}
