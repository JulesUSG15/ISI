using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUDOKU
{
    internal class SUDOKU
    {
        //attributs
        private Case[,] grille;
		//constructeur
        public Grille(){
            //on initialise la grille avec un tableau 2 dimensions 9 par 9 avec des objets Case
            initGrille();
            //on remplit la grille initialisée
            remplirBacktrack(0, 'n');
         }
		//methode pour initialiser la grille
        private void initGrille(){
            //on initialise la grille avec un tableau(9,9) d'objet Case
            grille = new Case[9,9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grille[i, j] = new Case();
                }
            }
        }


        private bool nestPasDansColonne(int valeur, int num_col)
        {
            for (int i = 0; i<grille.Length; i++)
            {
                if (grille[i,num_col] == valeur) return false;
            }
            return true;

        }
        private bool nestpasdansligne(int value, int num_ligne)
        {
            bool p = true;
            for (int i = 0; i < 9; i++)
            {
                if (grille[num_ligne, i] == value) p = false;
            }
            return p;
        }

        private bool nestpasdanscarre(int value, int num_col, int num_ligne)
        {
            bool p = true;
            int colonnecarre = num_col / 3;
            int lignecarre = num_ligne / 3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grille[lignecarre3 + i, colonnecarre*3 + j] == value) p = false;
                }
            }
            return p;
        }

        public int getValCase(int ligne, int col)
        {
            return grille[col, ligne].getValeur();
        }
    }
}

//classe Case
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
	
    class Case
    {
    	//attributs
        private bool[] tabValeurs;
        private int valeur;
		
		//constructeur
        public Case(){
            initCase();
        }
		
		//methode pour initialiser le tableau de valeurs de la case (a false)
		//et sa valeur a 0
        private void initCase()
        {
            tabValeurs = new bool[9];
            for (int i = 0; i < 9; i++)
            {
                tabValeurs[i] = false;
            }
            valeur = 0;
        }
		
		//methode pour reinitialiser le tableau de valeurs de la case
        public void resetTab()
        {
            for (int i = 0; i < 9; i++)
            {
                tabValeurs[i] = false;
            }
        }
		
		//methode pour enlever un chiffre des valeurs possibles de la case
        public void setVrai(int indice)
        {
            tabValeurs[indice - 1] = true;
        }
		
		//methode pour modifier la valeur de la case
        public void setValeur(int value)
        {
            valeur = value;
        }
		
		//methode pour obtenir la valeur de la case
        public int getValeur()
        {
            return valeur;
        }
		
		//methode pour recopier (passage par reference) le tableau de valeur de la case
		//dans un tableau passé en argument
        public void getTabValeurs(bool[] tabValCase)
        {
            for (int i = 0; i < 9; i++)
            {
                tabValCase[i] = tabValeurs[i];
            }
            
        }
    }
}


