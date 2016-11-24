using System;
using FenixLib.Core;

namespace FpgUI
{
	public partial class FpgEditorController
	{
		protected virtual void View_Closing(object sender, ClosingEventArgs e)
		{
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
		}

		protected virtual void View_NewFpgClicked(object sender, EventArgs e)
		{
			var v = context.ViewFactory.CreateDialogNewFpg();
			var c = new NewFpgDialogController(v, context);
			c.ShowView(View);
			c.OkAction = (f, p) =>
				{
					New(f, p);
				};
		}

		protected virtual void View_OpenClicked(object sender, EventArgs e)
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

		protected virtual void View_SaveClicked(object sender, EventArgs e)
		{
			if (IsNewFile)
			{
				View_SaveAsClicked(sender, e);
			}
			else
			{
				Save(editor.FileName);
			}
		}

		protected virtual void View_SaveAsClicked(object sender, EventArgs e)
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

		protected virtual void View_DuplicateFpgClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_CloseClicked(object sender, EventArgs e)
		{
			View.Fpg = null;
			editor.Fpg = null;
			editor.FileName = "";
			UpdateEnabledControls();
		}

		protected virtual void View_CopyClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_CutClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_PasteClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_AddGraphicClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_RemoveGraphicClicked(object sender, EventArgs e)
		{
			foreach (var s in View.FpgWidget.SelectedSprites)
			{
				editor.Fpg.Remove(s.Id);
			}
			// TODO: Temporal hack to force an update of the FpgEditorView
			View.FpgWidget.Fpg = View.FpgWidget.Fpg;
		}

		protected virtual void View_RenameGraphicClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_ViewEditGraphicClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_ExtractToPngClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_ExtractToMapClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_ViewEditPaletteClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void View_ExtractToPalClicked(object sender, EventArgs e)
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

		protected virtual void View_NewWindowClicked(object sender, EventArgs e)
		{
			var view = context.ViewFactory.CreateFpgEditorView();
			var controller = new FpgEditorController(view, context);
			controller.ShowView();
		}
	}
}

