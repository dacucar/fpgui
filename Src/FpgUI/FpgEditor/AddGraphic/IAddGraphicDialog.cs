using System;
using FenixLib.Core;

namespace FpgUI.FpgEditor.AddGraphic
{
	public interface IAddGraphicDialog
	{
		event EventHandler<ISprite> OkActivated;
	}
}

