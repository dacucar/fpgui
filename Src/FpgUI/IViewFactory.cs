using System;
using FenixLib.Core;

namespace FpgUI
{
	public interface IViewFactory
	{
		IFpgEditorView CreateFpgEditorView();

		IAddGraphicDialog CreateAddGraphicDialog();

		INewFpgDialog CreateDialogNewFpg();

		/*
		void CreatePaletteEditorView();

		void CreateSpriteEditorView();

		void CreateNewFpgView();

		void CreateAddGraphicView();*/
	}
}

