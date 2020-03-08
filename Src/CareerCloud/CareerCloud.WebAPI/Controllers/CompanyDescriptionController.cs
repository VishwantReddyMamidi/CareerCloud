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
    public class CompanyDescriptionController : ControllerBase
    {
        private readonly CompanyDescriptionLogic _logic;

        public CompanyDescriptionController()
        {
            EFGenericRepository<CompanyDescriptionPoco> Repo = new EFGenericRepository<CompanyDescriptionPoco>();
            _logic = new CompanyDescriptionLogic(Repo);
        }
        [HttpGet]
        [Route("CompanyDescription/{id}")]

        public ActionResult GetCompanyDescription(Guid id)
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
        [Route("CompanyDescription")]

        public ActionResult PostCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("CompanyDescription")]

        public ActionResult PutCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("CompanyDescription")]

        public ActionResult DeleteCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("CompanyDescription")]

        public ActionResult GetAllCompanyDescription()
        {
            var CompanyDescriptions = _logic.GetAll();
            if (CompanyDescriptions == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(CompanyDescriptions);
            }
        }

    }
}