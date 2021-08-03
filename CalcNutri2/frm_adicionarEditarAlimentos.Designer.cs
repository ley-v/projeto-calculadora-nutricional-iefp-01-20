
namespace CalcNutri2
{
    partial class frm_adicionarEditarAlimentos
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
            this.lbl_valorT = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeAlimento = new System.Windows.Forms.TextBox();
            this.txtProtAnimal = new System.Windows.Forms.TextBox();
            this.txtProtVegetal = new System.Windows.Forms.TextBox();
            this.txtHCarbono = new System.Windows.Forms.TextBox();
            this.txtLipidio = new System.Windows.Forms.TextBox();
            this.txtFibra = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblObservacaoAlimento = new System.Windows.Forms.Label();
            this.lstAlimentos = new System.Windows.Forms.ListBox();
            this.btnDeletarAlimento = new System.Windows.Forms.Button();
            this.btnIncluirAlimento = new System.Windows.Forms.Button();
            this.txtBuscaAlimento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnEditarAlimento = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_valorT
            // 
            this.lbl_valorT.AutoSize = true;
            this.lbl_valorT.Location = new System.Drawing.Point(313, 121);
            this.lbl_valorT.Name = "lbl_valorT";
            this.lbl_valorT.Size = new System.Drawing.Size(45, 17);
            this.lbl_valorT.TabIndex = 44;
            this.lbl_valorT.Text = "Valor:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(314, 91);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(44, 17);
            this.label32.TabIndex = 43;
            this.label32.Text = "Fibra:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(298, 61);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(60, 17);
            this.label28.TabIndex = 42;
            this.label28.Text = "Lipídios:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(59, 121);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(84, 17);
            this.label24.TabIndex = 41;
            this.label24.Text = "H. Carbono:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(26, 91);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(117, 17);
            this.label20.TabIndex = 40;
            this.label20.Text = "Proteína Vegetal:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(32, 61);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 17);
            this.label16.TabIndex = 39;
            this.label16.Text = "Proteína Animal:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 17);
            this.label1.TabIndex = 45;
            this.label1.Text = "Nome do Alimento:";
            // 
            // txtNomeAlimento
            // 
            this.txtNomeAlimento.Location = new System.Drawing.Point(148, 28);
            this.txtNomeAlimento.Name = "txtNomeAlimento";
            this.txtNomeAlimento.Size = new System.Drawing.Size(315, 22);
            this.txtNomeAlimento.TabIndex = 0;
            this.txtNomeAlimento.Enter += new System.EventHandler(this.txtNomeAlimento_Enter);
            // 
            // txtProtAnimal
            // 
            this.txtProtAnimal.Location = new System.Drawing.Point(148, 58);
            this.txtProtAnimal.Name = "txtProtAnimal";
            this.txtProtAnimal.Size = new System.Drawing.Size(100, 22);
            this.txtProtAnimal.TabIndex = 1;
            this.txtProtAnimal.Enter += new System.EventHandler(this.txtProtAnimal_Enter);
            // 
            // txtProtVegetal
            // 
            this.txtProtVegetal.Location = new System.Drawing.Point(148, 88);
            this.txtProtVegetal.Name = "txtProtVegetal";
            this.txtProtVegetal.Size = new System.Drawing.Size(100, 22);
            this.txtProtVegetal.TabIndex = 2;
            this.txtProtVegetal.Enter += new System.EventHandler(this.txtProtVegetal_Enter);
            // 
            // txtHCarbono
            // 
            this.txtHCarbono.Location = new System.Drawing.Point(148, 118);
            this.txtHCarbono.Name = "txtHCarbono";
            this.txtHCarbono.Size = new System.Drawing.Size(100, 22);
            this.txtHCarbono.TabIndex = 3;
            this.txtHCarbono.Enter += new System.EventHandler(this.txtHCarbono_Enter);
            // 
            // txtLipidio
            // 
            this.txtLipidio.Location = new System.Drawing.Point(363, 58);
            this.txtLipidio.Name = "txtLipidio";
            this.txtLipidio.Size = new System.Drawing.Size(100, 22);
            this.txtLipidio.TabIndex = 4;
            this.txtLipidio.Enter += new System.EventHandler(this.txtLipidio_Enter);
            // 
            // txtFibra
            // 
            this.txtFibra.Location = new System.Drawing.Point(363, 88);
            this.txtFibra.Name = "txtFibra";
            this.txtFibra.Size = new System.Drawing.Size(100, 22);
            this.txtFibra.TabIndex = 5;
            this.txtFibra.Enter += new System.EventHandler(this.txtFibra_Enter);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(363, 118);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 22);
            this.txtValor.TabIndex = 6;
            this.txtValor.Enter += new System.EventHandler(this.txtValor_Enter);
            // 
            // lblObservacaoAlimento
            // 
            this.lblObservacaoAlimento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblObservacaoAlimento.Location = new System.Drawing.Point(23, 156);
            this.lblObservacaoAlimento.Name = "lblObservacaoAlimento";
            this.lblObservacaoAlimento.Size = new System.Drawing.Size(440, 55);
            this.lblObservacaoAlimento.TabIndex = 53;
            this.lblObservacaoAlimento.Text = "Se você se mantém com rotina de exercícios raramente, é necessário multiplicar su" +
    "a TMB por 1,2";
            // 
            // lstAlimentos
            // 
            this.lstAlimentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAlimentos.FormattingEnabled = true;
            this.lstAlimentos.ItemHeight = 16;
            this.lstAlimentos.Location = new System.Drawing.Point(480, 60);
            this.lstAlimentos.Name = "lstAlimentos";
            this.lstAlimentos.Size = new System.Drawing.Size(269, 196);
            this.lstAlimentos.TabIndex = 56;
            this.lstAlimentos.DoubleClick += new System.EventHandler(this.lstAlimentos_DoubleClick);
            this.lstAlimentos.Enter += new System.EventHandler(this.listBox1_Enter);
            // 
            // btnDeletarAlimento
            // 
            this.btnDeletarAlimento.Location = new System.Drawing.Point(133, 221);
            this.btnDeletarAlimento.Name = "btnDeletarAlimento";
            this.btnDeletarAlimento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDeletarAlimento.Size = new System.Drawing.Size(106, 35);
            this.btnDeletarAlimento.TabIndex = 9;
            this.btnDeletarAlimento.Text = "Deletar";
            this.btnDeletarAlimento.UseVisualStyleBackColor = true;
            this.btnDeletarAlimento.Click += new System.EventHandler(this.btnDeletarAlimento_Click);
            this.btnDeletarAlimento.Enter += new System.EventHandler(this.btnDeletarAlimento_Enter);
            // 
            // btnIncluirAlimento
            // 
            this.btnIncluirAlimento.Location = new System.Drawing.Point(357, 221);
            this.btnIncluirAlimento.Name = "btnIncluirAlimento";
            this.btnIncluirAlimento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnIncluirAlimento.Size = new System.Drawing.Size(106, 35);
            this.btnIncluirAlimento.TabIndex = 11;
            this.btnIncluirAlimento.Text = "Incluir";
            this.btnIncluirAlimento.UseVisualStyleBackColor = true;
            this.btnIncluirAlimento.Click += new System.EventHandler(this.btnIncluirAlimento_Click);
            this.btnIncluirAlimento.Enter += new System.EventHandler(this.btnIncluirAlimento_Enter);
            // 
            // txtBuscaAlimento
            // 
            this.txtBuscaAlimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscaAlimento.Location = new System.Drawing.Point(599, 28);
            this.txtBuscaAlimento.Name = "txtBuscaAlimento";
            this.txtBuscaAlimento.Size = new System.Drawing.Size(150, 22);
            this.txtBuscaAlimento.TabIndex = 7;
            this.txtBuscaAlimento.TextChanged += new System.EventHandler(this.txtBuscaAlimento_TextChanged);
            this.txtBuscaAlimento.Enter += new System.EventHandler(this.textBox8_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(480, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 59;
            this.label2.Text = "Buscar Alimento:";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(22, 221);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLimpar.Size = new System.Drawing.Size(105, 35);
            this.btnLimpar.TabIndex = 8;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            this.btnLimpar.Enter += new System.EventHandler(this.btnLimpar_Enter);
            // 
            // btnEditarAlimento
            // 
            this.btnEditarAlimento.Location = new System.Drawing.Point(245, 221);
            this.btnEditarAlimento.Name = "btnEditarAlimento";
            this.btnEditarAlimento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEditarAlimento.Size = new System.Drawing.Size(106, 35);
            this.btnEditarAlimento.TabIndex = 10;
            this.btnEditarAlimento.Text = "Editar";
            this.btnEditarAlimento.UseVisualStyleBackColor = true;
            this.btnEditarAlimento.Click += new System.EventHandler(this.btnEditarAlimento_Click);
            this.btnEditarAlimento.Enter += new System.EventHandler(this.btnEditarAlimento_Enter);
            // 
            // frm_adicionarEditarAlimentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 276);
            this.Controls.Add(this.btnEditarAlimento);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.txtBuscaAlimento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDeletarAlimento);
            this.Controls.Add(this.btnIncluirAlimento);
            this.Controls.Add(this.lstAlimentos);
            this.Controls.Add(this.lblObservacaoAlimento);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtFibra);
            this.Controls.Add(this.txtLipidio);
            this.Controls.Add(this.txtHCarbono);
            this.Controls.Add(this.txtProtVegetal);
            this.Controls.Add(this.txtProtAnimal);
            this.Controls.Add(this.txtNomeAlimento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_valorT);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label16);
            this.Name = "frm_adicionarEditarAlimentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar e Editar Alimentos";
            this.Click += new System.EventHandler(this.frm_adicionarEditarAlimentos_Click);
            this.Enter += new System.EventHandler(this.frm_adicionarEditarAlimentos_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_valorT;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeAlimento;
        private System.Windows.Forms.TextBox txtProtAnimal;
        private System.Windows.Forms.TextBox txtProtVegetal;
        private System.Windows.Forms.TextBox txtHCarbono;
        private System.Windows.Forms.TextBox txtLipidio;
        private System.Windows.Forms.TextBox txtFibra;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblObservacaoAlimento;
        private System.Windows.Forms.ListBox lstAlimentos;
        private System.Windows.Forms.Button btnDeletarAlimento;
        private System.Windows.Forms.Button btnIncluirAlimento;
        private System.Windows.Forms.TextBox txtBuscaAlimento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnEditarAlimento;
    }
}