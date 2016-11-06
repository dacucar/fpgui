using System;

namespace FpgUI.Core
{
	public interface IWindowsFactory
	{
		void ShowFpgEditor(ApplicationContext context);

		void ShowPaletteEditor();

		void ShowGraphicEditor();

		void ShowNewFpgDialog(ApplicationContext context);
	}
}

