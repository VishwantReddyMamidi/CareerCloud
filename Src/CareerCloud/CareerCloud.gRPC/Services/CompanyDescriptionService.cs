﻿using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CareerCloud.gRPC.Protos.CompanyDescription;

namespace CareerCloud.gRPC.Services
{
    public class CompanyDescriptionService : CompanyDescriptionBase
    {
        private readonly CompanyDescriptionLogic _logic;

        public CompanyDescriptionService()
        {
            EFGenericRepository<CompanyDescriptionPoco> Repo = new EFGenericRepository<CompanyDescriptionPoco>();
            _logic = new CompanyDescriptionLogic(Repo);
        }

        public override Task<CompanyDescriptionPayload> ReadCompanyDescription(IdRequest7 request, ServerCallContext context)
        {
            var poco =_logic.Get(Guid.Parse(request.Id));
            return new Task<CompanyDescriptionPayload>(() => new CompanyDescriptionPayload() { 
            Id=poco.Id.ToString(),
            Company=poco.Company.ToString(),
            LanguageId=poco.LanguageId,
            CompanyName=poco.CompanyName,
            CompanyDescription=poco.CompanyDescription
            });
        }

        public override Task<Empty> CreateCompanyDescription(CompanyDescriptionPayload request, ServerCallContext context)
        {
            CompanyDescriptionPoco[] poco = { new CompanyDescriptionPoco() {
            Id = Guid.Parse(request.Id),
            Company = Guid.Parse(request.Company),
            LanguageId= request.LanguageId,
            CompanyName= request.CompanyName,
            CompanyDescription=request.CompanyDescription
            } };

            _logic.Add(poco);
            return new Task<Empty>(()=> new Empty()) ;
        }

        public override Task<Empty> UpdateCompanyDescription(CompanyDescriptionPayload request, ServerCallContext context)
        {
            CompanyDescriptionPoco[] poco = { new CompanyDescriptionPoco() {
            Id = Guid.Parse(request.Id),
            Company = Guid.Parse(request.Company),
            LanguageId= request.LanguageId,
            CompanyName= request.CompanyName,
            CompanyDescription=request.CompanyDescription
            } };

            _logic.Update(poco);
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> DeleteCompanyDescription(CompanyDescriptionPayload request, ServerCallContext context)
        {
            CompanyDescriptionPoco[] poco = { new CompanyDescriptionPoco() {
            Id = Guid.Parse(request.Id),
            Company = Guid.Parse(request.Company),
            LanguageId= request.LanguageId,
            CompanyName= request.CompanyName,
            CompanyDescription=request.CompanyDescription
            } };

            _logic.Delete(poco);
            return new Task<Empty>(() => new Empty());
        }
    }
}