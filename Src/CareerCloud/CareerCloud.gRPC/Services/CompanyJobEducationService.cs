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
using static CareerCloud.gRPC.Protos.CompanyJobEducation;

namespace CareerCloud.gRPC.Services
{
    public class CompanyJobEducationService : CompanyJobEducationBase
    {
        private readonly CompanyJobEducationLogic _logic;

        public CompanyJobEducationService()
        {
            EFGenericRepository<CompanyJobEducationPoco> Repo = new EFGenericRepository<CompanyJobEducationPoco>();
            _logic = new CompanyJobEducationLogic(Repo);
        }

        public override Task<CompanyJobEducationPayload> ReadCompanyJobEducation(IdRequest9 request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<CompanyJobEducationPayload>(() => new CompanyJobEducationPayload() { 
            Id = poco.Id.ToString(),
            Job=poco.Job.ToString(),
            Importance=poco.Importance,
            Major=poco.Major
            
            });
        }

        public override Task<Empty> CreateCompanyJobEducation(CompanyJobEducationPayload request, ServerCallContext context)
        {
            CompanyJobEducationPoco[] poco = { new CompanyJobEducationPoco() { 
            Id = Guid.Parse(request.Id),
            Job=Guid.Parse(request.Job),
            Importance= (short)request.Importance,
            Major = request.Major
            } };

            _logic.Add(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> DeleteCompanyJobEducation(CompanyJobEducationPayload request, ServerCallContext context)
        {
            CompanyJobEducationPoco[] poco = { new CompanyJobEducationPoco() {
            Id = Guid.Parse(request.Id),
            Job=Guid.Parse(request.Job),
            Importance= (short)request.Importance,
            Major = request.Major
            } };

            _logic.Delete(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> UpdateCompanyJobEducation(CompanyJobEducationPayload request, ServerCallContext context)
        {
            CompanyJobEducationPoco[] poco = { new CompanyJobEducationPoco() {
            Id = Guid.Parse(request.Id),
            Job=Guid.Parse(request.Job),
            Importance= (short)request.Importance,
            Major = request.Major
            } };

            _logic.Update(poco);
            return new Task<Empty>(() => new Empty());
        }
    }
}
