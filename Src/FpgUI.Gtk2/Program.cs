using System;
using Xwt;
using FpgUI.Ui;
using FpgUI.Core;

namespace FpgUI.Gtk2
{
	public class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Initialize(ToolkitType.Gtk);

			var context = 
				new ApplicationContext();

			Application.Run();

			Application.Dispose();
		}
	}
}

