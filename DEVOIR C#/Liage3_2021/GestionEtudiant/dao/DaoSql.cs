using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiant.dao
{
    class DaoSql
    {
        //Gerer la connexion dans la base de donnée SqlServer
        private SqlConnection conn;
        //Execution de la requette
        private SqlCommand cmd;

        //Convertir les enregistrements de la BD dans un DataSet
        private SqlDataAdapter da;

        public DaoSql()
        {
            conn = new SqlConnection();
            cmd = new SqlCommand();
            da = new SqlDataAdapter();
        }

        public void OuvrirConnexionBD()
        {
            if (conn.State == ConnectionState.Closed || 
                conn.State == ConnectionState.Broken)
            {
                conn.ConnectionString = @"Data Source= DESKTOP-7O52489 ; Initial Catalog = gestion_etudiant; Integrated Security= True";

                conn.Open();
            }

        }

        public void FermerConnexionBD()
        {
            if (conn.State == ConnectionState.Open ||
                conn.State == ConnectionState.Connecting)
            {
                conn.Close();
            }

        }

        public int ExecuteUpdate(string sql)
        {
            int nbreLigne = 0;

            OuvrirConnexionBD();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            nbreLigne=cmd.ExecuteNonQuery();

            FermerConnexionBD();

            return nbreLigne;
        }
        public DataTable ExecuteSelect(string sql)
        {
            OuvrirConnexionBD();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            //DataSet => Base de donnee en memoire centrale
            //Un DataSet est formé de DataTable => Table BD

            DataSet ds = new DataSet();

            da.SelectCommand = cmd;

            da.Fill(ds,"result");

            FermerConnexionBD();

            return ds.Tables["result"];
        }

     
    }
}
