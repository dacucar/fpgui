using System;

namespace FpgUI
{
	public partial class FpgEditorController
	{
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
			View.Fpg = null;
			editor.Fpg = null;
			editor.FileName = "";
			UpdateEnabledControls();
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
			string filename = View.LetUserSelectPaletteToExtract("untitled.pal");
			if (filename != null)
			{
				try
				{
					ExtractPalette(filename);
				}
				catch
				{
					// TODO
				}
			}
		}

		protected virtual void OnNewWindowClicked(object sender, EventArgs e)
		{
			var view = context.ViewFactory.CreateFpgEditorView();
			var controller = new FpgEditorController(view, context);
			controller.ShowView();
		}
	}
}

