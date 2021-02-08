using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiant.dao
{
    //T peut être une personne,un detail ou une classe
    public interface IDao<T>
    {

        /*
         * int insert (Personne pers)
         * int insert (Detail det)
         * int insert (Classe classe)
         */
         
         int Insert(T obj);




    }
}
