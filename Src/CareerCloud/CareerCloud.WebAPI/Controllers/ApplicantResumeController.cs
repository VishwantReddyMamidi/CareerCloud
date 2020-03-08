using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/Applicant/v1")]
    [ApiController]
    public class ApplicantResumeController : ControllerBase
    {
        private readonly ApplicantResumeLogic _logic;

        public ApplicantResumeController()
        {
            EFGenericRepository<ApplicantResumePoco> Repo = new EFGenericRepository<ApplicantResumePoco>();
            _logic = new ApplicantResumeLogic(Repo);
        }
        [HttpGet]
        [Route("ApplicantResume/{id}")]

        public ActionResult GetApplicantResume(Guid id)
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
        [Route("ApplicantResume")]

        public ActionResult PostApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("ApplicantResume")]

        public ActionResult PutApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("ApplicantResume")]

        public ActionResult DeleteApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("ApplicantResume")]

        public ActionResult GetAllApplicantResume()
        {
            var ApplicantResumes = _logic.GetAll();
            if (ApplicantResumes == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ApplicantResumes);
            }
        }
    }
}