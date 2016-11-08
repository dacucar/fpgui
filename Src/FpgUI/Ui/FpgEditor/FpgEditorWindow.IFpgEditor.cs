using System;
using System.Collections.Generic;
using FenixLib.Core;
using FpgUI.Core;
using FpgUI.Core.FpgEditor;

namespace FpgUI.Ui
{
	public partial class FpgEditorWindow
    {
		/*
		public event EventHandler FpgChanged;

		public object WindowBackend => this;

		public ISpriteAssortment Fpg
		{ 
			get
			{
				return fpgWidget.Fpg;
			}
			set
			{
				fpgWidget.Fpg = value;
				depthLabel.Text = $"{Fpg.GraphicFormat.BitsPerPixel}bpp";

				if (FpgChanged != null)
				{
					FpgChanged(this, EventArgs.Empty);
				}
			}
		}

		public IFpgEditorActionsHandler ActionsHandler { get; }
			= new ActionsHandler ();

		private string filename;
		public string FileName
		{ 
			get
			{
				return filename;
			}
			set
			{
				filename = value;
				statusLabel.Text = filename;
			}
		}

		public IEnumerable<int> SelectedGraphicsIds
		{
			get
			{
				return fpgWidget.SelectedIds;
			}
		}

		public void NotifyFpgChange()
		{
			FpgChanged(this, EventArgs.Empty);
		}

		public bool IsNewFile => ((IFpgEditor)this).FileName == null;

		public ApplicationContext Context => this.context;*/
    }
}

