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
    public partial class frm_iniciarTrocarPlano : Form
    {
        string tabelaPlano = "[TPlano]";
        List<List<string>> l1 = new List<List<string>>();



        public frm_iniciarTrocarPlano()
        {
            InitializeComponent();
            CRUDBancoDeDados c = new CRUDBancoDeDados(tabelaPlano);
            DataTable dt = c.BuscarTodosOsDadosNaTabela();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                l1.Add(new List<string> { dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString() });
            }
            PreencherLista();
            lstPlanos.Sorted = true;
        }

        private void btnSelecionarPlano_Click(object sender, EventArgs e)
        {
            if (lstPlanos.SelectedIndex != -1)
            {
                ItemDataTable x = (ItemDataTable)lstPlanos.Items[lstPlanos.SelectedIndex];
                if (MessageBox.Show("Tem certeza que deseja selecionar esse Plano?", "Iniciar/Trocar Plano Nutricional", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frm_principal p = new frm_principal();
                    p.CHAVEMESTRA = x.Id;
                    this.Close();
                }
                else MessageBox.Show("errouuu");
            }
            else MessageBox.Show("Selecione um item da lista", "Iniciar/Trocar Plano Nutricional", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void PreencherLista()
        {
            for (int i = 0; i < l1.Count; i++)
            {
                ItemDataTable x = new ItemDataTable();
                x.Id = l1[i][0];
                x.NomePlano = l1[i][1];
                x.Nome = l1[i][2];
                lstPlanos.Items.Add(x);
            }
        }
    }

    class ItemDataTable
    {
        public string Id { get; set; }
        public string NomePlano { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return Id + " - " + Nome + " - " + NomePlano;
        }
    }

}

