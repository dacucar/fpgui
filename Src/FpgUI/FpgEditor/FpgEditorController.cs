using System;
using System.IO;
using FenixLib.Core;
using FenixLib.IO;

namespace FpgUI.FpgEditor
{
	public class FpgEditorController : ViewController<IFpgEditorView>
	{
		private Model editor;

		public FpgEditorController(IFpgEditorView view, ApplicationContext context)
			: base(view, context)
		{
			this.editor = new Model();

			// Subscribe to model state change events
			editor.FpgChanged += OnFpgChanged;

			// Suscribe to model user events
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

		protected bool IsNewFile => editor.FileName == null;

		protected string Title => editor.FileName == null 
			? "untitled.fpg" 
			: editor.FileName ;

		#region model sync events

		protected virtual void OnFpgChanged(object sender, EventArgs e)
		{
			View.Fpg = editor.Fpg;
		}

		#endregion

		#region user input events

		protected virtual void OnNewFpgClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnOpenClicked(object sender, EventArgs e)
		{
			var filename = View.LetUserSelectFileToOpen();
			if (filename != null)
			{
				try
				{
					Load(filename);
				}
				catch
				{
					// TODO: Show Error
				}
			}
		}

		protected virtual void OnSaveClicked(object sender, EventArgs e)
		{
			if (IsNewFile)
			{
				OnSaveAsClicked(sender, e);
			}
			else
			{
				Save(editor.FileName);
			}
		}

		protected virtual void OnSaveAsClicked(object sender, EventArgs e)
		{
			var filename = View.LetUserSelectFileToSave("untitled.fpg");
			if (filename != null)
			{
				try
				{
					Save(filename);
				}
				catch
				{
					// TODO: Show Error
				}
			}
		}

		protected virtual void OnDuplicateFpgClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnCloseClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
			
		protected virtual void OnCopyClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnCutClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnPasteClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnAddGraphicClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnRemoveGraphicClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnRenameGraphicClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnViewEditGraphicClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnExtractToPngClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnExtractToMapClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnViewEditPaletteClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnExtractToPalClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnNewWindowClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Data mapping

		// TODO: Encapsulate in helper service?

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
		}

		public void Load(string filename)
		{
			Load(filename, new FpgSpriteAssortmentDecoder());
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
		}

		public void Save(string filename)
		{
			Save(filename, new FpgSpriteAssortmentEncoder());
		}

		#endregion


	}
}

