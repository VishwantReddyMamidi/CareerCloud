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
    public class SecurityLoginController : ControllerBase
    {
        private readonly SecurityLoginLogic _logic;

        public SecurityLoginController()
        {
            EFGenericRepository<SecurityLoginPoco> Repo = new EFGenericRepository<SecurityLoginPoco>();
            _logic = new SecurityLoginLogic(Repo);
        }
        [HttpGet]
        [Route("SecurityLogin/{id}")]

        public ActionResult GetSecurityLogin(Guid id)
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
        [Route("SecurityLogin")]

        public ActionResult PostSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("SecurityLogin")]

        public ActionResult PutSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("SecurityLogin")]

        public ActionResult DeleteSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("SecurityLogin")]

        public ActionResult GetAllSecurityLogin()
        {
            var SecurityLogins = _logic.GetAll();
            if (SecurityLogins == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(SecurityLogins);
            }
        }
    }
}