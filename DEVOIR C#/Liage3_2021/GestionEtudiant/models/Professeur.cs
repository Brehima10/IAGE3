using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiant.models
{
    class Professeur: Personne
    {
        private string grade;
        private List<string> modules;
        private string matricule;

        //Propiétés
        public string Grade { get => grade; set => grade = value; }
        public List<string> Modules { get => modules; set => modules = value; }
        public string Matricule { get => matricule; set => matricule = value; }

        public Professeur(int id, string nomComplet,string grade,string matricule): base(id,nomComplet)
        {
            this.matricule = matricule;
            this.grade = grade;
            Type = "Professeur";
        }

        public Professeur(string nomComplet, string grade,string matricule) : base(nomComplet)
        {
            this.matricule = matricule;
            this.grade = grade;
            Type = "Professeur";
        }

        public Professeur() 
        {
            Type = "Professeur";
        }

    }
}
