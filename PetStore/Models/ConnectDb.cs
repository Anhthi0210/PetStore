using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class ConnectDb
    {
        public SqlConnection connect = new SqlConnection(@"Data Source=MRTHAWNG;Initial Catalog=PetStore;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

    }
}