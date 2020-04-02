using LibrarieModele;
using System;
using System.Collections.Generic;
using System.IO;

namespace NivelAccesDate
{
    public class AdministrareAutomobile_FisierText: IStocareData
    {
        string NumeFisier { get; set; }
        public AdministrareAutomobile_FisierText(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisierText.Close();
        }
        public void AddAutomobil(Automobile []s,int _numarmasini)
        {
            if (File.Exists(@"C:\Users\Stefan\source\repos\TemaLab5\Problema\Problema\bin\Debug\Automobile.txt"))
            {
                File.WriteAllText(@"C:\Users\Stefan\source\repos\TemaLab5\Problema\Problema\bin\Debug\Automobile.txt", String.Empty);
            }
            for (int i = 0; i < _numarmasini; i++)
            {
                try
                {
                    using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                    {
                        swFisierText.WriteLine(s[i].afisare());
                    }
                }
                catch (IOException eIO)
                {
                    throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
                }
                catch (Exception eGen)
                {
                    throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
                }
            }
        }
    }
}
