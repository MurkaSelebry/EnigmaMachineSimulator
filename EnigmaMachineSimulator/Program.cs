using System;

namespace Enigma2
{
	public static class Program
	{
		[STAThread]
		static void Main()
		{
			using (GameMain main = new GameMain())
			{
				SettingsForm form = new SettingsForm(main);
				main.formSettings = form;
				main.Run();
			}
		}
	}
}
