using System;
using FpgUI.Core;
using FpgUI.Ui;

namespace FpgUI.Ui
{
	public class WindowsFactory : IWindowsFactory
    {
        public WindowsFactory()
        {
        }

		#region IWindowsFactory implementation

		public void ShowFpgEditor(ApplicationContext context)
		{
			var w = new FpgEditorWindow(context);
			w.Show();
		}

		public void ShowNewFpgDialog(ApplicationContext context)
		{
			var w = new NewFpgDialog();
			w.Show();
		}

		public void ShowPaletteEditor()
		{
			throw new NotImplementedException();
		}

		public void ShowGraphicEditor()
		{
			throw new NotImplementedException();
		}

		#endregion
    }
}

