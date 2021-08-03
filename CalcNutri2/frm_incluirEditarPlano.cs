using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace CalcNutri2
{
    public partial class frm_incluirEditarPlano : Form
    {
        //Para receber o botão do MenuStrip do formulário principal
        ToolStripMenuItem componenteMenuFrmPrincipal;
        string tabelaPlano = "[TPlano]";
        //Essas variáveis privadas receberão os dados já validados e, posteriormente, serão alocadas em uma classe específica, 
        //onde essa, por sua vez, fará o repasse ao banco de dados
        string nomePlano;
        string nome;
        string sexo;
        //A ideia era acompanhar os mesmos tipos de dados da tabela. Mas como há uma interpretação diferente entre VS e SQL a cerca de números
        //quebrados, já que um usa vírgula e o outro ponto pra separar as casas decimais, na hora de repassar o string SQL o comando retornava
        //inválido. Sendo assim, pra poupar cabelos brancos, o campo Peso e Coeficiente serão do tipo String
        string peso;
        int idade;
        int altura;
        string coeficiente;
        string objetivo;

        // essa variável vai guardar o índice na tecla TAB referente ao campo que estiver sendo acessado no momento
        int tabIndex;
        // Juntamente com a variável acima esta será usada para implementar uma lógica de interação com o utilizador por meio de dialogBoxes.
        // Será apresentada uma caixa de dilálogo informando erros no preenchimento do formulário, porém, essa caixa não irá travar 
        //no campo em questão por mais de 1 aviso subsequente
        bool foco = false;

        public frm_incluirEditarPlano()
        {
            InitializeComponent();
            //Inicializo os 2 RadioButtons sem nenhuma seleção
            rdbM.Checked = false;
            rdbF.Checked = false;
            frm_principal p = new frm_principal();
            //Pra que a 'Chave Mestra" seja diferente de "x", algum plano já deve ter sido selecionado no formulário 'Iniciar Trocar Plano'
            if (p.CHAVEMESTRA != "x")
            {
                CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaPlano);
                //Caso algm plano já tenha sido selecionado, o formulário será preenchido com os dados buscados na base de dados, usando
                //o ID como parametro
                RepassarDadosDoPlanoParaOFormulario(c.BuscarDadosNaTabelaComID("*", p.CHAVEMESTRA, false));

                //StringBuilder s = new StringBuilder();
                //for (int i = 0; i < dt.Columns.Count; i++)
                //{
                //    s.AppendLine(dt.Rows[0][i].ToString());
                //}
                //MessageBox.Show(s.ToString());

                //string peso = dt.Rows[0]["Peso"].ToString();
                //MessageBox.Show(peso);
            }

        }


        //Região reservada para tratar a interação e a validação do campo 'txtNomePlano'
        #region "Nome do plano"

        //Quando o utilizador clicar no campo, as 2 variáveis serão atribuídas com os valores informados abaixo
        private void txtNomePlano_Click(object sender, EventArgs e)
        {
            tabIndex = 0;
            foco = true;
        }
        //Se a tecla pressionada antes do cursor entrar no campo txtNomePlano for a tecla TAB, as 2 variáveis receberão os respectivos valores
        //Dessa forma, como o utilizador irá navegar pelos campos do formulário através da tecla tab, farei uma Dialogbox travar aquele campo
        //toda vez que for preenchido incorretamente
        private void txtNomePlano_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                tabIndex = 0;
                foco = true;
            }
        }
        //Sempre que o cursor entrar no campo txtNomePlano a mensagem abaixo será exposta no campo de observação (label) no rodapé do formulário. 
        //Isso guiará o preenchimento dos dados de forma correta pelo utilizador
        private void txtNomePlano_Enter(object sender, EventArgs e)
        {
            lblObservacaoPlano.Text = "Insira o nome do Plano. \nEx: Quero deixar de ser gordo, tentativa 10245\nEx: Projeto verão 2021";
        }
        //Quando houver uma tentativa de deixar o campo haverá uma validação específica em txtNomePlano onde será verificado
        //se a string está vazia. Em caso positivo será verificado 1-se a tabIndex corresponde ao index deste campo e, 2-se a variável bool
        //é verdadeira. Confirmada as 2 condições uma messageBox surgirá para informar o utilizador sobre o preenchimento incorreto do campo.
        //Se o utilizador clicar en OK a variável booleana se tornará falsa e assim o utilizador será liberado para clicar em outro campo
        // mesmo sem ter preenchido o campo atual. Caso o utilizador tente navegar pelo formulário com a tecla TAB, a variável bool retorna a
        // true, e assim a mensagem de aviso sobre o preenchimento incorreto persistira até que ela seja solucionada.
        private void txtNomePlano_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNomePlano.Text))
            {
                if (tabIndex == 0 && foco)
                {
                    if (MessageBox.Show("O campo 'Nome do Plano' não pode ficar vazio", "Preenchimento Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        txtNomePlano.Focus();
                        foco = false;
                    }
                }
            }
            else nomePlano = txtNomePlano.Text;
        }
        #endregion



        //Região reservada para tratar a interação e a validação do campo 'txtNome'
        #region "Nome"
        //Os códigos aqui são iguais aos utilizados no campo anterior
        private void txtNome_Click(object sender, EventArgs e)
        {
            tabIndex = 1;
            foco = true;
        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            lblObservacaoPlano.Text = "Aqui é só digitar o Nome. Não dá pra errar, né? \nEx: Johnny Bigorna";
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNome.Text))
            {
                if (tabIndex == 1 && foco)
                {
                    if (MessageBox.Show("O campo 'Nome' não pode ficar vazio", "Preenchimento Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        foco = false;
                        txtNome.Focus();
                    }
                }
            }
            else nome = txtNome.Text;
        }

        private void txtNome_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                tabIndex = 1;
                foco = true;
            }
        }
        #endregion



        //Região reservada para tratar a interação e a validação dos campos 'rdbM' e 'rdbF'
        #region "Sexo"
        private void rdbM_Enter(object sender, EventArgs e)
        {
            lblObservacaoPlano.Text = "É Bedido ou bedida?";
        }

        private void rdbF_Enter(object sender, EventArgs e)
        {
            lblObservacaoPlano.Font = new Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Strikeout);
            lblObservacaoPlano.Text = "3x por semana";
            //lblInformacaoPlano.Leave += new System.EventHandler(MudarFont(), e); ###############################################################################################
        }

        private void rdbF_Leave(object sender, EventArgs e)
        {
            lblObservacaoPlano.Font = new Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular);
            if (rdbF.Checked) sexo = "f";
        }

        private void rdbM_Leave(object sender, EventArgs e)
        {
            if (rdbM.Checked) sexo = "m";
        }

        #endregion



        //Região reservada para tratar a interação e a validação do campo 'mskPeso'
        #region "Peso"
        //Inicialmente pensei em validar os campos que receberiam valores numéricos usando Máscara de texto e definindo os dígitos como
        // filtros para inserção de dados. Teria dado certo. Mas achei estéticamente feio. Por isso acabei usando os componentes
        // MaskedTextBoxes como TextBoxes normais.
        // A lógica aqui se mantem a mesma dos componentes anteriores. Apenas no evento Leave implementei mais uma condição de validação
        // que se refere ao comprimento do texto, no qual limitei em 6 caracteres

        private void mskPeso_Enter(object sender, EventArgs e)
        {
            lblObservacaoPlano.Text = "Informe o peso em Quilogramas (e não em arrobas). \nEx: 80   /   Ex: 70,55\n\nPS - Insira somente números.";
        }

        private void mskPeso_Leave(object sender, EventArgs e)
        {
            bool nPeso = double.TryParse(mskPeso.Text.Replace(".", ","), out double vPeso);
            if (nPeso)
            {
                if (vPeso.ToString().Length >= 7)
                {
                    mskPeso.Text = "";
                    if (tabIndex == 4 && foco)
                    {
                        if (MessageBox.Show("O campo 'Peso' excede o número máximo de caracteres", "Preenchimento Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            mskPeso.Focus();
                            foco = false;
                        }
                    }
                }
                else
                {
                    // pra nenhum engraçadinho introduzir número negativo
                    if (vPeso < 0) vPeso *= -1;
                    peso = vPeso.ToString();
                    peso = peso.Replace(",", ".");
                    //Para arrumar a formatação do texto no formulárioe e tirar sinal de negativo
                    mskPeso.Text = peso.Trim();
                }
            }
            else
            {
                mskPeso.Text = "";
                if (tabIndex == 4 && foco)
                {
                    if (MessageBox.Show("O campo 'Peso' não pode ficar vazio e só pode receber dígitos", "Preenchimento Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        mskPeso.Focus();
                        foco = false;
                    }
                }
            }
        }

        private void mskPeso_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                tabIndex = 4;
                foco = true;
            }
        }

        private void mskPeso_Click(object sender, EventArgs e)
        {
            tabIndex = 4;
            foco = true;
        }

        #endregion



        //Região reservada para tratar a interação e a validação do campo 'mskIdade'
        #region "Idade"
        //A lógica é a mesma que a do peso. A única diferença é que limitei a idade para no máximo 100 anos

        private void mskIdade_Enter(object sender, EventArgs e)
        {
            lblObservacaoPlano.Text = "Informe a idade em Anos. \nEx: 23   /   Ex: 59\n\nPS - Insira somente números.";
        }

        private void mskIdade_Leave(object sender, EventArgs e)
        {
            bool nIdade = int.TryParse(mskIdade.Text, out int vIdade);
            if (nIdade)
            {
                if (vIdade > 100)
                {
                    mskIdade.Text = "";
                    if (tabIndex == 5 && foco)
                    {
                        if (MessageBox.Show("Quer me enganar que tem mais de 100 anos? Preencha o campo 'Idade' direito", "Preenchimento Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            mskIdade.Focus();
                            foco = false;
                        }
                    }
                }
                else
                {
                    if (vIdade < 0) vIdade *= -1;
                    idade = vIdade;
                    //Para arrumar a formatação do texto no formulário e tirar sinal de negativo
                    mskIdade.Text = String.Join("", mskIdade.Text.ToCharArray().Where(Char.IsDigit));
                }
            }
            else
            {
                mskIdade.Text = "";
                if (tabIndex == 5 && foco)
                {
                    if (MessageBox.Show("O campo 'Idade' não pode ficar vazio e só pode receber dígitos", "Preenchimento Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        mskIdade.Focus();
                        foco = false;
                    }
                }
            }
        }

        private void mskIdade_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                foco = true;
                tabIndex = 5;
            }
        }

        private void mskIdade_Click(object sender, EventArgs e)
        {
            tabIndex = 5;
            foco = true;
        }

        #endregion



        //Região reservada para tratar a interação e a validação do campo 'mskAltura'
        #region "Altura"
        //Aqui implementei um método do Visual Basic e também Linq e Regex

        private void mskAltura_Enter(object sender, EventArgs e)
        {
            lblObservacaoPlano.Text = "Informe a altura em Centímetros. \nEx: 150   /   Ex: 180\n\nPS - Insira somente números.";
        }

        private void mskAltura_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                tabIndex = 6;
                foco = true;
            }
        }

        private void mskAltura_Click(object sender, EventArgs e)
        {
            tabIndex = 6;
            foco = true;
        }

        private void mskAltura_Leave(object sender, EventArgs e)
        {
            //Para variar o código e testar novas formas de validação, usei aqui um método pronto do VisualBasic que inspeciona se string 
            // inserida na textBix é um número. Acabei por descobrir que ela também considera a vírgula, por isso usei o método 
            // .Replace() para eliminá-las, visto que esse campo será convertido em um tipo inteiro.
            //Para ter acesso aos métodos do Visual Basic tive que adicionar a referência no projeto principal e também tive que incluir
            // a mesma dll Microsoft.VisualBasic no Using space

            mskAltura.Text = mskAltura.Text.Replace(".", "");
            if (Information.IsNumeric(mskAltura.Text))
            {
                //O méodo .Trim() é realmente PÉSSIMO. Ele praticamente só funciona se houver apenas 1 espaço na string e se esse espaço 
                // vier depois do dígito, caso venha antes, o programa quebra. Por isso tive que pesquisar outras formas de podar a string
                //afim de obter apenas os dígitos. Encontrei uma solução usando Regex e outra usando Linq. Os 2 funcionam lindamente

                //mskAltura.Text = mskAltura.Text.Trim();

                mskAltura.Text = mskAltura.Text.Replace(",", "");
                String.Join("", mskAltura.Text.ToCharArray().Where(Char.IsDigit));
                //mskAltura.Text = string.Join(null, System.Text.RegularExpressions.Regex.Split(mskAltura.Text, "[^\\d]"));
                if (mskAltura.Text.Length < 4 && mskAltura.Text.Length > 2)
                {
                    //Para arrumar a formatação do texto no formulário
                    mskAltura.Text = String.Join("", mskAltura.Text.ToCharArray().Where(Char.IsDigit));
                    altura = Convert.ToInt32(mskAltura.Text);
                }
                else
                {
                    mskAltura.Text = "";
                    if (tabIndex == 6 && foco)
                    {
                        if (MessageBox.Show("O campo 'Altura' deve conter 3 dígitos", "Preenchimento Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            mskAltura.Focus();
                            foco = false;
                        }
                    }
                }
            }
            else
            {
                mskAltura.Text = "";
                if (tabIndex == 6 && foco)
                {
                    if (MessageBox.Show("O campo 'Altura' não pode ficar vazio e só pode receber dígitos", "Preenchimento Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        mskAltura.Focus();
                        foco = false;
                    }
                }
            }
        }




        #endregion



        //Região reservada para tratar a interação e a validação do campo 'cmbCoeficiente'
        #region "Coeficiente"
        //O utilizador pode, tanto escolher o coeficiente através dos índices, como pode digitar pelo teclado, desde que o valor
        // digitado seja igual a algum item da lista
        private void cmbCoeficiente_Enter(object sender, EventArgs e)
        {
            lblObservacaoPlano.Text = "Selecione seu nível de atividade física";
        }

        //Cada item selecionado mostrará a observação correspondente para que o utilizador possa basear sua escolha
        private void cmbCoeficiente_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbCoeficiente.SelectedIndex)
            {
                case 0:
                    lblObservacaoPlano.Text = "Se você se mantém com rotina de exercícios raramente, é necessário multiplicar sua TMB por 1,2\nToma vergonha na cara";
                    break;
                case 1:
                    lblObservacaoPlano.Text = "Se você pratica exercícios de 1 a 3 dias por semana, deve multiplicar sua TMB por 1,375 \nSó pra dizer que é fitness...";
                    break;
                case 2:
                    lblObservacaoPlano.Text = "Se você pratica exercícios de 3 a 5 dias por semana, precisa multiplicar sua TMB por 1,55 \nCrossfiteiros e modelinhos de instagram? achei vcs";
                    break;
                case 3:
                    lblObservacaoPlano.Text = "Se você pratica exercícios de 6 a 7 dias por semana, precisa multiplicar sua TMB por 1,725 \nRato de academia";
                    break;
                case 4:
                    lblObservacaoPlano.Text = "Se você mantém a rotina de exercícios diariamente e tem um trabalho físico, ou costuma se exercitar duas vezes por dia, é necessário multiplicar a sua TMB por 1,9 \nPra que o super-homem precisa de dieta?";
                    break;
                default:
                    lblObservacaoPlano.Text = "Selecione o item que corresponde ao seu nível de atividade";
                    break;
            }
        }

        private void cmbCoeficiente_Leave(object sender, EventArgs e)
        {
            bool coeficienteValido = false;
            //Se o índice selecionado for diferente dos índices da combobox, que vai de 0 a 4, haverá uma segunda verificação
            if (cmbCoeficiente.SelectedIndex >= 0 && cmbCoeficiente.SelectedIndex <= 4)
            {
                coeficiente = cmbCoeficiente.Items[cmbCoeficiente.SelectedIndex].ToString();
                coeficiente = coeficiente.Replace(",", ".");
                coeficienteValido = true;
            }
            //O valor inserido a mão pelo utilizador tem correspondência com os itens contidos na combobox? Se sim, os valores são válidos, 
            //se não, a variável bool mantem sua atribuição como falsa, o valor digitado pelo utilizador será apagado e aparecerá
            // uma mensagem de alerta sobre preenchimento incorreto do campo
            else
            {
                for (int i = 0; i < cmbCoeficiente.Items.Count; i++)
                {
                    if (cmbCoeficiente.Text.Replace(".", ",") == cmbCoeficiente.Items[i].ToString())
                    {
                        //Foi quando eu descobri que a vírgula que estava causando problema na hora de inserir dados na tabela
                        double LIXODESQL = Convert.ToDouble(cmbCoeficiente.Items[i]);
                        coeficiente = LIXODESQL.ToString();
                        coeficiente = coeficiente.Replace(",", ".");
                        coeficienteValido = true;
                    }
                }
            }
            if (coeficienteValido == false)
            {
                cmbCoeficiente.Text = "";
                if (tabIndex == 7 && foco)
                {
                    if (MessageBox.Show("O campo 'Coeficiente de Atividade' não pode ficar vazio e só pode ser preenchido com os valores pré concebidos", "Preenchimento Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        cmbCoeficiente.Focus();
                        foco = false;
                    }
                }
            }
        }

        private void cmbCoeficiente_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                tabIndex = 7;
                foco = true;
            }
        }

        private void cmbCoeficiente_Click(object sender, EventArgs e)
        {
            tabIndex = 7;
            foco = true;
        }

        #endregion



        //Região reservada para tratar a interação e a validação do campo 'cmbObjetivo'
        #region "Objetivo"
        //Os códigos são os mesmos que o da combobox anterior. Apenas alterei o rodapé com as observações pertinentes para esse campo
        private void cmbObjetivo_Enter(object sender, EventArgs e)
        {
            lblObservacaoPlano.Text = "A vida é feita de escolhas difíceis. Suas opções:\n\nCutting     /     Manter \nBulking Seco     /     Bulking Severo";
        }

        private void cmbObjetivo_Click(object sender, EventArgs e)
        {
            tabIndex = 8;
            foco = true;
        }

        private void cmbObjetivo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                tabIndex = 8;
                foco = true;
            }
        }

        private void cmbObjetivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbObjetivo.SelectedIndex)
            {
                case 0:
                    lblObservacaoPlano.Text = "No Cutting, seu saldo calórico diário (TDEE), será reduzido em 25%. Essa redução é a máxima recomendada para quem quer perder gordura sem sacrificar a massa magra.";
                    break;
                case 1:
                    lblObservacaoPlano.Text = "Se escolher manter o peso seu consumo calórico diário será equivalente ao seu TDEE";
                    break;
                case 2:
                    lblObservacaoPlano.Text = "Pra crescer seco (ou pelo menos da forma menos suja possível) seu consumo calórico diário será acrescido de 150kcal";
                    break;
                case 3:
                    lblObservacaoPlano.Text = "Bulking severo é um ótimo pretexto pra ser gordo. Seu consumo calórico diário será acrescido de 300kcal";
                    break;
                default:
                    lblObservacaoPlano.Text = "Não esqueça dos aeróbicos!";
                    break;
            }
        }

        private void cmbObjetivo_Leave(object sender, EventArgs e)
        {
            bool coeficienteValido = false;
            if (cmbObjetivo.SelectedIndex >= 0 && cmbObjetivo.SelectedIndex <= 3)
            {
                objetivo = cmbObjetivo.Items[cmbObjetivo.SelectedIndex].ToString();
                coeficienteValido = true;
            }
            else
            {
                for (int i = 0; i < cmbObjetivo.Items.Count; i++)
                {
                    if (cmbObjetivo.Text == cmbObjetivo.Items[i].ToString())
                    {
                        objetivo = cmbObjetivo.Items[i].ToString();
                        coeficienteValido = true;
                    }
                }
            }
            if (coeficienteValido == false)
            {
                cmbObjetivo.Text = "";
                if (tabIndex == 8 && foco)
                {
                    if (MessageBox.Show("O campo 'Objetivo' não pode ficar vazio e só pode ser preenchido com os valores pré concebidos", "Preenchimento Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        cmbObjetivo.Focus();
                        foco = false;
                    }
                }
            }
        }


        #endregion


        //Repasso os dados pra classe 'TratamentoDeDados.Plano' pois lá é onde criei a StringSQL de inserção de dados
        public TratamentoDeDados.Plano RepassarDadosDoFormularioParaOPlano()
        {
            TratamentoDeDados.Plano tp = new TratamentoDeDados.Plano();
            tp.nomePlano = nomePlano;
            tp.nome = nome;
            tp.sexo = sexo;
            tp.peso = peso;
            tp.idade = idade;
            tp.altura = altura;
            tp.coeficiente = coeficiente;
            tp.objetivo = objetivo;

            return tp;
        }

        //preencher o formulário com os dados recebidos da base de dados. Dessa forma o utilizador poderá conferir quais dados ele inseriu
        //no momento do cadastro e se, por exemplo, houve alteração de peso e ele queira atualizar o plano, todos os outros campos já estarão
        //preenchidos
        public void RepassarDadosDoPlanoParaOFormulario(DataTable dt)
        {
            txtNomePlano.Text = dt.Rows[0]["Plano"].ToString();
            txtNome.Text = dt.Rows[0]["Nome"].ToString();
            if (dt.Rows[0]["Sexo"].ToString() == "m") rdbM.Checked = true;
            else rdbF.Checked = true;
            mskPeso.Text = dt.Rows[0]["Peso"].ToString();
            mskIdade.Text = dt.Rows[0]["Idade"].ToString();
            mskAltura.Text = dt.Rows[0]["Altura"].ToString();
            cmbCoeficiente.Text = dt.Rows[0]["CoeficienteAtividade"].ToString();
            cmbObjetivo.Text = dt.Rows[0]["Objetivo"].ToString();
            //os campos são preenchidos, mas a validação é feita e inserida nas propriedade. Por isso que o repasse não estava sendo feito
            //para a classe de Tratamento de Dados Plano, pois os campos abaixo constavam todos como vazios eles existiam apenas visualmente
            //no formulário. Mas esta classe não tinha seus valores
            nomePlano = txtNomePlano.Text;
            nome = txtNome.Text;
            if (rdbF.Checked) sexo = "f";
            else sexo = "m";
            //Aconteceu novamente o problema de conversão entre SQL e VS. Os valores quebrados da tabela SQLsaem com Ponto mas chegam com
            //Vírgula. Mas como na hora de preencher o formulário isso é feito pelo programa e não acontece o evento 'Leave' para executar as 
            //críticas necessárias e fazer o ajuste implementado naquele evento, nessa alada de passa ou repassa, o SQL acaba recebendo de volta
            //os valores com Vírgulo. Por isso aqui se faz necessário 1-Ou usar o método Replace para substituir as vírgulas,
            ////ou 2-Chamar o evento            ########### NÃO FUNCIONOU NÃO SEI PQ, deixei com o método Replace mesmo
            //'Leave' do respetivo campo na hora que o campo sofrer alteração, já que no evento 'Leave' já existe, entre outras coisas,
            //o código para converter a vírgula em ponto.
            peso = mskPeso.Text.Replace(",", ".");
            idade = Convert.ToInt32(mskIdade.Text);
            altura = Convert.ToInt32(mskAltura.Text);
            ////Como o Coeficiente sempre manipula valores quebrados, excepcionalmente na mudança desse campo, implementarei todas as validações da
            ////rotina 'Leave'
            // ESQUECEEEEE NÃO DEU CERTO O ESQUEMA DE CHAMAR O LEAVE' NA MUDANÇA DO CAMPO. TIVE QUE METER UM REPLACE MESMO
            //cmbCoeficiente.TextChanged += new EventHandler(cmbCoeficiente_Leave);
            coeficiente = cmbCoeficiente.Text.Replace(",", ".");
            objetivo = cmbObjetivo.Text;

        }

        //Limpa os dados do formulário
        public void LimparFormulario()
        {
            txtNomePlano.Text = "";
            txtNome.Text = "";
            rdbM.Checked = false;
            rdbF.Checked = false;
            mskPeso.Text = "";
            mskIdade.Text = "";
            mskAltura.Text = "";
            cmbCoeficiente.Text = "";
            cmbObjetivo.Text = "";
        }

        //O utilizador será questionado se pretende limpar o formulário com intuito de cadastrar um novo plano ou se a limpeza é só para
        //apagar os campos do formuário
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Caso a intenção do utilizador seja limpar o formulário para cadastrar um novo plano, mudarei o ID base do programa para um
            // valor genérico, no caso "x", isso forçara o utilizador trocar o plano em que deseja trabalhar assim que terminar o cadastro.
            if (MessageBox.Show("Deseja Cadastrar um novo Plano?", "Limpeza do Formulário", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frm_principal p = new frm_principal();
                p.CHAVEMESTRA = "x";
            }
            LimparFormulario();
        }


        //Embora tenha implementado a validação de forma unitária, em cada componente, para melhorar a interação do usuário com o programa
        // dei a opção de avançar pelos campos e ir preenchendo o formulário na ordem que fosse mais conveniente ao utilizador.
        //Por isso se faz necessário uma segunda verificação na hora de Editar/Incluir o formulário. Porém, aqui só se verifica se algum
        //campo permanece em branco.
        private void btnEditarIncluirPlano_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtNomePlano.Text == "" || mskIdade.Text == "" || mskAltura.Text == "" || mskPeso.Text == ""
                || cmbCoeficiente.Text == "" || cmbObjetivo.Text == "" || (rdbM.Checked == false && rdbF.Checked == false))
            {
                //A verificação dos campos sem preenchimento será feita de forma sequencial. Ex: Se o campo 'peso' e o campo 'objetivo'
                //estiverem vazios, o foco irá para o campo 'peso' pois ele aparece no formulário antes de 'objetivo'
                MessageBox.Show("Todos os Campos devem ser preenchidos", "Preencimento Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtNomePlano.Text == "") txtNomePlano.Focus();
                else if (txtNome.Text == "") txtNome.Focus();
                else if (rdbM.Checked == false && rdbF.Checked == false)
                {
                    //Sempre que um radioButton recebe foco ele automaticamente muda o estado para CHECADO. Assim, como meu intuito é forçar
                    //o utilizador escolher um dos sexos, e não deixar um ou outro radioButton previamente selecionado como padrão, retirei
                    //a seleção do radioButton logo após o foco, contudo, esse componente continua destacado no formulário
                    rdbM.Focus();
                    rdbM.Checked = false;
                }
                else if (mskPeso.Text == "") mskPeso.Focus();
                else if (mskIdade.Text == "") mskIdade.Focus();
                else if (mskAltura.Text == "") mskAltura.Focus();
                else if (cmbCoeficiente.Text == "") cmbCoeficiente.Focus();
                else if (cmbObjetivo.Text == "") cmbObjetivo.Focus();
            }
            else
            {
                //Se a chave Mesta for igual a 'x' significa que o utilizador quer cadastrar um novo PlanoNutricional
                frm_principal p = new frm_principal();
                //crio uma instancia da classe 'TratamentoDeDados.Plano'
                TratamentoDeDados.Plano tp = new TratamentoDeDados.Plano();
                //inclui no objeto 'tp' os dados já validados do formulário
                tp = RepassarDadosDoFormularioParaOPlano();
                if (p.CHAVEMESTRA == "x")
                {
                    try
                    {
                        //instancio a classe CRUD q contém os comandos genéricos CRUD e que, no seu construtor, abre conexão com a base de dados
                        CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaPlano);
                        //verifico, pelo status, se a conexão foi aberta
                        if (c.status)
                        {
                            //Uso o método da classe CRUD que insere os dados na tabela informada como argumento no momento da instanciação, e
                            //nesse método repasso a StringSQL que contem os valores de inclusão
                            c.IncluirDadosNaTabela(tp.StringSQLInclusao());
                            //Se o status for verdadeiso significa que os dados foram incluídos na tabela e a conexão já foi fechada
                            if (c.status)
                            {
                                MessageBox.Show("Camada - P1.1 // Inclusão bem sucedida\n" + c.mensagem);
                                //Caso o programa tenha iniciado sem nenhum registo na dabela de clientes, a opção do menu onde seria possível
                                //escolher um plano nutricional estará desabilitada. Agora que o utilizador acabou de incluir um registo, esse botão
                                // do menuStrip do formulário principal ficará habilitado.
                                componenteMenuFrmPrincipal.Enabled = true;
                                this.Close();
                            }
                            //aqui houve erro na inclusão dos dados
                            else MessageBox.Show("ERRO-Camada - P1.1 // Erro na Inclusão\n" + c.mensagem);
                        }
                        //aqui houve erro na conexão com a base de dados dos dados
                        else MessageBox.Show("ERRO-Camada - P1.1.2 // Erro na conexão com a Base de Dados\n" + c.mensagem);
                    }
                    //aqui possivelmente ocorreu algum erro crítico
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERRO-Camada - P1.1.3 // Erro na Inclusão\n" + ex.Message);
                    }
                }
                //Caso a CHAVE MESTRA, que é o Id que o programa está trabalhando, seja diferente de 'x', significa que já existe um registo
                //selecionado e portanto o cliente não pretende incluir um cadastro novo, mas sim realizar alterações nesse registo
                else
                {
                    try
                    {
                        if (MessageBox.Show("Tem certeza que pretende Alterar esse Plano Nutricional?\n" +
                            "(Se pretende cadastrar um novo Plano primeiro clique em Limpar o Formulário, preencha os campos e então clique em +" +
                            "Acidionar)", "Alteração", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaPlano);
                            if (c.status)
                            {
                                //Chamo o método de alterar dados da classe CRUD e passo como argumentos 1-a string SQL que encontra-se dentro da
                                //classe de tratamento de dados, e 2-o a chave primária que é i Id da tabela, nomeada aqui como CHAVEMESTRA
                                c.AlterarDadosNaTabelaComID(tp.StringSQLAlteracao(), p.CHAVEMESTRA);
                                //Aqui não há necessidade de fechar o formulário pois o Id já está selecionado e continuará o mesmo
                                if (c.status) MessageBox.Show("Camada - P1.2 // Alteração bem sucedida\n" + c.mensagem);
                                else MessageBox.Show("ERRO-Camada - P1.2 // Erro na Alteração\n" + c.mensagem);
                            }
                            //aqui houve erro na conexão com a base de dados dos dados
                            else MessageBox.Show("ERRO-Camada - P1.2.2 // Erro na conexão com a Base de Dados\n" + c.mensagem);
                        }
                    }
                    //aqui possivelmente ocorreu algum erro crítico
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERRO-Camada - P1.2.3 // Erro na Alteração\n" + ex.Message);
                    }
                }
            }
        }

        //Aqui recebo o objeto da barra de menu do formulário principal para, assim que o primeiro registo seja incluído na tabela, o botão
        // de 'iniciar/trocar de plano' fique habilitado
        public void HabilitarComponenteDoMenu(ToolStripMenuItem obj)
        {
            componenteMenuFrmPrincipal = obj;
        }

        //Esse botão vai deletar o registo atualmente selecionado
        private void btnDeletarPlano_Click(object sender, EventArgs e)
        {
            frm_principal p = new frm_principal();
            if (p.CHAVEMESTRA != "x")
            {
                try
                {
                    //Na instanciação da classe CRUD eu abro conexão com o Banco de dados e a propriedade 'status' me indica se a conexão foi
                    //bem sucedida
                    CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaPlano);
                    if (c.status)
                    {
                        if (MessageBox.Show("Tem certeza que pretende Excluir esse Plano Nutricional?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //O método foi criado para deletar um registo inteido da tabela. Preciso apenas informar o Id
                            c.DeletarRegistoNaTabelaComID(p.CHAVEMESTRA);
                            if (c.status)
                            {
                                LimparFormulario();
                                MessageBox.Show("Camada - P1.3 // Exclusão bem sucedida\n" + c.mensagem);
                                //Agora a chave toma o valor de X, o que obrigará o utilizador escolher um novo plano para que o programa possa
                                //basear seus cálculos
                                CRUDBancoDeDados cc = new CRUDBancoDeDados(tabelaPlano);

                                p.CHAVEMESTRA = "x";
                                DataTable dt = cc.BuscarTodosOsDadosNaTabela();
                                //Caso não reste nenhum registo na tabela, o botão de 'iniciar/trocar Plano' no menu do formulário principal
                                //ficará desabilitado
                                if (dt.Rows.Count == 0)
                                {
                                    componenteMenuFrmPrincipal.Enabled = false;
                                    MessageBox.Show("Não há mais nenhum Plano Nutricional cadastrado na Base de Dados");
                                }
                            }
                            //aqui houve erro na inclusão dos dados
                            else MessageBox.Show("ERRO-Camada - P1.3.1 // Erro na Exclusão\n" + c.mensagem);
                        }
                    }
                    //aqui houve erro na conexão com a base de dados dos dados
                    else MessageBox.Show("ERRO-Camada - P1.3.2 // Erro na conexão com a Base de Dados\n" + c.mensagem);
                }
                //aqui possivelmente ocorreu algum erro crítico
                catch (Exception ex)
                {
                    MessageBox.Show("ERRO-Camada - P1.3.3 // Erro na Exclusão\n" + ex.Message);
                }
            }
            else MessageBox.Show("Não há nenhum Plano Nutricional selecionado para efetuar a exclusão", "ERRO na Exclusão do Plano Butricional", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }




        // ############################################# FAZER COMENTARIOS ##########################################################

        // ############################################# FAZER COMENTARIOS ##########################################################

        // ############################################# FAZER COMENTARIOS ##########################################################

        // ############################################# FAZER COMENTARIOS ##########################################################

        // ############################################# FAZER COMENTARIOS ##########################################################

    }
}
