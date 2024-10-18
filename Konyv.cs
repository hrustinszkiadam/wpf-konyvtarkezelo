using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace konyvtarkezelo
{
	internal class Konyv
	{
		public string cim { get; set; }
		public string mufaj { get; set; }

		public static List<Konyv> konyvek = new List<Konyv>();
		public static List<string> mufajok = new List<string>() {
			"Regény",
			"Novella",
			"Fantasy",
			"Sci-fi",
			"Történelmi regény",
			"Krimi",
			"Romantikus regény",
			"Thriller",
			"Dráma",
			"Életrajz",
			"Ismeretterjesztő",
			"Filozófiai"
		};

		public Konyv(string cim, string mufaj)
		{
			this.cim = cim;
			this.mufaj = mufaj;
		}

		public override string ToString()
		{
			return $"{this.cim} - {this.mufaj}";
		}
	}
}
