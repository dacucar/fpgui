using System;
using FenixLib.Core;

namespace FpgUI.FpgEditor.NewFpg
{
	public interface INewFpgDialog: IView
	{
		event EventHandler<bool> DialogAction;

		GraphicFormat GraphicFormat { get; }
		Palette Palette { get; }
	}

}

