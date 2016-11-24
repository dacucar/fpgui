using System;
using System.Collections.Generic;
using FenixLib.Core;

namespace FpgUI
{
	public interface IFpgWidget
	{
		event EventHandler SelectionChanged;

		IReadOnlyCollection<SpriteAssortmentSprite> SelectedSprites { get; }

		ISpriteAssortment Fpg { get; set; }
	}
}

