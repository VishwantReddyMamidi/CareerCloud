using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CareerCloud.gRPC.Protos.SecurityLoginsRole;

namespace CareerCloud.gRPC.Services
{
    public class SecurityLoginsRoleService : SecurityLoginsRoleBase
    {
        private readonly SecurityLoginsRoleLogic _logic;

        public SecurityLoginsRoleService()
        {
            EFGenericRepository<SecurityLoginsRolePoco> Repo = new EFGenericRepository<SecurityLoginsRolePoco>();
            _logic = new SecurityLoginsRoleLogic(Repo);
        }

        public override Task<SecurityLoginsRolePayload> ReadSecurityLoginsRole(IdRequest16 request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<SecurityLoginsRolePayload>(() => new SecurityLoginsRolePayload() { 
            Id = poco.Id.ToString(),
            Login = poco.Login.ToString(),
            Role=poco.Role.ToString()
            });
        }

        public override Task<Empty> CreateSecurityLoginsRole(SecurityLoginsRolePayload request, ServerCallContext context)
        {
            SecurityLoginsRolePoco[] poco = { new SecurityLoginsRolePoco() { 
            Id=Guid.Parse(request.Id),
            Login=Guid.Parse(request.Login),
            Role=Guid.Parse(request.Role)
            } };

            _logic.Add(poco);
            return new Task<Empty>(()=> new Empty());
        }

        public override Task<Empty> DeleteSecurityLoginsRole(SecurityLoginsRolePayload request, ServerCallContext context)
        {
            SecurityLoginsRolePoco[] poco = { new SecurityLoginsRolePoco() {
            Id=Guid.Parse(request.Id),
            Login=Guid.Parse(request.Login),
            Role=Guid.Parse(request.Role)
            } };

            _logic.Delete(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> UpdateSecurityLoginsRole(SecurityLoginsRolePayload request, ServerCallContext context)
        {
            SecurityLoginsRolePoco[] poco = { new SecurityLoginsRolePoco() {
            Id=Guid.Parse(request.Id),
            Login=Guid.Parse(request.Login),
            Role=Guid.Parse(request.Role)
            } };

            _logic.Update(poco);
            return new Task<Empty>(() => new Empty());
        }


    }
}
