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
using static CareerCloud.gRPC.Protos.SystemLanguageCode;

namespace CareerCloud.gRPC.Services
{
    public class SystemLanguageCodeService : SystemLanguageCodeBase
    {
        private readonly SystemLanguageCodeLogic _logic;

        public SystemLanguageCodeService()
        {
            EFGenericRepository<SystemLanguageCodePoco> Repo = new EFGenericRepository<SystemLanguageCodePoco>();
            _logic = new SystemLanguageCodeLogic(Repo);
        }

        public override Task<SystemLanguageCodePayload> ReadSystemLanguageCode(LanguageIDRequest request, ServerCallContext context)
        {
            var poco = _logic.Get(request.LanguageID);
            return new Task<SystemLanguageCodePayload>(()=> new SystemLanguageCodePayload() { 
            LanguageID = poco.LanguageID,
            Name = poco.Name,
            NativeName= poco.NativeName
            });
        }

        public override Task<Empty> CreateSystemLanguageCode(SystemLanguageCodePayload request, ServerCallContext context)
        {
            SystemLanguageCodePoco[] poco = { new SystemLanguageCodePoco() { 
            LanguageID = request.LanguageID,
            Name = request.Name,
            NativeName= request.NativeName
            }};
            _logic.Add(poco);
            return new Task<Empty>(()=> new Empty());
        }

        public override Task<Empty> DeleteSystemLanguageCode(SystemLanguageCodePayload request, ServerCallContext context)
        {
            SystemLanguageCodePoco[] poco = { new SystemLanguageCodePoco() {
            LanguageID = request.LanguageID,
            Name = request.Name,
            NativeName= request.NativeName
            }};
            _logic.Delete(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> UpdateSystemLanguageCode(SystemLanguageCodePayload request, ServerCallContext context)
        {
            SystemLanguageCodePoco[] poco = { new SystemLanguageCodePoco() {
            LanguageID = request.LanguageID,
            Name = request.Name,
            NativeName= request.NativeName
            }};
            _logic.Update(poco);
            return new Task<Empty>(() => new Empty());
        }
    }
}
