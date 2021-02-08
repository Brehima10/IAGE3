using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEtudiant.dao ;
using GestionEtudiant.models;

namespace Fondamentaux
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
                *Variables
                
               
            int id = 1;
            double qte = 4.5 ;
            bool result = true ;
            String chaine = "Bonjour";
            string chaine2 = "Bonjour";

            Console.WriteLine("id:" + id);
            */
            #region Test DaoClasse
            //1-Creer un objet DaoClasse
            DaoClasse dao = new DaoClasse();
            Classe classe = new Classe()
            {
                Libelle="GLRS3", 
                NbreEtudiant=30
            };
            //2-insert()
            dao.Insert(classe);


            //3-findAllClasse() et Afficher
            List<Classe> classes = dao.FindAll();
            foreach(var cl in classes)
            {
                Console.WriteLine(cl);

            }
            #endregion
        }
    }
}
