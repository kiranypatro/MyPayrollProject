using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HR_Payroll.Models;
using HR_Payroll.ViewModels;

namespace HR_Payroll.Controllers
{
    public class EmployeeController : Controller
    {
        HR_PayrollEntities _db = new HR_PayrollEntities();


        //New Employee
        public ActionResult NewEmployee()
        {
            List<Models.CountryMaster> countryList = _db.CountryMasters.ToList<Models.CountryMaster>();
            ViewBag.CountryList = new SelectList(countryList, "Country_ID", "Country_Name");
            return View();
        }


        //ESI Rate
        public ActionResult ESIRates()
        {
            return View();
        }

        //Company

        public ActionResult CompanyList()
        {
            return View();
        }

        public ActionResult Get_Company_Data()
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();
            _db.Configuration.ProxyCreationEnabled = false;
            List<Company> compnay_list = _db.Companies.ToList<Company>();
            return Json(new { data = compnay_list }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddUpdate_Company(int id = 0)
        {
            if (id == 0)
            { return View(new Company()); }
            else
            {
                HR_PayrollEntities _db = new HR_PayrollEntities();

                return View(_db.Companies.Where(x => x.Company_ID == id).FirstOrDefault<Company>());

            }

        }

        [HttpPost]
        public ActionResult AddUpdate_Company(Company company)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            if (company.Company_ID == 0)
            {
                _db.Companies.Add(company);
                _db.SaveChanges();
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                _db.Entry(company).State = EntityState.Modified;
                _db.SaveChanges();
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult Delete_Company(int id)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            Company company = _db.Companies.Where(x => x.Company_ID == id).FirstOrDefault<Company>();
            _db.Companies.Remove(company);
            _db.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

        }


        //

        //Branch

        public List<StateMaster> GetStateList()
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();
            List<StateMaster> Statelist = _db.StateMasters.ToList<StateMaster>();

            return Statelist;
        }

        public List<Company> GetCompanyList()
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();
            List<Company> Companylist = _db.Companies.ToList<Company>();

            return Companylist;
        }

        public List<CountryMaster> GetCountryList()
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();
            List<CountryMaster> Countrylist = _db.CountryMasters.ToList<CountryMaster>();

            return Countrylist;
        }
        public ActionResult BranchList()
        {
            var BL = (
                from b in _db.Branches
                join s in _db.StateMasters on b.State_ID equals s.State_ID
                select new
                {
                    b.Branch_ID,
                    b.Branch_Name,
                    b.Branch_Type,
                    b.Company_ID,
                    b.Adress1,
                    b.Adress2,
                    b.Adress3,
                    b.Land_Mark,
                    s.State_Name,
                    //b.State_ID,
                    b.City,
                    b.Country_ID,
                    b.Pin_Code,
                    b.Landline_Number,
                    b.Mobile_Number,
                    b.Email,
                    b.Branch_Head_Person_ID
                }
                );
            return View(BL.ToList());
        }

        public ActionResult Get_Branch_Data()
        {
            //HR_PayrollEntities _db = new HR_PayrollEntities();
            //_db.Configuration.ProxyCreationEnabled = false;
            //List<Branch> branch_list = _db.Branches.ToList<Branch>();
            var BL = (
                from b in _db.Branches
                join s in _db.StateMasters on b.State_ID equals s.State_ID
                select new
                {
                    b.Branch_ID,
                    b.Branch_Name,
                    b.Branch_Type,
                    b.Company_ID,
                    b.Adress1,
                    b.Adress2,
                    b.Adress3,
                    b.Land_Mark,
                    s.State_Name,
                    //b.State_ID,
                    b.City,
                    b.Country_ID,
                    b.Pin_Code,
                    b.Landline_Number,
                    b.Mobile_Number,
                    b.Email,
                    b.Branch_Head_Person_ID
                }
                );

            return Json(new { data = BL }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddUpdateBranch(int id = 0)
        {
            ViewBag.StateList = new SelectList(GetStateList(), "State_Id", "State_Name");
            ViewBag.CompanyList = new SelectList(GetCompanyList(), "Company_Id", "Company_Name");
            ViewBag.CountryList = new SelectList(GetCountryList(), "Country_Id", "Country_Name");
            if (id == 0)
            { return View(new Branch()); }
            else
            {
                HR_PayrollEntities _db = new HR_PayrollEntities();

                return View(_db.Branches.Where(x => x.Branch_ID == id).FirstOrDefault<Branch>());

            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUpdateBranch(Branch branch)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();
            if (ModelState.IsValid)
            {

                if (branch.Branch_ID == 0)
                {
                    _db.Branches.Add(branch);
                    _db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    _db.Entry(branch).State = EntityState.Modified;
                    _db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
            return View(branch);

        }

        [HttpPost]
        public ActionResult Delete_Branch(int id)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            Branch branch = _db.Branches.Where(x => x.Branch_ID == id).FirstOrDefault<Branch>();
            _db.Branches.Remove(branch);
            _db.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

        }

        //Branch

        //Designation
        public ActionResult DesignationList()
        {

            return View();
        }

        public ActionResult GetDesignationsData()
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();
            _db.Configuration.ProxyCreationEnabled = false;
            List<Designation> designationList = _db.Designations.ToList<Designation>();
            return Json(new { data = designationList }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult AddUpdateDesignations(int id = 0)
        {
            if (id == 0)
            { return View(new Designation()); }
            else
            {
                HR_PayrollEntities _db = new HR_PayrollEntities();

                return View(_db.Designations.Where(x => x.Designation_ID == id).FirstOrDefault<Designation>());

            }

        }

        [HttpPost]
        public ActionResult AddUpdateDesignations(Designation designation)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            if (designation.Designation_ID == 0)
            {
                _db.Designations.Add(designation);
                _db.SaveChanges();
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                _db.Entry(designation).State = EntityState.Modified;
                _db.SaveChanges();
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult DeleteDesignations(int id)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            Designation designation = _db.Designations.Where(x => x.Designation_ID == id).FirstOrDefault<Designation>();
            _db.Designations.Remove(designation);
            _db.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

        }
        //Designation
        //Grade
        public ActionResult GradeList()
        {

            return View();
        }
        public ActionResult GetGradesData()
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();
            _db.Configuration.ProxyCreationEnabled = false;
            List<Grade> gradeList = _db.Grades.ToList<Grade>();
            return Json(new { data = gradeList }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult AddUpdateGrades(int id = 0)
        {
            if (id == 0)
            { return View(new Grade()); }
            else
            {
                HR_PayrollEntities _db = new HR_PayrollEntities();

                return View(_db.Grades.Where(x => x.Grade_ID == id).FirstOrDefault<Grade>());

            }

        }
        [HttpPost]
        public ActionResult AddUpdateGrades(Grade grade)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            if (grade.Grade_ID == 0)
            {
                _db.Grades.Add(grade);
                _db.SaveChanges();
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                _db.Entry(grade).State = EntityState.Modified;
                _db.SaveChanges();
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult DeleteGrades(int id)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            Grade grade = _db.Grades.Where(x => x.Grade_ID == id).FirstOrDefault<Grade>();
            _db.Grades.Remove(grade);
            _db.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

        }
        //Grade
        //Holiday
        public ActionResult HolidayList()
        {

            return View();
        }

        public ActionResult GetHolidaysData()
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();
            _db.Configuration.ProxyCreationEnabled = false;
            List<Holiday> holidList = _db.Holidays.ToList<Holiday>();
            return Json(new { data = holidList }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult AddUpdateHolidays(int id = 0)
        {
            if (id == 0)
            {
                return View(new Holiday());
            }
            else
            {
                HR_PayrollEntities _db = new HR_PayrollEntities();

                return View(_db.Holidays.Where(x => x.HolidayID == id).FirstOrDefault<Holiday>());

            }

        }
        [HttpPost]
        public ActionResult AddUpdateHolidays(Holiday holid)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            if (holid.HolidayID == 0)
            {
                holid.ID = 1;
                DateTime dt = holid.Holiday_Date.Value;
                string day = dt.DayOfWeek.ToString();
                holid.Day = day;
                _db.Holidays.Add(holid);
                _db.SaveChanges();
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                holid.ID = 1;
                DateTime dt = holid.Holiday_Date.Value;
                string day = dt.DayOfWeek.ToString();
                holid.Day = day;
                _db.Entry(holid).State = EntityState.Modified;
                _db.SaveChanges();
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult DeleteHolidays(int id)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            Holiday holid = _db.Holidays.Where(x => x.HolidayID == id).FirstOrDefault<Holiday>();
            _db.Holidays.Remove(holid);
            _db.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

        }
        //Holiday

        //Financial_Year
        public ActionResult Financial_YearList()
        {

            return View();
        }
        public ActionResult Get_Financial_Year_Data()
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();
            _db.Configuration.ProxyCreationEnabled = false;
            List<Financial_Year> financial_year_List = _db.Financial_Year.ToList<Financial_Year>();
            return Json(new { data = financial_year_List }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddUpdate_Financial_Year(int id = 0)
        {
            if (id == 0)
            { return View(new Financial_Year()); }
            else
            {
                HR_PayrollEntities _db = new HR_PayrollEntities();

                return View(_db.Financial_Year.Where(x => x.Financial_Year_ID == id).FirstOrDefault<Financial_Year>());

            }

        }
        [HttpPost]
        public ActionResult AddUpdate_Financial_Year(Financial_Year financial_year)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            if (financial_year.Financial_Year_ID == 0)
            {
                _db.Financial_Year.Add(financial_year);
                _db.SaveChanges();
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                _db.Entry(financial_year).State = EntityState.Modified;
                _db.SaveChanges();
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult Delete_financial_year(int id)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            Financial_Year financial_year = _db.Financial_Year.Where(x => x.Financial_Year_ID == id).FirstOrDefault<Financial_Year>();
            _db.Financial_Year.Remove(financial_year);
            _db.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

        }
        //Financial Year

        //Financial_Institution

        public ActionResult Financial_Institution_List()
        {
            return View();
        }

        public ActionResult Get_Financial_Institution_Data()
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();
            _db.Configuration.ProxyCreationEnabled = false;
            List<Financial_Institution> Financial_InstitutionList = _db.Financial_Institution.ToList<Financial_Institution>();
            return Json(new { data = Financial_InstitutionList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddUpdate_Financial_Institution(int id = 0)
        {
            if (id == 0)
            { return View(new Financial_Institution()); }
            else
            {
                HR_PayrollEntities _db = new HR_PayrollEntities();

                return View(_db.Financial_Institution.Where(x => x.Financial_Institution_ID == id).FirstOrDefault<Financial_Institution>());

            }
        }

        [HttpPost]
        public ActionResult AddUpdate_Financial_Institution(Financial_Institution financial_institution)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            if (financial_institution.Financial_Institution_ID == 0)
            {
                _db.Financial_Institution.Add(financial_institution);
                _db.SaveChanges();
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                _db.Entry(financial_institution).State = EntityState.Modified;
                _db.SaveChanges();
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult Delete_Financial_Institution(int id)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            Financial_Institution financial_institution = _db.Financial_Institution.Where(x => x.Financial_Institution_ID == id).FirstOrDefault<Financial_Institution>();
            _db.Financial_Institution.Remove(financial_institution);
            _db.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

        }

        //

        //Salary_Group_Type_Master
        public ActionResult Salary_Group_Type_Master_List()
        {
            return View();
        }
        public ActionResult Get_Salary_Group_Type_Master_Data()
        {
            // HRMPayrollEntities _db = new HRMPayrollEntities();
            _db.Configuration.ProxyCreationEnabled = false;
            List<Models.Salary_Group_Type_Master> Salary_Group_Type_Master_List = _db.Salary_Group_Type_Master.ToList<Models.Salary_Group_Type_Master>();
            return Json(new { data = Salary_Group_Type_Master_List }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult AddUpdate_Salary_Group_Type_Master(int id = 0)
        {
            if (id == 0)
            { return View(new Models.Salary_Group_Type_Master()); }
            else
            {
                using (HR_PayrollEntities _db = new HR_PayrollEntities())
                {
                    return View(_db.Salary_Group_Type_Master.Where(x => x.Salary_Group_Type_ID == id).FirstOrDefault<Models.Salary_Group_Type_Master>());
                }
            }

        }

        [HttpPost]
        public ActionResult AddUpdate_Salary_Group_Type_Master(Models.Salary_Group_Type_Master salary_group_type_master)
        {
            using (HR_PayrollEntities _db = new HR_PayrollEntities())
            {
                if (ModelState.IsValid)
                {
                    if (salary_group_type_master.Salary_Group_Type_ID == 0)
                    {
                        _db.Salary_Group_Type_Master.Add(salary_group_type_master);
                        _db.SaveChanges();
                        return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        _db.Entry(salary_group_type_master).State = EntityState.Modified;
                        _db.SaveChanges();
                        return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return View(salary_group_type_master);
        }

        [HttpPost]
        public ActionResult Delete_Salary_Group_Type_Master(int id)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            Models.Salary_Group_Type_Master salary_group_type_master = _db.Salary_Group_Type_Master.Where(x => x.Salary_Group_Type_ID == id).FirstOrDefault<Models.Salary_Group_Type_Master>();
            _db.Salary_Group_Type_Master.Remove(salary_group_type_master);
            _db.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

        }
        //Salary_Group_Type_Master
        //Salary_Head
        public List<Models.Salary_Head_Type> Get_Salary_Head_Type_List()
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();
            List<Models.Salary_Head_Type> salary_head_type = _db.Salary_Head_Type.ToList<Models.Salary_Head_Type>();

            return salary_head_type;
        }
        public ActionResult Salary_Head_List()
        {

            ViewBag.Salary_Head_Type_List = Get_Salary_Head_Type_List();
            Get_Salary_Head_Data(1);
            return View();
        }
        public ActionResult Get_Salary_Head_Data(int? Salary_Head_Type_ID)
        {

            Salary_Head_ViewModel salary_head_viewModel = new Salary_Head_ViewModel();
            var data = salary_head_viewModel.Get_Salary_Head_List(Salary_Head_Type_ID);
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddUpdate_Salary_Head(int id = 0)
        {
            ViewBag.Salary_Head_Type_List = new SelectList(Get_Salary_Head_Type_List(), "Salary_Head_Type_ID", "Name_Salary_Head");

            if (id == 0)
            { return View(new Salary_Head()); }
            else
            {
                HR_PayrollEntities _db = new HR_PayrollEntities();

                return View(_db.Salary_Head.Where(x => x.Salary_Head_ID == id).FirstOrDefault<Salary_Head>());

            }

        }

        [HttpPost]
        public ActionResult AddUpdate_Salary_Head(Salary_Head salary_head)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            try
            {



                if (salary_head.Salary_Head_ID == 0)
                {
                    _db.Salary_Head.Add(salary_head);
                    _db.SaveChanges();

                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    _db.Entry(salary_head).State = EntityState.Modified;
                    _db.SaveChanges();

                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }




        }

        [HttpPost]
        public ActionResult Delete_Salary_Head(int id)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            Salary_Head salary_head = _db.Salary_Head.Where(x => x.Salary_Head_ID == id).FirstOrDefault<Salary_Head>();
            _db.Salary_Head.Remove(salary_head);
            _db.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

        }


        //Salary_Head

        //Salary_Head_Type

        public ActionResult Salary_Head_Type_List()
        {
            return View();
        }

        public ActionResult Get_Salary_Head_Type_Data()
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();
            _db.Configuration.ProxyCreationEnabled = false;
            List<Models.Salary_Head_Type> salary_head_type_list = _db.Salary_Head_Type.ToList<Models.Salary_Head_Type>();
            return Json(new { data = salary_head_type_list }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddUpdate_Salary_Head_Type(int id = 0)
        {

            if (id == 0)
            { return View(new Models.Salary_Head_Type()); }
            else
            {
                HR_PayrollEntities _db = new HR_PayrollEntities();

                return View(_db.Salary_Head_Type.Where(x => x.Salary_Head_Type_ID == id).FirstOrDefault<Models.Salary_Head_Type>());

            }

        }

        [HttpPost]
        public ActionResult AddUpdate_Salary_Head_Type(Models.Salary_Head_Type salary_head_type)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            if (salary_head_type.Salary_Head_Type_ID == 0)
            {
                _db.Salary_Head_Type.Add(salary_head_type);
                _db.SaveChanges();
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                _db.Entry(salary_head_type).State = EntityState.Modified;
                _db.SaveChanges();
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult Delete_Salary_Head_Type(int id)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            Models.Salary_Head_Type salary_head_type = _db.Salary_Head_Type.Where(x => x.Salary_Head_Type_ID == id).FirstOrDefault<Models.Salary_Head_Type>();
            _db.Salary_Head_Type.Remove(salary_head_type);
            _db.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

        }

        //Salary_Head_Type

        // GET: Employee
        public ActionResult DepartmentList()
        {
            return View();
        }


        public ActionResult GetDepartmentData()
        {
            // HRMPayrollEntities _db = new HRMPayrollEntities();
            _db.Configuration.ProxyCreationEnabled = false;
            List<Models.Department> deplList = _db.Departments.ToList<Models.Department>();
            return Json(new { data = deplList }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult AddUpdateDepartment(int id = 0)
        {
            if (id == 0)
            { return View(new Models.Department()); }
            else
            {
                using (HR_PayrollEntities _db = new HR_PayrollEntities())
                {
                    return View(_db.Departments.Where(x => x.Department_ID == id).FirstOrDefault<Models.Department>());
                }
            }

        }
        [HttpPost]
        public ActionResult AddUpdateDepartment(Models.Department dept)
        {
            using (HR_PayrollEntities _db = new HR_PayrollEntities())
            {
                if (ModelState.IsValid)
                {
                    if (dept.Department_ID == 0)
                    {
                        _db.Departments.Add(dept);
                        _db.SaveChanges();
                        return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        _db.Entry(dept).State = EntityState.Modified;
                        _db.SaveChanges();
                        return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return View(dept);
        }
        [HttpPost]
        public ActionResult DeleteDepartment(int id)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            Models.Department dept = _db.Departments.Where(x => x.Department_ID == id).FirstOrDefault<Models.Department>();
            _db.Departments.Remove(dept);
            _db.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }
        //
        //Sub_Department
        public List<Models.Department> GetDeptList()
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();
            List<Models.Department> deptlist = _db.Departments.ToList<Models.Department>();

            return deptlist;
        }
        //public ActionResult SubDepartmentList()
        //{
        //    ViewBag.DepartmentList = new SelectList(GetDeptList(), "Department_Id", "Department_Name");

        //    // ViewBag.DepartmentListItems = _db.Departments.Distinct().Select(i => new SelectListItem() { Text = i.Department_Name, Value = i.Department_Id.ToString() }).ToList();
        //    return View();
        //}


        public ActionResult SubDepartmentList()
        {
            List<Models.Department> depList = _db.Departments.ToList<Models.Department>();
            ViewBag.DeptList = new SelectList(depList, "Department_Id", "Department_Name");
            LoadData(0);
            return View();
        }


        [HttpGet]
        public ActionResult LoadData(int? Sub_Department_ID)
        {
            SubDepartmentList objsdeptList = new SubDepartmentList();
            var data = objsdeptList.GetSubDepartmentData(Sub_Department_ID);
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetSubDepartmentData(int Department_Id)
        {
            List<Models.Sub_Department> subDeplList;
            _db.Configuration.ProxyCreationEnabled = false;
            if (Department_Id == 0)
            {

                subDeplList = _db.Sub_Department.ToList<Models.Sub_Department>();
            }
            else
            {
                subDeplList = _db.Sub_Department.Where(x => x.Department_ID == Department_Id).ToList<Models.Sub_Department>();

            }
            return Json(new { data = subDeplList }, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<SelectListItem> GetDepartments()
        {
            using (var context = new HR_PayrollEntities())
            {
                List<SelectListItem> depts = context.Departments.AsNoTracking()
                        // .OrderBy(n => n.CountryNameEnglish)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.Department_ID.ToString(),
                            Text = n.Department_Name
                        }).ToList();
                var depttip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- Select Department ---"
                };
                depts.Insert(0, depttip);
                return new SelectList(depts, "Value", "Text");
            }

        }

        [HttpGet]
        public ActionResult AddUpdateSubDepartment(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.Department = _db.Departments.ToList<Models.Department>();
                return View(new Models.Sub_Department());
            }
            else
            {
                using (HR_PayrollEntities _db = new HR_PayrollEntities())
                {

                    ViewBag.Department = _db.Departments.ToList<Models.Department>();
                    return View(_db.Sub_Department.Where(x => x.Sub_Department_ID == id).FirstOrDefault<Models.Sub_Department>());
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUpdateSubDepartment(Models.Sub_Department sdept)
        {
            //using (HR_PayrollEntities _db = new HR_PayrollEntities())
            //{
            if (ModelState.IsValid)
            {
                if (sdept.Sub_Department_ID == 0)
                {
                    _db.Sub_Department.Add(sdept);
                    _db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    _db.Entry(sdept).State = EntityState.Modified;
                    _db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
                //}
            }
            return View(sdept);

        }

        [HttpPost]
        public ActionResult DeleteSubDepartment(int id)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            Models.Sub_Department sdept = _db.Sub_Department.Where(x => x.Sub_Department_ID == id).FirstOrDefault<Models.Sub_Department>();
            _db.Sub_Department.Remove(sdept);
            _db.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

        }

        //Sub_Department

        //public JsonResult IsCodeExists(string Parameter)
        //{
        //    bool status=false;
        //    if (Parameter == "Category_Code")
        //    {

        //        status  = _db.Asset_Category.Any(y => y.Category_Code == Parameter);
        //    }

        //    else if (Parameter == "Branch_Type")
        //    {
        //        status  = _db.Branches.Any(x => x.Branch_Type == Parameter);

        //    }
        //    return Json(!(status), JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult IsCodeExists(string Category_Code)
        //{

        //    //check if any of the Category code matches the CategoryCode specified in the Parameter using the ANY extension method
        //    return Json(!_db.Asset_Category.Any(x => x.Category_Code == Category_Code), JsonRequestBehavior.AllowGet);
        //}

        //Assets
        public ActionResult AssetCategoryList()
        {
            return View();
        }

        public ActionResult GetAssetCategoryData()
        {
            // HRMPayrollEntities _db = new HRMPayrollEntities();
            _db.Configuration.ProxyCreationEnabled = false;

            List<Asset_Category> assetClList = _db.Asset_Category.ToList<Asset_Category>();

            return Json(new { data = assetClList }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult AddUpdateAssetCategory(int id = 0)
        {
            if (id == 0)
            { return View(new Asset_Category()); }
            else
            {
                using (HR_PayrollEntities _db = new HR_PayrollEntities())
                {
                    return View(_db.Asset_Category.Where(x => x.Asset_Category_ID == id).FirstOrDefault<Asset_Category>());
                }
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUpdateAssetCategory([Bind(Include = "Asset_Category_ID,Category_Code,Category_Name")]Asset_Category assetc)
        {
            //  using (HR_PayrollEntities _db = new HR_PayrollEntities())
            //  {
            if (ModelState.IsValid)
            {
                if (assetc.Asset_Category_ID == 0)
                {
                    _db.Asset_Category.Add(assetc);
                    _db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    _db.Entry(assetc).State = EntityState.Modified;
                    _db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
                //  }
            }
            return View(assetc);
        }
        [HttpPost]
        public ActionResult DeleteAssetCategory(int id)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            Asset_Category assetc = _db.Asset_Category.Where(x => x.Asset_Category_ID == id).FirstOrDefault<Asset_Category>();
            _db.Asset_Category.Remove(assetc);
            _db.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

        }
        //Asstets

        //Sub_Assets

        public List<Asset_Category> GetAssetCategoryList()
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();
            List<Asset_Category> assetcategorylist = _db.Asset_Category.ToList<Asset_Category>();

            return assetcategorylist;
        }

        public ActionResult AssetSubCategoryList()
        {

            List<Asset_Category> AssetCatList = _db.Asset_Category.ToList<Asset_Category>();
            ViewBag.AssetCategoryList = new SelectList(AssetCatList, "Asset_Category_ID", "Category_Name");
            LoadAssetSubCatData(0);
            return View();
        }

        [HttpGet]
        public ActionResult LoadAssetSubCatData(int? Asset_Sub_Cat_ID)
        {
            Asset_SubCategory_List objassetsubcatList = new Asset_SubCategory_List();
            var data = objassetsubcatList.GetAssetSubCategoryData(Asset_Sub_Cat_ID);
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAssetSubCategoryData(int Asset_Cat_ID)
        {

            List<Asset_Sub_Category> assetsubClList;
            _db.Configuration.ProxyCreationEnabled = false;

            if (Asset_Cat_ID == 0)
            {

                assetsubClList = _db.Asset_Sub_Category.ToList<Asset_Sub_Category>();
            }
            else
            {
                assetsubClList = _db.Asset_Sub_Category.Where(x => x.Asset_Category_ID == Asset_Cat_ID).ToList<Asset_Sub_Category>();

            }


            return Json(new { data = assetsubClList }, JsonRequestBehavior.AllowGet);

        }

        public IEnumerable<SelectListItem> GetAsstCategoryList()
        {
            using (var context = new HR_PayrollEntities())
            {
                List<SelectListItem> AssetCategory = context.Asset_Category.AsNoTracking()
                        // .OrderBy(n => n.CountryNameEnglish)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.Asset_Category_ID.ToString(),
                            Text = n.Category_Name
                        }).ToList();
                var Asset_Category_ip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- Select Asset Category ---"
                };
                AssetCategory.Insert(0, Asset_Category_ip);
                return new SelectList(AssetCategory, "Value", "Text");
            }

        }

        [HttpGet]
        public ActionResult AddUpdateSubAssetCategory(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.AssetCategory = _db.Asset_Category.ToList<Asset_Category>();
                return View(new Asset_Sub_Category());
            }
            else
            {
                using (HR_PayrollEntities _db = new HR_PayrollEntities())
                {
                    ViewBag.AssetCategory = _db.Asset_Category.ToList<Asset_Category>();
                    return View(_db.Asset_Sub_Category.Where(x => x.Asset_Sub_Category_ID == id).FirstOrDefault<Asset_Sub_Category>());
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUpdateSubAssetCategory(Asset_Sub_Category assetsc)
        {
            //  using (HR_PayrollEntities _db = new HR_PayrollEntities())
            //  {
            if (ModelState.IsValid)
            {
                if (assetsc.Asset_Sub_Category_ID == 0)
                {
                    _db.Asset_Sub_Category.Add(assetsc);
                    _db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    _db.Entry(assetsc).State = EntityState.Modified;
                    _db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
                //  }
            }
            return View(assetsc);
        }

        [HttpPost]
        public ActionResult DeleteAssetSubCategory(int id)
        {
            HR_PayrollEntities _db = new HR_PayrollEntities();

            Asset_Sub_Category assetsc = _db.Asset_Sub_Category.Where(x => x.Asset_Sub_Category_ID == id).FirstOrDefault<Asset_Sub_Category>();
            _db.Asset_Sub_Category.Remove(assetsc);
            _db.SaveChanges();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

        }

        //Sub_Assets

        //Employee Information

        public ActionResult EmployeeInformation()
        {
            return View();
        }





        // GET: Employee/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Employee/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Employee/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Employee/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Employee/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Employee/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Employee/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
