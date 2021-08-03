using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace CalcNutri2
{
    //(CRUD-Create, Read, Update and Delete)
    public class CRUDBancoDeDados
    {
        public string tabela;
        public ConexaoSQLServer db;
        public bool status;
        public string mensagem;

        //Na instanciação da classe será requerido o nome da tabela em que se pretende trabalhar. Dessa forma, todos os métodos contidos
        // nessa classe, sendo eles: criação, leitura, atualização e exclusão de dados nas tabelas, poderão ser utilizados em qualquer parte
        // do programa, bastando informar a tabela e repassar a string sql de conteúdo de dados para inclusão e/ou alteração
        public CRUDBancoDeDados(string Tabela)
        {
            status = true;
            try
            {
                db = new ConexaoSQLServer();
                tabela = Tabela;
                mensagem = "Camada - 3.0 // Conexão com a Tabela efetuada com sucesso.";
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "ERRO-Camada - 3.0 // Não foi possível se conectar a Tabela. --\n" + ex.Message;
            }
        }

        public void IncluirDadosNaTabela(string stringDados)
        {
            status = true;
            try
            {
                //crio a string SQL com a sintaxe correta de inclusão e com os dados para a inclusão
                string stringSQL = "INSERT INTO " + tabela + stringDados + ";";
                //Abro o comando SQL para a inclusão
                db.SQLComando(stringSQL);
                //Guardo o status como verdadeiro a fim de confirmar nas camadas superiores que tudo ocorreu como esperado
                status = true;
                mensagem = "Camada - 3.1 // Inclusão de dados na tabela '" + tabela + "' efetuada com sucesso.";
                //Encerro a conexão para evitar travamento ou conflito de dados em operções futuras
                db.Fechar();
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "ERRO-Camada - 3.1 // Inclusão de dados na tabela '" + tabela + "' apresentou falha. --\n" + ex.Message;
            }
        }


        public DataTable BuscarTodosOsDadosNaTabela()
        {
            DataTable dt = new DataTable();
            status = true;
            try
            {
                string stringSQL = "SELECT * FROM" + tabela;
                dt = db.SQLQuery(stringSQL);
                db.Fechar();
                status = true;
                mensagem = "Camada - 3.2.1 // Busca de dados na tabela '" + tabela + "' efetuada com sucesso.";
                return dt;
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "ERRO-Camada - 3.2.1 // Busca de dados na tabela '" + tabela + "' apresentou falha. --\n" + ex.Message;
            }
            return dt;
        }


        public DataTable BuscarDadosNaTabelaComID(string stringDados, string strindId, bool manterConexao)
        {
            DataTable dt = new DataTable();
            status = true;
            try
            {
                string stringSQL = "SELECT " + stringDados + " FROM " + tabela + " WHERE Id = " + strindId;
                dt = db.SQLQuery(stringSQL);
                //Eventualmente preciso que a conexão se mantenha aberta por isso inclui um parametro onde eu possa manipular a abertura e o
                //encerramento da conexão
                if (!manterConexao) db.Fechar();
                status = true;
                mensagem = "Camada - 3.3.1 // Busca de dados na tabela '" + tabela + "' efetuada com sucesso.";
                return dt;
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "ERRO-Camada - 3.3.2 // Busca de dados na tabela '" + tabela + "' apresentou falha. --\n" + ex.Message;
            }
            return dt;
        }


        public DataTable BuscarDadosNaTabelaComNome(string stringDados, string strindNome, bool manterConexao)
        {
            DataTable dt = new DataTable();
            status = true;
            try
            {
                string stringSQL = "SELECT " + stringDados + " FROM " + tabela + " WHERE Nome = '" + strindNome + "';";
                dt = db.SQLQuery(stringSQL);
                //Eventualmente preciso que a conexão se mantenha aberta por isso inclui um parametro onde eu possa manipular a abertura e o
                //encerramento da conexão
                if (!manterConexao) db.Fechar();
                status = true;
                mensagem = "Camada - 3.4.1 // Busca de dados na tabela '" + tabela + "' efetuada com sucesso.";
                return dt;
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "ERRO-Camada - 3.4.2 // Busca de dados na tabela '" + tabela + "' apresentou falha. --\n" + ex.Message;
            }
            return dt;
        }


        public void DeletarRegistoNaTabelaComID(string stringId)
        {
            status = true;
            try
            {
                DataTable dt = db.SQLQuery("SELECT * FROM" + tabela);
                if (dt.Rows.Count > 0)
                {
                    string stringSQL = "DELETE FROM " + tabela + " WHERE Id = " + stringId;
                    db.SQLComando(stringSQL);
                    db.Fechar();
                    status = true;
                    mensagem = "Camada - 3.5 // Exclusão de registo na tabela '" + tabela + "' efetuada com sucesso.";
                }
                else
                {
                    status = false;
                    mensagem = "ERRO-Camada - 3.5.1 // Exclusão de registo na tabela '" + tabela + "' apresentou falha. -- O Id + '" + stringId + "' Não existe.";
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "ERRO-Camada - 3.5.2 // Exclusão de registo na tabela '" + tabela + "' apresentou falha. --\n" + ex.Message;
            }
        }

        public void AlterarDadosNaTabelaComID(string stringDados, string stringId)
        {
            status = true;
            try
            {
                //Não usei o método 'BuscarTodosOsDadosNaTabela' aqui pq terminada a instrução a conexao é fechada, e preciso manter ela
                //aberta paraexecutar um segundo comando, o UPDATE
                DataTable dt = db.SQLQuery("SELECT * FROM " + tabela);
                if (dt.Rows.Count > 0)
                {
                    string stringSQL = "UPDATE " + tabela + " SET " + stringDados + " WHERE Id = " + stringId;
                    db.SQLComando(stringSQL);
                    db.Fechar();
                    status = true;
                    mensagem = "Camada - 3.6 // Alteração de dados na tabela '" + tabela + "' efetuada com sucesso.";
                    mensagem += "\n\n\n" + stringSQL;
                }
                else
                {
                    status = false;
                    mensagem = "ERRO-Camada - 3.6.1 // Alteração de dados na tabela '" + tabela + "' apresentou falha. -- O Id + '" + stringId + "' Não existe.";
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "ERRO-Camada - 3.6.2 // Alteração de dados na tabela '" + tabela + "' apresentou falha. --\n" + ex.Message;
            }
        }


        public DataTable FiltrarDadosNaTabelaComNome(string stringDados, string strindNome)
        {
            DataTable dt = new DataTable();
            status = true;
            try
            {
                string stringSQL = "SELECT " + stringDados + " FROM " + tabela + " WHERE Nome like '%" + strindNome + "%';";
                dt = db.SQLQuery(stringSQL);
                db.Fechar();
                status = true;
                mensagem = "Camada - 3.7.1 // Filtro de dados na tabela '" + tabela + "' efetuada com sucesso.";
                return dt;
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "ERRO-Camada - 3.7.2 // Filtro de dados na tabela '" + tabela + "' apresentou falha. --\n" + ex.Message;
            }
            return dt;
        }

        public void CUDDeDadosLIVRE(string stringDados, bool manterConexao)
        {
            status = true;
            try
            {
                //Abro o comando SQL para a inclusão
                db.SQLComando(stringDados);
                //Guardo o status como verdadeiro a fim de confirmar nas camadas superiores que tudo ocorreu como esperado
                status = true;
                mensagem = "Camada - 3.x // CUD bem sucedido.";
                //Encerro a conexão para evitar travamento ou conflito de dados em operções futuras
                if (!manterConexao) db.Fechar();
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "ERRO-Camada - 3.x // CUD apresentou falha. --\n" + ex.Message;
            }
        }

        public DataTable BuscarDadosLIVRE(string stringDados, bool manterConexao)
        {
            DataTable dt = new DataTable();
            status = true;
            try
            {
                dt = db.SQLQuery(stringDados);
                //Eventualmente preciso que a conexão se mantenha aberta por isso inclui um parametro onde eu possa manipular a abertura e o
                //encerramento da conexão
                if (!manterConexao) db.Fechar();
                status = true;
                mensagem = "Camada - 3.x // Busca de dados efetuada com sucesso.";
                return dt;
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "ERRO-Camada - 3.x // Busca de dados apresentou falha. --\n" + ex.Message;
            }
            return dt;
        }

        public void FecharConexao()
        {
            db.Fechar();
        }
    }
}
