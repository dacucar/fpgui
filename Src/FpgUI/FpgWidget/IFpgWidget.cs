using System;
using System.Collections.Generic;
using FenixLib.Core;

namespace FpgUI
{
	public interface IFpgWidget
	{
		IReadOnlyCollection<ISprite> SelectedSprites { get; }

		ISpriteAssortment Fpg { get; set; }
	}
}

