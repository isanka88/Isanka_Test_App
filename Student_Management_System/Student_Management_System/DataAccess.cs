using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Student_Management_System
{
   public class DataAccess
    {
       SqlConnection conn = new SqlConnection("Data Source=DELL-PC;Initial Catalog=QueenceDB;Integrated Security=True");

       /*
         create database QueenceDB
 
        
         create table Registation(
         id varchar(20),
         name varchar(20),
         dob varchar(20),
         grade int,
         active varchar(20)
         ) ;

        */
       public void RegisterStudent(string id, string name, string DOB, int grade, string Active)
       {

           try
           {
               SqlCommand cmd = conn.CreateCommand();
               cmd.CommandText = "Insert into Registation (id,name,dob,grade,active) values (@id,@name,@dob,@grade,@active)";
               cmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = id;
               cmd.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = name;
               cmd.Parameters.Add("@dob", SqlDbType.VarChar, 20).Value = DOB;
               cmd.Parameters.Add("@grade", SqlDbType.Int).Value = grade;
               cmd.Parameters.Add("@active", SqlDbType.VarChar, 20).Value = Active;

               conn.Open();
               cmd.ExecuteNonQuery();
              
           }
           catch (Exception){}
          
           finally
           {
               conn.Close();
           }
       }


       public DataTable getData(string query)
       {
           try
           {
               conn.Open();
               DataTable dt = new DataTable();
               SqlCommand cmd = new SqlCommand(query, conn);
               SqlDataReader reader = cmd.ExecuteReader();
               dt.Load(reader);
               reader.Close();
               return dt;

           }
           catch (Exception) 
           { 
               return null; 
           }

           finally
           {
               conn.Close();
           }
       }

    }
}
