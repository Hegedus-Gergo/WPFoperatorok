using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class Kifejezes
    {
        int szamOperandus;
        string szovegoperator;
        int szamOperandus2;

        public Kifejezes(int szamOperandus, int szamOperandus2, string szovegoperator)
        {
            this.szamOperandus = szamOperandus;
            this.szamOperandus2 = szamOperandus2;
            this.szovegoperator = szovegoperator;
        }

        public int SzamOperandus { get => szamOperandus;}
        public int SzamOperandus2 { get => szamOperandus;}
        public string Szovegoperator { get => szovegoperator;}

        public string Eredmeny()
        {
            if (szovegoperator == "+")
            {
                return Convert.ToString(szamOperandus + szamOperandus2);
            }
            else if (szovegoperator == "-")
            {
                return Convert.ToString(szamOperandus - szamOperandus2);
            }
            else if (szovegoperator == "*")
            {
                return Convert.ToString(szamOperandus * szamOperandus2);
            }
            else if (szovegoperator == "/" && szamOperandus2 != 0)
            {
                return Convert.ToString(szamOperandus / szamOperandus2);
            }
            else if (szovegoperator == "div" && szamOperandus2 != 0)
            {
                return Convert.ToString((szamOperandus / szamOperandus2)); //Math.Round
            }

            else if (szovegoperator == "mod" && szamOperandus2 != 0)
            {
                return Convert.ToString(szamOperandus % szamOperandus2);
            }
            else if (szovegoperator != "+" || szovegoperator != "-" || szovegoperator != "*" || szovegoperator != "/" || szovegoperator != "div" || szovegoperator != "mod")
            {
                return "Hibás operátor!";
            }
            else { 
                return "Egyéb hiba!";
            }
        }
    }
}

