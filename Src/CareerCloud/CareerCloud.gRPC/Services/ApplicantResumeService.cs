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
using static CareerCloud.gRPC.Protos.ApplicantResume;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantResumeService : ApplicantResumeBase
    {
        private readonly ApplicantResumeLogic _logic;

        public ApplicantResumeService()
        {
            EFGenericRepository<ApplicantResumePoco> Repo = new EFGenericRepository<ApplicantResumePoco>(); 
            _logic = new ApplicantResumeLogic(Repo);
        }

        public override Task<ApplicantResumePayload> ReadApplicantResume(IdRequest4 request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<ApplicantResumePayload>(
                () => new ApplicantResumePayload()
                {
                    Id = poco.Id.ToString(),
                    Applicant = poco.Applicant.ToString(),
                    Resume = poco.Resume,
                    LastUpdated = Timestamp.FromDateTime((DateTime)poco.LastUpdated)
                }); ;
        }

        public override Task<Empty> CreateApplicantResume(ApplicantResumePayload request, ServerCallContext context)
        {
            ApplicantResumePoco[] poco = {new ApplicantResumePoco()

            { Id = Guid.Parse(request.Id),
                Applicant = Guid.Parse(request.Applicant),
                Resume = request.Resume,
                LastUpdated = DateTime.Parse(request.LastUpdated.ToString())
            } };

            _logic.Add(poco);

            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> UpdateApplicantResume(ApplicantResumePayload request, ServerCallContext context)
        {
            ApplicantResumePoco[] poco = {new ApplicantResumePoco()

            {
                Id = Guid.Parse(request.Id),
                Applicant = Guid.Parse(request.Applicant),
                Resume = request.Resume,
                LastUpdated = DateTime.Parse(request.LastUpdated.ToString())
            } };

            _logic.Update(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> DeleteApplicantResume(ApplicantResumePayload request, ServerCallContext context)
        {
            ApplicantResumePoco[] poco = {new ApplicantResumePoco()

            {
                Id = Guid.Parse(request.Id),
                Applicant = Guid.Parse(request.Applicant),
                Resume = request.Resume,
                LastUpdated = DateTime.Parse(request.LastUpdated.ToString())
            } };

            _logic.Delete(poco);
            return new Task<Empty>(() => new Empty());
        }
    }
}
