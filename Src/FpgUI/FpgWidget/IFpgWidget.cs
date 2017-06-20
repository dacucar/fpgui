using System;
using System.Collections.Generic;
using FenixLib.Core;

namespace FpgUI.FpgWidget
{
	public interface IFpgWidget
	{
		event EventHandler SelectionChanged;

		IReadOnlyCollection<SpriteAssortmentSprite> SelectedSprites { get; }

		ISpriteAssortment Fpg { get; set; }
	}
}

