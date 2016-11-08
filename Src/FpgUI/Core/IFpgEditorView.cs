using System;
using System.Collections.Generic;
using FenixLib.Core;

namespace FpgUI.Core
{
	public interface IFpgEditorView : IView
	{
		#region user events
		event EventHandler NewFpgClicked;
		event EventHandler OpenClicked;
		event EventHandler SaveClicked;
		event EventHandler SaveAsClicked;
		event EventHandler DuplicateFpgClicked;
		event EventHandler CloseClicked;

		event EventHandler CopyClicked;
		event EventHandler CutClicked;
		event EventHandler PasteClicked;

		event EventHandler AddGraphicClicked;
		event EventHandler RemoveGraphicClicked;
		event EventHandler RenameGraphicClicked;
		event EventHandler ViewEditGraphicClicked;
		event EventHandler ExtractToPngClicked;
		event EventHandler ExtractToMapClicked;

		event EventHandler ViewEditPaletteClicked;
		event EventHandler ExtractToPalClicked;

		event EventHandler NewWindowClicked;
		#endregion

		FpgEditorModel Model { get; }

		//void UpdateEnabled(CommandFlags flags);

		//ApplicationContext Context { get; }
	}
}

