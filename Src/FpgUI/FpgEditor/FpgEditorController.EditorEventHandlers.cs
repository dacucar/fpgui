using System;
using FenixLib.Core;

namespace FpgUI
{
	public partial class FpgEditorController
	{
		protected virtual void Editor_FpgChanged(object sender, ISpriteAssortment fpg)
		{
			View.Fpg = fpg;
		}

		protected virtual void Editor_FileNameChanged(object sender, string fileName)
		{
			// TODO: Update the title
			// TODO: Update the status Bar
		}
	}
}

