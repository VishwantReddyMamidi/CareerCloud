using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    [ApiController]
    public class CompanyJobEducationController : ControllerBase
    {
        private readonly CompanyJobEducationLogic _logic;

        public CompanyJobEducationController()
        {
            EFGenericRepository<CompanyJobEducationPoco> Repo = new EFGenericRepository<CompanyJobEducationPoco>();
            _logic = new CompanyJobEducationLogic(Repo);
        }
        [HttpGet]
        [Route("CompanyJobEducation/{id}")]

        public ActionResult GetCompanyJobEducation(Guid id)
        {
            var poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(poco);
            }
        }

        [HttpPost]
        [Route("CompanyJobEducation")]

        public ActionResult PostCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("CompanyJobEducation")]

        public ActionResult PutCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("CompanyJobEducation")]

        public ActionResult DeleteCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("CompanyJobEducation")]

        public ActionResult GetAllCompanyJobEducation()
        {
            var CompanyJobEducations = _logic.GetAll();
            if (CompanyJobEducations == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(CompanyJobEducations);
            }
        }
    }
}