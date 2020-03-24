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
using static CareerCloud.gRPC.Protos.ApplicantWorkHistory;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantWorkHistory : ApplicantWorkHistoryBase
    {
        private readonly ApplicantWorkHistoryLogic _logic;

        public ApplicantWorkHistory()
        {
            EFGenericRepository<ApplicantWorkHistoryPoco> Repo = new EFGenericRepository<ApplicantWorkHistoryPoco>(); 
            _logic = new ApplicantWorkHistoryLogic(Repo);
        }

        public override Task<ApplicantWorkHistoryPayload> ReadApplicantWorkHistory(IdRequest6 request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<ApplicantWorkHistoryPayload>(() => new ApplicantWorkHistoryPayload()
            {
                Id = poco.Id.ToString(),
                Applicant=poco.Applicant.ToString(),
                CompanyName=poco.CompanyName,
                CountryCode =poco.CountryCode,
                Location=poco.Location,
                JobTitle=poco.JobTitle,
                JobDescription=poco.JobDescription,
                StartMonth=poco.StartMonth,
                StartYear=poco.StartYear,
                EndMonth=poco.EndMonth,
                EndYear=poco.EndYear
            }) ;
        }

        public override Task<Empty> CreateApplicantWorkHistory(ApplicantWorkHistoryPayload request, ServerCallContext context)
        {
            ApplicantWorkHistoryPoco[] poco = { new ApplicantWorkHistoryPoco() { 
            Id=Guid.Parse(request.Id),
            Applicant=Guid.Parse(request.Applicant),
            CompanyName = request.CompanyName,
            CountryCode=request.CountryCode,
            Location=request.Location,
            JobDescription=request.JobDescription,
            JobTitle=request.JobTitle,
            StartMonth=(short)request.StartMonth,
            StartYear=request.StartYear,
            EndMonth=(short)request.EndMonth,
            EndYear = request.EndYear
            } };

            _logic.Add(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> UpdateApplicantWorkHistory(ApplicantWorkHistoryPayload request, ServerCallContext context)
        {
            ApplicantWorkHistoryPoco[] poco = { new ApplicantWorkHistoryPoco() {
            Id=Guid.Parse(request.Id),
            Applicant=Guid.Parse(request.Applicant),
            CompanyName = request.CompanyName,
            CountryCode=request.CountryCode,
            Location=request.Location,
            JobDescription=request.JobDescription,
            JobTitle=request.JobTitle,
            StartMonth=(short)request.StartMonth,
            StartYear=request.StartYear,
            EndMonth=(short)request.EndMonth,
            EndYear = request.EndYear
            } };

            _logic.Update(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> DeleteApplicantWorkHistory(ApplicantWorkHistoryPayload request, ServerCallContext context)
        {
            ApplicantWorkHistoryPoco[] poco = { new ApplicantWorkHistoryPoco() {
            Id=Guid.Parse(request.Id),
            Applicant=Guid.Parse(request.Applicant),
            CompanyName = request.CompanyName,
            CountryCode=request.CountryCode,
            Location=request.Location,
            JobDescription=request.JobDescription,
            JobTitle=request.JobTitle,
            StartMonth=(short)request.StartMonth,
            StartYear=request.StartYear,
            EndMonth=(short)request.EndMonth,
            EndYear = request.EndYear
            } };

            _logic.Delete(poco);
            return new Task<Empty>(() => new Empty());
        }
    }
}
