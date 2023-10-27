using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int nbClick = 0;
        Button btnCouleur = new Button();
        List<Button> btnList = new List<Button>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateButtons(50);
            Initbuttons();
            PlayerChange();
            WinDiagonale();
        }

        /// <summary>
        /// Création des boutons
        /// </summary>
        /// <param name="taille"></param>
        private void CreateButtons(int taille)
        {
            btnList.Clear();
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {

                    Button btn = new Button();
                    Controls.Add(btn);
                    btn.Size = new Size(taille, taille);
                    btn.Visible = true;
                    btn.Enabled = false;
                    btn.Location = new Point(15 + (taille + 5) * x, 40 + (taille + 5) * y);
                    btn.Click += new EventHandler(button_Click);
                    btnList.Add(btn);
                }
            }
            Controls.Add(btnCouleur);
            btnCouleur.Size = new Size(30, 30);
            btnCouleur.Visible = true;
            btnCouleur.Enabled = false;
            btnCouleur.Location = new Point(15, 5);
            btnCouleur.BackColor = Color.Red;
        }

        private void Initbuttons()
        {
            for (int k = 0; k < 7; k++)
            {
                btnList[41 - 6 * k].Enabled = true;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            nbClick++;
            var indice = btnList.IndexOf((Button)sender);
            btnList[indice].Enabled = false;
            EnableNextButton(indice);

            if (lblPlayer.Text == "Au tour du joueur rouge")
            {
                btnList[indice].BackColor = Color.Red;
            }
            else
            {
                btnList[indice].BackColor = Color.Yellow;
            }
            PlayerChange();
            if (WinLigne()||WinColonne()||WinDiagonale())
            {
                foreach(Button btn in btnList)
                {
                    btn.Enabled = false;
                }
                if(btnList[indice].BackColor == Color.Red)
                {
                    lblPlayer.Text = "Le joueur rouge à gagné !";
                    btnCouleur.BackColor = Color.Red;
                }
                else
                {
                    lblPlayer.Text = "Le joueur jaune à gagné !";
                    btnCouleur.BackColor = Color.Yellow;
                }
            }
            else
            {
                if (nbClick == 42)
                {
                    lblPlayer.Text = "Egalité !";
                    btnCouleur.BackColor = DefaultBackColor;
                }
            }
        }

        private void EnableNextButton(int indice)
        {
            if(indice != 0 && btnList[indice-1].BackColor == DefaultBackColor)
            {
            btnList[indice - 1].Enabled = true;
            }
        }

        private void PlayerChange()
        {
            {
                if (lblPlayer.Text == "Au tour du joueur rouge")
                {
                    lblPlayer.Text = "Au tour du joueur jaune";
                    btnCouleur.BackColor = Color.Yellow;
                }
                else
                {
                    lblPlayer.Text = "Au tour du joueur rouge";
                    btnCouleur.BackColor = Color.Red;
                }
            }

        }

        private bool TestVictoire(List<Button> buttons, int i)
        {
            //k doit être 3 pour les colonnes et 4 pour les lignes en raison de l'asymétrie du plateau
            //k dépend aussi de la taille des diagonales. 
            for (int k = 0; k < i; k++)
            {
                if (buttons[k].BackColor == buttons[k + 1].BackColor && buttons[k + 1].BackColor == buttons[k + 2].BackColor
                        && buttons[k + 2].BackColor == buttons[k + 3].BackColor && buttons[k + 3].BackColor != DefaultBackColor)
                {
                    return true;
                }
            }return false;

        }

        //fonction permettant de déterminer si l'un des joueur à gagné sur une colonne
        private bool WinColonne()
        {
            int i = 6;
            List<Button> col1 = new List<Button>();
            List<Button> col2 = new List<Button>();
            List<Button> col3 = new List<Button>();
            List<Button> col4 = new List<Button>();
            List<Button> col5 = new List<Button>();
            List<Button> col6 = new List<Button>();
            List<Button> col7 = new List<Button>();
            //On découpe la Liste des boutons en colonnes
            for (int k = 0; k < 6; k++)
            {
                col1.Add(btnList[k]);
                col2.Add(btnList[i+k]);
                col3.Add(btnList[2*i + k]);
                col4.Add(btnList[3 * i + k]);
                col5.Add(btnList[4 * i + k]);
                col6.Add(btnList[5 * i + k]);
                col7.Add(btnList[6 * i + k]);
            }
           if(TestVictoire(col1,3)||TestVictoire(col2,3)||TestVictoire(col3,3)||TestVictoire(col4,3)
                || TestVictoire(col5,3) || TestVictoire(col6,3) || TestVictoire(col7,3))
            {
                return true;
            }
            return false;
        }

        //même chose mais sur les lignes
        private bool WinLigne()
        {
            List<Button> lig1 = new List<Button>();
            List<Button> lig2 = new List<Button>();
            List<Button> lig3 = new List<Button>();
            List<Button> lig4 = new List<Button>();
            List<Button> lig5 = new List<Button>();
            List<Button> lig6 = new List<Button>();

            //On découpe la liste des boutons en lignes
            for (int k= 0; k<7; k++)
            {
                lig1.Add(btnList[6 * k]);
                lig2.Add(btnList[6 * k + 1]);
                lig3.Add(btnList[6 * k + 2]);
                lig4.Add(btnList[6 * k + 3]);
                lig5.Add(btnList[6 * k + 4]);
                lig6.Add(btnList[6 * k + 5]);
            }
            if (TestVictoire(lig1,4) || TestVictoire(lig2,4) || TestVictoire(lig3,4) || TestVictoire(lig4,4)
               || TestVictoire(lig5,4) || TestVictoire(lig6,4))
            {
                return true;
            }
            return false;
        }

        //même fonctionne sur les diagonales
        private bool WinDiagonale()
        {
            //il y a cette fois-ci différentes tailles de diagonales possibles, on va donc créer les listes séparément en fonction de leur taille
            List<Button> dia41 = new List<Button>();
            List<Button> dia42 = new List<Button>();
            List<Button> dia43 = new List<Button>();
            List<Button> dia44 = new List<Button>();

            //diagonales de taille 4 :
            for (int k=0; k<4; k++)
            {
                dia41.Add(btnList[2+k*7]);
                dia42.Add(btnList[18 + k * 7]);
                dia43.Add(btnList[3+k*5]);
                dia44.Add(btnList[23 + k * 5]);

            }

            List<Button> dia51 = new List<Button>();
            List<Button> dia52 = new List<Button>();
            List<Button> dia53 = new List<Button>();
            List<Button> dia54 = new List<Button>();
            //diagonales de taille 5 :
            for (int k = 0; k < 5; k++)
            {
                dia51.Add(btnList[4+5*k]);
                dia52.Add(btnList[17 + 5 * k]);
                dia53.Add(btnList[1 + 7 * k]);
                dia54.Add(btnList[12+7*k]);
            }
            List<Button> dia61 = new List<Button>();
            List<Button> dia62 = new List<Button>();
            List<Button> dia63 = new List<Button>();
            List<Button> dia64 = new List<Button>();
            //diagonales de taille 6 :
            for (int k=0; k < 6; k++)
            {
                dia61.Add(btnList[7*k]);
                dia62.Add(btnList[6 + 7 * k]);
                dia63.Add(btnList[5 + 5 * k]);
                dia64.Add(btnList[11 + 5 * k]);
            }
            if (TestVictoire(dia41, 1) || TestVictoire(dia42, 1) 
               || TestVictoire(dia43, 1) || TestVictoire(dia44, 1))
            {
                return true;
            }
            if (TestVictoire(dia51, 2) || TestVictoire(dia52, 2)
               || TestVictoire(dia53, 2) || TestVictoire(dia54, 2))
            {
                return true;
            }
            if (TestVictoire(dia61, 3) || TestVictoire(dia62, 3)
               || TestVictoire(dia63, 3) || TestVictoire(dia64, 3))
            {
                return true;
            }
            return false;

        }
    }
}
