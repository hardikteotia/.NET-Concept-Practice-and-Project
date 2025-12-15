using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SqlServerConnectionLib;
namespace ProductCrud.ProductDAL
{
    class ProductDAL
    {
         SqlServerConnection serverConnection = new SqlServerConnection();

        //microsoft's sqlconnection object
        SqlConnection connectionObject = serverConnection.provideConnection();
        




    }
}
