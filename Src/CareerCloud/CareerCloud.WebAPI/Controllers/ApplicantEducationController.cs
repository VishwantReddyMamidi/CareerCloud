using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/Applicant/v1")]
    [ApiController]
    public class ApplicantEducationController : ControllerBase
    {
        private readonly ApplicantEducationLogic _logic;

        public ApplicantEducationController()
        {
            // how can we inject EFgenericRepo here ??????

           EFGenericRepository<ApplicantEducationPoco> Repo = new EFGenericRepository<ApplicantEducationPoco>();
            _logic = new ApplicantEducationLogic(Repo);

        }

        [HttpGet]
        [Route("education/{id}")]
        public ActionResult GetApplicantEducation(Guid id)
        {
            ApplicantEducationPoco poco = _logic.Get(id);
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
        [Route("education")]

        public ActionResult PostApplicantEducation
            ([FromBody]ApplicantEducationPoco[] applicantEducations)
        {
            _logic.Add(applicantEducations);
            return Ok();
        }

        [HttpPut]
        [Route("education")]

        public ActionResult PutApplicantEducation
            ([FromBody]ApplicantEducationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("education")]

        public ActionResult DeleteApplicantEducation
            ([FromBody] ApplicantEducationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("education")]

        public ActionResult GetAllApplicatEducation()
        {
            var applicants = _logic.GetAll();
            if(applicants == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(applicants);
            }
        }
        
    }
}
