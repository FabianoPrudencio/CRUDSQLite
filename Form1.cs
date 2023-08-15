using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUDSQLite
{
    public partial class Form1 : Form
    {
        public Random random;

        public Form1()
        {
            InitializeComponent();

            random = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BDcrudsqlite.CriarBancoSQLite();
            BDcrudsqlite.CriarTabelaSQLite();

            int numeroAleatorio = random.Next(1, 10001);
            txtId.Text = numeroAleatorio.ToString();
        }

        private void btnLancar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    MessageBox.Show("Forneça o NOME !");
                }
                else
                {

                    GScrudsqlite gScrudsqlite = new GScrudsqlite();
                    gScrudsqlite.ID = txtId.Text;
                    gScrudsqlite.NOME = txtNome.Text;
                    gScrudsqlite.EMAIL = txtEmail.Text;

                    BDcrudsqlite.Add(gScrudsqlite);

                    txtId.Clear();
                    txtNome.Clear();
                    txtEmail.Clear();

                    int numeroAleatorio = random.Next(1, 10001);
                    txtId.Text = numeroAleatorio.ToString();

                    MessageBox.Show("Entrada efetuada com sucesso !");
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERRO :" + EX.Message);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("Forneça o ID !");
                }
                else
                {
                    DataTable dt = new DataTable();
                    int ID = int.Parse(txtId.Text);
                    dt = BDcrudsqlite.GetID(ID);

                    DataRow row = dt.Rows[0];

                    if (row["ID"].ToString() == txtId.Text)
                    {
                        txtId.Text = row["ID"].ToString();
                        txtNome.Text = row["NOME"].ToString();
                        txtEmail.Text = row["EMAIL"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("ID não existe !");
                    }
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERRO :" + EX.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("Forneça o ID !");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Deseja editar o registro ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        GScrudsqlite gScrudsqlite = new GScrudsqlite();
                        gScrudsqlite.ID = txtId.Text;
                        gScrudsqlite.NOME = txtNome.Text;
                        gScrudsqlite.EMAIL = txtEmail.Text;

                        BDcrudsqlite.Update(gScrudsqlite);

                        txtId.Clear();
                        txtNome.Clear();
                        txtEmail.Clear();

                        int numeroAleatorio = random.Next(1, 10001);
                        txtId.Text = numeroAleatorio.ToString();

                        MessageBox.Show("Registro editado com sucesso !");
                    }
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERRO :" + EX.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(txtId.Text);

                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("Forneça o ID !");
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = BDcrudsqlite.GetID(ID);
                    DataRow row = dt.Rows[0];

                    if (row["ID"].ToString() == txtId.Text)
                    {
                        DialogResult result = MessageBox.Show("Deseja exculir ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            BDcrudsqlite.DeleteId(ID);

                            txtId.Clear();
                            txtNome.Clear();
                            txtEmail.Clear();

                            int numeroAleatorio = random.Next(1, 10001);
                            txtId.Text = numeroAleatorio.ToString();

                            MessageBox.Show("Registro deletado com sucesso !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não há registro ativo para esse ID");
                    }
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERRO :" + EX.Message);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja sair ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) 
            { 
                Application.Exit();            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtNome.Clear();
            txtEmail.Clear();

            int numeroAleatorio = random.Next(1, 10001);
            txtId.Text = numeroAleatorio.ToString();
        }
    }
}
