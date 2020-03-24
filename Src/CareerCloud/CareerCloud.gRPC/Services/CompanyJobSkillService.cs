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
using static CareerCloud.gRPC.Protos.CompanyJobSkill;

namespace CareerCloud.gRPC.Services
{
    public class CompanyJobSkillService : CompanyJobSkillBase
    {
        private readonly CompanyJobSkillLogic _logic;

        public CompanyJobSkillService()
        {
            EFGenericRepository<CompanyJobSkillPoco> Repo = new EFGenericRepository<CompanyJobSkillPoco>(); 
            _logic = new CompanyJobSkillLogic(Repo);
        }

        public override Task<CompanyJobSkillPayload> ReadCompanyJobSkill(IdRequest11 request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<CompanyJobSkillPayload>(() => new CompanyJobSkillPayload() { 
            Id = poco.Id.ToString(),
            Job = poco.Job.ToString(),
            Importance =poco.Importance,
            Skill= poco.Skill,
            SkillLevel=poco.SkillLevel
            });
        }

        public override Task<Empty> CreateCompanyJobSkill(CompanyJobSkillPayload request, ServerCallContext context)
        {
            CompanyJobSkillPoco[] poco = { new CompanyJobSkillPoco() {
            Id =Guid.Parse(request.Id),
            Job = Guid.Parse(request.Job),
            Importance = request.Importance,
            Skill = request.Skill,
            SkillLevel = request.SkillLevel
            }};
            _logic.Add(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> DeleteCompanyJobSkill(CompanyJobSkillPayload request, ServerCallContext context)
        {
            CompanyJobSkillPoco[] poco = { new CompanyJobSkillPoco() {
            Id =Guid.Parse(request.Id),
            Job = Guid.Parse(request.Job),
            Importance = request.Importance,
            Skill = request.Skill,
            SkillLevel = request.SkillLevel
            }};
            _logic.Delete(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> UpdateCompanyJobSkill(CompanyJobSkillPayload request, ServerCallContext context)
        {
            CompanyJobSkillPoco[] poco = { new CompanyJobSkillPoco() {
            Id =Guid.Parse(request.Id),
            Job = Guid.Parse(request.Job),
            Importance = request.Importance,
            Skill = request.Skill,
            SkillLevel = request.SkillLevel
            }};
            _logic.Update(poco);
            return new Task<Empty>(() => new Empty());
        }
    }
}
