using Xwt;
using Xwt.Drawing;
using FenixLib.Core;

namespace FpgUI.Ui
{
	public class FpgWidget : ListView
	{
		DataField<string> name = new DataField<string>();
		DataField<string> size = new DataField<string>();
		DataField<string> center = new DataField<string>();
		ListStore store;

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
				store.Clear();
				foreach (var s in fpg)
				{
					var r = store.AddRow();
					store.SetValue(r, name, s.Description);
					store.SetValue(r, size, $"{s.Width}x{s.Height}");
					store.SetValue(r, center, $"{s.Center.X}x{s.Center.Y}");
				}
			}
		}

		public FpgWidget()
		{
			store = new ListStore(name, size, center);
			Columns.Add("Description", name);
			Columns.Add("Size", size);
			Columns.Add("Center", center);
			DataSource = store;
		}
	}
}

