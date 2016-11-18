using System;
using Xwt;
using FpgUI.FpgEditor;

namespace FpgUI.Gtk3
{
	public class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Initialize(ToolkitType.Gtk3);

			ApplicationContext context = 
				new ApplicationContext();

			var view = new FpgEditorView();
			var controller = new FpgEditorController(view, context);

			controller.ShowView();
			Application.Run();
			//w.Dispose();
			Application.Dispose();
		}
	}
}

