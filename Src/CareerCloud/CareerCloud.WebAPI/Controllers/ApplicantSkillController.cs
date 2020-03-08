using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.BusinessLogicLayer;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/Applicant/v1")]
    [ApiController]
    public class ApplicantSkillController : ControllerBase
    {
        private readonly ApplicantSkillLogic _logic;

        public ApplicantSkillController()
        {
            EFGenericRepository<ApplicantSkillPoco> Repo = new EFGenericRepository<ApplicantSkillPoco>();
            _logic = new ApplicantSkillLogic(Repo);
        }
        [HttpGet]
        [Route("ApplicantSkill/{id}")]

        public ActionResult GetApplicantSkill(Guid id)
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
        [Route("ApplicantSkill")]

        public ActionResult PostApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("ApplicantSkill")]

        public ActionResult PutApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("ApplicantSkill")]

        public ActionResult DeleteApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("ApplicantSkill")]

        public ActionResult GetAllApplicantSkill()
        {
            var ApplicantSkills = _logic.GetAll();
            if (ApplicantSkills == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ApplicantSkills);
            }
        }
    }
}