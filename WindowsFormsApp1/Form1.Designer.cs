namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblPlayer = new System.Windows.Forms.Label();
            this.btnCouleur = new System.Windows.Forms.Button();
            this.btnRejouer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(64, 18);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(46, 17);
            this.lblPlayer.TabIndex = 0;
            this.lblPlayer.Text = "label1";
            // 
            // btnCouleur
            // 
            this.btnCouleur.Enabled = false;
            this.btnCouleur.Location = new System.Drawing.Point(20, 5);
            this.btnCouleur.Name = "btnCouleur";
            this.btnCouleur.Size = new System.Drawing.Size(40, 40);
            this.btnCouleur.TabIndex = 1;
            this.btnCouleur.UseVisualStyleBackColor = true;
            // 
            // btnRejouer
            // 
            this.btnRejouer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRejouer.BackgroundImage")));
            this.btnRejouer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRejouer.Location = new System.Drawing.Point(345, 370);
            this.btnRejouer.Name = "btnRejouer";
            this.btnRejouer.Size = new System.Drawing.Size(50, 50);
            this.btnRejouer.TabIndex = 2;
            this.btnRejouer.UseVisualStyleBackColor = true;
            this.btnRejouer.Click += new System.EventHandler(this.btnRejouer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 485);
            this.Controls.Add(this.btnRejouer);
            this.Controls.Add(this.btnCouleur);
            this.Controls.Add(this.lblPlayer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = " Puissance 4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Button btnCouleur;
        private System.Windows.Forms.Button btnRejouer;
    }
}

