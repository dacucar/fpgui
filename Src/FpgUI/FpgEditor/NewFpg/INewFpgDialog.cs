using System;
using Xwt;
using FenixLib.Core;

namespace FpgUI
{
	public interface INewFpgDialog: IView
	{
		event EventHandler<bool> DialogAction;

		GraphicFormat GraphicFormat { get; }
		Palette Palette { get; }
	}

}

