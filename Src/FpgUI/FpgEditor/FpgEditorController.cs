using System;
using System.IO;
using FenixLib.Core;
using FenixLib.IO;

namespace FpgUI
{
	public partial class FpgEditorController : ViewController<IFpgEditorView>
	{
		private FpgEditor editor;
		private FpgUIContext context;

		public FpgEditorController(IFpgEditorView view, FpgUIContext context)
			: base(view, context)
		{
			this.editor = new FpgEditor();
			this.context = context;

			// Subscribe to model state change events
			editor.FpgChanged += Editor_FpgChanged;

			View.Closing += (sender, e) => {
				if (editor.Fpg != null && HasChanged)
				{
					string m = "There are unsaved changes in the Fpg. "
						+ "Save before closing?";
					var response = View.AskUserIfChangesShouldBeSaved(m);
					if (response == YesNoCancel.Yes)
					{
						View_SaveClicked(this, e);
					}
					else if (response == YesNoCancel.Cancel)
					{
						e.Cancel = true;
					}	
				}
			};

			View.NewFpgClicked += View_NewFpgClicked;
			View.OpenClicked += View_OpenClicked;
			View.SaveClicked += View_OpenClicked;
			View.SaveAsClicked += View_SaveAsClicked;
			View.DuplicateFpgClicked += View_DuplicateFpgClicked;
			View.CloseClicked += View_CloseClicked;

			View.CopyClicked += View_CopyClicked;
			View.CutClicked += View_CutClicked;
			View.PasteClicked += View_PasteClicked;

			View.AddGraphicClicked += View_AddGraphicClicked;
			View.RemoveGraphicClicked += View_RemoveGraphicClicked;
			View.RenameGraphicClicked += View_RenameGraphicClicked;
			View.ViewEditGraphicClicked += View_ViewEditGraphicClicked;
			View.ExtractToPngClicked += View_ExtractToPngClicked;
			View.ExtractToMapClicked += View_ExtractToMapClicked;

			View.ViewEditPaletteClicked += View_ViewEditPaletteClicked;
			View.ExtractToPalClicked += View_ExtractToPalClicked;

			View.NewWindowClicked += View_NewWindowClicked;

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

