using System;
using FpgUI.Xwt;
using Xwt;

namespace FpgUI.Wpf
{
    public class Program
    {
        [STAThread]
        public static void Main ( string [] args )
        {
			Application.Initialize(ToolkitType.Wpf);

			var context = new FpgUiContext(new ViewFactory(), XwtDefaults.LastViewClosedHandler);
			var view = context.ViewFactory.CreateFpgEditorView();
			var controller = new FpgEditorController(view, context);

			controller.ShowView();
			Application.Run();
			((Window)view).Dispose();
			Application.Dispose();
        }
    }
}

