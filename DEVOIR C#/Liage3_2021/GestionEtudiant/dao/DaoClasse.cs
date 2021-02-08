using GestionEtudiant.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiant.dao
{
    public class DaoClasse : IDao<Classe>
    {
        private DaoSql sqlServer;

        public DaoClasse()
        {
            sqlServer = new DaoSql();
        }

        public int Insert(Classe classe)
        {
            string sql = string.Format("INSERT INTO classe" +
                                      "(libelle, nbre_etudiant)" +
                                      " VALUES ('{0}',{1})",
                                      classe.Libelle,classe.NbreEtudiant);
            return sqlServer.ExecuteUpdate(sql);
        }
        public List<Classe> FindAll()
        {
            List<Classe> lClasses=new List<Classe>();
            String sql = String.Format("select * from classe");
            //Remplir la liste

            DataTable dt = sqlServer.ExecuteSelect(sql);
            //Convertir notre DataTable en une  List<Classe> 
            foreach (DataRow row in dt.Rows)
            {
                Classe classe = new Classe();
                classe.Id = int.Parse(row.ItemArray[0].ToString().Trim());
                classe.Libelle = row.ItemArray[1].ToString().Trim();
                classe.NbreEtudiant= int.Parse(row.ItemArray[2].ToString().Trim());
                lClasses.Add(classe);
            }

            return lClasses;
        }


    }
}
