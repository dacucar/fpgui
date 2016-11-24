using System;
using FenixLib.Core;

namespace FpgUI
{
	public interface IAddGraphicDialog
	{
		event EventHandler<ISprite> OkActivated;
	}
}

