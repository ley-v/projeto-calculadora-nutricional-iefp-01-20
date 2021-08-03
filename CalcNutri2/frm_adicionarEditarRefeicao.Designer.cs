
namespace CalcNutri2
{
    partial class frm_adicionarEditarRefeicao
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
            this.components = new System.ComponentModel.Container();
            this.lstRefeicao = new System.Windows.Forms.ListBox();
            this.txtNomeRef = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnDeletarRefeicao = new System.Windows.Forms.Button();
            this.btnAdicionarRefeicao = new System.Windows.Forms.Button();
            this.lstAlimento = new System.Windows.Forms.ListBox();
            this.btnIncluirAlimento = new System.Windows.Forms.Button();
            this.txtBuscaAlimento = new System.Windows.Forms.TextBox();
            this.picExclamacao = new System.Windows.Forms.PictureBox();
            this.dicaExclamacao = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picExclamacao)).BeginInit();
            this.SuspendLayout();
            // 
            // lstRefeicao
            // 
            this.lstRefeicao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRefeicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.lstRefeicao.FormattingEnabled = true;
            this.lstRefeicao.ItemHeight = 20;
            this.lstRefeicao.Location = new System.Drawing.Point(12, 84);
            this.lstRefeicao.Name = "lstRefeicao";
            this.lstRefeicao.Size = new System.Drawing.Size(270, 104);
            this.lstRefeicao.TabIndex = 1;
            this.lstRefeicao.Click += new System.EventHandler(this.lstRefeicao_Click);
            this.lstRefeicao.SelectedIndexChanged += new System.EventHandler(this.lstRefeicao_SelectedIndexChanged);
            this.lstRefeicao.SelectedValueChanged += new System.EventHandler(this.lstRefeicao_SelectedValueChanged);
            this.lstRefeicao.CursorChanged += new System.EventHandler(this.lstRefeicao_CursorChanged);
            this.lstRefeicao.DoubleClick += new System.EventHandler(this.lstRefeicao_DoubleClick);
            this.lstRefeicao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstRefeicao_KeyDown);
            // 
            // txtNomeRef
            // 
            this.txtNomeRef.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtNomeRef.Location = new System.Drawing.Point(12, 45);
            this.txtNomeRef.Name = "txtNomeRef";
            this.txtNomeRef.Size = new System.Drawing.Size(270, 27);
            this.txtNomeRef.TabIndex = 0;
            this.txtNomeRef.TextChanged += new System.EventHandler(this.txtNomeRef_TextChanged);
            this.txtNomeRef.Enter += new System.EventHandler(this.txtNomeRef_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label1.Location = new System.Drawing.Point(58, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "Nome da Refeição:";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtQuantidade.Location = new System.Drawing.Point(132, 455);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(150, 27);
            this.txtQuantidade.TabIndex = 6;
            this.txtQuantidade.Tag = "";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label16.Location = new System.Drawing.Point(14, 458);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 20);
            this.label16.TabIndex = 49;
            this.label16.Text = "Quantidade:";
            // 
            // btnDeletarRefeicao
            // 
            this.btnDeletarRefeicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnDeletarRefeicao.Location = new System.Drawing.Point(12, 187);
            this.btnDeletarRefeicao.Name = "btnDeletarRefeicao";
            this.btnDeletarRefeicao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDeletarRefeicao.Size = new System.Drawing.Size(100, 35);
            this.btnDeletarRefeicao.TabIndex = 2;
            this.btnDeletarRefeicao.Tag = "";
            this.btnDeletarRefeicao.Text = "Deletar";
            this.btnDeletarRefeicao.UseVisualStyleBackColor = true;
            this.btnDeletarRefeicao.Click += new System.EventHandler(this.btnDeletarRefeicao_Click);
            // 
            // btnAdicionarRefeicao
            // 
            this.btnAdicionarRefeicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnAdicionarRefeicao.Location = new System.Drawing.Point(130, 187);
            this.btnAdicionarRefeicao.Name = "btnAdicionarRefeicao";
            this.btnAdicionarRefeicao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdicionarRefeicao.Size = new System.Drawing.Size(152, 35);
            this.btnAdicionarRefeicao.TabIndex = 3;
            this.btnAdicionarRefeicao.Tag = "";
            this.btnAdicionarRefeicao.Text = "Incluir";
            this.btnAdicionarRefeicao.UseVisualStyleBackColor = true;
            this.btnAdicionarRefeicao.Click += new System.EventHandler(this.btnAdicionarRefeicao_Click);
            // 
            // lstAlimento
            // 
            this.lstAlimento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAlimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.lstAlimento.FormattingEnabled = true;
            this.lstAlimento.ItemHeight = 20;
            this.lstAlimento.Location = new System.Drawing.Point(12, 230);
            this.lstAlimento.Name = "lstAlimento";
            this.lstAlimento.Size = new System.Drawing.Size(270, 184);
            this.lstAlimento.TabIndex = 4;
            this.lstAlimento.Click += new System.EventHandler(this.lstAlimento_Click);
            this.lstAlimento.DoubleClick += new System.EventHandler(this.lstAlimento_DoubleClick);
            this.lstAlimento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstAlimento_KeyDown);
            // 
            // btnIncluirAlimento
            // 
            this.btnIncluirAlimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIncluirAlimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnIncluirAlimento.Location = new System.Drawing.Point(130, 492);
            this.btnIncluirAlimento.Name = "btnIncluirAlimento";
            this.btnIncluirAlimento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnIncluirAlimento.Size = new System.Drawing.Size(152, 35);
            this.btnIncluirAlimento.TabIndex = 8;
            this.btnIncluirAlimento.Tag = "";
            this.btnIncluirAlimento.Text = "Incluir";
            this.btnIncluirAlimento.UseVisualStyleBackColor = true;
            this.btnIncluirAlimento.Click += new System.EventHandler(this.btnIncluirEditarAlimento_Click);
            // 
            // txtBuscaAlimento
            // 
            this.txtBuscaAlimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscaAlimento.Enabled = false;
            this.txtBuscaAlimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtBuscaAlimento.Location = new System.Drawing.Point(12, 417);
            this.txtBuscaAlimento.Name = "txtBuscaAlimento";
            this.txtBuscaAlimento.Size = new System.Drawing.Size(270, 27);
            this.txtBuscaAlimento.TabIndex = 5;
            this.txtBuscaAlimento.Tag = "";
            this.txtBuscaAlimento.TextChanged += new System.EventHandler(this.txtBuscaAlimento_TextChanged);
            this.txtBuscaAlimento.Enter += new System.EventHandler(this.txtBuscaAlimento_Enter);
            // 
            // picExclamacao
            // 
            this.picExclamacao.Location = new System.Drawing.Point(8, 8);
            this.picExclamacao.Name = "picExclamacao";
            this.picExclamacao.Size = new System.Drawing.Size(20, 20);
            this.picExclamacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExclamacao.TabIndex = 57;
            this.picExclamacao.TabStop = false;
            // 
            // frm_adicionarEditarRefeicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 545);
            this.Controls.Add(this.picExclamacao);
            this.Controls.Add(this.txtBuscaAlimento);
            this.Controls.Add(this.btnIncluirAlimento);
            this.Controls.Add(this.lstAlimento);
            this.Controls.Add(this.btnDeletarRefeicao);
            this.Controls.Add(this.btnAdicionarRefeicao);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtNomeRef);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstRefeicao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frm_adicionarEditarRefeicao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar e Editar Refeição";
            ((System.ComponentModel.ISupportInitialize)(this.picExclamacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstRefeicao;
        private System.Windows.Forms.TextBox txtNomeRef;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnDeletarRefeicao;
        private System.Windows.Forms.Button btnAdicionarRefeicao;
        private System.Windows.Forms.ListBox lstAlimento;
        private System.Windows.Forms.Button btnIncluirAlimento;
        private System.Windows.Forms.TextBox txtBuscaAlimento;
        private System.Windows.Forms.PictureBox picExclamacao;
        private System.Windows.Forms.ToolTip dicaExclamacao;
    }
}