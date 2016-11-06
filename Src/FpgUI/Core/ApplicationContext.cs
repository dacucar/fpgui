using System;
using System.Collections.Generic;

namespace FpgUI.Core
{
	public class ApplicationContext
	{
		private IWindowsFactory windowsFactory;

		public void NewFpgEditorWindow()
		{
			this.windowsFactory.ShowFpgEditor(this);
		}

		public void NewFpgEditorNewDialog()
		{
			this.windowsFactory.ShowNewFpgDialog(this);
		}

		public void NewPaletteEditorWindow(bool standalone = false)
		{
			this.windowsFactory.ShowPaletteEditor();
		}

		public void NewGraphicEditorWindow(bool standalone = false)
		{
			this.windowsFactory.ShowGraphicEditor();
		}

		public ApplicationContext(IWindowsFactory windowsFactory)
		{
			this.windowsFactory = windowsFactory;
		}
	}
}

