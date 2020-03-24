using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using static CareerCloud.gRPC.Protos.CompanyProfile;
using CareerCloud.gRPC.Protos;
using Grpc.Core;
using Google.Protobuf.WellKnownTypes;

namespace CareerCloud.gRPC.Services
{
    public class CompanyProfileService : CompanyProfileBase
    {
        private readonly CompanyProfileLogic _logic;

        public CompanyProfileService()
        {
            EFGenericRepository<CompanyProfilePoco> Repo = new EFGenericRepository<CompanyProfilePoco>();
            _logic = new CompanyProfileLogic(Repo);
        }

        public override Task<CompanyProfilePayload> ReadCompanyProfile(IdRequest13 request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<CompanyProfilePayload>(() => new CompanyProfilePayload()
            { 
              Id = poco.Id.ToString(),
              RegistrationDate = Timestamp.FromDateTime(poco.RegistrationDate),
              CompanyLogo=BitConverter.ToInt32(poco.CompanyLogo),
              CompanyWebsite = poco.CompanyWebsite,
              ContactName = poco.ContactName,
              ContactPhone=poco.ContactPhone
            });
        }

        public override Task<Empty> CreateCompanyProfile(CompanyProfilePayload request, ServerCallContext context)
        {
            CompanyProfilePoco[] poco = { new CompanyProfilePoco() { 
            Id = Guid.Parse(request.Id),
            RegistrationDate=DateTime.Parse(request.RegistrationDate.ToString()),
            CompanyLogo =BitConverter.GetBytes(request.CompanyLogo),
            CompanyWebsite = request.CompanyWebsite,
            ContactName = request.ContactName,
            ContactPhone= request.ContactPhone
            } };
            _logic.Add(poco);
            return new Task<Empty>(()=> new Empty());
        }

        public override Task<Empty> DeleteCompanyProfile(CompanyProfilePayload request, ServerCallContext context)
        {
            CompanyProfilePoco[] poco = { new CompanyProfilePoco() {
            Id = Guid.Parse(request.Id),
            RegistrationDate=DateTime.Parse(request.RegistrationDate.ToString()),
            CompanyLogo =BitConverter.GetBytes(request.CompanyLogo),
            CompanyWebsite = request.CompanyWebsite,
            ContactName = request.ContactName,
            ContactPhone= request.ContactPhone
            } };
            _logic.Delete(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> UpdateCompanyProfile(CompanyProfilePayload request, ServerCallContext context)
        {
            CompanyProfilePoco[] poco = { new CompanyProfilePoco() {
            Id = Guid.Parse(request.Id),
            RegistrationDate=DateTime.Parse(request.RegistrationDate.ToString()),
            CompanyLogo =BitConverter.GetBytes(request.CompanyLogo),
            CompanyWebsite = request.CompanyWebsite,
            ContactName = request.ContactName,
            ContactPhone= request.ContactPhone
            } };
            _logic.Update(poco);
            return new Task<Empty>(() => new Empty());
        }
    }
}
