using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enigma2
{
    public class BaseEnigma
    {
        static string[] rotors = new[] { "EKMFLGDQVZNTOWYHXUSPAIBRCJ","AJDKSIRUXBLHWTMCQGZNPYFVOE","BDFHJLCPRTXVZNYEIWGAKMUSQO",
                                         "ESOVPZJAYQUIRHXLNFTGKDCMWB","VZBRGITYUPSDNHLXAWMJQOFECK","JPGVOUMFYQBENHZRDKASXLICTW",
                                         "NZJHGRCXMYSWBOUFAIVLPEKQDT","FKQHTLXOCBJSPDZRAMEWNIUYGV",
                                         "LEYJVCNIXWPBQMDRTAKZGFUHOS", "FSOKANUERHMBTIYCWLQPZXVGJD"};
        static int[][] symbols = "q,q;e,e;v,v;j,j;z,z;z,m;z,m;z,m".Split(';').Select(x => x.Split(',').Select(y => code(y.ToCharArray()[0])).ToArray()).ToArray();

        static string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string reflectorB = "YRUHQSLDPXNGOKMIEBFZCWVJAT";
        public static string reflectorBThin = "ENKQAUYWJICOPBLMDXZVFTHRGS";
        public static string reflectorC = "FVPJIAOYEDRZXWGCTKUQSBNMHL";
        public static string reflectorCThin = "RDOBJNTKVEHMLFCWZAXGYIPSUQ";

        public Dictionary<char, char> Replace = new Dictionary<char, char>();

        public int[] key = toKey("AAA");
        public int[] _rotors = toKey("ABC");
        public int[] ring = toKey("AAA");

        /*static void Main(string[] args)
        {
            int[] key = toKey("AAAZ");
            int[] _rotors = toKey("ABCI");
            int[] ring = toKey("AAAY");

            string enc = "";
            string dec = "";
            string message = "hellomycoolfriendiloveyoumyfrienisthisonetwoonetwoonethisiscoooolnews";

            foreach (char x in message)
                enc += encode(x, key, _rotors, ring, reflectorBThin, null);
            Console.WriteLine(enc);

            key = toKey("AAAZ");
            _rotors = toKey("ABCI");
            ring = toKey("AAAY");

            foreach (char x in enc)
                dec += encode(x, key, _rotors, ring, reflectorBThin, null);
            Console.WriteLine(dec);
            
            Console.Read();
        }*/

        public static int[] toKey(string str)
        {
            return str.Select(x => code(x)).ToArray();
        }
        public static int[] toKey(int num)
        {
            return num.ToString().Select(x => int.Parse(x.ToString()) - 1).ToArray();
        }

        static string reverse(string msg)
        {
            int i = 0;
            string repl = new string(msg.Select(y =>
            {
                char temp = abc[msg.IndexOf(abc[i])];
                i++;
                return temp;
            }).ToArray());
            return repl;
        }

        public static char encode(char symbol, int[] key, int[] rotrs, int[] ring, string reflector, Dictionary<char, char> plugboard)
        {
            increment(key, rotrs);
            return enigma(symbol, key, rotrs, ring, reflector, plugboard);
        }

        static void increment(int[] key, int[] r)
        {
            int temp1 = key[1];
            if (key[1] == symbols[r[1]][0] || key[1] == symbols[r[1]][1])
            {
                key[0] = (key[0] + 1) % 26;
                key[1] = (key[1] + 1) % 26;
            }
            if (key[2] == symbols[r[2]][0] || key[2] == symbols[r[2]][1])
            {
                if (temp1 == key[1])
                    key[1] = (key[1] + 1) % 26;
            }
            key[2] = (key[2] + 1) % 26;
        }

        static void decrement(int[] key, int[] r)
        {
            int temp1 = key[1];
            if (key[1] == (symbols[r[1]][0] + 1) % 26 || key[1] == (symbols[r[1]][1] + 1) % 26)
            {
                if (key[0] - 1 < 0)
                    key[0] = (key[0] - 1 + 26) % 26;
                else
                    key[0] = (key[0] - 1) % 26;

                if (key[1] - 1 < 0)
                    key[1] = (key[1] - 1 + 26) % 26;
                else
                    key[1] = (key[1] - 1) % 26;
            }
            if (key[2] == (symbols[r[2]][0] + 1) % 26 || key[2] == (symbols[r[2]][1] + 1) % 26)
            {
                if (temp1 == key[1])
                {
                    if (key[1] - 1 < 0)
                        key[1] = (key[1] - 1 + 26) % 26;
                    else
                        key[1] = (key[1] - 1) % 26;
                }
            }
            if (key[2] - 1 < 0)
                key[2] = (key[2] - 1 + 26) % 26;
            else
                key[2] = (key[2] - 1) % 26;
        }

        static char enigma(char symbol, int[] key, int[] _rotors, int[] ring, string reflector, Dictionary<char, char> replc)
        {
            if (replc.ContainsKey(symbol))
                symbol = replc[symbol];

            bool m4 = false;
            int rotor4 = 0, ring4 = 0, key4 = 0;

            if (_rotors.Length > 3)
            {
                m4 = true;
                key4 = key[3];
                key = new[] { key[0], key[1], key[2] };
                rotor4 = _rotors[3];
                _rotors = new[] { _rotors[0], _rotors[1], _rotors[2] };
                ring4 = ring[3];
                ring = new[] { ring[0], ring[1], ring[2] };
            }

            int i = _rotors.Length - 1;
            while (i >= 0)
            {
                symbol = rotor(symbol, rotors[_rotors[i]], key[i] - ring[i]);
                i--;
            }

            if (m4) symbol = rotor(symbol, rotors[rotor4], key4 - ring4);
            symbol = sub(symbol, reflector.ToCharArray());
            if (m4) symbol = rotor(symbol, reverse(rotors[rotor4]), key4 - ring4);

            i = 0;
            while (i < _rotors.Length)
            {
                symbol = rotor(symbol, reverse(rotors[_rotors[i]]), key[i] - ring[i]);
                i++;
            }

            if (replc.ContainsKey(symbol))
                symbol = replc[symbol];
            return symbol;
        }

        /*static char rotor(char symbol, string rotor, int offset)
        {
            int i = code(symbol) + offset;
            char sym = rotor[i + 26 % 26];
            return abc[code(sym) - offset];
        }*/

        static char rotor(char symbol, string rotor, int offset)
        {
            int symbolCode = (code(symbol) + 26 + offset) % 26;
            return (char)((code(rotor[symbolCode]) + 26 - offset) % 26 + 65);
        }

        static char sub(char sym, char[] data)
        {
            return data[code(sym)];
        }

        public static int code(char ch)
        {
            return ((int)ch.ToString().ToUpper().ToCharArray()[0]) - 65;
        }

        internal char Encode(char symbol, string reflector)
        {
            return encode(symbol, key, _rotors, ring, reflector, Replace);
        }

        public void Decrement()
        {
            decrement(key, _rotors);
        }

        internal void Back()
        {
            if (key[2] - 1 < 0)
                key[2] = (key[2] - 1 + 26) % 26;
            else
                key[2] = (key[2] - 1) % 26;
        }

        internal void Move()
        {
            key[2] = (key[2] + 1) % 26;
        }

        internal void MoveAt(int p)
        {
            key[p] = (key[p] + 1) % 26;
        }

        internal void BackAt(int p)
        {
            if (key[p] - 1 < 0)
                key[p] = (key[p] - 1 + 26) % 26;
            else
                key[p] = (key[p] - 1) % 26;
        }
    }
}
