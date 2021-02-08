using GestionEtudiant.models;
using GestionEtudiant.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionEtudiant
{
    public partial class Form1 : Form
    {
        private Service metier = new Service();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtLibelle.Text)
                || string.IsNullOrEmpty(txtNbreEtudiant.Text))
            {
                MessageBox.Show(
                  "Libelle et Nbre Etudiant sont obligatoires",
                  "Message Erreur",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error 
                    );
            }
            else
            {
                Classe classe = new Classe()
                {
                   Libelle=txtLibelle.Text.Trim(),
                   NbreEtudiant=int.Parse(txtNbreEtudiant.Text.Trim())
                };
                if (metier.CreerClasse(classe))
                {
                    MessageBox.Show(
                     "Classe créée avec succèss",
                     "Message Information",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information
                       );
                    //Vider les champs
                    txtLibelle.Clear();
                    txtNbreEtudiant.Clear();
                    //Recharger la DataGridView
                    LoadDataGridView();
                }
            }
             
        }
         private void LoadDataGridView()
        {
            dtgvClasses.DataSource = metier.ListerClasse();
        }

        private void dtgvClasses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            //e.RowIndex: index de la ligne selectionnée
            //1- Recuperer la ligne selectionnée
            DataGridViewRow row = dtgvClasses.Rows[e.RowIndex];
            //2-  Selectionner toute la ligne
            row.Selected = true;
            //3- Recuperation de l'Id Classe
            //row.Cells recupere les cellules de la ligne
            int id = int.Parse(row.Cells[0].Value.ToString());
            Classe classe = new Classe()
            {
               Id=id
            };
            //4- Charger le dtgvEtudiant
            dtgvEtudiant.DataSource = metier.ListerEtudiantParClasse(classe);
        }
    }
}
