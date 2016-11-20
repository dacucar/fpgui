using System;

namespace FpgUI
{
	public partial class FpgEditorController
	{
		protected virtual void OnFpgChanged(object sender, EventArgs e)
		{
			View.Fpg = editor.Fpg;
		}
	}
}

