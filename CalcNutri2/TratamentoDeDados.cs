using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Com o botão direito em Referencias do projeto principal > adicionar > Framework, adicionei a dll 'System.ComponentModel.DataAnnotations'
using System.ComponentModel.DataAnnotations; //Adicionei essa biblioteca para validar a classe Alimento

namespace CalcNutri2
{
    //Classe designada para receber o conteúdo digitado nos formulários
    public class TratamentoDeDados
    {
        //Os testes serão associados a classe
        //Primeiro, a classe Alimento irá receber todas as informações do formulário e só então implementará os testes (dentro da própria classe)
        public class Alimentos
        {
            //regra do componentModel.DataAnnotations obrigando o preenchimento do campo:
            //As propriedades entre conchetes não são obrigatórias e, caso não sejam preenchidas, o .net retornará uma mensagem padrão
            //O método Required exige que o campo seja preenchido
            [Required(ErrorMessage = "O Nome do Alimento é obrigatório")]
            // \w = aceita qualquer caractere que não seja especial (@,-,+,/,' etc..)
            // \s = aceita espaços e tabs
            // + = um ou mais da especificação anterior
            [RegularExpression(@"\w+\s*\w*\s*\w*\s*\w*\s*\w*\s*\w*\s*\w*", ErrorMessage = "O campo Nome do Alimento não pode conter caracteres especiais")]
            //Limitei o tamanho da string para até no máximo 150 caracteres para ter o mesmo tamanho definido na tabela do bando de dados
            [StringLength(150, ErrorMessage = "Você excedeu o limite de caracteres para o campo Nome do Alimento")]
            public string nome { get; set; }
            //// @ serve para o programa considerar tudo o que está entre aspas, da forma em que foi escrita
            ////(sem @ teria que ser usada 2 barras e isso afetaria o entendimento da Regex)
            //// \d = qualquer dígito de 0 a 9
            //// * = zero ou mais da especificação anterior ao símbolo
            //// \. = contem um ponto
            //// \, = contem uma vírgula
            //// ? pode ou não conter a definição predecessora
            //// @"\d{0,2}\.?\,?\d{0,2}" = o primeiro valor deve ser um, dois ou nenhum dígito, em seguida pode haver um ou nenhum ponto, 
            //// e também pode haver uma ou nenhuma vírgula, seguido ou não de um ou dois dígitos
            //Refatorei o código = Agora há 3 tipos de formato de entrada 1- 99,9+ / 2- 99.9+ / 3- 99 / ou nenhuma entrada
            //A princípio todos os campos, com exceção do nome, deveriam receber double. Contudo, se o tipo fosse double era preciso 
            //converter o valor antes de ser atribuído a classe, sendo que a classe só faria a validação após ser preenchida.
            //Pra sair do dilema do ovo e da galinha resolvi deixar todas as propriedades como tipo string e fazer o repasse sem as aspas para o comando sql
            [RegularExpression(@"(\d{0,2}\.\d{1,2})|(\d{0,2}\,\d{1,2})|(\d{0,2})", ErrorMessage = "O campo Proteína Animal foi inserido de forma incorreta")]
            public string protAnimal { get; set; }
            [RegularExpression(@"(\d{0,2}\.\d{1,2})|(\d{0,2}\,\d{1,2})|(\d{0,2})", ErrorMessage = "O campo Proteína Vegetal foi inserido de forma incorreta")]
            public string protVegetal { get; set; }
            [RegularExpression(@"(\d{0,2}\.\d{1,2})|(\d{0,2}\,\d{1,2})|(\d{0,2})", ErrorMessage = "O campo Hidrato de Carbono foi inserido de forma incorreta")]
            public string hCarbono { get; set; }
            [RegularExpression(@"(\d{0,2}\.\d{1,2})|(\d{0,2}\,\d{1,2})|(\d{0,2})", ErrorMessage = "O campo Lipídio foi inserido de forma incorreta")]
            public string lipidios { get; set; }
            [RegularExpression(@"(\d{0,2}\.\d{1,2})|(\d{0,2}\,\d{1,2})|(\d{0,2})", ErrorMessage = "O campo Fibra foi inserido de forma incorreta")]
            public string fibra { get; set; }
            //[Range(0, double.MaxValue, ErrorMessage ="regex pra double")]
            [RegularExpression(@"(\d{0,2}\.\d{1,2})|(\d{0,2}\,\d{1,2})|(\d{0,2})", ErrorMessage = "O campo Valor foi inserido de forma incorreta")]
            public string valor { get; set; }

            //Método necessário para conferir se as regras de preenchimento foram obedecidas, em caso negativo o programa irá gerar uma exceção
            public void ValidaAlimento()
            {
                //As duas primeiras linhas capturam o resultado dos testes (se o campo está vazio, se há apenas números etc..)
                ValidationContext contexto = new ValidationContext(this, serviceProvider: null, items: null);
                List<ValidationResult> resultados = new List<ValidationResult>();
                //Caso algum teste dê problema haverá um retorno booleano 'False'
                bool ehValido = Validator.TryValidateObject(this, contexto, resultados, true);
                if (ehValido == false)
                {
                    StringBuilder sErros = new StringBuilder();
                    //Esse loop fará acrescentar na string cada erro capturado
                    foreach (var item in resultados)
                    {
                        //AppendLine permite que seja inserido um string por linha 
                        sErros.AppendLine(item.ErrorMessage);
                    }
                    //Caso haja erros no preenchimento do formulário irei forçar uma exceção onde estará contida todas as mensagens de erro
                    throw new ValidationException("ERRO-Camada - 2.0 //\n" + sErros.ToString());
                }
            }

            public string StringSQLInclusao()
            {
                string sqlDados = "([Nome], [ProteinaAnimal], [ProteinaVegetal], [HCarbono], [Lipidio], [Fibra], [Valor]) VALUES ";
                sqlDados += "('" + nome + "', ";
                sqlDados += protAnimal.Replace(",", ".") + ", ";
                sqlDados += protVegetal.Replace(",", ".") + ", ";
                sqlDados += hCarbono.Replace(",", ".") + ", ";
                sqlDados += lipidios.Replace(",", ".") + ", ";
                sqlDados += fibra.Replace(",", ".") + ", ";
                sqlDados += valor.Replace(",", ".") + ")";

                return sqlDados;
            }

            public string StringSQLAlteracao()
            {
                string sqlDados = "[Nome] = '" + nome + "', ";
                sqlDados += "[ProteinaAnimal] = " + protAnimal.Replace(",", ".") + ", ";
                sqlDados += "[ProteinaVegetal] = " + protVegetal.Replace(",", ".") + ", ";
                sqlDados += "[HCarbono] = " + hCarbono.Replace(",", ".") + ", ";
                sqlDados += "[Lipidio] = " + lipidios.Replace(",", ".") + ", ";
                sqlDados += "[Fibra] = " + fibra.Replace(",", ".") + ", ";
                sqlDados += "[Valor] = " + valor.Replace(",", ".");

                return sqlDados;
            }

        }



        //Aqui as validações serão feitas dentro do formulário, ou seja, conforme o utilizador for preenchendo os campos
        public class Plano
        {
            public string id { get; set; }
            public string nomePlano { get; set; }
            public string nome { get; set; }
            public string sexo { get; set; }
            public string peso { get; set; }
            public int idade { get; set; }
            public int altura { get; set; }
            public string coeficiente { get; set; }
            public string objetivo { get; set; }

            public string StringSQLInclusao()
            {
                string sqlDados = "([Plano],[Nome],[Sexo],[Peso],[Idade],[Altura],[CoeficienteAtividade],[Objetivo]) VALUES ";
                sqlDados += "('" + nomePlano + "', ";
                sqlDados += "'" + nome + "', ";
                sqlDados += "'" + sexo + "', ";
                sqlDados += peso + ", ";
                sqlDados += idade + ", ";
                sqlDados += altura + ", ";
                sqlDados += coeficiente + ", ";
                sqlDados += "'" + objetivo + "')";

                return sqlDados;
            }

            public string StringSQLAlteracao()
            {
                string sqlDados = "[Plano] = '" + nomePlano + "', ";
                sqlDados += "[Nome] = '" + nome + "', ";
                sqlDados += "[Sexo] = '" + sexo + "', ";
                sqlDados += "[Peso] = " + peso + ", ";
                sqlDados += "[Idade] = " + idade + ", ";
                sqlDados += "[Altura] = " + altura + ", ";
                sqlDados += "[CoeficienteAtividade] = " + coeficiente + ", ";
                sqlDados += "[Objetivo] = '" + objetivo + "'";

                return sqlDados;
            }
        }


        //Método para conferir se uma string é vazia. Em caso positivo, retorna 'zero'
        public string TestaVazio(string txt)
        {
            string retorno;
            if (txt == "") retorno = "0";
            else retorno = txt;
            return retorno;
        }


        public class Refeicao
        {
            [Required(ErrorMessage = "O preenchimento do campo 'Nome da Refeição' é obrigatório")]
            // \w = aceita qualquer caractere que não seja especial (@,-,+,/,' etc..)
            // \s = aceita espaços e tabs
            // + = um ou mais da especificação anterior
            [RegularExpression(@"\w+\s*\w*\s*\w*\s*\w*\s*\w*", ErrorMessage = "O campo 'Nome da Refeição' não pode conter caracteres especiais")]
            [StringLength(50, ErrorMessage = "Você excedeu o limite de caracteres para o campo Nome do Alimento")]
            public string nome { get; set; }

            public void ValidaRefeicao()
            {
                ValidationContext context = new ValidationContext(this);
                List<ValidationResult> resultado = new List<ValidationResult>();
                bool ehValido = Validator.TryValidateObject(this, context, resultado, true);
                if (!ehValido)
                {
                    StringBuilder s = new StringBuilder();
                    foreach (var item in resultado)
                        s.AppendLine(item.ErrorMessage);
                    throw new ValidationException("ERRO-Camada - 2.0 //\n" + s);
                }
            }
        }


        public class LinhaRefeicao
        {
            [Required(ErrorMessage = "O preenchimento do campo 'Quantidade' é obrigatório")]
            // \w = aceita qualquer caractere que não seja especial (@,-,+,/,' etc..)
            // \s = aceita espaços e tabs
            // + = um ou mais da especificação anterior
            [RegularExpression(@"\d{1,3}", ErrorMessage = "O campo 'Quantidade' foi inserido de forma incorreta")]
            public string quantidade { get; set; }

            public void ValidaLinhaRefeicao()
            {
                ValidationContext context = new ValidationContext(this);
                List<ValidationResult> resultado = new List<ValidationResult>();
                bool ehValido = Validator.TryValidateObject(this, context, resultado, true);
                if (!ehValido)
                {
                    StringBuilder s = new StringBuilder();
                    foreach (var item in resultado)
                        s.AppendLine(item.ErrorMessage);
                        throw new ValidationException("ERRO-Camada - 2.0 //\n" + s);
                }
            }
        }
    }
}
