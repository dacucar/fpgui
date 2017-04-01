namespace FpgUI.Xwt
{
	public class ViewFactory : IViewFactory
	{
		public ViewFactory()
		{
		}

		public IFpgEditorView FpgEditorView()
		{
			var v = new FpgEditorView();
			return v;
		}

		public IAddGraphicDialog AddGraphicDialog()
		{
			var v = new AddGraphicDialog();
			return v;
		}

		public INewFpgDialog NewFpgDialog()
		{
			var v = new NewFpgDialog();
			return v;
		}

	}
}
	