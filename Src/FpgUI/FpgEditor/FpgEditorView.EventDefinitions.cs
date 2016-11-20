using System;

namespace FpgUI
{
	public partial class FpgEditorView
	{
		public event EventHandler<ClosingEventArgs> Closing;

		public event EventHandler NewFpgClicked;
		public event EventHandler OpenClicked;
		public event EventHandler SaveClicked;
		public event EventHandler SaveAsClicked;
		public event EventHandler DuplicateFpgClicked;
		public event EventHandler CloseClicked;

		public event EventHandler CopyClicked;
		public event EventHandler CutClicked;
		public event EventHandler PasteClicked;

		public event EventHandler AddGraphicClicked;
		public event EventHandler RemoveGraphicClicked;
		public event EventHandler RenameGraphicClicked;
		public event EventHandler ViewEditGraphicClicked;
		public event EventHandler ExtractToPngClicked;
		public event EventHandler ExtractToMapClicked;

		public event EventHandler ViewEditPaletteClicked;
		public event EventHandler ExtractToPalClicked;

		public event EventHandler NewWindowClicked;
	}
}

