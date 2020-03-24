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
using static CareerCloud.gRPC.Protos.SecurityLogin;

namespace CareerCloud.gRPC.Services
{
    public class SecurityLoginService : SecurityLoginBase
    {
        private readonly SecurityLoginLogic _logic;

        public SecurityLoginService()
        {
            EFGenericRepository<SecurityLoginPoco> Repo = new EFGenericRepository<SecurityLoginPoco>();
            _logic = new SecurityLoginLogic(Repo);
        }

        public override Task<SecurityLoginPayload> ReadSecurityLogin(IdRequest14 request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<SecurityLoginPayload>(() => new SecurityLoginPayload() {
                Id = poco.Id.ToString(),
                Login = poco.Login,
                AgreementAccepted = poco.AgreementAccepted is null ?
                                 null :
                                 Timestamp.FromDateTime((DateTime)poco.AgreementAccepted),
                Created = Timestamp.FromDateTime(poco.Created),
            EmailAddress = poco.EmailAddress,
            FullName = poco.FullName,
            ForceChangePassword = poco.ForceChangePassword,
            IsInactive=poco.IsInactive,
            IsLocked=poco.IsLocked,
            Password=poco.Password,
            PasswordUpdate= poco.PasswordUpdate is null ?
                                 null :
                                 Timestamp.FromDateTime((DateTime)poco.PasswordUpdate),
            PhoneNumber=poco.PhoneNumber,
            PrefferredLanguage=poco.PrefferredLanguage
            }); ;
        }

        public override Task<Empty> CreateSecurityLogin(SecurityLoginPayload request, ServerCallContext context)
        {
            SecurityLoginPoco[] poco = { new SecurityLoginPoco() { 
            Id = Guid.Parse(request.Id),
            Login = request.Login,
            AgreementAccepted = DateTime.Parse(request.AgreementAccepted.ToString()),
            Created = DateTime.Parse(request.Created.ToString()),
            EmailAddress = request.EmailAddress,
            FullName=request.FullName,
            ForceChangePassword = request.ForceChangePassword,
            IsInactive = request.IsInactive,
            IsLocked= request.IsLocked,
            Password = request.Password,
            PasswordUpdate =DateTime.Parse(request.PasswordUpdate.ToString()),
            PhoneNumber = request.PhoneNumber,
            PrefferredLanguage=request.PrefferredLanguage
            } };

            _logic.Add(poco);
            return new Task<Empty>(()=> new Empty());
        }

        public override Task<Empty> DeleteSecurityLogin(SecurityLoginPayload request, ServerCallContext context)
        {
            SecurityLoginPoco[] poco = { new SecurityLoginPoco() {
            Id = Guid.Parse(request.Id),
            Login = request.Login,
            AgreementAccepted = DateTime.Parse(request.AgreementAccepted.ToString()),
            Created = DateTime.Parse(request.Created.ToString()),
            EmailAddress = request.EmailAddress,
            FullName=request.FullName,
            ForceChangePassword = request.ForceChangePassword,
            IsInactive = request.IsInactive,
            IsLocked= request.IsLocked,
            Password = request.Password,
            PasswordUpdate =DateTime.Parse(request.PasswordUpdate.ToString()),
            PhoneNumber = request.PhoneNumber,
            PrefferredLanguage=request.PrefferredLanguage
            } };

            _logic.Delete(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> UpdateSecurityLogin(SecurityLoginPayload request, ServerCallContext context)
        {
            SecurityLoginPoco[] poco = { new SecurityLoginPoco() {
            Id = Guid.Parse(request.Id),
            Login = request.Login,
            AgreementAccepted = DateTime.Parse(request.AgreementAccepted.ToString()),
            Created = DateTime.Parse(request.Created.ToString()),
            EmailAddress = request.EmailAddress,
            FullName=request.FullName,
            ForceChangePassword = request.ForceChangePassword,
            IsInactive = request.IsInactive,
            IsLocked= request.IsLocked,
            Password = request.Password,
            PasswordUpdate =DateTime.Parse(request.PasswordUpdate.ToString()),
            PhoneNumber = request.PhoneNumber,
            PrefferredLanguage=request.PrefferredLanguage
            } };

            _logic.Update(poco);
            return new Task<Empty>(() => new Empty());
        }
    }
}
