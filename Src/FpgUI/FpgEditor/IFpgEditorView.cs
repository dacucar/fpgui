using System;
using System.Collections.Generic;
using FenixLib.Core;

namespace FpgUI.FpgEditor
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

		string LetUserSelectFileToOpen();
		string LetUserSelectFileToSave(string initialFileName);

		ISpriteAssortment Fpg { set; }

		void DisableCommand(UiCommand command);
		void EnableCommand(UiCommand command);

		//ApplicationContext Context { get; }
	}
}

