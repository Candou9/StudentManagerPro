﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    //Common DAL
    public class SQLHelper
    {
        private static string connString = "Server=.;DataBase=SMDB;Uid=sa;Pwd=sa";

        //Operate add, delete, correct, query
        public static int Update(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                // write into system log 

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        //Get single result query
        public static object GetSingleResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                // write into system log 

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        //return an result set query
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                // write into system log 
                conn.Close();
                throw ex;
            }
        }
    }
}