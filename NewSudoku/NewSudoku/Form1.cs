using NewSudoku;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NewSudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            createCells();

            startNewGame();
        }

        SudokuCell[,] cells = new SudokuCell[9, 9];

        private void createCells()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Creation des 81 cases pour le sudoku
                    cells[i, j] = new SudokuCell();
                    cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    cells[i, j].Size = new Size(70, 70);
                    cells[i, j].ForeColor = SystemColors.ControlDarkDark;
                    cells[i, j].Location = new Point(i * 70, j * 70);
                    cells[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray;
                    cells[i, j].FlatStyle = FlatStyle.Flat;
                    cells[i, j].FlatAppearance.BorderColor = Color.Black;
                    cells[i, j].X = i;
                    cells[i, j].Y = j;

                    // mettre une key press pour chaque case
                    cells[i, j].KeyPress += cell_keyPressed;

                    panel1.Controls.Add(cells[i, j]);
                }
            }
        }

        private void cell_keyPressed(object sender, KeyPressEventArgs e)
        {
            var cell = sender as SudokuCell;

            // Ne rien faire si la cellule n'est pas libre 
            if (cell.IsLocked)
                return;

            int value;

            // Ajouter la valeur de la touche pressée dans la cellule uniquement s'il s'agit d'un nombre
            if (int.TryParse(e.KeyChar.ToString(), out value))
            {
                // Efface la valeur de la cellule si la touche pressée est zéro
                if (value == 0)
                    cell.Clear();
                else
                    cell.Text = value.ToString();

                cell.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void startNewGame()
        {
            loadValues();

            var hintsCount = 0;

            if (radioButton1.Checked)
                hintsCount = 45;
            else if (radioButton2.Checked)
                hintsCount = 30;
            else if (radioButton3.Checked)
                hintsCount = 15;

            showRandomValuesHints(hintsCount);
        }

        private void showRandomValuesHints(int hintsCount)
        {
            // Afficher la valeur dans les cellules radom
            // Le nombre d'indices est basé sur le niveau choisi par le joueur
            for (int i = 0; i < hintsCount; i++)
            {
                var rX = random.Next(9);
                var rY = random.Next(9);

                cells[rX, rY].Text = cells[rX, rY].Value.ToString();
                cells[rX, rY].ForeColor = Color.Black;
                cells[rX, rY].IsLocked = true;
            }
        }

        private void loadValues()
        {
            // Effacer les valeurs de chaque cellule
            foreach (var cell in cells)
            {
                cell.Value = 0;
                cell.Clear();
            }

            //Cette méthode sera appelée de manière récurrente jusqu'à ce qu'elle trouve des valeurs appropriées pour chaque cellule. 
            findValueForNextCell(0, -1);
        }

        Random random = new Random();

        private bool findValueForNextCell(int i, int j)
        {
            // Incrémenter les valeurs i et j pour passer à la cellule suivante et si la colonne se termine, passer à la ligne suivante
            if (++j > 8)
            {
                j = 0;

                // Sortir si la ligne se termine
                if (++i > 8)
                    return true;
            }

            var value = 0;
            var numsLeft = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Trouver un nombre aléatoire et valide pour la cellule et passer à la cellule suivante et vérifie si elle peut être attribuée à un autre nombre aléatoire et valide
            do
            {
                // S'il n'y a plus de numéros dans la liste à essayer ensuite, on retourne à la cellule précédente et on lui attribue un autre numéro, revenir à la cellule précédente et lui attribuer un autre numéro.
                if (numsLeft.Count < 1)
                {
                    cells[i, j].Value = 0;
                    return false;
                }

                // Prendre un nombre aléatoire parmi les nombres restants dans la liste
                value = numsLeft[random.Next(0, numsLeft.Count)];
                cells[i, j].Value = value;
                numsLeft.Remove(value);
            }
            while (!isValidNumber(value, i, j) || !findValueForNextCell(i, j));

            return true;
        }

        private bool isValidNumber(int value, int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                // verification colonne
                if (i != y && cells[x, i].Value == value)
                    return false;

                // verification ligne
                if (i != x && cells[i, y].Value == value)
                    return false;
            }

            // verification case 3*3
            for (int i = x - (x % 3); i < x - (x % 3) + 3; i++)
            {
                for (int j = y - (y % 3); j < y - (y % 3) + 3; j++)
                {
                    if (i != x && j != y && cells[i, j].Value == value)
                        return false;
                }
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var wrongCells = new List<SudokuCell>();
            foreach (var cell in cells)
            {
                if (!string.Equals(cell.Value.ToString(), cell.Text))
                {
                    wrongCells.Add(cell);
                }
            }

            if (wrongCells.Any())
            {
                wrongCells.ForEach(x => x.ForeColor = Color.Red);
                MessageBox.Show("Wrong inputs");
            }
            else
            {
                MessageBox.Show("You Wins");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var cell in cells)
            {
                if (cell.IsLocked == false)
                    cell.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            startNewGame();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
