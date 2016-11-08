using System;
using FenixLib.Core;

namespace FpgUI.Core
{
	public class FpgEditorPresenter : PresenterBase<IFpgEditorView>
	{
		public FpgEditorPresenter(SpriteAssortment fpg, IFpgEditorView view)
			: base(view)
		{
			View.FpgChanged += OnFpgChanged;

			View.NewFpgClicked += OnNewFpgClicked;
			View.SaveClicked += OnOpenClicked;
			View.SaveAsClicked += OnSaveAsClicked;
			View.DuplicateFpgClicked += OnDuplicateFpgClicked;

			View.Model.Fpg = fpg;
		}

		public FpgEditorPresenter(string filename, IFpgEditorView view)
			: base(view)
		{
			
		}

		public void OnFpgChanged(object sender, EventArgs args)
		{
			
		}

		public void OnNewFpgClicked(object sender, EventArgs args)
		{
			
		}

		public void OnOpenClicked(object sender, EventArgs args)
		{
			
		}

		public void OnSaveClicked(object sender, EventArgs args)
		{
			
		}

		public void OnSaveAsClicked(object sender, EventArgs args)
		{
			
		}

		public void OnDuplicateFpgClicked(object sender, EventArgs args)
		{
			
		}
	}
}

