using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filebeolvasas
{
	internal class Karakter
	{
		private string nev;
		private int szint;
		private int eletero;
		private int ero;

		public Karakter(string nev, int szint, int eletero, int ero)
		{
			this.nev = nev;
			this.szint = szint;
			this.eletero = eletero;
			this.ero = ero;
		}

		public string Nev
		{ 
			get
			{
				return this.nev;
			} 
			set => nev = value; }
		public int Szint { get => szint; set => szint = value; }
		public int Eletero { get => eletero; set => eletero = value; }
		public int Ero { get => ero; set => ero = value; }

		public int Kombinacio
		{
			get
			{
				return this.eletero + this.ero;
			}
		}

        public int EroSzint
        {
            get
            {
                return this.szint + this.ero;
            }
        }

        public override string? ToString()
		{
			return $"neve: {nev}, szintje: {szint}, életereje: {eletero}, ereje: {ero}";
		}


	}
}
