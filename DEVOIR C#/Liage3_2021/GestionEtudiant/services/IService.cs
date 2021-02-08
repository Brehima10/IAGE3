using GestionEtudiant.entityframework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiant.services
{
    interface IService<C,P>
    {
        //Classe =>ADO.NET
        //classe =>EF

        DataTable ListerEtudiantParClasse(C cl;
        bool CreerClasse(C cl);
        List<C> ListerClasse();
        bool CreerPersonne(P pers);
        P SeConnecter(String login, String pwd);
        P ChercherProfesseurParMatricule(String matricule);
        bool AttribuerClasse(C cl, P pers, List<string> modules,String annee);
        List<P> ListerProfesseur();
        List<String> ListerModulesProfesseurParClasse(P cl);

    }
}
