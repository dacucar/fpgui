using System;

namespace FpgUI.Core
{
	public interface IWindowsFactory
	{
		void NewFpgEditor();

		void NewPaletteEditor();

		void NewGraphicEditor();
	}
}

