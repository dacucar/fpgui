using System;
using FenixLib.Core;

namespace FpgUI.Core
{
	public class FpgEditorController : ViewController<IFpgEditorView>
	{
		private FpgEditor model;

		public FpgEditorController(IFpgEditorView view, ApplicationContext context)
			: base(view, context)
		{
			this.model = new FpgEditor();

			// Subscribe to model state change events
			model.FpgChanged += OnFpgChanged;

			// Suscribe to model user events
			View.NewFpgClicked += OnNewFpgClicked;
			View.OpenClicked += OnNewFpgClicked;
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

		protected bool IsNewFile => model.FileName == null;

		protected string Title => model.FileName == null 
			? "untitled.fpg" 
			: model.FileName ;

		#region data sync events

		protected virtual void OnFpgChanged(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region user input events

		protected virtual void OnNewFpgClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnOpenClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnSaveClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnSaveAsClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
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
	}
}

