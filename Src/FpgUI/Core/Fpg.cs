using System;
using System.Collections;
using System.Collections.Generic;
using FenixLib.Core;

namespace FpgUI
{
	public class Fpg : ISpriteAssortment
	{
		private ISpriteAssortment baseAssortment;

		public Fpg(ISpriteAssortment baseAssortment)
		{
			this.baseAssortment = baseAssortment;	
		}
			
		#region ISpriteAssortment implementation

		void ISpriteAssortment.Add(int id, ISprite sprite)
		{
			baseAssortment.Add(id, sprite);
		}

		void ISpriteAssortment.Update(int id, ISprite sprite)
		{
			baseAssortment.Update(id, sprite);
		}

		int ISpriteAssortment.GetFreeId()
		{
			baseAssortment.GetFreeId();
		}

		GraphicFormat ISpriteAssortment.GraphicFormat
		{
			get
			{
				return baseAssortment.GraphicFormat;
			}
		}

		Palette ISpriteAssortment.Palette
		{
			get
			{
				return baseAssortment.Palette;
			}
		}

		SpriteAssortmentSprite ISpriteAssortment.this[int id]
		{
			get
			{
				return baseAssortment[id];
			}
		}

		System.Collections.Generic.ICollection<SpriteAssortmentSprite> ISpriteAssortment.Sprites
		{
			get
			{
				return baseAssortment.Sprites;
			}
		}

		System.Collections.Generic.IEnumerable<int> ISpriteAssortment.Ids
		{
			get
			{
				return baseAssortment.Ids;
			}
		}

		#endregion

		#region IEnumerable implementation

		IEnumerator<SpriteAssortmentSprite> IEnumerable<SpriteAssortmentSprite>.GetEnumerator()
		{
			return baseAssortment;
		}

		#endregion

		#region IEnumerable implementation

		IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return baseAssortment.GetEnumerator();
		}

		#endregion
	}
}

