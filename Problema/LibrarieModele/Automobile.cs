using System;
namespace LibrarieModele
{
    public class Automobile
    {
        public const string IEFTIN1 = "Prima optiune este mai ieftina";
        public const string EGAL = "Optiunile au acelasi pret";
        public const string IEFTIN2 = "A doua optiune este mai ieftina";

        public string marca { get; set; }
        public string culoare { get; set; }
        public long pret { get; set; }
        public ClasaBuget BugetClass {get;set;}
        public Optiuni Opt { get; set; }

        public Automobile()
        {
            marca = string.Empty;
            culoare = string.Empty;
            pret = 0;
        }

        public Automobile(string _marca, string _culoare, long _pret, int _BugetClass)
        {
            marca = _marca;
            culoare = _culoare;
            pret = _pret;
            ClasaBuget buget = (ClasaBuget)_BugetClass;
            BugetClass = buget;
        }

        public Automobile(string sir)
        {
            int i = 0;
            string[] date = sir.Split(',');
            foreach (var cuvant in date)
            {
                if (i == 0)
                    marca = cuvant;
                if (i == 1)
                    culoare = cuvant;
                if (i == 2)
                    pret = Convert.ToInt64(cuvant);
                if(i==3)
                {
                    int v = Convert.ToInt32(cuvant);
                    ClasaBuget bug = (ClasaBuget)v;
                    BugetClass = bug;
                }               
                i++;
            }
        }

        public int Preferinte(string optiune, string opcul, long buget)
        {

            if (optiune.Equals(marca))
            {
                if (opcul.Equals(culoare))
                {
                    if (buget >= pret)
                        return 1;
                    else
                        return 2;
                }
            }
            return 0;
        }

        public string afisare()
        {
            return string.Format(" {0}, de culoare {1}, la pretul de {2} euro, Buget Class: {3}, Optiuni: {4} \n", marca, culoare, pret, BugetClass, Opt);
        }

        public string Compara(long pret1)
        {
            if (pret < pret1)
            {
                return IEFTIN2;
            }
            else
            if (pret == pret1)
            {
                return EGAL;
            }
            else
                return IEFTIN1;
        }
    }
}