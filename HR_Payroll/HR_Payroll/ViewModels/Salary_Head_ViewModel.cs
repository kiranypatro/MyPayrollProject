using HR_Payroll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_Payroll.ViewModels
{
    public class Salary_Head_ViewModel
    {
        HR_PayrollEntities _db = new HR_PayrollEntities();
        List<Salary_Head_Data> salary_head_data = new List<Salary_Head_Data>();

        public List<Salary_Head_Data> Get_Salary_Head_List(int? Salary_Head_Type_ID)
        {


            var query = _db.Salary_Head.Where(c => c.Salary_Head_Type_ID == Salary_Head_Type_ID).ToList();

            salary_head_data = query.Select(i =>
                      new Salary_Head_Data
                      {
                          Salary_Head_ID = i.Salary_Head_ID,
                          Salary_Head_Code = i.Salary_Head_Code,
                          Salary_Head_Name = i.Salary_Head_Name,
                          Salary_Head_Type_ID = i.Salary_Head_Type_ID

                      }).ToList();


            return salary_head_data;
        }
    }

    public class Salary_Head_Data
    {
        public int Salary_Head_ID { get; set; }
        public string Salary_Head_Code { get; set; }
        public string Salary_Head_Name { get; set; }
        public Nullable<int> Salary_Head_Type_ID { get; set; }
        public string Name_Salary_Head { get; set; }

    }
}