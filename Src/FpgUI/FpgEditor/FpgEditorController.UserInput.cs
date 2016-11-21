using System;

namespace FpgUI
{
	public partial class FpgEditorController
	{
		protected virtual void View_OnNewFpgClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_OnOpenClicked(object sender, EventArgs e)
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

		protected virtual void View_OnSaveClicked(object sender, EventArgs e)
		{
			if (IsNewFile)
			{
				View_OnSaveAsClicked(sender, e);
			}
			else
			{
				Save(editor.FileName);
			}
		}

		protected virtual void View_OnSaveAsClicked(object sender, EventArgs e)
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

		protected virtual void View_OnDuplicateFpgClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_OnCloseClicked(object sender, EventArgs e)
		{
			View.Fpg = null;
			editor.Fpg = null;
			editor.FileName = "";
			UpdateEnabledControls();
		}

		protected virtual void View_OnCopyClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_OnCutClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_OnPasteClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_OnAddGraphicClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_OnRemoveGraphicClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnRenameGraphicClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_OnViewEditGraphicClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_OnExtractToPngClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_OnExtractToMapClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_OnViewEditPaletteClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_OnExtractToPalClicked(object sender, EventArgs e)
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

		protected virtual void View_OnNewWindowClicked(object sender, EventArgs e)
		{
			var view = context.ViewFactory.CreateFpgEditorView();
			var controller = new FpgEditorController(view, context);
			controller.ShowView();
		}
	}
}

