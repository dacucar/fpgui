using System;
using FenixLib.Core;

namespace FpgUI.FpgEditor
{
	public class FpgEditor
	{
		public event EventHandler<ISpriteAssortment> FpgChanged;
		public event EventHandler<string> FileNameChanged;

		private ISpriteAssortment fpg;
		private string fileName;

		public FpgEditor()
		{
		}
			
		public ISpriteAssortment Fpg
		{ 
			get
			{
				return fpg;
			}
			set
			{
				fpg = value;
				OnFpgChanged(fpg);
			}
		}

		public string FileName 
		{ 
			get
			{
				return fileName;
			}
			set
			{
				fileName = value;
				OnFileNameChanged(fileName);
			}
		}

		protected virtual void OnFpgChanged(ISpriteAssortment fpg)
		{
			FpgChanged?.Invoke(this, fpg);
		}

		protected virtual void OnFileNameChanged(string fileName)
		{
			FileNameChanged?.Invoke(this, fileName);
		}
	}
}

