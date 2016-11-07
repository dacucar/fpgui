using System;
using System.Collections.Generic;

namespace FpgUI.Core
{
	public class ApplicationContext
	{
		private IWindowsFactory windowsFactory;

		public void CreateNewFpgEditorWindow()
		{
			this.windowsFactory.CreateFpgEditorWindow(this);
		}

		public void CreateNewFpgDialog()
		{
			this.windowsFactory.CreateNewFpgDialog(this);
		}

		public void CreatePaletteEditorWindow(bool standalone = false)
		{
			this.windowsFactory.CreatePaletteEditorWindow(this);
		}

		public void CreateSpriteEditorWindow(bool standalone = false)
		{
			this.windowsFactory.CreateSpriteEditorWindow(this);
		}

		public void CreateAddGraphicDialog()
		{
			this.windowsFactory.CreateAddGraphicDialog(this);
		}

		public ApplicationContext(IWindowsFactory windowsFactory)
		{
			this.windowsFactory = windowsFactory;
		}
	}
}

