using System;
using System.Collections.Generic;
using FenixLib.Core;

namespace FpgUI.Widgets
{
    public interface IFpgWidget
    {
		IEnumerable<ISprite> SelectedSprites { get; }
		ISpriteAssortment Fpg { get; set; }
    }
}

