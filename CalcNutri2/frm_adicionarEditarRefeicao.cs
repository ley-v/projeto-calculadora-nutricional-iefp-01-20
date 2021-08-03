using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace CalcNutri2
{
    // ESSE FORMULÁRIO TERÁ MENOS TRATAMENTO DE SEGURANÇA PQ EU TO COM PRESSA. OS OUTROS EU FIZ COM EXTREMO ZELO PQ EU TINHA BASTANTE TEMPO.
    //JÁ NÃO É MAIS O CASO       -,-"
    public partial class frm_adicionarEditarRefeicao : Form
    {
        public static string chaveMestraRef = "x";
        public string CHAVEMESTRAp = "x";
        public string CHAVEMESTRAali = "x";
        public string CHAVEMESTRAref
        {
            get
            {
                return chaveMestraRef;
            }
            set
            {
                chaveMestraRef = value;
            }
        }
        string tabelaRefeicao = "[TRefeicao]";
        string tabelaAlimento = "[TAlimento]";
        string tabelaLinhaRef = "[TLinhaRefeicao]";

        List<List<string>> lbRef = new List<List<string>>();
        List<List<string>> lbAli = new List<List<string>>();

        List<ItemAlimento> listaItem = new List<ItemAlimento>();
        List<ItemRef> listaItemRef = new List<ItemRef>();

        frm_principal p;
        public frm_adicionarEditarRefeicao(frm_principal fp)
        {
            InitializeComponent();
            p = fp;
            CHAVEMESTRAp = p.CHAVEMESTRA;
            //picExclamacao.Image = Image.FromFile("C:\\Users\\Ley\\Pictures\\exclamacaotransparente3.png");
            //dicaExclamacao.SetToolTip(picExclamacao, "Dê um duplo click, ou tecle enter, sobre Refeição onde\nse pretende adicionar os Alimentos.\nPara remover a seleção tecle Esc");
            //dicaExclamacao.SetToolTip(btnAdicionarRefeicao, "Não use caracteres especiais como . @ # , / ' % etc");

            AtualizarListaRef();
            AtualizarListaAlimento();
            lstAlimento.Sorted = true;
        }

        private void btnAdicionarRefeicao_Click(object sender, EventArgs e)
        {
            try
            {
                TratamentoDeDados.Refeicao r = new TratamentoDeDados.Refeicao();
                r.nome = txtNomeRef.Text;
                r.ValidaRefeicao();
                CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaRefeicao);
                if (c.status)
                {
                    string sql = "INSERT INTO " + tabelaRefeicao + " ([IdPlano], [Nome]) VALUES (" + CHAVEMESTRAp + ", '" + r.nome + "')";
                    c.CUDDeDadosLIVRE(sql, false);
                    if (c.status)
                    {
                        AtualizarListaRef();
                        p.AtualizarListaRef();
                        p.CalculoDosMacros();
                        MessageBox.Show("foi, deu: " + sql);
                    }
                    else MessageBox.Show("Erro \n" + c.mensagem);

                }
                else MessageBox.Show("Erro \n" + c.mensagem);
            }
            catch (ValidationException ex)
            {
                MessageBox.Show("Erro na validação\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Inclusão\n" + ex.Message);
            }
        }

        public void ObterRegistosDaTabelaRef()
        {
            CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaRefeicao);
            string sql = "select * from " + tabelaRefeicao + " where [IdPlano] = " + CHAVEMESTRAp;
            DataTable dt = c.BuscarDadosLIVRE(sql, false);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lbRef.Add(new List<string> { dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString() });
            }
        }

        public void PreencherListaRef()
        {
            for (int i = 0; i < lbRef.Count; i++)
            {
                ItemRef ir = new ItemRef();
                ir.Id = lbRef[i][0];
                ir.IdPlano = lbRef[i][1];
                ir.nome = lbRef[i][2];

                lstRefeicao.Items.Add(ir);
            }
        }

        public void AtualizarListaRef()
        {
            lstRefeicao.Items.Clear();
            lbRef.Clear();
            ObterRegistosDaTabelaRef();
            PreencherListaRef();
        }

        public class ItemRef
        {
            public string Id { get; set; }
            public string IdPlano { get; set; }
            public string nome { get; set; }

            public override string ToString()
            {
                return nome;
            }
        }



        private void lstRefeicao_DoubleClick(object sender, EventArgs e)
        {
            if (lstRefeicao.SelectedIndex < 0)
            {
                CHAVEMESTRAref = "x";
                //MessageBox.Show("ChaveMestra Ref: " + CHAVEMESTRAref);

            }
            else
            {
                ItemRef ir = (ItemRef)lstRefeicao.Items[lstRefeicao.SelectedIndex];
                CHAVEMESTRAref = ir.Id;

                //MessageBox.Show("id obj: " + ir.Id + "ChaveMestra Ref: " + CHAVEMESTRAref);
                txtNomeRef.BackColor = Color.LightGreen;
                txtNomeRef.Text = ir.nome;
            }
        }

        private void lstRefeicao_Click(object sender, EventArgs e)
        {


            //if (CHAVEMESTRAref != "x")
            //{
            //    ItemRef ir = (ItemRef)lstRefeicao.SelectedItem;

            //    if (ir.Id != CHAVEMESTRAref)
            //    {
            //        //lstRefeicao.SelectedItem = false;
            //lstRefeicao.SelectedIndex = false;
            //lstRefeicao.SelectionMode = false;
            //lstRefeicao.SelectedValue = false;
            //lstRefeicao.SelectedItems = false;
            //lstRefeicao.SelectionMode = false;
            txtNomeRef.BackColor = Color.White;
            txtNomeRef.Text = "";

            //lstRefeicao.ClearSelected();
            //MessageBox.Show("id obj: " + ir.Id + "ChaveMestra Ref: " + CHAVEMESTRAref);

            CHAVEMESTRAref = "x";
            //        MessageBox.Show("id obj: " + ir.Id + "ChaveMestra Ref: " + CHAVEMESTRAref);

            //    }
            //    else
            //        MessageBox.Show("igual id obj: " + ir.Id + "ChaveMestra Ref: " + CHAVEMESTRAref);
            //}

        }

        private void lstRefeicao_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (CHAVEMESTRAref != "x")
            //{
            //    CHAVEMESTRAref = "x";
            //    lstRefeicao.ClearSelected();
            //}
            //else if (CHAVEMESTRAref == "x")
            //    lstRefeicao.ClearSelected();
        }
        //public void Zerar()
        //{
        //    if (CHAVEMESTRAref != "x")
        //    {
        //        CHAVEMESTRAref = "x";
        //        txtNomeRef.BackColor = Color.White;
        //        txtNomeRef.Text = "";

        //        lstRefeicao.ClearSelected();
        //        MessageBox.Show("entrou?");
        //    }
        //}

        private void lstRefeicao_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void lstRefeicao_CursorChanged(object sender, EventArgs e)
        {


        }

        private void lstRefeicao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) lstRefeicao_DoubleClick(sender, e);
            if (e.KeyData == Keys.Escape)
            {
                if (CHAVEMESTRAref != "x")
                {
                    CHAVEMESTRAref = "x";
                    txtNomeRef.BackColor = Color.White;
                    txtNomeRef.Text = "";

                    lstRefeicao.ClearSelected();
                }
            }
        }

        public void ObterRegistosDaTabelaAlimento()
        {
            CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaAlimento);
            string sql = "select * from " + tabelaAlimento;
            DataTable dt = c.BuscarDadosLIVRE(sql, false);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lbAli.Add(new List<string> { dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString() });
            }
        }

        public void PreencherListaAlimento()
        {
            for (int i = 0; i < lbAli.Count; i++)
            {
                ItemAlimento ia = new ItemAlimento();
                ia.Id = lbAli[i][0];
                ia.nome = lbAli[i][1];

                lstAlimento.Items.Add(ia);
            }
        }

        public void AtualizarListaAlimento()
        {
            lstAlimento.Items.Clear();
            lbAli.Clear();
            ObterRegistosDaTabelaAlimento();
            PreencherListaAlimento();
        }


        public class ItemAlimento
        {
            public string Id { get; set; }
            public string nome { get; set; }
            //public string Id { get; set; }
            //public string IdRefeicao { get; set; }
            //public string IdAlimento { get; set; }
            //public string IdPlano { get; set; }
            //public string quantidade { get; set; }

            public override string ToString()
            {
                return nome;
            }
        }



        private void txtBuscaAlimento_TextChanged(object sender, EventArgs e)
        {
            //if (!(String.IsNullOrEmpty(txtBuscaAlimento.Text)))
            //{
            //    lstAlimento.Items.Clear();
            //    foreach (ItemAlimento ia in listaItem)
            //    {
            //        //Caso quisesse procurar pelo início da palavra, ao invés do método 'Contains', deveria usar o 'StartsWith'
            //        if (ia.nome.ToUpper().Contains(txtBuscaAlimento.Text.ToUpper()))
            //        {
            //            lstAlimento.Items.Add(ia);
            //        }
            //    }
            //}
            //else AtualizarListaAlimento();
        }

        private void btnIncluirEditarAlimento_Click(object sender, EventArgs e)
        {
            try
            {
                TratamentoDeDados.LinhaRefeicao l = new TratamentoDeDados.LinhaRefeicao();
                l.quantidade = txtQuantidade.Text;
                l.ValidaLinhaRefeicao();
                if (CHAVEMESTRAp != "x" && CHAVEMESTRAref != "x" && CHAVEMESTRAali != "x")
                {
                    CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaLinhaRef);
                    if (c.status)
                    {
                        string sql = "INSERT INTO " + tabelaLinhaRef + " ([IdRefeicao], [IdAlimento], [IdPlano], [Quantidade]) VALUES " +
                            " (" + CHAVEMESTRAref + ", " + CHAVEMESTRAali + ", " + CHAVEMESTRAp + ", " + l.quantidade + ")";
                        c.CUDDeDadosLIVRE(sql, false);
                        if (c.status)
                        {
                            AtualizarListaRef();
                            AtualizarListaAlimento();
                            txtQuantidade.Text = "";
                            p.AtualizarListaRef();
                            p.CalculoDosMacros();

                            //MessageBox.Show("foi, deu: " + sql);
                        }
                        else MessageBox.Show("Erro \n" + c.mensagem);
                    }
                    else MessageBox.Show("Erro na conexão\n" + c.mensagem);
                }
                else
                {
                    MessageBox.Show("Para efetuar a inclusão a 'Refeição' e o 'Alimento' devem estar selecionados");

                }

            }
            catch (ValidationException ex)
            {
                MessageBox.Show("Erro na validação\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Inclusão\n" + ex.Message);
            }
        }

        private void lstAlimento_DoubleClick(object sender, EventArgs e)
        {
            if (lstAlimento.SelectedIndex < 0)
            {
                CHAVEMESTRAali = "x";
                //MessageBox.Show("ChaveMestra Ali: " + CHAVEMESTRAali);

            }
            else
            {
                ItemAlimento ia = (ItemAlimento)lstAlimento.Items[lstAlimento.SelectedIndex];
                CHAVEMESTRAali = ia.Id;

                //MessageBox.Show("id obj: " + ia.Id + "ChaveMestra Ali: " + CHAVEMESTRAali);
                txtBuscaAlimento.BackColor = Color.LightGreen;
                txtBuscaAlimento.Text = ia.nome;
            }
        }

        private void lstAlimento_Click(object sender, EventArgs e)
        {
            //if (CHAVEMESTRAali != "x")
            //{
            //    if (lstAlimento.SelectedIndex > 0)
            //    {


            //        ItemAlimento ia = (ItemAlimento)lstAlimento.SelectedItem;

            //        if (ia.Id != CHAVEMESTRAali)
            //        {
            //            txtBuscaAlimento.BackColor = Color.White;
            //            txtBuscaAlimento.Text = "";

            //            lstAlimento.ClearSelected();
            //            MessageBox.Show("id obj: " + ia.Id + "ChaveMestra Ali: " + CHAVEMESTRAali);

            //            CHAVEMESTRAali = "x";
            //            MessageBox.Show("id obj: " + ia.Id + "ChaveMestra Ali: " + CHAVEMESTRAali);

            //        }
            //        else
            //            MessageBox.Show("igual id obj: " + ia.Id + "ChaveMestra Ali: " + CHAVEMESTRAali);
            //    }
            //    else {
            CHAVEMESTRAali = "x";
            txtBuscaAlimento.BackColor = Color.White;
            txtBuscaAlimento.Text = "";


            //}

            //}
        }

        private void lstAlimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) lstAlimento_DoubleClick(sender, e);
            if (e.KeyData == Keys.Escape)
            {
                if (CHAVEMESTRAali != "x")
                {
                    CHAVEMESTRAali = "x";
                    txtBuscaAlimento.BackColor = Color.White;
                    txtBuscaAlimento.Text = "";

                    lstAlimento.ClearSelected();
                }
            }
        }

        private void txtBuscaAlimento_Enter(object sender, EventArgs e)
        {
            foreach (ItemAlimento ia in lstAlimento.Items)
            {
                listaItem.Add(ia);
            }
        }

        private void txtNomeRef_Enter(object sender, EventArgs e)
        {
            foreach (ItemRef ir in lstRefeicao.Items)
            {
                listaItemRef.Add(ir);
            }
        }

        private void txtNomeRef_TextChanged(object sender, EventArgs e)
        {
            //if (!(String.IsNullOrEmpty(txtNomeRef.Text)))
            //{
            //    lstRefeicao.Items.Clear();
            //    foreach (ItemRef ir in listaItemRef)
            //    {
            //        //Caso quisesse procurar pelo início da palavra, ao invés do método 'Contains', deveria usar o 'StartsWith'
            //        if (ir.nome.ToUpper().Contains(txtNomeRef.Text.ToUpper()))
            //        {
            //            lstRefeicao.Items.Add(ir);
            //        }
            //    }
            //}
            //else AtualizarListaRef();
        }

        private void btnDeletarRefeicao_Click(object sender, EventArgs e)
        {
            try
            {

                if (CHAVEMESTRAp != "x" && CHAVEMESTRAref != "x")
                {
                    CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaRefeicao);
                    if (MessageBox.Show("Tem certeza que deseja Excluir essa Refeição?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string sql = "DELETE FROM " + "[TRefeicao]" + " WHERE [Id] = " + CHAVEMESTRAref + ";";
                        c.CUDDeDadosLIVRE(sql, false);
                        if (c.status)
                        {
                            CRUDBancoDeDados cc = new CRUDBancoDeDados(tabelaLinhaRef);

                            sql = "DELETE FROM " + "[TLinhaRefeicao]" + " WHERE [IdRefeicao] = " + CHAVEMESTRAref + ";";
                            cc.CUDDeDadosLIVRE(sql, false);
                            if (cc.status)
                            {
                                AtualizarListaRef();
                                AtualizarListaAlimento();
                                txtQuantidade.Text = "";
                                lstAlimento_Click(sender, e);
                                p.AtualizarListaRef();
                                p.CalculoDosMacros();
                                p.dgvQuantidadeAlimentos.Rows.Clear();

                                CHAVEMESTRAref = "x";
                                txtNomeRef.BackColor = Color.White;
                                txtNomeRef.Text = "";

                                MessageBox.Show("foi, deu");
                            }
                            else MessageBox.Show("Erro na Exclusão dos Registros da 'TabelaRefeição'\n" + cc.mensagem);
                        }
                        else MessageBox.Show("Erro na Exclusão dos Registros da 'TabelaLinhaRefeição'\n" + c.mensagem);
                    }


                }
                else
                {
                    MessageBox.Show("Selecione a 'Refeição' que se pretende Excluir");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Inclusão\n" + ex.Message);
            }
        }
    }
}
