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
using static CareerCloud.gRPC.Protos.ApplicantSkill;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantSkillService : ApplicantSkillBase
    {
        private readonly ApplicantSkillLogic _logic;

        public ApplicantSkillService()
        {
            EFGenericRepository<ApplicantSkillPoco> Repo = new EFGenericRepository<ApplicantSkillPoco>();
            _logic = new ApplicantSkillLogic(Repo);

        }

        public override Task<ApplicantSkillPayload> ReadApplicantSkill(IdRequest5 request, ServerCallContext context)
        {

            var poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<ApplicantSkillPayload>(
                () => new ApplicantSkillPayload { 
                Id=poco.Id.ToString(),
                Applicant = poco.Applicant.ToString(),
                Skill = poco.Skill,
                SkillLevel=poco.SkillLevel,
                StartMonth=poco.StartMonth,
                StartYear = poco.StartYear,
                EndMonth = poco.EndMonth,
                EndYear=poco.EndYear
                });
        }

        public override Task<Empty> CreateApplicantSkill(ApplicantSkillPayload request, ServerCallContext context)
        {
            ApplicantSkillPoco[] poco = { new ApplicantSkillPoco() { 
            Id=Guid.Parse(request.Id),
            Applicant=Guid.Parse(request.Applicant),
            Skill=request.Skill,
            SkillLevel=request.SkillLevel,
            StartMonth=(byte)request.StartMonth,
            StartYear = request.StartYear,
            EndMonth = (byte)request.EndMonth,
            EndYear = request.EndYear
            } };

            _logic.Add(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> UpdateApplicantSkill(ApplicantSkillPayload request, ServerCallContext context)
        {
            ApplicantSkillPoco[] poco = { new ApplicantSkillPoco() {
            Id=Guid.Parse(request.Id),
            Applicant=Guid.Parse(request.Applicant),
            Skill=request.Skill,
            SkillLevel=request.SkillLevel,
            StartMonth=(byte)request.StartMonth,
            StartYear = request.StartYear,
            EndMonth = (byte)request.EndMonth,
            EndYear = request.EndYear
            } };

            _logic.Update(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> DeleteApplicantSkill(ApplicantSkillPayload request, ServerCallContext context)
        {
            ApplicantSkillPoco[] poco = { new ApplicantSkillPoco() {
            Id=Guid.Parse(request.Id),
            Applicant=Guid.Parse(request.Applicant),
            Skill=request.Skill,
            SkillLevel=request.SkillLevel,
            StartMonth=(byte)request.StartMonth,
            StartYear = request.StartYear,
            EndMonth = (byte)request.EndMonth,
            EndYear = request.EndYear
            } };

            _logic.Delete(poco);
            return new Task<Empty>(() => new Empty());
        }
    }
}
