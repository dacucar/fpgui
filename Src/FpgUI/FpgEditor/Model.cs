using System;
using FenixLib.Core;
using FenixLib.IO;
using System.IO;

namespace FpgUI.FpgEditor
{
	public class Model
	{
		#region state change events
		public event EventHandler FpgChanged;
		#endregion

		public Model()
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

