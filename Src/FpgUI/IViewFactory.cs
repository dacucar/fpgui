using System;
using FenixLib.Core;

namespace FpgUI
{
	public interface IViewFactory
	{
		IFpgEditorView CreateFpgEditorView();

		IAddGraphicDialog CreateAddGraphicDialog();

		INewFpgDialog CreateDialogNewFpg();
	}
}

