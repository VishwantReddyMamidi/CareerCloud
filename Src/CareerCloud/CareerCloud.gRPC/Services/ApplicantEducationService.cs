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
using static CareerCloud.gRPC.Protos.ApplicantEducation;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantEducationService : ApplicantEducationBase
    {
        private readonly ApplicantEducationLogic _logic;

        public ApplicantEducationService()
        {
            EFGenericRepository<ApplicantEducationPoco> repo = new EFGenericRepository<ApplicantEducationPoco>();
            _logic = new ApplicantEducationLogic(repo);
        }
        public override Task<ApplicantEducationPayload> ReadApplicantEducation(IdRequest request, ServerCallContext context)
        {

            var poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<ApplicantEducationPayload>(
                () => new ApplicantEducationPayload()
                {
                    Id=poco.Id.ToString(),
                    Applicant=poco.Applicant.ToString(),
                    CertificateDiploma = poco.CertificateDiploma,
                    CompletionDate = poco.CompletionDate is null ?
                                     null : 
                                     Timestamp.FromDateTime((DateTime)poco.CompletionDate),
                    CompletionPercent = poco.CompletionPercent is null ?
                                     0 : 
                                     (int) poco.CompletionPercent,
                    Major=poco.Major,
                    StartDate = poco.StartDate is null ?
                                 null :
                                 Timestamp.FromDateTime((DateTime) poco.StartDate)

                }
                );
        }

        public override Task<Empty> CreateApplicantEducation(ApplicantEducationPayload request, ServerCallContext context)
        {
            ApplicantEducationPoco poco = new ApplicantEducationPoco()
            {
                Id = Guid.Parse(request.Id),
                Applicant = Guid.Parse(request.Applicant),
                Major = request.Major,
                CertificateDiploma = request.CertificateDiploma,
                CompletionDate = DateTime.Parse(request.CompletionDate.ToString()),
                CompletionPercent = (byte)request.CompletionPercent,
                StartDate = DateTime.Parse(request.StartDate.ToString())
            };

            ApplicantEducationPoco[] pocoarray = { poco };
            _logic.Add(pocoarray);
           return new Task<Empty>(()=>new Empty());
        }

        public override Task<Empty> UpdateApplicantEducation(ApplicantEducationPayload request, ServerCallContext context)
        {
            ApplicantEducationPoco poco = new ApplicantEducationPoco()
            {
                Id = Guid.Parse(request.Id),
                Applicant = Guid.Parse(request.Applicant),
                Major = request.Major,
                CertificateDiploma = request.CertificateDiploma,
                CompletionDate = DateTime.Parse(request.CompletionDate.ToString()),
                CompletionPercent = (byte)request.CompletionPercent,
                StartDate = DateTime.Parse(request.StartDate.ToString())
            };

            ApplicantEducationPoco[] pocoarray = { poco };
            _logic.Update(pocoarray);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> DeleteApplicantEducation(ApplicantEducationPayload request, ServerCallContext context)
        {
            ApplicantEducationPoco poco = new ApplicantEducationPoco()
            {
                Id = Guid.Parse(request.Id),
                Applicant = Guid.Parse(request.Applicant),
                Major = request.Major,
                CertificateDiploma = request.CertificateDiploma,
                CompletionDate = DateTime.Parse(request.CompletionDate.ToString()),
                CompletionPercent = (byte)request.CompletionPercent,
                StartDate = DateTime.Parse(request.StartDate.ToString())
            };

            ApplicantEducationPoco[] pocoarray = { poco };
            //_logic.Delete(pocoarray);
            return new Task<Empty>(() => new Empty());
        }
    }
}
