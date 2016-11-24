using System;
using FenixLib.Core;
using Xwt;

namespace FpgUI
{
	public class ViewFactory : IViewFactory
	{
		public ViewFactory()
		{
		}

		public IFpgEditorView CreateFpgEditorView()
		{
			var v = new FpgEditorView();
			return v;
		}

		public IAddGraphicDialog CreateAddGraphicDialog()
		{
			var v = new AddGraphicDialog();
			return v;
		}

		public INewFpgDialog CreateDialogNewFpg()
		{
			var v = new NewFpgDialog();
			return v;
		}

	}
}
	