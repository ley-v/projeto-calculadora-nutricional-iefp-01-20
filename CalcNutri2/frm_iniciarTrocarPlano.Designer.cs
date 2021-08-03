
namespace CalcNutri2
{
    partial class frm_iniciarTrocarPlano
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstPlanos = new System.Windows.Forms.ListBox();
            this.btnSelecionarPlano = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstPlanos
            // 
            this.lstPlanos.FormattingEnabled = true;
            this.lstPlanos.ItemHeight = 16;
            this.lstPlanos.Location = new System.Drawing.Point(12, 12);
            this.lstPlanos.Name = "lstPlanos";
            this.lstPlanos.Size = new System.Drawing.Size(311, 244);
            this.lstPlanos.TabIndex = 0;
            this.lstPlanos.DoubleClick += new System.EventHandler(this.btnSelecionarPlano_Click);
            // 
            // btnSelecionarPlano
            // 
            this.btnSelecionarPlano.Location = new System.Drawing.Point(53, 271);
            this.btnSelecionarPlano.Name = "btnSelecionarPlano";
            this.btnSelecionarPlano.Size = new System.Drawing.Size(229, 50);
            this.btnSelecionarPlano.TabIndex = 1;
            this.btnSelecionarPlano.Text = "Selecionar Plano Nutricional";
            this.btnSelecionarPlano.UseVisualStyleBackColor = true;
            this.btnSelecionarPlano.Click += new System.EventHandler(this.btnSelecionarPlano_Click);
            // 
            // frm_iniciarTrocarPlano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 335);
            this.Controls.Add(this.btnSelecionarPlano);
            this.Controls.Add(this.lstPlanos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_iniciarTrocarPlano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar/Trocar de Plano";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstPlanos;
        private System.Windows.Forms.Button btnSelecionarPlano;
    }
}