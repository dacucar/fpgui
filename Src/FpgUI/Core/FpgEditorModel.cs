using System;
using FenixLib.Core;

namespace FpgUI
{
	public class FpgEditorModel
	{
		#region state change events
		public event EventHandler FpgChanged;
		#endregion

		public FpgEditorModel()
		{
		}

		private ISpriteAssortment fpg;
		public ISpriteAssortment Fpg
		{ 
			get
			{
				return fpg;
			}
			set
			{
				fpg = value;
				FpgChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public string FileName { get; set; }

		bool IsNewFile => FileName == null;

		string Title => ( FileName == null ? "untitled.fpg" : FileName );
	}
}

