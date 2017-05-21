using System;
using System.Collections.Generic;

namespace InConsoleExperiments.Common
{
	public class DummyModel
	{
		public string Value { get; set; }
		public List<DummyModel> Childrens { get; set; }

		public bool HasChildrens
		{
			get
			{
				return !(Childrens == null || Childrens.Count == 0);
			}
		}

		public DummyModel()
		{
		}

		public static List<DummyModel> Populate(int size, int parents, int deep)
		{
			var l = new List<DummyModel>();

			for (int i = 0; i < size; i++)
			{
				l.Add(new DummyModel
				{
					Value = string.Format("{0}-{1}", deep, i)
				});
			}

			if (deep <= 0)
				return l;

			for (int i = 0; i < (parents > size ? size : parents); i++)
			{
				l[i].Childrens = Populate(size, parents, deep - 1);
			}

			return l;
		}
	}
}
