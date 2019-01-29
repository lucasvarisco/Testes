using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Projeto_Blog_DAO
{
    public class dao : IDisposable
    {
        public SqlConnection connection { get; set; }
        public dao()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["blogs"]
            .ConnectionString);
            connection.Open();
            Console.WriteLine("ok");

        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
            Console.WriteLine("des");

        }
    }

}
