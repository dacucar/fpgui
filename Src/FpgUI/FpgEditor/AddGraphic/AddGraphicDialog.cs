using System;
using FenixLib.Core;
using Xwt;

namespace FpgUI.FpgEditor.AddGraphic
{
	public class AddGraphicDialog : Dialog, IAddGraphicDialog
	{
		public event EventHandler<ISprite> OkActivated;

		public AddGraphicDialog()
		{
			var vbox1 = new VBox();
			vbox1.PackStart(new Label("Original:"));
			vbox1.PackStart(new ImageView());

			var vbox2 = new VBox();
			vbox1.PackStart(new Label("To be replaced"));
			vbox1.PackStart(new ImageView());

			var hbox1 = new HBox();
			hbox1.PackStart(vbox1);
			hbox1.PackStart(new ImageView());
			hbox1.PackStart(vbox2);

			var hbox2 = new HBox();
			hbox2.PackStart(new Label("Code:"));
			hbox2.PackStart(new Button("FP"));
			hbox2.PackStart(new Button("P"));
			hbox2.PackStart(new Button("N"));
			hbox2.PackStart(new Button("NF"));

			var hbox3 = new HBox();
			hbox3.PackStart(new Label("Description"));
			hbox3.PackStart(new TextEntry());
			hbox3.PackStart(new Button("Magic"));

			var cpframe = new Frame();
			var vboxcp = new VBox();
			vboxcp.PackStart(new RadioButton("Use original graphic control points"));
			vboxcp.PackStart(new RadioButton("Keep replaced control points"));
			vboxcp.PackStart(new RadioButton("Load control points from file..."));
			cpframe.Content = vboxcp;

			var vboxLeft = new VBox();
			vboxLeft.PackStart(hbox1);
			vboxLeft.PackStart(hbox2);
			vboxLeft.PackStart(hbox3);
			vboxLeft.PackStart(cpframe);

			Buttons.Add(new DialogButton(Command.Ok));
			Buttons.Add(new DialogButton(Command.Cancel));

			Content = vboxLeft;
		}

		protected override void OnCommandActivated(Command cmd)
		{
			if (cmd == Command.Ok)
			{
				OnOkActivated(null); // TODO: Feed the sprite...
			}

			base.OnCommandActivated(cmd);
		}

		protected virtual void OnOkActivated(ISprite sprite)
		{
			OkActivated?.Invoke(this, sprite);
		}
	}
}

