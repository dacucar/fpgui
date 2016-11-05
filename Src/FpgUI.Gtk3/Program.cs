using System;
using Xwt;
using FpgUI.Ui;

namespace FpgUI.Gtk3
{
	public class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Initialize(ToolkitType.Gtk3);

			FpgEditorWindow w = new FpgEditorWindow();
			w.Show();

			Application.Run();

			w.Dispose();
			Application.Dispose();
		}
	}
}

