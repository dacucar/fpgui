using System;
using FenixLib.Core;
using FpgUI.Core.FpgEditorActions;
using FpgUI.FpgEditor;

namespace FpgUI
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

