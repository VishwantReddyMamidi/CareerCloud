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
    public class SecurityLoginsRoleController : ControllerBase
    {
        private readonly SecurityLoginsRoleLogic _logic;

        public SecurityLoginsRoleController()
        {
            EFGenericRepository<SecurityLoginsRolePoco> Repo = new EFGenericRepository<SecurityLoginsRolePoco>();
            _logic = new SecurityLoginsRoleLogic(Repo);
        }
        [HttpGet]
        [Route("SecurityLoginsRole/{id}")]

        public ActionResult GetSecurityLoginsRole(Guid id)
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
        [Route("SecurityLoginsRole")]

        public ActionResult PostSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("SecurityLoginsRole")]

        public ActionResult PutSecurityLoginsRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("SecurityLoginsRole")]

        public ActionResult DeleteSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("SecurityLoginsRole")]

        public ActionResult GetAllSecurityLoginsRole()
        {
            var SecurityLoginsRoles = _logic.GetAll();
            if (SecurityLoginsRoles == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(SecurityLoginsRoles);
            }
        }
    }
}