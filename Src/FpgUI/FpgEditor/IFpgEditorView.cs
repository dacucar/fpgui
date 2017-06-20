using System;
using FenixLib.Core;
using FpgUI.FpgWidget;

namespace FpgUI.FpgEditor
{
	public interface IFpgEditorView : IView
	{
		IFpgWidget FpgWidget { get; }

		#region view events
		event EventHandler<ClosingEventArgs> Closing;
		#endregion

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

		// TODO: This urges some refractoring...
		string LetUserSelectFileToOpen();
		string LetUserSelectFileToSave(string initialFileName);
		string LetUserSelectPaletteToExtract(string initialFilename);
		string LetUserSelectWhereToExtractGraphic(string initialFileName);
		YesNoCancel AskUserIfChangesShouldBeSaved(string message);

		ISpriteAssortment Fpg { set; }

		void SetControlEnabled(UiControl control, bool value);

		//ApplicationContext Context { get; }
	}
}

