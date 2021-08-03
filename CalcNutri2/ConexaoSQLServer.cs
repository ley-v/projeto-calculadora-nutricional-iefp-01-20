using System;
using System.Collections.Generic;
using System.Data; //biblioteca para tratar a resposta do banco de dados com datatable
using System.Data.SqlClient; //biblioteca que fará acesso ao banco
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcNutri2
{
    //Classe para fazer a conectividade e conversar com o banco de dados
    public class ConexaoSQLServer
    {
        //string que fornece as propriedades de conectividade
        public string strDeConexao;
        //propriedade para armazenar a conexão e facilitar a manipulação da classe após a sua instanciação
        public SqlConnection conexao;
        public ConexaoSQLServer()
        {
            try
            {
                
                


                    //Nome do PC \\ Nome da Instância - pode ser substituído pelo 'ipv4,porto'
                    strDeConexao =  "data source = xxx; " + //*************************ATENÇÃOOOOOOOOOOO
                               "Initial catalog = dbCalcNutri; " +
                               "user id = sa; " +
                               "password = xxx;";
                //inicializa a variável e chama a conexão
                conexao = new SqlConnection(strDeConexao);
                //abre a conexão
                conexao.Open();
            }
            catch (Exception ex)
            {
                //No caso da conexão não abrir, o programa gera uma exceção com a mensagem abaixo
                throw new Exception("ERRO-Camada - 4.0 //\nNão foi possível se conectar a base de dados." + ex.Message);
            }
        }


        //Método para executar um comando no SQL Server / Inclusão, alteração, exclusão
        public void SQLComando(string comando)
        {
            try
            {
                SqlCommand novoComando = new SqlCommand(comando, conexao);
                //tempo de espera para que o comando retorne alguma mensagem
                //Deixando com o valor 0 significa que não existe Timeout, e assim previnimos que a conexão caia caso o tempo de resposta demore muito
                novoComando.CommandTimeout = 0;
                //envia o comando para o banco de dados
                novoComando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO-Camada - 4.1 //\nNão foi possível enviar este comando para a base de dados." + ex.Message);
            }
        }


        //Método que retornará dados em uma tabela em memória, será usada para consulta a base de dados
        public DataTable SQLQuery(string comando)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand novoComando = new SqlCommand(comando, conexao);
                novoComando.CommandTimeout = 0;
                SqlDataReader dadosDeRetorno = novoComando.ExecuteReader();
                //A variável dt, que é uma tabela em memória, vai receber o conteúdo do retorno do comando SQL que fez a consulta no banco de dados
                dt.Load(dadosDeRetorno);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO-Camada - 4.2 //\nNão foi possível enviar esta Query para a base de dados." + ex.Message);
            }
            //Mesmo que a tabela retorne vazia usaremos essa informação para fazer as manipulações pertinentes
            return dt;
        }


        //Método para fechar a conexão
        //Manter a conexão aberta pode gerar problemas como bloqueio de transação de dados ou travamento na consulta por certas funções
        // em certas tabelas
        public void Fechar()
        {
            conexao.Close();
        }



















        /*
        private string bancoDeDados = "data source = DESKTOP-EP24QQ1\\SQLEXPRESS; " +
                                      "Initial catalog = dbCalcNutri; " +
                                      "user id = sa; " +
                                      "password = 123.abc;";
        public string BancoDeDados {
            get 
            {
                return bancoDeDados;
            } 
        }
        public DataTable BuscarDados(string strConnection, string strSQL)
        {
            //criar uma conexão:
            SqlConnection C = new SqlConnection(strConnection);
            C.Open();
            //criar comando SQL para extrair os dados pretendidos:
            SqlCommand command = C.CreateCommand();
            command.CommandText = strSQL;

            //trazer os dados da tabela especificada para uma "tabela" em memória:
            SqlDataAdapter da = new SqlDataAdapter(command);
            var dt = new DataTable();
            da.Fill(dt);

            //desligar a conexão:
            C.Close();
            return dt;
        }
        */




    }
}
