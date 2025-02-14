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

	}
}
