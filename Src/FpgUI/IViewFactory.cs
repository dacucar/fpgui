using System;
using FenixLib.Core;
using FpgUI.FpgEditor;
using FpgUI.FpgEditor.AddGraphic;
using FpgUI.FpgEditor.NewFpg;

namespace FpgUI
{
	public interface IViewFactory
	{
		IFpgEditorView FpgEditorView();

		IAddGraphicDialog AddGraphicDialog();

		INewFpgDialog NewFpgDialog();
	}
}

