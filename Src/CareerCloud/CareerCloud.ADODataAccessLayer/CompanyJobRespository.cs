using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobRepository : IDataRepository<CompanyjobPoco>
    {
        public void Add(params CompanyjobPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyjobPoco> GetAll(params Expression<Func<CompanyjobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyjobPoco> GetList(Expression<Func<CompanyjobPoco, bool>> where, params Expression<Func<CompanyjobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyjobPoco GetSingle(Expression<Func<CompanyjobPoco, bool>> where, params Expression<Func<CompanyjobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params CompanyjobPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params CompanyjobPoco[] items)
        {
            throw new NotImplementedException();
        }
    }
}
