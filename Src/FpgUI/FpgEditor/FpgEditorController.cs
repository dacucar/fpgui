using System;
using System.IO;
using FenixLib.Core;
using FenixLib.IO;

namespace FpgUI
{
	public partial class FpgEditorController : ViewController<IFpgEditorView>
	{
		private Model editor;
		private FpgUIContext context;

		public FpgEditorController(IFpgEditorView view, FpgUIContext context)
			: base(view, context)
		{
			this.editor = new Model();
			this.context = context;

			// Subscribe to model state change events
			editor.FpgChanged += OnFpgChanged;

			// Suscribe to window input events
			View.Closing += (sender, e) => {
				e.Cancel = true;
			};

			View.NewFpgClicked += OnNewFpgClicked;
			View.OpenClicked += OnOpenClicked;
			View.SaveClicked += OnOpenClicked;
			View.SaveAsClicked += OnSaveAsClicked;
			View.DuplicateFpgClicked += OnDuplicateFpgClicked;
			View.CloseClicked += OnCloseClicked;

			View.CopyClicked += OnCopyClicked;
			View.CutClicked += OnCutClicked;
			View.PasteClicked += OnPasteClicked;

			View.AddGraphicClicked += OnAddGraphicClicked;
			View.RemoveGraphicClicked += OnRemoveGraphicClicked;
			View.RenameGraphicClicked += OnRenameGraphicClicked;
			View.ViewEditGraphicClicked += OnViewEditGraphicClicked;
			View.ExtractToPngClicked += OnExtractToPngClicked;
			View.ExtractToMapClicked += OnExtractToMapClicked;

			View.ViewEditPaletteClicked += OnViewEditPaletteClicked;
			View.ExtractToPalClicked += OnExtractToPalClicked;

			View.NewWindowClicked += OnNewWindowClicked;

		}

		public override void ShowView()
		{
			base.ShowView();
			UpdateEnabledControls();
		}

		protected bool IsNewFile => editor.FileName == null;

		protected string Title => editor.FileName == null 
			? "untitled.fpg" 
			: editor.FileName;

		public bool HasChanged { get; protected set; }

		protected virtual void UpdateEnabledControls()
		{
			bool fpgIsNull = editor.Fpg != null;
			bool canPaste = false;
			bool fpgIs8bpp = fpgIsNull
			                 && editor.Fpg.GraphicFormat == GraphicFormat.Format8bppIndexed;
			bool somethingSelected = View.FpgWidget.SelectedSprites.Count > 0;
			bool multipleSelection = View.FpgWidget.SelectedSprites.Count > 1;

			View.SetControlEnabled(UiControl.SaveFpg, fpgIsNull);
			View.SetControlEnabled(UiControl.SaveAsFpg, fpgIsNull);
			View.SetControlEnabled(UiControl.DuplicateFpg, fpgIsNull);
			View.SetControlEnabled(UiControl.AddGraphic, fpgIsNull);
			View.SetControlEnabled(UiControl.Close, fpgIsNull);

			View.SetControlEnabled(UiControl.Paste, fpgIsNull && canPaste);

			// Todo: Contextual menus

			View.SetControlEnabled(UiControl.PaletteControls, fpgIs8bpp);

			View.SetControlEnabled(UiControl.Cut, somethingSelected);
			View.SetControlEnabled(UiControl.Copy, somethingSelected);
			View.SetControlEnabled(UiControl.ViewEditGraphic, somethingSelected);
			View.SetControlEnabled(UiControl.ExportGraphic, somethingSelected);
			View.SetControlEnabled(UiControl.Delete, somethingSelected);
		}
			
		#region Data mapping

		public void Load(string filename,  IDecoder<ISpriteAssortment> decoder)
		{
			using (var stream = File.Open(
				filename, 
				FileMode.Open, 
				FileAccess.Read, 
				FileShare.None))
			{
				var fpg = decoder.Decode(stream);
				editor.FileName = filename;
				editor.Fpg = fpg;
			}
			HasChanged = false;
		}

		public void Load(string filename)
		{
			Load(filename, new FpgSpriteAssortmentDecoder());
			UpdateEnabledControls();
		}

		public void Save(string filename, IEncoder<ISpriteAssortment> encoder)
		{
			using (var stream = File.Open(
				filename, 
				FileMode.Create, 
				FileAccess.Write,
				FileShare.None))
			{
				encoder.Encode(editor.Fpg, stream);
				editor.FileName = filename;
			}
			HasChanged = false;
		}

		public void Save(string filename)
		{
			Save(filename, new FpgSpriteAssortmentEncoder());
		}

		public void ExtractPalette(string filename, IEncoder<Palette> encoder)
		{
			using (var stream = File.Open(
				                    filename,
				                    FileMode.Create,
				                    FileAccess.Write,
				                    FileShare.None))
			{
				encoder.Encode(editor.Fpg.Palette, stream);
			}
		}

		public void ExtractPalette(string filename)
		{
			ExtractPalette(filename, new PalPaletteEncoder());
		}

		#endregion
	}
}

