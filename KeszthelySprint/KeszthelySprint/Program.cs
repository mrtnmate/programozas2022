using System.Text;
using System.Xml.Schema;

feladat f = new feladat();
class feladat
{
    List<adatok> adatokLista = new List<adatok>();

    public feladat()
    {
        f1();
        f2();
        f3();
        f4();
        f5();
        f6();
    }
       
    void f1()
    {
        string[] sorok = File.ReadAllLines("Eredmenyek.txt",Encoding.Default);
        for (int i = 0; i < sorok.Length; i++)
        {
            adatokLista.Add(new adatok (sorok[i]));
        }


    }

    void f2()
    {
        Console.WriteLine("2.feladat: A versenyt {0} versenyző fejezte be",adatokLista.Count);
        
    }

    void f3()
    {
        int db=0;
        foreach (var item in adatokLista)
        {
            if (item.kategoria=="elit junior")
            {
                db++;
            }
        }

        Console.WriteLine("3.feladat: Versenyzők száma az \"elit junior\" kategóriában: {0} fő",db);
    }

    void f4()
    {
        double ossz=0;
        foreach (var item in adatokLista)
        {
            ossz += 2014 - item.szuldatum;
        }
        Console.WriteLine("4.feladat: Átlagéletkor: {0:0.0} év",ossz/adatokLista.Count);
    }

    void f5()
    {
        Console.Write("5.feladat: Kérek egy kategóriát: ");
        string bekert=Console.ReadLine();
        Console.Write("Rajtszám(ok): ");
        string rajtszamok="";
        for (int i = 0; i < adatokLista.Count; i++)
        {
            if (adatokLista[i].kategoria==bekert)
            {
                rajtszamok += adatokLista[i].rajtszam + " ";
            }
        }
        if (rajtszamok=="")
        {
            Console.WriteLine("Nincs ilyen kategória!");
        }
        else
        {
            Console.WriteLine(rajtszamok);
        }
    }

    void f6()
    {
        int index=0;
        for (int i = 0; i < adatokLista.Count; i++)
        {
            if (!adatokLista[i].ferfi)
            {
                if (adatokLista[index].osszIdo() > adatokLista[i].osszIdo())
                {
                    index = i;
                }
            }
        }

        Console.WriteLine("6.feladat: A legjobb időt {0} érte el", adatokLista[index].nev);


    }
}



class adatok
{
    public bool ferfi = true;
    public string nev, kategoria,idoeredmeny,uszas,depo1,kerekpar,depo2,futas;
    public int szuldatum, rajtszam;

    public adatok(string sor)
    //Ábrahám Richárd;1998;159;f;16-17;00:24:03;00:01:54;00:45:15;00:01:15;00:25:15
    {
        string[] vag = sor.Split(";");
        nev = vag[0];
        szuldatum =Convert.ToInt32(vag[1]);
        rajtszam = Convert.ToInt32(vag[2]);
        ferfi = vag[3] == "f";
        kategoria = vag[4];
        uszas = vag[5];
        depo1 = vag[6];
        kerekpar = vag[7];
        depo2 = vag[8];
        futas = vag[9];



    }

    int mp(string ido)
    {
        //"00:12:04"
        string[]vag= ido.Split(":");
        /*
         * "00"
         * "12"
         * "04"
        */

        return Convert.ToInt32(vag[0]) * 60 * 60 + Convert.ToInt32(vag[1]) * 60 + Convert.ToInt32(vag[2]);
    }

    public int osszIdo()
    {
        return mp(uszas)+ mp(depo1)+mp(kerekpar)+mp(depo2)+mp(futas);
    }
   

}