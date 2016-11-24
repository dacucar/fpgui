using System;
using System.Collections.Generic;
using FenixLib.Core;

namespace FpgUI
{
	public interface IFpgWidget
	{
		IReadOnlyCollection<SpriteAssortmentSprite> SelectedSprites { get; }

		ISpriteAssortment Fpg { get; set; }
	}
}

