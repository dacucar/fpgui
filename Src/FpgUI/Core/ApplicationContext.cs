using System;
using System.Collections.Generic;

namespace FpgUI.Core
{
	public class ApplicationContext
	{
		private IWindowsFactory windowsFactory;

		public void NewFpgEditorWindow()
		{
			this.windowsFactory.CreateFpgEditorWindow(this);
		}

		public void NewFpgEditorNewDialog()
		{
			this.windowsFactory.CreateNewFpgDialog(this);
		}

		public void NewPaletteEditorWindow(bool standalone = false)
		{
			this.windowsFactory.CreatePaletteEditorWindow(this);
		}

		public void NewGraphicEditorWindow(bool standalone = false)
		{
			this.windowsFactory.CreateSpriteEditorWindow(this);
		}

		public void NewAddGraphicDialog()
		{
			this.windowsFactory.CreateAddGraphicDialog(this);
		}

		public ApplicationContext(IWindowsFactory windowsFactory)
		{
			this.windowsFactory = windowsFactory;
		}
	}
}

