using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        {
        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach(CompanyProfilePoco poco in pocos)
            {
                if(string.IsNullOrEmpty(poco.CompanyWebsite))
                {
                    exceptions.Add(new ValidationException(600, "websites field cannot be empty"));

                }
                else if (!Regex.IsMatch(poco.CompanyWebsite, @"\A(?:[a-z0-9!#$%&'*+\/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+\/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)(com|biz|ca))\z",RegexOptions.IgnoreCase));
                {
                    exceptions.Add(new ValidationException(600, "websites must end with the following extensions – .ca,.com,.biz"));
                }
                if (string.IsNullOrEmpty(poco.ContactPhone))
                {
                    exceptions.Add(new ValidationException(601, "contact phone field cannot be empty"));

                }

                else if (!Regex.IsMatch(poco.ContactPhone, @"\A(?:(416)\-{1})(?:[0-9]{3}\-{1})(?:[0-9]{4})\z", RegexOptions.IgnoreCase));
                {
                    exceptions.Add(new ValidationException(601, "contact number should match the pattern xxx-xxx-xxxx"));
                }
            }
            if(exceptions.Count>0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
    }
}
