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
    [Route("api/careercloud/Applicant/v1")]
    [ApiController]
    public class ApplicantProfileController : ControllerBase
    {
        private readonly ApplicantProfileLogic _logic;

        public ApplicantProfileController()
        {
            EFGenericRepository<ApplicantProfilePoco> Repo = new EFGenericRepository<ApplicantProfilePoco>();
            _logic = new ApplicantProfileLogic(Repo);
        }

        [HttpGet]
        [Route("ApplicantProfile/{id}")]

        public ActionResult GetApplicantProfile(Guid id)
        {
            var poco = _logic.Get(id);
            if(poco==null)
            {
                return NotFound();

            }
            else
            {
                return Ok(poco);
            }
        }

        [HttpPost]
        [Route("ApplicantProfile")]

        public ActionResult PostApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("ApplicantProfile")]

        public ActionResult PutApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("ApplicantProfile")]

        public ActionResult DeleteApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("ApplicantProfile")]

        public ActionResult GetAllApplicantProfiles()
        {
            var ApplicantProfiles = _logic.GetAll();
            if (ApplicantProfiles==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ApplicantProfiles);
            }
        }
    }
}