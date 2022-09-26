using System.Security.Cryptography.X509Certificates;
using System.Text;

feladat f = new feladat();
class feladat
{
    List<adatok> arvaltozas = new List<adatok>();
    public feladat()
    {
        f2();
        f3();
        f4();
        f5();
    }
    void f5()
    {

    }
    void f4()
    {
        int mink = arvaltozas[0].kulonbseg();
        for (int i = 0; i < arvaltozas.Count; i++)
        {
            if (arvaltozas[i].kulonbseg()<mink)
            {
                mink = arvaltozas[i].kulonbseg();
            }
        }
        Console.WriteLine("4. feladat: A legkisebb különbség: {0}",mink);
    }
    void f3()
    {
        Console.WriteLine("3.feladat: Változások száma: {0}",arvaltozas.Count);
    }
    void f2()
    {
        string[] sorok = File.ReadAllLines("uzemanyag.txt");
        for (int i = 0; i < sorok.Length; i++)
        {
            arvaltozas.Add(new adatok(sorok[i]));
        }
    }
}

class adatok
{
    public string datum;
    public int benzinar, gazolajar;
    public adatok(string sor)
    {
        string[] vag = sor.Split(";");
        datum = vag[0];
        benzinar = Convert.ToInt32(vag[1]);
        gazolajar = Convert.ToInt32(vag[2]);
    }
    public int kulonbseg()
    {
        return Math.Abs(benzinar - gazolajar);
    }
}