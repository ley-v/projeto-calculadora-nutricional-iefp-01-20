
namespace CalcNutri2
{
    partial class frm_incluirEditarPlano
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCoeficiente = new System.Windows.Forms.ComboBox();
            this.txtNomePlano = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.rdbM = new System.Windows.Forms.RadioButton();
            this.rdbF = new System.Windows.Forms.RadioButton();
            this.lblObservacaoPlano = new System.Windows.Forms.Label();
            this.cmbObjetivo = new System.Windows.Forms.ComboBox();
            this.btnDeletarPlano = new System.Windows.Forms.Button();
            this.btnEditarIncluirPlano = new System.Windows.Forms.Button();
            this.mskPeso = new System.Windows.Forms.MaskedTextBox();
            this.mskIdade = new System.Windows.Forms.MaskedTextBox();
            this.mskAltura = new System.Windows.Forms.MaskedTextBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do Plano Nutricional:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sexo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Idade:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Peso:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Altura:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 34);
            this.label7.TabIndex = 6;
            this.label7.Text = "Coeficiente de atividade:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(199, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Objetivo:";
            // 
            // cmbCoeficiente
            // 
            this.cmbCoeficiente.FormattingEnabled = true;
            this.cmbCoeficiente.Items.AddRange(new object[] {
            "1,2",
            "1,375",
            "1,55",
            "1,725",
            "1,9"});
            this.cmbCoeficiente.Location = new System.Drawing.Point(129, 175);
            this.cmbCoeficiente.Name = "cmbCoeficiente";
            this.cmbCoeficiente.Size = new System.Drawing.Size(66, 24);
            this.cmbCoeficiente.TabIndex = 7;
            this.cmbCoeficiente.SelectedIndexChanged += new System.EventHandler(this.cmbCoeficiente_SelectedIndexChanged);
            this.cmbCoeficiente.Click += new System.EventHandler(this.cmbCoeficiente_Click);
            this.cmbCoeficiente.Enter += new System.EventHandler(this.cmbCoeficiente_Enter);
            this.cmbCoeficiente.Leave += new System.EventHandler(this.cmbCoeficiente_Leave);
            this.cmbCoeficiente.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCoeficiente_PreviewKeyDown);
            // 
            // txtNomePlano
            // 
            this.txtNomePlano.Location = new System.Drawing.Point(129, 35);
            this.txtNomePlano.Name = "txtNomePlano";
            this.txtNomePlano.Size = new System.Drawing.Size(268, 22);
            this.txtNomePlano.TabIndex = 0;
            this.txtNomePlano.Click += new System.EventHandler(this.txtNomePlano_Click);
            this.txtNomePlano.Enter += new System.EventHandler(this.txtNomePlano_Enter);
            this.txtNomePlano.Leave += new System.EventHandler(this.txtNomePlano_Leave);
            this.txtNomePlano.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtNomePlano_PreviewKeyDown);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(129, 70);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(268, 22);
            this.txtNome.TabIndex = 1;
            this.txtNome.Click += new System.EventHandler(this.txtNome_Click);
            this.txtNome.Enter += new System.EventHandler(this.txtNome_Enter);
            this.txtNome.Leave += new System.EventHandler(this.txtNome_Leave);
            this.txtNome.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtNome_PreviewKeyDown);
            // 
            // rdbM
            // 
            this.rdbM.AutoSize = true;
            this.rdbM.Checked = true;
            this.rdbM.Location = new System.Drawing.Point(129, 105);
            this.rdbM.Name = "rdbM";
            this.rdbM.Size = new System.Drawing.Size(40, 21);
            this.rdbM.TabIndex = 2;
            this.rdbM.TabStop = true;
            this.rdbM.Text = "M";
            this.rdbM.UseVisualStyleBackColor = true;
            this.rdbM.Enter += new System.EventHandler(this.rdbM_Enter);
            this.rdbM.Leave += new System.EventHandler(this.rdbM_Leave);
            // 
            // rdbF
            // 
            this.rdbF.AutoSize = true;
            this.rdbF.Location = new System.Drawing.Point(188, 105);
            this.rdbF.Name = "rdbF";
            this.rdbF.Size = new System.Drawing.Size(37, 21);
            this.rdbF.TabIndex = 3;
            this.rdbF.TabStop = true;
            this.rdbF.Text = "F";
            this.rdbF.UseVisualStyleBackColor = true;
            this.rdbF.Enter += new System.EventHandler(this.rdbF_Enter);
            this.rdbF.Leave += new System.EventHandler(this.rdbF_Leave);
            // 
            // lblObservacaoPlano
            // 
            this.lblObservacaoPlano.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblObservacaoPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacaoPlano.Location = new System.Drawing.Point(14, 212);
            this.lblObservacaoPlano.Name = "lblObservacaoPlano";
            this.lblObservacaoPlano.Size = new System.Drawing.Size(383, 69);
            this.lblObservacaoPlano.TabIndex = 17;
            this.lblObservacaoPlano.Text = "Se você se mantém com rotina de exercícios raramente, é necessário multiplicar su" +
    "a TMB por 1,2";
            // 
            // cmbObjetivo
            // 
            this.cmbObjetivo.FormattingEnabled = true;
            this.cmbObjetivo.Items.AddRange(new object[] {
            "Cutting",
            "Manter",
            "Bulking Seco",
            "Bulking Severo"});
            this.cmbObjetivo.Location = new System.Drawing.Point(267, 175);
            this.cmbObjetivo.Name = "cmbObjetivo";
            this.cmbObjetivo.Size = new System.Drawing.Size(130, 24);
            this.cmbObjetivo.TabIndex = 8;
            this.cmbObjetivo.SelectedIndexChanged += new System.EventHandler(this.cmbObjetivo_SelectedIndexChanged);
            this.cmbObjetivo.Click += new System.EventHandler(this.cmbObjetivo_Click);
            this.cmbObjetivo.Enter += new System.EventHandler(this.cmbObjetivo_Enter);
            this.cmbObjetivo.Leave += new System.EventHandler(this.cmbObjetivo_Leave);
            this.cmbObjetivo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbObjetivo_PreviewKeyDown);
            // 
            // btnDeletarPlano
            // 
            this.btnDeletarPlano.Location = new System.Drawing.Point(134, 289);
            this.btnDeletarPlano.Name = "btnDeletarPlano";
            this.btnDeletarPlano.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDeletarPlano.Size = new System.Drawing.Size(100, 35);
            this.btnDeletarPlano.TabIndex = 10;
            this.btnDeletarPlano.Text = "Deletar";
            this.btnDeletarPlano.UseVisualStyleBackColor = true;
            this.btnDeletarPlano.Click += new System.EventHandler(this.btnDeletarPlano_Click);
            // 
            // btnEditarIncluirPlano
            // 
            this.btnEditarIncluirPlano.Location = new System.Drawing.Point(247, 289);
            this.btnEditarIncluirPlano.Name = "btnEditarIncluirPlano";
            this.btnEditarIncluirPlano.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEditarIncluirPlano.Size = new System.Drawing.Size(150, 35);
            this.btnEditarIncluirPlano.TabIndex = 11;
            this.btnEditarIncluirPlano.Text = "Editar/Incluir";
            this.btnEditarIncluirPlano.UseVisualStyleBackColor = true;
            this.btnEditarIncluirPlano.Click += new System.EventHandler(this.btnEditarIncluirPlano_Click);
            // 
            // mskPeso
            // 
            this.mskPeso.Location = new System.Drawing.Point(301, 105);
            this.mskPeso.Name = "mskPeso";
            this.mskPeso.Size = new System.Drawing.Size(96, 22);
            this.mskPeso.TabIndex = 4;
            this.mskPeso.Click += new System.EventHandler(this.mskPeso_Click);
            this.mskPeso.Enter += new System.EventHandler(this.mskPeso_Enter);
            this.mskPeso.Leave += new System.EventHandler(this.mskPeso_Leave);
            this.mskPeso.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.mskPeso_PreviewKeyDown);
            // 
            // mskIdade
            // 
            this.mskIdade.Location = new System.Drawing.Point(129, 140);
            this.mskIdade.Name = "mskIdade";
            this.mskIdade.Size = new System.Drawing.Size(96, 22);
            this.mskIdade.TabIndex = 5;
            this.mskIdade.Click += new System.EventHandler(this.mskIdade_Click);
            this.mskIdade.Enter += new System.EventHandler(this.mskIdade_Enter);
            this.mskIdade.Leave += new System.EventHandler(this.mskIdade_Leave);
            this.mskIdade.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.mskIdade_PreviewKeyDown);
            // 
            // mskAltura
            // 
            this.mskAltura.Location = new System.Drawing.Point(301, 140);
            this.mskAltura.Name = "mskAltura";
            this.mskAltura.Size = new System.Drawing.Size(96, 22);
            this.mskAltura.TabIndex = 6;
            this.mskAltura.Click += new System.EventHandler(this.mskAltura_Click);
            this.mskAltura.Enter += new System.EventHandler(this.mskAltura_Enter);
            this.mskAltura.Leave += new System.EventHandler(this.mskAltura_Leave);
            this.mskAltura.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.mskAltura_PreviewKeyDown);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(57, 289);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLimpar.Size = new System.Drawing.Size(65, 35);
            this.btnLimpar.TabIndex = 9;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // frm_incluirEditarPlano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 333);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.mskAltura);
            this.Controls.Add(this.mskIdade);
            this.Controls.Add(this.mskPeso);
            this.Controls.Add(this.btnDeletarPlano);
            this.Controls.Add(this.btnEditarIncluirPlano);
            this.Controls.Add(this.cmbObjetivo);
            this.Controls.Add(this.lblObservacaoPlano);
            this.Controls.Add(this.rdbF);
            this.Controls.Add(this.rdbM);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtNomePlano);
            this.Controls.Add(this.cmbCoeficiente);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_incluirEditarPlano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incluir/Editar Plano Nutricional";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCoeficiente;
        private System.Windows.Forms.TextBox txtNomePlano;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.RadioButton rdbM;
        private System.Windows.Forms.RadioButton rdbF;
        private System.Windows.Forms.Label lblObservacaoPlano;
        private System.Windows.Forms.ComboBox cmbObjetivo;
        private System.Windows.Forms.Button btnDeletarPlano;
        private System.Windows.Forms.Button btnEditarIncluirPlano;
        private System.Windows.Forms.MaskedTextBox mskPeso;
        private System.Windows.Forms.MaskedTextBox mskIdade;
        private System.Windows.Forms.MaskedTextBox mskAltura;
        private System.Windows.Forms.Button btnLimpar;
    }
}