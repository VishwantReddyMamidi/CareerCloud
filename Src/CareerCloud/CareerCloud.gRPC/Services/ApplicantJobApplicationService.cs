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
using static CareerCloud.gRPC.Protos.ApplicantJobApplication;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantJobApplicationService : ApplicantJobApplicationBase
    {
        private readonly ApplicantJobApplicationLogic _logic;

        public ApplicantJobApplicationService()
        {
            EFGenericRepository<ApplicantJobApplicationPoco> Repo = new EFGenericRepository<ApplicantJobApplicationPoco>();
            _logic = new ApplicantJobApplicationLogic(Repo);
        }

        public override Task<ApplicantJobApplicationPayload> ReadApplicantJobApplication(IdRequest2 request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<ApplicantJobApplicationPayload>(
                () => new ApplicantJobApplicationPayload()
                {
                    Id = poco.Id.ToString(),
                    Applicant=poco.Applicant.ToString(),
                    ApplicationDate=Timestamp.FromDateTime(poco.ApplicationDate),
                    Job=poco.Job.ToString()
                });

        }

        public override Task<Empty> CreateApplicantJobApplication(ApplicantJobApplicationPayload request, ServerCallContext context)
        {
            ApplicantJobApplicationPoco poco = new ApplicantJobApplicationPoco()
            {Id = Guid.Parse(request.Id),
            Applicant= Guid.Parse(request.Applicant),
            Job=Guid.Parse(request.Job),
            ApplicationDate = DateTime.Parse(request.ApplicationDate.ToString())
            };

            ApplicantJobApplicationPoco[] pocoarray = { poco };
            _logic.Add(pocoarray);

            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> UpdateApplicantJobApplication(ApplicantJobApplicationPayload request, ServerCallContext context)
        {
            ApplicantJobApplicationPoco poco = new ApplicantJobApplicationPoco()
            {
                Id = Guid.Parse(request.Id),
                Applicant = Guid.Parse(request.Applicant),
                Job = Guid.Parse(request.Job),
                ApplicationDate = DateTime.Parse(request.ApplicationDate.ToString())
            };

            ApplicantJobApplicationPoco[] pocoarray = { poco };
            _logic.Update(pocoarray);

            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> DeleteApplicantJobApplication(ApplicantJobApplicationPayload request, ServerCallContext context)
        {
            ApplicantJobApplicationPoco poco = new ApplicantJobApplicationPoco()
            {
                Id = Guid.Parse(request.Id),
                Applicant = Guid.Parse(request.Applicant),
                Job = Guid.Parse(request.Job),
                ApplicationDate = DateTime.Parse(request.ApplicationDate.ToString())
            };

            ApplicantJobApplicationPoco[] pocoarray = { poco };
            _logic.Delete(pocoarray);

            return new Task<Empty>(() => new Empty());
        }
    }
}
