using System;
using FenixLib.Core;

namespace FpgUI.Core
{
	public class FpgEditor
	{
		#region state change events
		public event EventHandler FpgChanged;
		#endregion

		public FpgEditor()
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
	}
}

