using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
    {
        public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
        {
        }

        protected override void Verify(CompanyDescriptionPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach(CompanyDescriptionPoco poco in pocos)
            {
                if(string.IsNullOrEmpty(poco.CompanyDescription))
                {
                    exceptions.Add(new ValidationException(107, "company descriptions must be greater than 2 charachters"));
                }
                else if (poco.CompanyDescription.Length <=2)
                {
                    exceptions.Add(new ValidationException(107, "company descriptions must be greater than 2 charachters"));
                }
                if(string.IsNullOrEmpty(poco.CompanyName))
                {
                    exceptions.Add(new ValidationException(106, "company Name must be greater than 2 charachters"));
                }

               else if (poco.CompanyName.Length <= 2)
                {
                    exceptions.Add(new ValidationException(106, "company Name must be greater than 2 charachters"));
                }

            }
            if(exceptions.Count>0)
            {
                throw new AggregateException(exceptions);
            }
        }
        public override void Add(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
    }
}
