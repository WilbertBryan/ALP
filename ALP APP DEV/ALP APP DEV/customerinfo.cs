using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

internal class customerinfo
{
    string query = "";
    string connection = "server=localhost;uid=root;pwd=root;database=db_concert";
    MySqlConnection sqlConnection;
    MySqlCommand sqlCommand;
    MySqlDataAdapter sqlDataAdapter;
    DataTable dtCustomer = new DataTable();

    public string setId(string email)
    {
        query = $"SELECT id_cust from customer where email_cust='{email}';";
        sqlCommand = new MySqlCommand(query, sqlConnection);
        sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
        sqlDataAdapter.Fill(dtCustomer);
        string id=dtCustomer.Rows[0][0].ToString();
        return id;
    }
}

