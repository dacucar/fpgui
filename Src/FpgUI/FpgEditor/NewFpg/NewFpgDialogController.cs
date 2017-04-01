using System;
using FenixLib.Core;

namespace FpgUI
{
	public class NewFpgDialogController : ViewController<INewFpgDialog>
	{
		public Action<GraphicFormat, Palette> OkAction { get; set; }

		public NewFpgDialogController(INewFpgDialog v, FpgUiContext c) : base(v, c)
		{
			v.DialogAction += (sender, e) => {
				if (e == true)
				{
					OkAction?.Invoke(v.GraphicFormat, v.Palette);
				}
			};
		}
	}
}

