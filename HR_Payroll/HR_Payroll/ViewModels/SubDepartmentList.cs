using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR_Payroll.Models;
using System.Data.Entity;

namespace HR_Payroll.ViewModels
{
    public class SubDepartmentList
    {
        HR_PayrollEntities _db = new HR_PayrollEntities();
        //public List<Sub_Department> subDeptList = new List<Sub_Department>();
        List<SubDepartmentData> subdeptList = new List<SubDepartmentData>();


        public List<SubDepartmentData> GetSubDepartmentData(int? deptID)
        {
            
            
            
           if(deptID==0 || deptID==null)
            {

                var query = _db.Sub_Department.Include(m => m.Department).Where(m => m.Department_ID !=null ).ToList();

                subdeptList = query.Select(i =>
                          new SubDepartmentData
                          {
                              Sub_Department_ID = i.Sub_Department_ID,
                              Department_ID = i.Department_ID,
                              Department_Name = i.Department.Department_Name,
                              Sub_Department_Name = i.Sub_Department_Name
                          }).ToList();

                // subdeptList = _db.Sub_Department.Include(m => m.Department).ToList();
            }
            else
            {
                var query = _db.Sub_Department.Include(m => m.Department).Where(c => c.Department_ID == deptID).ToList();
                subdeptList = query.Select(i =>
                         new SubDepartmentData
                         {
                             Sub_Department_ID = i.Sub_Department_ID,
                             Department_ID = i.Department_ID,
                             Department_Name = i.Department.Department_Name,
                             Sub_Department_Name = i.Sub_Department_Name
                         }).ToList();

            }

            //  var query = _db.Sub_Department.Include(m => m.Department).Where(m => m.Department_ID == deptID).ToList();

            //  var query1 = from d in _db.Sub_Department.Include(m => m.Department) select d;
            //  var query = _db.Sub_Department.Include(m => m.Department).Where(m => m.Department_ID == deptID).ToList();
            //var result = query.Select(i =>
            //          new SubDepartmentData
            //          {
            //              Sub_Department_ID = i.Sub_Department_ID,
            //              Department_ID = i.Department_ID,
            //              Department_Name = i.Department.Department_Name,
            //              Sub_Department_Name = i.Sub_Department_Name
            //          }).ToList();

            return subdeptList;
        }


    }
    public class SubDepartmentData
    {
        public int Sub_Department_ID { get; set; }
        public Nullable<int> Department_ID { get; set; }
        public string Sub_Department_Name { get; set; }
        public String Department_Name { get; set; }
    }

}





