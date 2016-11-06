using System;
using System.Collections.Generic;

namespace FpgUI.Core
{
	public class ApplicationContext
	{
		private IWindowsFactory windowsFactory;

		public void NewFpgEditorWindow()
		{
			this.windowsFactory.NewFpgEditor();
		}

		public void NewPaletteEditorWindow(bool standalone = false)
		{
			this.windowsFactory.NewPaletteEditor();
		}

		public void NewGraphicEditorWindow(bool standalone = false)
		{
			this.windowsFactory.NewGraphicEditor();
		}

		public ApplicationContext(IWindowsFactory windowsFactory)
		{
			this.windowsFactory = windowsFactory;
		}
	}
}

