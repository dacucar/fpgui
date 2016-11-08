using System;
using FenixLib.Core;
using FpgUI.Core.FpgEditor;

namespace FpgUI.Core
{
	public interface IViewFactory
	{
		IFpgEditorView CreateFpgEditorView();

		void CreatePaletteEditorView();

		void CreateSpriteEditorView();

		void CreateNewFpgView();

		void CreateAddGraphicView();
	}
}

