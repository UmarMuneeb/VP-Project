
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccessLayer
{

	public class DBHelper
	{
		public static SqlConnection GetConnection()
		{
			SqlConnection con = new SqlConnection("Data Source=DESKTOP-69MIFBU\\SQLEXPRESS;Initial Catalog=Ecommerce;Integrated Security=True;Encrypt=False");
				return con;
		}
	}
}
