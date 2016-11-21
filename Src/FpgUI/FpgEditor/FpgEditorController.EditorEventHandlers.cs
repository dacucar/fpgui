using System;

namespace FpgUI
{
	public partial class FpgEditorController
	{
		protected virtual void Editor_FpgChanged(object sender, EventArgs e)
		{
			View.Fpg = editor.Fpg;
		}
	}
}

