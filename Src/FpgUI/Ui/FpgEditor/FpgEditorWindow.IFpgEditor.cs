using System;
using System.Collections.Generic;
using FenixLib.Core;
using FpgUI.Core.FpgEditor;

namespace FpgUI.Ui
{
	public partial class FpgEditorWindow
    {
		public event EventHandler FpgChanged;

		public object WindowBackend => this.BackendHost.Backend.Window;

		public ISpriteAssortment Fpg
		{ 
			get
			{
				return fpgWidget.Fpg;
			}
			set
			{
				fpgWidget.Fpg = value;
				FpgChanged(this, EventArgs.Empty);
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
				depthLabel.Text = $"{Fpg.GraphicFormat.BitsPerPixel}bpp";
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
    }
}

