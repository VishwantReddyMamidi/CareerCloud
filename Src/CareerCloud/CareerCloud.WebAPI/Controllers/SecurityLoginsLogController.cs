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
    [Route("api/careercloud/security/v1")]
    [ApiController]
    public class SecurityLoginsLogController : ControllerBase
    {
        private readonly SecurityLoginsLogLogic _logic;

        public SecurityLoginsLogController()
        {
            EFGenericRepository<SecurityLoginsLogPoco> Repo = new EFGenericRepository<SecurityLoginsLogPoco>();
            _logic = new SecurityLoginsLogLogic(Repo);
        }
        [HttpGet]
        [Route("SecurityLoginsLog/{id}")]

        public ActionResult GetSecurityLoginLog(Guid id)
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
        [Route("SecurityLoginsLog")]

        public ActionResult PostSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("SecurityLoginsLog")]

        public ActionResult PutSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("SecurityLoginsLog")]

        public ActionResult DeleteSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("SecurityLoginsLog")]

        public ActionResult GetAllSecurityLoginsLog()
        {
            var SecurityLoginsLogs = _logic.GetAll();
            if (SecurityLoginsLogs == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(SecurityLoginsLogs);
            }
        }
    }
}