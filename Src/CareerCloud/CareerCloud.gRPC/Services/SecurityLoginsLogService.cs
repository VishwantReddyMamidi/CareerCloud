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
using static CareerCloud.gRPC.Protos.SecurityLoginsLog;

namespace CareerCloud.gRPC.Services
{
    public class SecurityLoginsLogService : SecurityLoginsLogBase
    {
        private readonly SecurityLoginsLogLogic _logic;

        public SecurityLoginsLogService()
        {
            EFGenericRepository<SecurityLoginsLogPoco> Repo = new EFGenericRepository<SecurityLoginsLogPoco>();
            _logic = new SecurityLoginsLogLogic(Repo);
        }

        public override Task<SecurityLoginsLogPayload> ReadSecurityLoginsLog(IdRequest15 request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<SecurityLoginsLogPayload>(()=> new SecurityLoginsLogPayload() { 
            Id = poco.Id.ToString(),
            Login=poco.Id.ToString(),
            IsSuccesful = poco.IsSuccesful,
            LogonDate =Timestamp.FromDateTime(poco.LogonDate),
            SourceIP=poco.SourceIP
            });
        }

        public override Task<Empty> CreateSecurityLoginsLog(SecurityLoginsLogPayload request, ServerCallContext context)
        {
            SecurityLoginsLogPoco[] poco = { new SecurityLoginsLogPoco() { 
            Id = Guid.Parse(request.Id),
            Login=Guid.Parse(request.Login),
            IsSuccesful = request.IsSuccesful,
            LogonDate = DateTime.Parse(request.LogonDate.ToString()),
            SourceIP = request.SourceIP
            }};
            _logic.Add(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> DeleteSecurityLoginsLog(SecurityLoginsLogPayload request, ServerCallContext context)
        {
            SecurityLoginsLogPoco[] poco = { new SecurityLoginsLogPoco() {
            Id = Guid.Parse(request.Id),
            Login=Guid.Parse(request.Login),
            IsSuccesful = request.IsSuccesful,
            LogonDate = DateTime.Parse(request.LogonDate.ToString()),
            SourceIP = request.SourceIP
            }};
            _logic.Delete(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> UpdateSecurityLoginsLog(SecurityLoginsLogPayload request, ServerCallContext context)
        {
            SecurityLoginsLogPoco[] poco = { new SecurityLoginsLogPoco() {
            Id = Guid.Parse(request.Id),
            Login=Guid.Parse(request.Login),
            IsSuccesful = request.IsSuccesful,
            LogonDate = DateTime.Parse(request.LogonDate.ToString()),
            SourceIP = request.SourceIP
            }};
            _logic.Update(poco);
            return new Task<Empty>(() => new Empty());
        }
    }
}
