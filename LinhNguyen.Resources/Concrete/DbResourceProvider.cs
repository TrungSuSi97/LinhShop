using LinhNguyen.Resources.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinhNguyen.Resources.Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace LinhNguyen.Resources.Concrete
{
    public class DbResourceProvider : BaseResourceProvider
    {
        // Database create a connection string
        private static string connectionString = null;

        // Create default constructure initilize instance when object is invoked
        public DbResourceProvider()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MainContext"].ConnectionString;
        }

        public DbResourceProvider(string connection)
        {
            connectionString = connection;
        }

        protected override ResourceEntry ReadResource(string name, string culture)
        {
            ResourceEntry resource = null;

            const string sql = "select Culture, Name, Value from [dbo].[Resouces] where culture = @culture and name = @name;";

            using (var con = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@cultrue", culture);
                cmd.Parameters.AddWithValue("@name", name);

                con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        resource = new ResourceEntry
                        {
                            Name = reader["Name"].ToString(),
                            Value = reader["Value"].ToString(),
                            Culture = reader["Culture"].ToString()
                        };
                    }
                    if (!reader.HasRows)
                    {
                        throw new Exception(string.Format($"Resource {name} for culture {culture} is not found"));
                    }
                }
            }

            return resource;
        }

        protected override IList<ResourceEntry> ReadResources()
        {
            var resources = new List<ResourceEntry>();

            const string sql = "select Culture, Name, Value from [dbo].[Resouces];";

            using (var con = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(sql, con);
                con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resources.Add(new ResourceEntry
                        {
                            Name = reader["Name"].ToString(),
                            Value = reader["Value"].ToString(),
                            Culture = reader["Culture"].ToString()
                        });
                    }

                    if (!reader.HasRows)
                    {
                        throw new Exception("No resources were found");
                    }
                }
            }

            return resources;
        }
    }
}
