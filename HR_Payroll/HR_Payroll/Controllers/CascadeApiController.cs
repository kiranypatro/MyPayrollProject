using HR_Payroll.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HR_Payroll.Models;
using System.Data.Entity;

namespace HR_Payroll.Controllers
{
    [RoutePrefix("api/Cascading")]
    public class CascadeApiController : ApiController
    {
        CascadingCountryStateCity objCSC = new CascadingCountryStateCity();
        [HttpGet]
        [Route("CountryDetails")]
        public List<CountryMaster> BindCountryDetails()
        {


            List<CountryMaster> countryDetail = new List<CountryMaster>();
            try
            {
                countryDetail = objCSC.BindCountry();
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return countryDetail;
        }
        [HttpGet]
        [Route("StateDetails")]
        public List<StateMaster> BindStateDetails(int CountryId)
        {

            List<StateMaster> stateDetail = new List<StateMaster>();
            try
            {
                stateDetail = objCSC.BindState(CountryId);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return stateDetail;
        }

        [HttpGet]
        [Route("CityDetails")]
        public List<CityMaster> BindCityDetails(int stateId)
        {
            List<CityMaster> cityDetail = new List<CityMaster>();
            try
            {
                cityDetail = objCSC.BindCity(stateId);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return cityDetail;
        }

    }
}
