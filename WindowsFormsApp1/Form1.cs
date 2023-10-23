﻿using System;
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
        }

        /// <summary>
        /// Création des boutons
        /// </summary>
        /// <param name="taille"></param>
        private void CreateButtons(int taille)
        {
            int k = 0;
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

            if (lblPlayer.Text == "Joueur Rouge")
            {
                btnList[indice].BackColor = Color.Red;
            }
            else
            {
                btnList[indice].BackColor = Color.Yellow;
            }
            PlayerChange();
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
                if (lblPlayer.Text == "Joueur Rouge")
                {
                    lblPlayer.Text = "Joueur Jaune";
                }
                else
                {
                    lblPlayer.Text = "Joueur Rouge";
                }
            }
        }
    }
}
