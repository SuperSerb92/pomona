using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Models
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
        string datumBezVremena;
        string trosakS;
        string prihodS;
        string profitS;

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
        public string DatumBezVremena { get => datumBezVremena; set => datumBezVremena = value; }
        public string ProfitS { get => profitS; set => profitS = value; }
        public string PrihodS { get => prihodS; set => prihodS = value; }
        public string TrosakS { get => trosakS; set => trosakS = value; }
    }
}
