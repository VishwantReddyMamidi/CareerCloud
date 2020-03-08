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
    public class SecurityRoleController : ControllerBase
    {
        private readonly SecurityRoleLogic _logic;

        public SecurityRoleController()
        {
            EFGenericRepository<SecurityRolePoco> Repo = new EFGenericRepository<SecurityRolePoco>();
            _logic = new SecurityRoleLogic(Repo);
        }
        [HttpGet]
        [Route("SecurityRole/{id}")]

        public ActionResult GetSecurityRole(Guid id)
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
        [Route("SecurityRole")]

        public ActionResult PostSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("SecurityRole")]

        public ActionResult PutSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("SecurityRole")]

        public ActionResult DeleteSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("SecurityRole")]

        public ActionResult GetAllSecurityRole()
        {
            var SecurityRoles = _logic.GetAll();
            if (SecurityRoles == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(SecurityRoles);
            }
        }
    }
}