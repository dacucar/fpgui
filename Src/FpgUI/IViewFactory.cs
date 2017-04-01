using System;
using FenixLib.Core;

namespace FpgUI
{
	public interface IViewFactory
	{
		IFpgEditorView FpgEditorView();

		IAddGraphicDialog AddGraphicDialog();

		INewFpgDialog NewFpgDialog();
	}
}

