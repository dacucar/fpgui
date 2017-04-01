using System;
using Xwt;
using FpgUI.Xwt;

namespace FpgUI.Gtk2
{
	public class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Initialize(ToolkitType.Gtk);

			var context = new FpgUiContext(new ViewFactory(), XwtDefaults.LastViewClosedHandler);
			var view = context.ViewFactory.CreateFpgEditorView();
			var controller = new FpgEditorController(view, context);

			controller.ShowView();

			Application.Run();

			Application.Dispose();
		}
	}
}

