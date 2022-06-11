using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Models
{
  public  class SummaryReport
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string NameSurname { get; set; }
        //public int PlotId { get; set; }
        //public int CultureTypeId { get; set; }
        //public int PlotListId { get; set; }
        //public int CultureId { get; set; }
        public decimal Neto { get; set; }
        public decimal NetoProsek { get; set; }
        public int NoOfBoxes { get; set; }
        //public decimal AvgWorkEval { get; set; }
        //public int ControllerId { get; set; }
        //public int UserLogID { get; set; }
        //public string Controller { get; set; }
    //    public string Culture { get; set; }
        public DateTime Date { get; set; }
        public int BrRadnihDana { get; set; }
        public int Total { get; set; }
        public int TrosakUbranogPloda { get; set; }
        //   public string PlotListName { get; set; }
        //   public string CultureType { get; set; }
    }
}
