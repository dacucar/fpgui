using System;
using Xwt;

namespace FpgUI.Gtk3
{
	public class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Initialize(ToolkitType.Gtk3);

			var context = new FpgUIContext();
			var view = context.ViewFactory.CreateFpgEditorView();
			var controller = new FpgEditorController(view, context);

			controller.ShowView();
			Application.Run();
			//w.Dispose();
			Application.Dispose();
		}
	}
}

