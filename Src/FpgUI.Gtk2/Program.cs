using System;
using Xwt;
using FpgUI.Ui;

namespace FpgUI.Gtk2
{
	public class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Initialize(ToolkitType.Gtk);

			var context = 
				new FpgUIContext();

			Application.Run();

			Application.Dispose();
		}
	}
}

