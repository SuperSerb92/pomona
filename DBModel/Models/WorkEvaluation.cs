using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Models
{
  public  class WorkEvaluation
    {
        public int Id { get; set; }
        
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public string NameSurname { get; set; }
        public DateTime Date { get; set; }
        public int Neto { get; set; }
        public int NoOfBoxes { get; set; }
        public int Evaluation { get; set; }//ocena 1-3
        public int PayPerDay { get; set; }//dnevnica
        public int ExpenseKg { get; set; }//trosak po kg
        public int Total { get; set; }
    }
}
