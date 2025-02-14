namespace filebeolvasas
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//úgy kiell file-t tenni, hogy megnyitjuk a mappát amiben a project van, és ott bin/debug/net8.0
			List<Karakter> karakterek = [];
			Beolvasas("karakterek.txt", karakterek);
			foreach (var item in karakterek)
			{
                //Console.WriteLine(item.ToString());
				Console.WriteLine(item);

			}
            Console.WriteLine();
            Legnagyobb(karakterek);
            Console.WriteLine();
			Atlagszint(karakterek);
            Console.WriteLine();
			Rendezes(karakterek);
            Console.WriteLine();
			KarakterErossegSzintFelett(karakterek);
            Console.WriteLine();
			KarakterStats(karakterek, 7);
            Console.WriteLine();
			LegjobbHarom(karakterek.ToList());
            Console.WriteLine();
			Rangsorolas(karakterek);
            Console.WriteLine();
			//Kombinacio(karakterek.ToList());






		}

		static void Beolvasas(string filenev, List<Karakter> karakterek)
		{

			StreamReader sr = new StreamReader(filenev); //de az is elég, ha csak azt írjuk, hogy new(filenev)
														 //Console.WriteLine(sr.ReadLine()); 

			//string[] sorok = File.ReadAllLines(sr.ReadToEnd());  //kiírja az összes sort

			sr.ReadLine();

			while (!sr.EndOfStream)  //addig megy amíg el nem ér a végéig
			{
				string sor = sr.ReadLine();
				string[] szavak = sor.Split(';');

				Karakter karakter = new Karakter(szavak[0], Convert.ToInt16(szavak[1]), Convert.ToInt16(szavak[2]), Convert.ToInt16(szavak[3]));
				karakterek.Add(karakter);

			}
		}

		//2.feladat
		static void Legnagyobb(List<Karakter> karakterek) { 
			//legnagyobb karakter
			Karakter valtozo = karakterek[0];
			for (int i = 0; i < karakterek.Count; i++)
			{
				if (valtozo.Eletero < karakterek[i].Eletero)
				{
					valtozo = karakterek[i];
				}
			}
            Console.WriteLine($"ez a legnagyobb karakter: {valtozo.Nev}, {valtozo.Szint},  {valtozo.Ero} ");

        }

		//3.feladat
		static void Atlagszint(List<Karakter> karakterek)
		{
			int atlag = 0;
			for (int i = 0; i < karakterek.Count; i++)
			{
				atlag += karakterek[i].Szint;
			}
			atlag = atlag / karakterek.Count;
			Console.WriteLine($"ez az átlagszint: {atlag} ");
		}

		//4.feladat
		static void Rendezes(List<Karakter> karakterek)
		{
			//Ezt együtt csináltuk Bogdán tanárnővel
			for (int i = 0;i < karakterek.Count-1; i++)
			{
				for(int j = i+1; j < karakterek.Count; j++)
				{
					if (karakterek[i].Ero > karakterek[j].Ero)
					{
						Karakter csere = karakterek[i];
						karakterek [i] = karakterek[j];
						karakterek[j] = csere;
					}
				}
			}
            Console.WriteLine("Erősség szerinti sorrend");
            foreach (var tem in karakterek)
			{
				Console.WriteLine(tem);
            }
		}

		//5.feladat
		static void KarakterErossegSzintFelett(List<Karakter> karakterek)
		{
			Console.WriteLine("Ezeknek a karaktereknek nayobb az ereje mint 50:");
			for (int i = 0; i < karakterek.Count; i++)
			{
				if (karakterek[i].Ero > 50)
				{
					Console.WriteLine(karakterek[i]);
                }
			}
		}

		//6.feladat
		//Bogdán tanárnő mondta hogy nem kell új oszályt csinálni

		static void KarakterStats(List<Karakter> karakterek, int szint)
		{
			Console.WriteLine($"Ezeknek a karaktereknek nayobb a szintje mint {szint}:");

			for (int i = 0;i < karakterek.Count; i++)
			{
				if (karakterek[i].Szint > szint)
				{
					Console.WriteLine(karakterek[i]);
                }
			}
		}

		//7. feladat - Bogdán tanárnő azt mondta nem tanultuk ezért nem kell

		//8. feladat
		static void LegjobbHarom(List<Karakter> karakterek)
		{
			Console.WriteLine($"Ez a 3 legjobb karakter:");

			for (int i = 0; i < karakterek.Count - 1; i++)
			{
				for (int j = i + 1; j < karakterek.Count; j++)
				{
					if (karakterek[i].EroSzint > karakterek[j].Ero)
					{
						Karakter csere = karakterek[i];
						karakterek[i] = karakterek[j];
						karakterek[j] = csere;
					}
				}
			}
			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine(karakterek[i]);
            }
		}

		//9.feladat
		static void Kombinacio(List<Karakter> karakterek)
		{
		Console.WriteLine();
			foreach (var item in karakterek)
			{
				Console.WriteLine(item.Kombinacio);
			}
		}
		static void Rangsorolas(List<Karakter> karakterek)
		{
			//Ezt együtt csináltuk Bogdán tanárnővel
			for (int i = 0; i < karakterek.Count - 1; i++)
			{
				for (int j = i + 1; j < karakterek.Count; j++)
				{
					if (karakterek[i].EroSzint  < karakterek[j].EroSzint)
					{
						Karakter csere = karakterek[i];
						karakterek[i] = karakterek[j];
						karakterek[j] = csere;
					}
				}
			}
			Console.WriteLine("Rangsorolás Életerő és erősség alapján");
			foreach (var tem in karakterek)
			{
				Console.WriteLine(tem);
			}
		}


		






	}
}
