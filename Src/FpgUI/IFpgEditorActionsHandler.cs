using System;

namespace FpgUI
{
	public interface IFpgEditorActionsHandler
	{
		IFileActionsHandler FpgActionsHandler { get; } 
		IGraphicActionsHandler GraphicActionsHandler { get; }
		ISystemActionsHandler SystemActionsHandler { get; }
		IEditActionsHandler EditActionsHandler { get; }
		IPaletteActionsHandler PaletteActionsHandler {get; }
	}
}

