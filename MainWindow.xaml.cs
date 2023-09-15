using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Kifejezes> kifejezesek = new List<Kifejezes>();
        public MainWindow()
        {
            InitializeComponent();
            var fajl = new OpenFileDialog();
            if (fajl.ShowDialog() == true)
            {
                StreamReader streamReader = new StreamReader(fajl.FileName);
                while (!streamReader.EndOfStream)
                {
                    string sor = streamReader.ReadLine();
                    string[] mezok = sor.Split(" ");
                    Kifejezes kifejezes = new Kifejezes(Convert.ToInt32(mezok[0]), Convert.ToInt32(mezok[2]), mezok[1]);
                    kifejezesek.Add(kifejezes);
                }
                streamReader.Close();

                int modokSzama = 0;
                foreach (Kifejezes operatorr in kifejezesek)
                {
                    if (operatorr.Szovegoperator == "mod")
                    {
                        modokSzama++;
                    }
                }
                //modokSzama = kifejezesek.Count(ob=>ob.Szovegoperator=="mod");

                bool igaze = false;
                foreach (Kifejezes szamok in kifejezesek)
                {
                    if (szamok.SzamOperandus % 10 == 0 && szamok.SzamOperandus2 % 10 == 0)
                    {
                        igaze = true;
                        break;
                    }
                }

                igaze = kifejezesek.Any(x => x.SzamOperandus % 10 == 0 && x.SzamOperandus2 % 10 == 0);

                int perek = 0;
                int divek = 0;
                foreach (Kifejezes operatorr in kifejezesek)
                {
                    switch (operatorr.Szovegoperator)
                    {
                        case "/":
                            perek++;
                            break;

                        case "div":
                            divek++;
                            break;

                    }
                }

                var csoportok = kifejezesek.GroupBy(x => x.Szovegoperator);

                foreach (var aktCsop in csoportok)
                {
                    Console.WriteLine(aktCsop.Key + ":" + aktCsop.Count());
                }


                int kivonas = 0;
                foreach (Kifejezes operatorr in kifejezesek)
                {
                    if (operatorr.Szovegoperator == "-")
                    {
                        kivonas++;
                    }
                }
                int szorzas = 0;
                foreach (Kifejezes operatorr in kifejezesek)
                {
                    if (operatorr.Szovegoperator == "*")
                    {
                        szorzas++;
                    }
                }
                int osszeads = 0;
                foreach (Kifejezes operatorr in kifejezesek)
                {
                    if (operatorr.Szovegoperator == "+")
                    {
                        osszeads++;
                    }
                }


                if (igaze)
                {
                    feladat2.Content = "2. feladat: Kifejezések száma: " + kifejezesek.Count + "\n3. feladat: Kifejezések maradéskos osztással: " + modokSzama + "\n4. feladat : Van ilyen kifejezés!\n5. feladat: Statisztika\n\tmod -> " + modokSzama + " db\n\t/ -> " + perek + " db\n\tdiv ->" + divek + " db\n\t- -> " + kivonas + " db\n\t* -> " + szorzas + " db\n\t+ ->" + osszeads + " db\n8. feladat: eredmenyek.txt";
                }
                else
                {
                    feladat2.Content = "2. feladat: Kifejezések száma: " + kifejezesek.Count + "\n3. feladat: Kifejezések maradéskos osztással: " + modokSzama + "\n4. feladat : Nincs ilyen kifejezés!\n5. feladat: Statisztika\t\nmod -> " + modokSzama + " db\n\t/ -> " + perek + " db\n\tdiv ->" + divek + " db\t\n- -> " + kivonas + " db\n\t* -> " + szorzas + " db\n\t+ ->" + osszeads + " db\n8. feladat: eredmenyek.txt";
                }

                using (StreamWriter sw = File.CreateText("eredmenyek.txt"))
                {
                    for (int i = 0; i < kifejezesek.Count; i++)
                    {


                        foreach (Kifejezes ertek in kifejezesek)
                        {
                            sw.WriteLine(ertek.SzamOperandus + " " + ertek.Szovegoperator + " " + ertek.SzamOperandus2 + " = " + Kifejezes.Eredmeny(ertek.SzamOperandus,ertek.SzamOperandus2,ertek.Szovegoperator));
                        }
                    }
                    sw.Close();
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string bekert = tbxmuvelet.Text;
            string[] muvelet= bekert.Split(' ');
            for (int i = 0; i < kifejezesek.Count; i++)
            {

                              
                    lberedmenyek.Items.Add(muvelet[0] + " " + muvelet[1] + " " + muvelet[2] + " = " + Kifejezes.Eredmeny(Convert.ToInt32(muvelet[0]),Convert.ToInt32(muvelet[2]), muvelet[1]));
                
            }

        }

    }
}
