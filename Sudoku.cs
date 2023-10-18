 private bool nestpasdansligne(int value, int indR)
        {
            bool p=true;
            for(int i=0;i<9;i++){
                if(grille[i,indR].getValeur()==value) p=false;
               }
            return p;
        }

private bool nestpasdanscolonne(int value, int indC)
        {
            bool p=true;
            for(int i=0;i<9;i++){
                if(grille[indC,i].getValeur()==value) p=false;    
                }
            return p;
        }

private bool nestpasdanscarre(int value, int indR, int indC)
        {
            bool p=true;
            int indRcarre=indR/3;
            int indCcarre=indC/3;
            for(int i=0;i<3;i++){
                for(int j=0;j<3;j++){
                    if(grille[indRcarre*3+i,indCcarre*3+j].getValeur()==value) p=false;
                }
            }
            return p;
        }


public class SudokuGenerator {
    private int[,] grille;

    public SudokuGenerator() {
        grille = new int[9, 9];
    }

    public int[,] GenererGrille() {
        GenererGrilleRecursif(0, 0);
        return grille;
    }

    private bool GenererGrilleRecursif(int ligne, int colonne) {
        if (ligne == 9) {
            return true; // grille complétée
        }

        int prochaineLigne = colonne == 8 ? ligne + 1 : ligne;
        int prochaineColonne = colonne == 8 ? 0 : colonne + 1;

        List<int> valeursPossibles = GetValeursPossibles(ligne, colonne);

        foreach (int valeur in valeursPossibles.OrderBy(v => Guid.NewGuid())) {
            grille[ligne, colonne] = valeur;

            if (GenererGrilleRecursif(prochaineLigne, prochaineColonne)) {
                return true;
            }
        }

        grille[ligne, colonne] = 0; // reset la case

        return false;
    }

    private List<int> GetValeursPossibles(int ligne, int colonne) {
        List<int> valeursPossibles = Enumerable.Range(1, 9).ToList();

        for (int i = 0; i < 9; i++) {
            valeursPossibles.Remove(grille[i, colonne]); // enlever les valeurs dans la colonne
            valeursPossibles.Remove(grille[ligne, i]); // enlever les valeurs dans la ligne
        }

        int carreLigne = ligne / 3 * 3;
        int carreColonne = colonne / 3 * 3;

        for (int i = carreLigne; i < carreLigne + 3; i++) {
            for (int j = carreColonne; j < carreColonne + 3; j++) {
                valeursPossibles.Remove(grille[i, j]); // enlever les valeurs dans le carré
            }
        }

        return valeursPossibles;
    }
}