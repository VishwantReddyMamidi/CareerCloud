using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CareerCloud.gRPC.Protos.ApplicantProfile;
using Google.Protobuf.WellKnownTypes;


namespace CareerCloud.gRPC.Services
{
    public class ApplicantProfileService : ApplicantProfileBase
    {
        private readonly ApplicantProfileLogic _logic;

        public ApplicantProfileService()
        {
            EFGenericRepository<ApplicantProfilePoco> Repo = new EFGenericRepository<ApplicantProfilePoco>();
            _logic = new ApplicantProfileLogic(Repo);
        }

        public override Task<ApplicantProfilePayload> ReadApplicantProfile(IdRequest3 request, ServerCallContext context)
             {
            var poco = _logic.Get(Guid.Parse(request.Id));
            return new Task<ApplicantProfilePayload>(
                () => new ApplicantProfilePayload()
                {
                    Id = poco.Id.ToString(),
                    Login = poco.Login.ToString(),
                    CurrentSalary = poco.CurrentSalary is null ?
                                     0.0:
                                     (double)poco.CurrentSalary,
                    CurrentRate = poco.CurrentRate is null ?
                                     0.0:
                                     (double)poco.CurrentSalary,
                    Currency = poco.Currency,
                    Country = poco.Country,
                    Province = poco.Province,
                    Street = poco.Street,
                    City = poco.City,
                    PostalCode = poco.PostalCode
                });

            
        }

        public override Task<Empty> CreateApplicantProfile(ApplicantProfilePayload request, ServerCallContext context)
        {
            var poco = new ApplicantProfilePoco() 
            {
                Id= Guid.Parse(request.Id),
                Login=Guid.Parse(request.Login),
                CurrentSalary=(decimal)request.CurrentSalary,
                CurrentRate=(decimal)request.CurrentRate,
                Currency=request.Currency,
                Country=request.Country,
                Province=request.Province,
                Street=request.Street,
                City=request.City,
                PostalCode=request.PostalCode

            };

            ApplicantProfilePoco[] pocoarray = { poco };
            _logic.Add(pocoarray);
            
            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> UpdateApplicantProfile(ApplicantProfilePayload request, ServerCallContext context)
        {
            var poco = new ApplicantProfilePoco()
            {
                Id = Guid.Parse(request.Id),
                Login = Guid.Parse(request.Login),
                CurrentSalary = (decimal)request.CurrentSalary,
                CurrentRate = (decimal)request.CurrentRate,
                Currency = request.Currency,
                Country = request.Country,
                Province = request.Province,
                Street = request.Street,
                City = request.City,
                PostalCode = request.PostalCode

            };

            ApplicantProfilePoco[] pocoarray = { poco };
            _logic.Update(pocoarray);

            return new Task<Empty>(() => new Empty());
        }

        public override Task<Empty> DeleteApplicantProfile(ApplicantProfilePayload request, ServerCallContext context)
        {
            var poco = new ApplicantProfilePoco()
            {
                Id = Guid.Parse(request.Id),
                Login = Guid.Parse(request.Login),
                CurrentSalary = (decimal)request.CurrentSalary,
                CurrentRate = (decimal)request.CurrentRate,
                Currency = request.Currency,
                Country = request.Country,
                Province = request.Province,
                Street = request.Street,
                City = request.City,
                PostalCode = request.PostalCode

            };

            ApplicantProfilePoco[] pocoarray = { poco };
            _logic.Delete(pocoarray);

            return new Task<Empty>(() => new Empty());
        }
    }
}
