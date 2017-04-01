using System;
using Xwt;
using FpgUI.Xwt;

namespace FpgUI.Gtk3
{
	public class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Initialize(ToolkitType.Gtk3);

			var context = new FpgUiContext(new ViewFactory(), XwtDefaults.LastViewClosedHandler);
			var view = context.ViewFactory.FpgEditorView();
			var controller = new FpgEditorController(view, context);

			controller.ShowView();
			Application.Run();
			((Window)view).Dispose();
			Application.Dispose();
		}
	}
}

