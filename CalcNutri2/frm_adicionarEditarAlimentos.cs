using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations; // Adicionei essa dll aqui para ser possível capturar a exceção do tipo ValidationException

namespace CalcNutri2
{
    public partial class frm_adicionarEditarAlimentos : Form
    {
        string CHAVEMESTRAal = "x";
        string tabelaPlano = "[TAlimento]";
        List<List<string>> listaBi = new List<List<string>>();
        List<ItemDataTable2> listaItem = new List<ItemDataTable2>();

        frm_principal p = new frm_principal();
        public frm_adicionarEditarAlimentos(frm_principal f)
        {
            InitializeComponent();
            BtnLimparClick();
            lstAlimentos.Sorted = true;
            ///////////////////////////////////////////
            p = f;


        }

        private void btnIncluirAlimento_Click(object sender, EventArgs e)
        {
            //Try/Catch para prevenir que o programa quebre
            try
            {
                //Instancio a classe onde possui as validações
                TratamentoDeDados.Alimentos a = new TratamentoDeDados.Alimentos();
                //Preencho as propriedades da classe com os valores instroduzidos no formulário
                a = RepassarDadosDoFormularioAlimento();

                //Chamo o método para validar as informações que agora estão dentro da classe e caso haja erros, o método irá criar as exceções
                a.ValidaAlimento();
                CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaPlano);
                if (c.status)
                {
                    //Aqui eu deixo a conexão aberta pois caso não haja um alimento com o mesmo nome, sera incluído um novo
                    DataTable dt = c.BuscarDadosNaTabelaComNome("*", txtNomeAlimento.Text, true);
                    if (dt.Rows.Count > 0)
                    {
                        if (MessageBox.Show("ATENÇÃO: Já existe um alimento com o nome '" + txtNomeAlimento.Text + "' cadastrado no Banco de Dados.\nDeseja cadastrar mais um alimento com o mesmo nome?", "Alimento já existente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            c.IncluirDadosNaTabela(a.StringSQLInclusao());
                            if (c.status)
                            {
                                MessageBox.Show("Camada - A1.1.1 // Inclusão bem sucedida\n" + c.mensagem);
                                //Depois de adicionar um novo alimento o formulário será limpo e a CHAVEMESTRAal retornará para o valor 'x'
                                BtnLimparClick();
                            }
                            //aqui houve erro na inclusão dos dados
                            else MessageBox.Show("ERRO-Camada - A1.1.1 // Erro na Inclusão\n" + c.mensagem);
                        }
                        else c.FecharConexao();
                    }
                    else
                    {
                        c.IncluirDadosNaTabela(a.StringSQLInclusao());
                        if (c.status)
                        {
                            MessageBox.Show("Camada - A1.1.2 // Inclusão bem sucedida\n" + c.mensagem);
                            //Depois de adicionar um novo alimento o formulário será limpo e a CHAVEMESTRAal retornará para o valor 'x'
                            BtnLimparClick();

                        }
                        //aqui houve erro na inclusão dos dados
                        else MessageBox.Show/*(a.StringSQLInclusao());*/("ERRO-Camada - A1.1.2 // Erro na Inclusão\n" + c.mensagem);
                    }
                }//aqui houve erro na conexão com a base de dados dos dados
                else MessageBox.Show("ERRO-Camada - A1.1.3 // Erro na conexão com a Base de Dados\n" + c.mensagem);
            }
            //Capturo e mostro na tela as exceções das camadas inferiores
            catch (ValidationException ex)
            {
                MessageBox.Show("ERRO-Camada - A1.1.4 //\n" + ex.Message); //O ex.Message é o conteúdo da exceção ValidationException
            }
            //aqui possivelmente ocorreu algum erro crítico
            catch (Exception ex)
            {
                MessageBox.Show("ERRO-Camada - A1.1.5 // Erro na Inclusão\n" + ex.Message);
            }
        }


        //Método responsável por capturar as informações preenchidas no formulário e jogar pra dentro de um objeto 
        public TratamentoDeDados.Alimentos RepassarDadosDoFormularioAlimento()
        {
            TratamentoDeDados.Alimentos a = new TratamentoDeDados.Alimentos();
            TratamentoDeDados t = new TratamentoDeDados();

            a.nome = txtNomeAlimento.Text;
            a.protAnimal = t.TestaVazio(txtProtAnimal.Text);
            a.protVegetal = t.TestaVazio(txtProtVegetal.Text);
            a.hCarbono = t.TestaVazio(txtHCarbono.Text);
            a.lipidios = t.TestaVazio(txtLipidio.Text);
            a.fibra = t.TestaVazio(txtFibra.Text);
            a.valor = t.TestaVazio(txtValor.Text);
            return a;
        }

        //Limpa os dados do formulário
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            BtnLimparClick();
        }
        //Criei esse método para poder usar as mesmas implementações do botão 'Limpar' em outros lugares
        public void BtnLimparClick()
        {
            //Limpo todos os campos e reseto a chave primária
            LimparFormulario();
            AtualizarListBox();
            CHAVEMESTRAal = "x";
        }

        public void LimparFormulario()
        {
            txtNomeAlimento.Text = "";
            txtProtAnimal.Text = "";
            txtProtVegetal.Text = "";
            txtHCarbono.Text = "";
            txtLipidio.Text = "";
            txtFibra.Text = "";
            txtValor.Text = "";
            txtBuscaAlimento.Text = "";
        }

        #region "Label de Observação"
        private void txtProtAnimal_Enter(object sender, EventArgs e)
        {
            lblObservacaoAlimento.Text = "Insira somente números e com no máximo 2 casas decimais.\nEx: 99\nEx: 99.99";
        }

        private void txtProtVegetal_Enter(object sender, EventArgs e)
        {
            lblObservacaoAlimento.Text = "Insira somente números e com no máximo 2 casas decimais.\nEx: 99\nEx: 99.99";
        }

        private void txtHCarbono_Enter(object sender, EventArgs e)
        {
            lblObservacaoAlimento.Text = "Insira somente números e com no máximo 2 casas decimais.\nEx: 99\nEx: 99.99";
        }

        private void txtLipidio_Enter(object sender, EventArgs e)
        {
            lblObservacaoAlimento.Text = "Insira somente números e com no máximo 2 casas decimais.\nEx: 99\nEx: 99.99";
        }

        private void txtFibra_Enter(object sender, EventArgs e)
        {
            lblObservacaoAlimento.Text = "Insira somente números e com no máximo 2 casas decimais.\nEx: 99\nEx: 99.99";
        }

        private void txtValor_Enter(object sender, EventArgs e)
        {
            lblObservacaoAlimento.Text = "Insira somente números e com no máximo 2 casas decimais.\nEx: 99     /     Ex: 99.99\nATENÇÃO- Insira o valor do Quilo do produto";
        }

        private void txtNomeAlimento_Enter(object sender, EventArgs e)
        {
            lblObservacaoAlimento.Text = "Campo limitado em 150 caracteres.\nEste campo não aceita caracteres especiais como @ - + ' /  etc...";
        }

        private void frm_adicionarEditarAlimentos_Click(object sender, EventArgs e)
        {
            lblObservacaoAlimento.Text = "ATENÇÃO-\nTodos os valores inseridos devem ser referentes a 100g do alimento\n ############################################";
        }

        private void frm_adicionarEditarAlimentos_Enter(object sender, EventArgs e)
        {
            lblObservacaoAlimento.Text = "Adicione os valores referentes a 100g do alimento";
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            lblObservacaoAlimento.Text = "Insira o nome do alimento que se pretende filtrar na tabela\n\nO programa não diferencia letras maiúsculas de minúsculas";
            foreach (ItemDataTable2 idt in lstAlimentos.Items)
            {
                listaItem.Add(idt);
            }
        }

        private void btnLimpar_Enter(object sender, EventArgs e)
        {
            lblObservacaoAlimento.Text = "Apaga todos os campos do formulário";
        }

        private void btnDeletarAlimento_Enter(object sender, EventArgs e)
        {
            lblObservacaoAlimento.Text = "Exclui o alimento da base de dados";
        }

        private void btnEditarAlimento_Enter(object sender, EventArgs e)
        {
            lblObservacaoAlimento.Text = "Altera um ou mais campos de um alimento já inserido no banco de dados";
        }

        private void btnIncluirAlimento_Enter(object sender, EventArgs e)
        {
            lblObservacaoAlimento.Text = "Adiciona um novo alimento a base de dados";
        }

        private void listBox1_Enter(object sender, EventArgs e)
        {
            lblObservacaoAlimento.Text = "Dê um duplo clique para selecionar o alimento.\nPS- Essa ListBox mostra todos os alimentos contidos na base de dados em ordem alfabética";
        }

        #endregion

        private void btnDeletarAlimento_Click(object sender, EventArgs e)
        {
            try
            {
                //Se existir algum Alimento selecionado o Id serádiferente de 'x'
                if (CHAVEMESTRAal != "x")
                {
                    CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaPlano);
                    //caso não haja erro na conexão
                    if (c.status)
                    {
                        //Verifico se existe algum registo com aquele Id no Banco de dados
                        DataTable dt = c.BuscarDadosNaTabelaComID("*", CHAVEMESTRAal, true);
                        if (dt.Rows.Count > 0)
                        {
                            if (MessageBox.Show("Deseja realmente Excluir o alimento '" + dt.Rows[0]["Nome"].ToString() + "' ?", "Exclusão de alimento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                c.DeletarRegistoNaTabelaComID(CHAVEMESTRAal);
                                if (c.status)
                                {
                                    //A exclusão foi bem sucedida. Apago os campos do formulário e volto a chavemestra ao valor 'x'
                                    MessageBox.Show("Camada - A1.2.1 // Exclusão bem sucedida\n" + c.mensagem);
                                    //Depois de adicionar um novo alimento o formulário será limpo e a CHAVEMESTRAal retornará para o valor 'x'
                                    BtnLimparClick();
                                }//aqui houve erro na Exclusão dos dados
                                else MessageBox.Show("ERRO-Camada - A1.2.1 // Erro na Exclusão\n" + c.mensagem);
                            }
                        }
                        else
                        {
                            //Caso a busca retorne vazia significa que não existe nenhum registo na tabela com aquele número de chave primária
                            //Visto que a operação não foi realizada preciso fechar a conexão que ficou aberta
                            c.FecharConexao();
                            MessageBox.Show("ERRO-Camada - A1.2.2 // Erro na Exclusão. O Id: '" + CHAVEMESTRAal + "' não existe na base de dados\n" + c.mensagem);
                        }
                    }
                    //aqui houve erro na conexão com a base de dados dos dados
                    else MessageBox.Show("ERRO-Camada - A1.2.3 // Erro na conexão com a Base de Dados\n" + c.mensagem);
                }
                else MessageBox.Show("Não há nenhum alimento selecionado para efetuar a exclusão", "ERRO na Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO-Camada - A1.2.4 // Erro na Exclusão\n" + ex.Message);
            }
        }

        private void btnEditarAlimento_Click(object sender, EventArgs e)
        {
            //Try/Catch para prevenir que o programa quebre
            try
            {
                //Instancio a classe onde possui as validações
                TratamentoDeDados.Alimentos a = new TratamentoDeDados.Alimentos();
                //Preencho as propriedades da classe com os valores instroduzidos no formulário
                a = RepassarDadosDoFormularioAlimento();
                //Chamo o método para validar as informações que agora estão dentro da classe e caso haja erros, o método irá criar as exceções
                a.ValidaAlimento();
                CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaPlano);
                if (c.status)
                {
                    //Aqui eu deixo a conexão aberta pois caso não haja um alimento com o mesmo nome, sera incluído um novo
                    DataTable dt = c.BuscarDadosNaTabelaComID("*", CHAVEMESTRAal, true);
                    if (dt.Rows.Count > 0)
                    {
                        if (MessageBox.Show("Deseja realmente efetuar a alteração do alimento '" + dt.Rows[0]["Nome"].ToString() + "' ?", "Alterar alimento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            c.AlterarDadosNaTabelaComID(a.StringSQLAlteracao(), CHAVEMESTRAal);
                            //c.IncluirDadosNaTabela(a.StringSQLInclusao());
                            if (c.status)
                            {
                                MessageBox.Show("Camada - A1.3.1 // Alteração bem sucedida\n" + c.mensagem);
                                //Depois de adicionar um novo alimento o formulário será limpo e a CHAVEMESTRAal retornará para o valor 'x'
                                BtnLimparClick();
                                p.CalculoDosMacros();
                            }
                            //aqui houve erro na inclusão dos dados
                            else MessageBox.Show("ERRO-Camada - A1.3.1 // Erro na Alteração\n" + c.mensagem);
                        }
                    }
                    else
                    {
                        //aqui houve erro na inclusão dos dados
                        MessageBox.Show("Não há nenhum alimento na base de dados com o Id selecionado", "ERRO na Alteração", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        c.FecharConexao();
                        MessageBox.Show/*(a.StringSQLInclusao());*/("ERRO-Camada - A1.3.2 // Erro na Alteração\n" + c.mensagem);
                    }
                }//aqui houve erro na conexão com a base de dados dos dados
                else MessageBox.Show("ERRO-Camada - A1.3.3 // Erro na conexão com a Base de Dados\n" + c.mensagem);
            }
            //Capturo e mostro na tela as exceções das camadas inferiores
            catch (ValidationException ex)
            {
                MessageBox.Show("ERRO-Camada - A1.3.4 //\n" + ex.Message); //O ex.Message é o conteúdo da exceção ValidationException
            }
            //aqui possivelmente ocorreu algum erro crítico
            catch (Exception ex)
            {
                MessageBox.Show("ERRO-Camada - A1.3.5 // Erro na Alteração\n" + ex.Message);
            }
        }

        private void lstAlimentos_DoubleClick(object sender, EventArgs e)
        {
            ItemDataTable2 idt = (ItemDataTable2)lstAlimentos.Items[lstAlimentos.SelectedIndex];
            //MessageBox.Show(idt.Id);
            CHAVEMESTRAal = idt.Id;
            RepassarDadosDaListaParaOFormulario(idt);
        }

                

    private void txtBuscaAlimento_TextChanged(object sender, EventArgs e)
        {
            //DEU CERTOOOOOOOOOOOOOO!! QUE LINDOOOOOOOOOOOOOOOOOOOOOO HAHHAHAHAHAHHAHAHA
            if (!(String.IsNullOrEmpty(txtBuscaAlimento.Text)))
            {
                lstAlimentos.Items.Clear();
                foreach (ItemDataTable2 idt in listaItem)
                {
                    //Caso quisesse procurar pelo início da palavra, ao invés do método 'Contains', deveria usar o 'StartsWith'
                    if (idt.nome.ToUpper().Contains(txtBuscaAlimento.Text.ToUpper()))
                    {
                        lstAlimentos.Items.Add(idt);
                    }
                }
            }
            else AtualizarListBox();
        }

        public void ObterRegistosDaTabela()
        {
            CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaPlano);
            DataTable dt = c.BuscarTodosOsDadosNaTabela();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listaBi.Add(new List<string> { dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString() });
            }
        }

        public void PreencherLista()
        {
            for (int i = 0; i < listaBi.Count; i++)
            {
                ItemDataTable2 idt = new ItemDataTable2();
                idt.Id = listaBi[i][0];
                idt.nome = listaBi[i][1];
                idt.protAnimal = listaBi[i][2];
                idt.protVegetal = listaBi[i][3];
                idt.hCarbono = listaBi[i][4];
                idt.lipidios = listaBi[i][5];
                idt.fibra = listaBi[i][6];
                idt.valor = listaBi[i][7];

                lstAlimentos.Items.Add(idt);
            }
        }

        public void AtualizarListBox()
        {
            lstAlimentos.Items.Clear();
            listaBi.Clear();
            ObterRegistosDaTabela();
            PreencherLista();
        }


        public void RepassarDadosDaListaParaOFormulario(ItemDataTable2 i)
        {
            txtNomeAlimento.Text = i.nome;
            txtProtAnimal.Text = i.protAnimal;
            txtProtVegetal.Text = i.protVegetal;
            txtHCarbono.Text = i.hCarbono;
            txtLipidio.Text = i.lipidios;
            txtFibra.Text = i.fibra;
            txtValor.Text = i.valor;
        }


    }

    public class ItemDataTable2
    {
        public string Id { get; set; }
        public string nome { get; set; }
        public string protAnimal { get; set; }
        public string protVegetal { get; set; }
        public string hCarbono { get; set; }
        public string lipidios { get; set; }
        public string fibra { get; set; }
        public string valor { get; set; }

        public override string ToString()
        {
            return /*Id + " - " + */nome;
        }
    }

}
