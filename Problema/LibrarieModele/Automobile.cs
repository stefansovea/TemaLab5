using System;
namespace LibrarieModele
{
    public class Automobile
    {
        public const string IEFTIN1 = "Prima optiune este mai ieftina";
        public const string EGAL = "Optiunile au acelasi pret";
        public const string IEFTIN2 = "A doua optiune este mai ieftina";
        private const bool SUCCES = true;
        private const string SEPARATOR_AFISARE = " ";
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';
        private const int MARCA = 0;
        private const int CULOARE = 1;
        private const int PRET = 2;
        private const int CLASA = 3;

        public string Marca { get; set; }
        public string Culoare { get; set; }
        public long Pret { get; set; }
        public ClasaBuget BugetClass {get;set;}
        public Optiuni Opt { get; set; }

        public Automobile()
        {
            Marca = string.Empty;
            Culoare = string.Empty;
            Pret = 0;
        }

        public Automobile(string _marca, string _culoare, long _pret, int _BugetClass)
        {
            Marca = _marca;
            Culoare = _culoare;
            Pret = _pret;
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
                    Marca = cuvant;
                if (i == 1)
                    Culoare = cuvant;
                if (i == 2)
                    Pret = Convert.ToInt64(cuvant);
                if(i==3)
                {
                    int v = Convert.ToInt32(cuvant);
                    ClasaBuget bug = (ClasaBuget)v;
                    BugetClass = bug;
                }        
                if(i>=4)
                {
                    Opt = Opt|(Optiuni)Convert.ToInt32(cuvant);
                    
                }
                i++;
            }
        }


        public int Preferinte(string optiune, string opcul, long buget)
        {

            if (optiune.Equals(Marca))
            {
                if (opcul.Equals(Culoare))
                {
                    if (buget >= Pret)
                        return 1;
                    else
                        return 2;
                }
            }
            return 0;
        }

        public string afisare()
        {
            return string.Format(" {0},{1},{2},{3},{4}", Marca, Culoare, Pret, Convert.ToInt32(BugetClass), Convert.ToInt32(Opt));
        }

        public string Compara(long pret1)
        {
            if (Pret < pret1)
            {
                return IEFTIN2;
            }
            else
            if (Pret == pret1)
            {
                return EGAL;
            }
            else
                return IEFTIN1;
        }
    }
}