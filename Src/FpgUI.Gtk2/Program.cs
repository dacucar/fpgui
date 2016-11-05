using System;
using Xwt;
using FpgUI.Xwt.FpgEditor;

namespace FpgUI.Gtk2
{
	public class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Initialize(ToolkitType.Gtk);

			var w = new FpgEditorWindow();
			w.Show();

			Application.Run();

			w.Dispose();
			Application.Dispose();
		}
	}
}

