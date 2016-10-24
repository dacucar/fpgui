using System;
using Xwt;

namespace FpgUI
{
	sealed class XwtFpgEditorActionsHandler : IFpgEditorActionsHandler
	{
		public IFileActionsHandler FpgActionsHandler { get; } 
			= new XwtFileActionsHandler();
		public IGraphicActionsHandler GraphicActionsHandler { get; } 
			= null;
		public IPaletteActionsHandler PaletteActionsHandler { get; } 
			= null;
		public IEditActionsHandler EditActionsHandler { get; } 
			= null;
		public ISystemActionsHandler SystemActionsHandler { get; } 
			= null;
	}
}

