﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace _12MTestStokProject
{
    public class DataAccess
    {
        SqlConnection sqlConnection = new SqlConnection(@"server=DESKTOP-VPLPK9Q;Initial Catalog = 12mStok; Integrated Security=True");


        public List<DataInfoModel> GetInfo( int baslangıcTarih, int bitisTarih)
        {
            List<DataInfoModel> info;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("12mStok"))) 
            {
                
                var p = new DynamicParameters();
                    p.Add("@BaslangıcTarih", baslangıcTarih);
                    p.Add("@BitisTarih", bitisTarih);
                    
                info = connection.Query<DataInfoModel>("dbo.spSTI_Filter", p, commandType: CommandType.StoredProcedure).ToList();
                
            }
            
            return info;

        }
    }
}
