using HR_Payroll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HR_Payroll.ViewModels
{
    public class CascadingCountryStateCity
    {
        HR_PayrollEntities _db = new HR_PayrollEntities();
        public List<CountryMaster> BindCountry()
        {
            this._db.Configuration.ProxyCreationEnabled = false;

            List<CountryMaster> lstCountry = new List<CountryMaster>();
            try
            {
                lstCountry = _db.CountryMasters.ToList();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return lstCountry;
        }

        public List<StateMaster> BindState(int countryId)
        {
            List<StateMaster> lstState = new List<StateMaster>();
            try
            {
                this._db.Configuration.ProxyCreationEnabled = false;

                lstState = _db.StateMasters.Where(a => a.Country_ID == countryId).ToList();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return lstState;
        }

        public List<CityMaster> BindCity(int stateId)
        {
            List<CityMaster> lstCity = new List<CityMaster>();
            try
            {
                this._db.Configuration.ProxyCreationEnabled = false;

                lstCity = _db.CityMasters.Where(a => a.State_ID == stateId).ToList();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return lstCity;
        }
    }
}