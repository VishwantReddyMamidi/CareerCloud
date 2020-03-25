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
using static CareerCloud.gRPC.Protos.SecurityRole;

namespace CareerCloud.gRPC.Services
{
    public class SecurityRoleService : SecurityRoleBase
    {
        private readonly SecurityRoleLogic _logic;

        public SecurityRoleService()
        {
            EFGenericRepository<SecurityRolePoco> Repo = new EFGenericRepository<SecurityRolePoco>();
            _logic = new SecurityRoleLogic(Repo);
        }

        public override Task<SecurityRolePayload> ReadSecurityRole(IdRequest17 request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<SecurityRolePayload>(() => new SecurityRolePayload() { 
            Id = poco.Id.ToString(),
            IsInactive=poco.IsInactive,
            Role=poco.Role
            });
        }

        public override Task<Empty> CreateSecurityRole(SecurityRolePayload request, ServerCallContext context)
        {
            SecurityRolePoco[] poco = { new SecurityRolePoco() {
            Id = Guid.Parse(request.Id),
            IsInactive = request.IsInactive,
            Role = request.Role
            }};

            _logic.Add(poco);
            return new Task<Empty>(()=> new Empty());
        }

        public override Task<Empty> DeleteSecurityRole(SecurityRolePayload request, ServerCallContext context)
        {
            SecurityRolePoco[] poco = { new SecurityRolePoco() {
            Id = Guid.Parse(request.Id),
            IsInactive = request.IsInactive,
            Role = request.Role
            }};

            _logic.Delete(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> UpdateSecurityRole(SecurityRolePayload request, ServerCallContext context)
        {
            SecurityRolePoco[] poco = { new SecurityRolePoco() {
            Id = Guid.Parse(request.Id),
            IsInactive = request.IsInactive,
            Role = request.Role
            }};

            _logic.Update(poco);
            return new Task<Empty>(() => new Empty());
        }


    }
}
