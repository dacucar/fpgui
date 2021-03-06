﻿using System;
using Xwt;
using FenixLib.Core;

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
			bpp1Radio.Group = bpp8Radio.Group = bpp16Radio.Group = 
				bpp32Radio.Group;
			bpp1Radio.Clicked += (sender, e) => GraphicFormat = GraphicFormat.Format1bppMonochrome;
			bpp8Radio.Clicked += (sender, e) => GraphicFormat = GraphicFormat.Format8bppIndexed;
			bpp16Radio.Clicked += (sender, e) => GraphicFormat = GraphicFormat.Format16bppRgb565;
			bpp32Radio.Clicked += (sender, e) => GraphicFormat = GraphicFormat.Format32bppArgb;

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

			Buttons.Add (new DialogButton (Command.Ok));
			Buttons.Add (new DialogButton (Command.Cancel));

			Content = mainContainer;
		}

		public GraphicFormat GraphicFormat
		{
			get;
			private set;
		}

		public Palette Palette
		{
			get;
			private set;
		}
	}
}

