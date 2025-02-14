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










	}
}
