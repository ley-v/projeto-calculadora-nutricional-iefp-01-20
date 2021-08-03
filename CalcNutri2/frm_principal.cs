using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcNutri2
{
    public partial class frm_principal : Form
    {
        //A chave mestra é o ID da tabela 'TPlano' que é a PrimaryKey e será utilizada como parametro para efetuar todos os cálculos
        //do programa. Deixei como estática para que o valor seja fixo, muito embora eu não vá fehcar o formulário principal em nenhum momento
        //Inicialmente tinha posto essa propriedade no formulário 'Inicia/troca Plano' e lá a propriedade static fazia mais sentido, pois
        //logo após selecionar o plano o formulário era fechado. Porém, resolvi manter a mesma configuração aqui. Só por segurança.
        public static string chaveMestra = "x";
        string tabelaPlano = "[TPlano]";

        public string CHAVEMESTRA
        {
            get
            {
                return chaveMestra;
            }
            set
            {
                chaveMestra = value;
            }
        }
        private bool exibirValor = true;

        List<List<string>> lbRef = new List<List<string>>();
        string tabelaRefeicao = "[TRefeicao]";
        string tabelaLinhaRefeicao = "[TLinhaRefeicao]";

        TratamentoDeDados.Plano dadosPlano = new TratamentoDeDados.Plano();
        public double TDEE;
        int idLinha = -1;

        public frm_principal()
        {
            InitializeComponent();

            CRUDBancoDeDados c = new CRUDBancoDeDados("[TPlano]");
            DataTable dt = c.BuscarTodosOsDadosNaTabela();
            if (dt.Rows.Count == 0)
            {
                iniciarTrocarPlanoNutricionalToolStripMenuItem.Enabled = false;
            }
            if (CHAVEMESTRA == "x") btn_adicionarEditarRefeicao.Enabled = false;

            dgvQuantidadeAlimentos.AllowUserToAddRows = false;
            dgvQuantidadeAlimentos.RowHeadersVisible = false;
            valorToolStripMenuItem.Enabled = false;

            toolTipGeral.SetToolTip(lblAguaRecomendada, "Indica-se, em média, o consumo de 50mls de água por quilo corporal");
            toolTipGeral.SetToolTip(lblTDEE, "Esse é um valor aproximado. \nCaso ao final de uma semana seja notado o aumento ou diminuição de peso,\ndeve-se fazer a devida calibragem de calorias");
            toolTipGeral.SetToolTip(lblFibraRecomendada, "Indica-se, em média, o consumo de 10g de fibras para cada mil kcal.\nMas desde que não chegue em um ponto de causar diarréia, quanto mais fibras melhor");
            toolTipGeral.SetToolTip(dgvQuantidadeAlimentos, "Dê um duplo click sobre o alimento que deseja eliminar da refeição");
        }



        private void iniciarTrocarPlanoNutricionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_iniciarTrocarPlano f = new frm_iniciarTrocarPlano();
            f.ShowDialog();
            if (CHAVEMESTRA == "x") btn_adicionarEditarRefeicao.Enabled = false;
            else btn_adicionarEditarRefeicao.Enabled = true;
            AtualizarListaRef();
            CalculoDosMacros();
            LimparFormularioPrincipal();
            dgvQuantidadeAlimentos.Rows.Clear();
            lblINQuantidade.Text = "";
            lblINProtAnl.Text = "";
            lblINProtVeg.Text = "";
            lblINHCarbo.Text = "";
            lblINLipidios.Text = "";
            lblINFibra.Text = "";
            lblINKcal.Text = "";
        }

        private void incluirEditarPlanoNutricionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Aqui inicializo a variável f com a classe do formulário de inclução e edição dos Planos Nutricionais
            frm_incluirEditarPlano f = new frm_incluirEditarPlano();
            //Caso o programa inicialize sem nenhum registo na base de dados a opção de inicializar/trocar de Plano Nutricional fica
            // desabilitada. Então, aqui eu repasso para um método do formulário acima instanciado, o objeto do menuStrip para que, assim que 
            //o primeiro registo seja incluído, o botão de 'iniciar/trocar de plano' fique habilitado
            f.HabilitarComponenteDoMenu(iniciarTrocarPlanoNutricionalToolStripMenuItem);
            f.ShowDialog();
            if (CHAVEMESTRA == "x") btn_adicionarEditarRefeicao.Enabled = false;
            else btn_adicionarEditarRefeicao.Enabled = true;
            AtualizarListaRef();
            LimparFormularioPrincipal();

        }

        private void valorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (exibirValor)
            //{
            //    this.Controls.Remove(lbl_valorT);
            //    this.Controls.Remove(lbl_valorC1);
            //    this.Controls.Remove(lbl_valorC2);

            //    this.Controls.Remove(lbl_valorDT);
            //    this.Controls.Remove(lbl_valorDC);

            //    this.Controls.Remove(lbl_valorMT);
            //    this.Controls.Remove(lbl_valorMC);

            //    exibirValor = false;
            //}
            //else
            //{
            //    this.Controls.Add(lbl_valorT);
            //    this.Controls.Add(lbl_valorC1);
            //    this.Controls.Add(lbl_valorC2);

            //    this.Controls.Add(lbl_valorDT);
            //    this.Controls.Add(lbl_valorDC);

            //    this.Controls.Add(lbl_valorMT);
            //    this.Controls.Add(lbl_valorMC);

            //    exibirValor = true;

            //}


        }

        private void btn_adicionarEditarAlimento_Click(object sender, EventArgs e)
        {
            frm_adicionarEditarAlimentos f = new frm_adicionarEditarAlimentos(this);
            f.Show();
            CalculoDosMacros();
        }

        private void btn_adicionarEditarRefeicao_Click(object sender, EventArgs e)
        {
            frm_adicionarEditarRefeicao f = new frm_adicionarEditarRefeicao(this);
            f.ShowDialog();
            CalculoDosMacros();
            //if(f.Close() == DialogResult.Cancel)
            //MessageBox.Show("estado " + f.DialogResult);
        }

        public void ObterRegistosDaTabelaRef()
        {
            CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaRefeicao);
            string sql = "select * from " + tabelaRefeicao + " where [IdPlano] = " + CHAVEMESTRA;
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

        private void lstRefeicao_Click(object sender, EventArgs e)
        {

            CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaRefeicao);
            var dt = c.BuscarTodosOsDadosNaTabela();
            if (dt.Rows.Count > 0)
            {
                if (lstRefeicao.SelectedIndex != -1)
                {
                    dgvQuantidadeAlimentos.Rows.Clear();
                    lblINQuantidade.Text = "";
                    lblINProtAnl.Text = "";
                    lblINProtVeg.Text = "";
                    lblINHCarbo.Text = "";
                    lblINLipidios.Text = "";
                    lblINFibra.Text = "";
                    lblINKcal.Text = "";
                    ItemRef ir = (ItemRef)lstRefeicao.SelectedItem;
                    string sql = "select l.Id, l.Quantidade, a.Nome, a.Id from TPlano t inner join TRefeicao r on t.Id = r.IdPlano " +
                        "inner join TLinhaRefeicao l on r.Id = l.IdRefeicao inner join TAlimento a on l.IdAlimento = a.Id " +
                        "where t.Id = " + CHAVEMESTRA + " and r.Id = " + ir.Id + ";";
                    //dgvQuantidadeAlimentos.Rows.Clear();
                    //sql = "select * from " + tabelaRefeicao + " where Id = " + ir.Id;
                    CRUDBancoDeDados cc = new CRUDBancoDeDados(tabelaRefeicao);
                    dt = cc.BuscarDadosLIVRE(sql, false);
                    //MessageBox.Show(dt.Rows[0][0].ToString());
                    dgvQuantidadeAlimentos.ColumnCount = 4;
                    dgvQuantidadeAlimentos.Columns[0].HeaderText = "Id";
                    dgvQuantidadeAlimentos.Columns[1].HeaderText = "Quantidade";
                    dgvQuantidadeAlimentos.Columns[2].HeaderText = "Nome do alimento";
                    dgvQuantidadeAlimentos.Columns[3].HeaderText = "IdAlimento";
                    dgvQuantidadeAlimentos.Columns[0].Width = 0;
                    dgvQuantidadeAlimentos.Columns[1].Width = 100;
                    dgvQuantidadeAlimentos.Columns[2].Width = 285;

                    dgvQuantidadeAlimentos.Columns[0].Visible = false;
                    dgvQuantidadeAlimentos.Columns[3].Visible = false;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvQuantidadeAlimentos.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString());
                    }
                    dgvQuantidadeAlimentos.AllowUserToResizeRows = false;
                    //if (dt.Rows.Count > 0) MessageBox.Show(ir.Id);
                    //else  MessageBox.Show(ir.Id + " fffff" );
                }
                else MessageBox.Show(lstRefeicao.SelectedIndex.ToString() + "selecionado");
            }
        }


        public void CalculoDosMacros()
        {
            if (CHAVEMESTRA != "x")
            {
                CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaPlano);
                var dt = c.BuscarDadosNaTabelaComID("*", CHAVEMESTRA, false);
                if (dt.Rows.Count > 0)
                {
                    //dgvQuantidadeAlimentos.DataSource = dt;
                    dadosPlano.nomePlano = dt.Rows[0]["plano"].ToString();
                    dadosPlano.nome = dt.Rows[0]["nome"].ToString();
                    dadosPlano.sexo = dt.Rows[0]["Sexo"].ToString();
                    //dadosPlano.peso = Convert.ToDouble(dt.Rows[0]["Peso"]);
                    double peso = Convert.ToDouble(dt.Rows[0]["Peso"]);
                    dadosPlano.idade = Convert.ToInt32(dt.Rows[0]["Idade"]);
                    dadosPlano.altura = Convert.ToInt32(dt.Rows[0]["Altura"]);
                    //dadosPlano.coeficiente = Convert.ToDouble(dt.Rows[0]["CoeficienteAtividade"]);
                    double coeficiente = Convert.ToDouble(dt.Rows[0]["CoeficienteAtividade"]);
                    dadosPlano.objetivo = dt.Rows[0]["Objetivo"].ToString();

                    double proteinaAnimal = 0;
                    double proteinaVegetal = 0;
                    double proteinaTotalGrama = 0;
                    double hCarboGrama = 0;
                    double lipidioGrama = 0;

                    lblNomeDoUtilizador.Text = dadosPlano.nome;
                    lblNomeDoPlano.Text = dadosPlano.nomePlano;

                    //MessageBox.Show(dadosPlano.StringSQLAlteracao());
                    if (dadosPlano.sexo == "m")
                    {
                        TDEE = coeficiente * (66 + ((13.7 * peso) + (5 * dadosPlano.altura) - (6.8 * dadosPlano.idade)));
                        lblTDEE.Text = TDEE.ToString();
                    }
                    else
                    {
                        TDEE = coeficiente * (655 + ((9.6 * peso) + (1.8 * dadosPlano.altura) - (4.7 * dadosPlano.idade)));
                        lblTDEE.Text = TDEE.ToString();
                    }

                    lblAguaRecomendada.Text = (peso * 0.05).ToString();
                    lblFibraRecomendada.Text = (TDEE / 100).ToString();


                    //////////////// EU DEVERIA CRIAR VARIOS MÉTODOS PRA ORGANIZAR, MAS COMO JÁ DISSE ANTES: Tô COM PRESSA
                    /////////////////////////////////// CALCULO PROTEINA ANIMAL GRAMAS
                    ConexaoSQLServer c1 = new ConexaoSQLServer();
                    string sql = "select l.Quantidade, a.ProteinaAnimal from TPlano p inner join TRefeicao r on p.Id = r.IdPlano " +
                        "inner join TLinhaRefeicao l on r.Id = l.IdRefeicao inner join TAlimento a on l.IdAlimento = a.Id " +
                        "where l.IdPlano = " + CHAVEMESTRA + ";";
                    dt = c1.SQLQuery(sql);
                    c1.Fechar();
                    //dgvQuantidadeAlimentos.DataSource = dt;
                    if (dt.Rows.Count >= 0)
                    {
                        double resultado = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            double quantidade = Convert.ToDouble(dt.Rows[i][0]) / 100;
                            resultado += Convert.ToDouble(dt.Rows[i][1]) * quantidade;

                        }
                        //MessageBox.Show(resultado.ToString());
                        lblProtAnlGrama.Text = resultado.ToString();
                        proteinaTotalGrama += resultado;
                        proteinaAnimal = resultado;
                    }



                    /////////////////////////////////// CALCULO PROTEINA VEGETAL GRAMAS
                    ConexaoSQLServer c2 = new ConexaoSQLServer();
                    sql = "select l.Quantidade, a.ProteinaVegetal from TPlano p inner join TRefeicao r on p.Id = r.IdPlano " +
                        "inner join TLinhaRefeicao l on r.Id = l.IdRefeicao inner join TAlimento a on l.IdAlimento = a.Id " +
                        "where l.IdPlano = " + CHAVEMESTRA + ";";
                    dt = c2.SQLQuery(sql);
                    c2.Fechar();
                    //dgvQuantidadeAlimentos.DataSource = dt;
                    if (dt.Rows.Count >= 0)
                    {
                        double resultado = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            double quantidade = Convert.ToDouble(dt.Rows[i][0]) / 100;
                            resultado += Convert.ToDouble(dt.Rows[i][1]) * quantidade;

                        }
                        //MessageBox.Show(resultado.ToString());
                        lblProtVegGrama.Text = resultado.ToString();
                        proteinaTotalGrama += resultado;
                        proteinaVegetal = resultado;

                    }



                    /////////////////////////////////// CALCULO PROTEINA TOTAL GRAMAS
                    lblProtTotalGrama.Text = proteinaTotalGrama.ToString();



                    /////////////////////////////////// CALCULO HIDRATOS DE CARBONO GRAMAS
                    ConexaoSQLServer c3 = new ConexaoSQLServer();
                    sql = "select l.Quantidade, a.HCarbono from TPlano p inner join TRefeicao r on p.Id = r.IdPlano " +
                        "inner join TLinhaRefeicao l on r.Id = l.IdRefeicao inner join TAlimento a on l.IdAlimento = a.Id " +
                        "where l.IdPlano = " + CHAVEMESTRA + ";";
                    dt = c3.SQLQuery(sql);
                    c3.Fechar();
                    //dgvQuantidadeAlimentos.DataSource = dt;
                    if (dt.Rows.Count >= 0)
                    {
                        double resultado = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            double quantidade = Convert.ToDouble(dt.Rows[i][0]) / 100;
                            resultado += Convert.ToDouble(dt.Rows[i][1]) * quantidade;
                            hCarboGrama = resultado;
                        }
                        //MessageBox.Show(resultado.ToString());
                        lblHCarbGrama.Text = resultado.ToString();
                    }



                    /////////////////////////////////// CALCULO LIPIDIOS GRAMAS
                    ConexaoSQLServer c4 = new ConexaoSQLServer();
                    sql = "select l.Quantidade, a.Lipidio from TPlano p inner join TRefeicao r on p.Id = r.IdPlano " +
                        "inner join TLinhaRefeicao l on r.Id = l.IdRefeicao inner join TAlimento a on l.IdAlimento = a.Id " +
                        "where l.IdPlano = " + CHAVEMESTRA + ";";
                    dt = c4.SQLQuery(sql);
                    c4.Fechar();
                    //dgvQuantidadeAlimentos.DataSource = dt;
                    if (dt.Rows.Count >= 0)
                    {
                        double resultado = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            double quantidade = Convert.ToDouble(dt.Rows[i][0]) / 100;
                            resultado += Convert.ToDouble(dt.Rows[i][1]) * quantidade;
                            lipidioGrama = resultado;
                        }
                        //MessageBox.Show(resultado.ToString());
                        lblLipidioGrama.Text = resultado.ToString();
                    }



                    /////////////////////////////////// CALCULO FIBRAS GRAMAS
                    ConexaoSQLServer c5 = new ConexaoSQLServer();
                    sql = "select l.Quantidade, a.Fibra from TPlano p inner join TRefeicao r on p.Id = r.IdPlano " +
                        "inner join TLinhaRefeicao l on r.Id = l.IdRefeicao inner join TAlimento a on l.IdAlimento = a.Id " +
                        "where l.IdPlano = " + CHAVEMESTRA + ";";
                    dt = c5.SQLQuery(sql);
                    c5.Fechar();
                    //dgvQuantidadeAlimentos.DataSource = dt;
                    if (dt.Rows.Count >= 0)
                    {
                        double resultado = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            double quantidade = Convert.ToDouble(dt.Rows[i][0]) / 100;
                            resultado += Convert.ToDouble(dt.Rows[i][1]) * quantidade;

                        }
                        //MessageBox.Show(resultado.ToString());
                        lblFibraDiario.Text = resultado.ToString();
                    }



                    /////////////////////////////////// CALCULO KCAL DIÁRIO
                    double KcalDiario = (proteinaTotalGrama + hCarboGrama) * 4 + (lipidioGrama) * 9;
                    lblKcalDiario.Text = Convert.ToString(KcalDiario);



                    /////////////////////////////////// CALCULO KCAL DIÁRIO EXCEDENTE
                    if (dadosPlano.objetivo == "Cutting") lblKcalExcedente.Text = Convert.ToString((KcalDiario - TDEE) * 0.76);
                    if (dadosPlano.objetivo == "Manter") lblKcalExcedente.Text = Convert.ToString(KcalDiario - TDEE);
                    if (dadosPlano.objetivo == "Bulking Seco") lblKcalExcedente.Text = Convert.ToString((KcalDiario - TDEE) + 125);
                    if (dadosPlano.objetivo == "Bulking Severo") lblKcalExcedente.Text = Convert.ToString((KcalDiario - TDEE) + 300);



                    /////////////////////////////////// CALCULO KCAL POR NUTRIENTE
                    lblkcalProtAnl.Text = Convert.ToString(proteinaAnimal * 4);
                    lblkcalProtVeg.Text = Convert.ToString(proteinaVegetal * 4);
                    lblkcalProtTotal.Text = Convert.ToString(proteinaTotalGrama * 4);
                    lblkcalHCarb.Text = Convert.ToString(hCarboGrama * 4);
                    lblkcalLipidios.Text = Convert.ToString(lipidioGrama * 9);



                    /////////////////////////////////// CALCULO GRAMA/KILO
                    double gKgproteinaAnimal = (proteinaAnimal) / peso;
                    double gKgproteinaVegetal = (proteinaVegetal) / peso;
                    double gKgproteinaTotalGrama = (proteinaTotalGrama) / peso;
                    double gKghCarboGrama = (hCarboGrama) / peso;
                    double gKglipidioGrama = (lipidioGrama) / peso;
                    lblGKgProtAnl.Text = Convert.ToString(gKgproteinaAnimal);
                    lblGKgProtVeg.Text = Convert.ToString(gKgproteinaVegetal);
                    lblGKgProtTotal.Text = Convert.ToString(gKgproteinaTotalGrama);
                    lblGKgHCarbo.Text = Convert.ToString(gKghCarboGrama);
                    lblGKgLipidios.Text = Convert.ToString(gKglipidioGrama);



                    /////////////////////////////////// CALCULO PORCENTAGEM
                    double somaParaPorcentagem = gKgproteinaAnimal + gKgproteinaVegetal + gKghCarboGrama + gKglipidioGrama;
                    lblPctProtAnl.Text = Convert.ToString(gKgproteinaAnimal / somaParaPorcentagem * 100);
                    lblPctProtVeg.Text = Convert.ToString(gKgproteinaVegetal / somaParaPorcentagem * 100);
                    lblPctProtTotal.Text = Convert.ToString(gKgproteinaTotalGrama / somaParaPorcentagem * 100);
                    lblPctHCarb.Text = Convert.ToString(gKghCarboGrama / somaParaPorcentagem * 100);
                    lblPctLipidios.Text = Convert.ToString(gKglipidioGrama / somaParaPorcentagem * 100);




                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////

                }
            }
        }

        public void LimparFormularioPrincipal()
        {
            if (CHAVEMESTRA == "x")
            {
                lblPctProtAnl.Text = "";
                lblPctProtVeg.Text = "";
                lblPctProtTotal.Text = "";
                lblPctHCarb.Text = "";
                lblPctLipidios.Text = "";

                lblkcalProtAnl.Text = "";
                lblkcalProtVeg.Text = "";
                lblkcalProtTotal.Text = "";
                lblkcalHCarb.Text = "";
                lblkcalLipidios.Text = "";

                lblGKgProtAnl.Text = "";
                lblGKgProtVeg.Text = "";
                lblGKgProtTotal.Text = "";
                lblGKgHCarbo.Text = "";
                lblGKgLipidios.Text = "";

                lblProtAnlGrama.Text = "";
                lblProtVegGrama.Text = "";
                lblProtTotalGrama.Text = "";
                lblHCarbGrama.Text = "";
                lblLipidioGrama.Text = "";

                lblFibraDiario.Text = "";
                lblKcalDiario.Text = "";
                lblAguaRecomendada.Text = "";
                lblFibraRecomendada.Text = "";
                lblKcalExcedente.Text = "";
                lblTDEE.Text = "";

                lblNomeDoUtilizador.Text = "";
                lblNomeDoPlano.Text = "";

                dgvQuantidadeAlimentos.Rows.Clear();
                lblINQuantidade.Text = "";
                lblINProtAnl.Text = "";
                lblINProtVeg.Text = "";
                lblINHCarbo.Text = "";
                lblINLipidios.Text = "";
                lblINFibra.Text = "";
                lblINKcal.Text = "";
            }
        }

        private void dgvQuantidadeAlimentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CHAVEMESTRA != "x")
            {
                //if (lstRefeicao.SelectedIndex > 0)
                //{
                ItemRef ir = (ItemRef)lstRefeicao.Items[lstRefeicao.SelectedIndex];
                if (MessageBox.Show("Deseja retirar esse alimento da refeição '" + ir.nome + "' ?", "Exclusão de Alimento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ConexaoSQLServer c = new ConexaoSQLServer();
                    int indexdgv = dgvQuantidadeAlimentos.CurrentCell.RowIndex;
                    idLinha = Convert.ToInt32(dgvQuantidadeAlimentos.Rows[indexdgv].Cells[0].Value);
                    //MessageBox.Show(dgvQuantidadeAlimentos.Rows[indexdgv].Cells[0].Value.ToString());
                    string sql = "delete from " + tabelaLinhaRefeicao + "where Id = " + idLinha;
                    c.SQLComando(sql);
                    c.Fechar();
                    lstRefeicao_Click(sender, e);
                    CalculoDosMacros();

                }

                //}
                //else MessageBox.Show("Selecione uma refeição", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void dgvQuantidadeAlimentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idLinhaRef = Convert.ToInt32(dgvQuantidadeAlimentos.Rows[dgvQuantidadeAlimentos.CurrentCell.RowIndex].Cells[0].Value);
            int idAlimento = Convert.ToInt32(dgvQuantidadeAlimentos.Rows[dgvQuantidadeAlimentos.CurrentCell.RowIndex].Cells[3].Value);
            //MessageBox.Show(idLinha.ToString());
            ConexaoSQLServer c = new ConexaoSQLServer();
            string sql = "select l.Quantidade, a.ProteinaAnimal, a.ProteinaVegetal, a.HCarbono, a.Lipidio, a.Fibra " +
                        "from TLinhaRefeicao l inner join TAlimento a on l.IdAlimento = a.Id " +
                        "where l.Id = " + idLinhaRef + " and a.Id = " + idAlimento + ";";
            DataTable dt = c.SQLQuery(sql);
            c.Fechar();
            if (dt.Rows.Count > 0)
            {
                double quantidade = Convert.ToInt32(dt.Rows[0][0]);
                double pa = Convert.ToDouble(dt.Rows[0][1]) * quantidade / 100;
                double pv = Convert.ToDouble(dt.Rows[0][2]) * quantidade / 100;
                double hc = Convert.ToDouble(dt.Rows[0][3]) * quantidade / 100;
                double lp = Convert.ToDouble(dt.Rows[0][4]) * quantidade / 100;
                double kcal = ((pa + pv + hc) * 4) + (lp * 9);
                lblINQuantidade.Text = Convert.ToString(quantidade);
                lblINProtAnl.Text = Convert.ToString(pa);
                lblINProtVeg.Text = Convert.ToString(pv);
                lblINHCarbo.Text = Convert.ToString(hc);
                lblINLipidios.Text = Convert.ToString(lp);
                lblINFibra.Text = Convert.ToString(Convert.ToDouble(dt.Rows[0][5]) * quantidade / 100);
                lblINKcal.Text = Convert.ToString(kcal);

            }
        }
    }
}
