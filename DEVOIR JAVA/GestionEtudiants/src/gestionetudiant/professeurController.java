/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gestionetudiant;

import java.net.URL;
import java.util.Collection;
import java.util.ResourceBundle;
import javafx.collections.FXCollections;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Alert;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.input.MouseEvent;
import metier.Service;
import models.Classe;

/**
 *
 * @author HP
 */
public class professeurController implements Initializable{

    @FXML
    private TableColumn<?, ?> tbid;
    @FXML
    private TableColumn<?, ?> tbnom;
    @FXML
    private TableColumn<?, ?> tbgrade;
    @FXML
    private TableView<?> obProfesseur;
    private Object tbProfesseur;
    private Service metier;
    @FXML
    private void handleProfesseur(ActionEvent event) {
    }
    public void initialize(URL url, ResourceBundle rb) {
       metier =new Service();
       //Chargement de ObservableList à partir de List de Professeur
       obProfesseur=FXCollections.
                  obProfesseur=FXCollections.
                 observableArrayList(
                          metier.listerClasse()
                 );
                         loadTable();
    }

    
    
    private void loadTable(){
         //Construction des cellule de Table
       tbid.setCellValueFactory(new PropertyValueFactory<>("id"));
       tbnom.setCellValueFactory(new PropertyValueFactory<>("nom"));
       tbgrade.setCellValueFactory(new PropertyValueFactory<>("grade"));
       //TableView se Souscrit à L'observable
       tbProfesseur.setItems(obProfesseur);
    }
    

        
    @FXML
    private void handleShowProfesseur(MouseEvent event) {
        //Recuperer le prof Selectionné
        Classe classeSelected=tbProfesseur
                              .getSelectionModel()
                              .getSelectedItem();
        obProfesseur=FXCollections
                .observableArrayList(
                        metier
                                .listerProfesseurParClasse(classeSelected)
                );
        //Construire les colonnes
        tbid.setCellValueFactory(new PropertyValueFactory<>("id"));
        tbnom.setCellValueFactory(new PropertyValueFactory<>("nomComplet"));
        tbgrade.setCellValueFactory(new PropertyValueFactory<>("tuteur"));
        //Souscription
        tbProfesseur.setItems(obProfesseur);
    }
    
}


