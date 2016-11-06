using System;
using Xwt;

namespace FpgUI.Ui
{
	public class NewFpgDialog : Dialog
	{
		public NewFpgDialog()
		{
			var bpp1Radio = new RadioButton("1bpp");
			var bpp8Radio = new RadioButton("8bpp");
			var bpp16Radio = new RadioButton("16bpp");
			var bpp32Radio = new RadioButton("32bpp");

			HBox depthOptions = new HBox();
			depthOptions.HorizontalPlacement = WidgetPlacement.Center;
			depthOptions.PackStart(bpp1Radio);
			depthOptions.PackStart(bpp8Radio);
			depthOptions.PackStart(bpp16Radio);
			depthOptions.PackStart(bpp32Radio);

			VBox mainContainer = new VBox();
			mainContainer.PackStart(new Label("Depth:"));
			mainContainer.PackStart(depthOptions);
			mainContainer.PackStart(new Label("Palette:"));
			mainContainer.PackStart(new Frame(new Label("No Palette")), true);

			Content = mainContainer;
		}
	}
}

