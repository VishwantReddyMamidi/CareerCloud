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
using static CareerCloud.gRPC.Protos.CompanyLocation;

namespace CareerCloud.gRPC.Services
{
    public class CompanyLocationService : CompanyLocationBase
    {
        private readonly CompanyLocationLogic _logic;

        public CompanyLocationService()
        {
            EFGenericRepository<CompanyLocationPoco> Repo = new EFGenericRepository<CompanyLocationPoco>();
            _logic = new CompanyLocationLogic(Repo);
        }

        public override Task<CompanyLocationPayload> ReadCompanyLocation(IdRequest12 request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<CompanyLocationPayload>(() => new CompanyLocationPayload() { 
            Id = poco.Id.ToString(),
            City=poco.City,
            Company=poco.Company.ToString(),
            CountryCode=poco.CountryCode,
            PostalCode=poco.PostalCode,
            Province=poco.Province,
            Street=poco.Street
            });
        }

        public override Task<Empty> CreateCompanyLocation(CompanyLocationPayload request, ServerCallContext context)
        {
            CompanyLocationPoco[] poco = { new CompanyLocationPoco() { 
            Id = Guid.Parse(request.Id),
            Company = Guid.Parse(request.Company),
            City = request.City,
            CountryCode = request.CountryCode,
            PostalCode = request.PostalCode,
            Province=request.Province,
            Street = request.Street
            } };

            _logic.Add(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> DeleteCompanyLocation(CompanyLocationPayload request, ServerCallContext context)
        {
            CompanyLocationPoco[] poco = { new CompanyLocationPoco() {
            Id = Guid.Parse(request.Id),
            Company = Guid.Parse(request.Company),
            City = request.City,
            CountryCode = request.CountryCode,
            PostalCode = request.PostalCode,
            Province=request.Province,
            Street = request.Street
            } };

            _logic.Delete(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> UpdateCompanyLocation(CompanyLocationPayload request, ServerCallContext context)
        {
            CompanyLocationPoco[] poco = { new CompanyLocationPoco() {
            Id = Guid.Parse(request.Id),
            Company = Guid.Parse(request.Company),
            City = request.City,
            CountryCode = request.CountryCode,
            PostalCode = request.PostalCode,
            Province=request.Province,
            Street = request.Street
            } };

            _logic.Update(poco);
            return new Task<Empty>(() => new Empty());
        }
    }
}
