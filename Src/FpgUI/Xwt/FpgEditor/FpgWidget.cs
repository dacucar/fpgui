using Xwt;
using Xwt.Drawing;
using FenixLib.Core;

namespace FpgUI.Xwt
{
    public class FpgWidget : ListView
    {
		DataField<string> name = new DataField<string> ();
		DataField<Image> icon = new DataField<Image> ();
		DataField<string> size = new DataField<string> ();
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
				}
				DataSource = store;
			}
		}

        public FpgWidget()
        {
			store = new ListStore(name, size);
			Columns.Add("Description", name);
			Columns.Add("Size", size);
			Columns.Add("Center", center);
			DataSource = store;
            //Content = new Label("Replace the label by custom content");
        }
    }
}

