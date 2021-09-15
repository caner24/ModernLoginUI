using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ModernLoginUI
{
    class MyDatabase
    {
        public SqlConnection baglanti()
        {
            SqlConnection sqlConnect = new SqlConnection(@"Data Source=DESKTOP-UU33E1H\SQLEXPRESS;Initial Catalog=Dbo_ModernLogin;Integrated Security=True");
            sqlConnect.Open();
            return sqlConnect;
        }
    }
}
