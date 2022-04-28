using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Models
{
   public class ProfitLossReport
    {
        DateTime datum;
        int brojBeraca;
        int brojKutija;
        int prosecanTrosakPoBeracu;
        int trosak;
        decimal netoOtkup;
        int prosecnaPC;
        int prosecnaCenaKost;
        int prihod;
        int profit;
        int trosakProc;

        public DateTime Datum { get => datum; set => datum = value; }
        public int BrojBeraca { get => brojBeraca; set => brojBeraca = value; }
        public int BrojKutija { get => brojKutija; set => brojKutija = value; }
        public int ProsecanTrosakPoBeracu { get => prosecanTrosakPoBeracu; set => prosecanTrosakPoBeracu = value; }
        public int Trosak { get => trosak; set => trosak = value; }
        public decimal NetoOtkup { get => netoOtkup; set => netoOtkup = value; }
        public int ProsecnaPC { get => prosecnaPC; set => prosecnaPC = value; }
        public int ProsecnaCenaKost { get => prosecnaCenaKost; set => prosecnaCenaKost = value; }
        public int Prihod { get => prihod; set => prihod = value; }
        public int Profit { get => profit; set => profit = value; }
        public int TrosakProc { get => trosakProc; set => trosakProc = value; }
    }
}
