using System;
using FenixLib.Core;
using FpgUI.Core.FpgEditorActions;

namespace FpgUI
{
	public interface IViewFactory
	{
		IFpgEditorView CreateFpgEditorView();

		/*
		void CreatePaletteEditorView();

		void CreateSpriteEditorView();

		void CreateNewFpgView();

		void CreateAddGraphicView();*/
	}
}

