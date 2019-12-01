using System;
using System.Collections.Generic;
using System.Text;
using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System.Linq.Expressions;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : IDataRepository<ApplicantEducationPoco>
    {
        private readonly string _connStr; 
        public ApplicantEducationRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connStr = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
        public void Add(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                foreach (ApplicantEducationPoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Educations]
           ([Id]
           ,[Applicant]
           ,[Major]
           ,[Certificate_Diploma]
           ,[Start_Date]
           ,[Completion_Date]
           ,[Completion_Percent])
     VALUES
           (@Id
           ,@Applicant
           ,@Major
           ,@Certificate_Diploma
           ,@Start_Date
           ,@Completion_Date
           ,@Completion_Percent)";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                    cmd.Parameters.AddWithValue("Completion_Date", poco.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                foreach (ApplicantEducationPoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = @"DELETE from [dbo].[Applicant_Educations]
                                      where Id=@Id";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                foreach (ApplicantEducationPoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Educations]
                    SET 
                     [Applicant] = @Applicant
                    ,[Major] = @Major
                    ,[Certificate_Diploma] = @Certificate_Diploma
                    ,[Start_Date] = @Start_Date
                    ,[Completion_Date] = @Completion_Date
                    ,[Completion_Percent] = @Completion_Percent
                     WHERE Id=@Id";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                    cmd.Parameters.AddWithValue("Completion_Date", poco.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
