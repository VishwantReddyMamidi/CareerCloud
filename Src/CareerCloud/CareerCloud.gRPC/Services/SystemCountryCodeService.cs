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
using static CareerCloud.gRPC.Protos.SystemCountryCode;

namespace CareerCloud.gRPC.Services
{
    public class SystemCountryCodeService : SystemCountryCodeBase
    {
        private readonly SystemCountryCodeLogic _logic;

        public SystemCountryCodeService()
        {
            EFGenericRepository<SystemCountryCodePoco> Repo = new EFGenericRepository<SystemCountryCodePoco>();
            _logic = new SystemCountryCodeLogic(Repo);
        }

        public override Task<SystemCountryCodePayload> ReadSystemCountryCode(CodeRequest request, ServerCallContext context)
        {
            var poco = _logic.Get(request.Code);
            return new Task<SystemCountryCodePayload>(()=> new SystemCountryCodePayload() { 
            Code=poco.Code,
            Name=poco.Name
            });
        }

        public override Task<Empty> CreateSystemCountryCode(SystemCountryCodePayload request, ServerCallContext context)
        {
            SystemCountryCodePoco[] poco = { new SystemCountryCodePoco() {
                Code=request.Code,
                Name = request.Name
            }};
            _logic.Add(poco);
            return new Task<Empty>(()=> new Empty());
        }

        public override Task<Empty> DeleteSystemCountryCode(SystemCountryCodePayload request, ServerCallContext context)
        {
            SystemCountryCodePoco[] poco = { new SystemCountryCodePoco() {
                Code=request.Code,
                Name = request.Name
            }};
            _logic.Delete(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> UpdateSystemCountryCode(SystemCountryCodePayload request, ServerCallContext context)
        {
            SystemCountryCodePoco[] poco = { new SystemCountryCodePoco() {
                Code=request.Code,
                Name = request.Name
            }};
            _logic.Update(poco);
            return new Task<Empty>(() => new Empty());
        }

    }
}
