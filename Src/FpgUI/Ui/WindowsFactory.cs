using System;
using FpgUI.Core;

namespace FpgUI.Ui
{
	public class WindowsFactory : IWindowsFactory
    {
        public WindowsFactory()
        {
        }

		#region IWindowsFactory implementation

		public void NewFpgEditor()
		{
			var w = new FpgEditorWindow();
			w.Show();
		}

		public void NewPaletteEditor()
		{
			throw new NotImplementedException();
		}

		public void NewGraphicEditor()
		{
			throw new NotImplementedException();
		}

		#endregion
    }
}

