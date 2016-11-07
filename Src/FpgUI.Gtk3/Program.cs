using System;
using Xwt;
using FpgUI.Ui;
using FpgUI.Core;

namespace FpgUI.Gtk3
{
	public class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Initialize(ToolkitType.Gtk3);

			ApplicationContext context = 
				new ApplicationContext(new WindowsFactory());

			context.CreateNewFpgEditorWindow();

			Application.Run();

			//w.Dispose();
			Application.Dispose();
		}
	}
}

