using System;
using FenixLib.Core;

namespace FpgUI
{
	public interface IViewFactory
	{
		IFpgEditorView CreateFpgEditorView();

		IAddGraphicDialog CreateAddGraphicDialog();

		/*
		void CreatePaletteEditorView();

		void CreateSpriteEditorView();

		void CreateNewFpgView();

		void CreateAddGraphicView();*/
	}
}

