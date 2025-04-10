using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;  // diretiva do pacote NuGet MySql.Data


namespace WinFormsApp1
{

    public partial class Form1 : Form
    {
        //https://dev.mysql.com/doc/connector-net/en/   //documentação do MySql connector no .NET

        private MySqlConnection Conexao;            // propriedade que conecta o programa com o MySql pelo pacote NuGet
        private string data_source = "datasource=localhost; username=root; password=; database=db_agenda";          // fonte de dados
        private int? idContatoSelecionado = null;


        public Form1()
        {
            InitializeComponent();

            listContatos.View = View.Details;   // Define o modo de exibição do ListView para 'Details', exibindo itens em uma grade com colunas
            listContatos.LabelEdit = true;      // Permite a edição do texto do item, mesmo que a funcionalidade de edição ainda não exista no aplicativo
            listContatos.AllowColumnReorder = true;     // Permite a reordenação das colunas
            listContatos.FullRowSelect = true;      // Seleciona a linha inteira ao clicar em um item
            listContatos.GridLines = true;      // Exibe linhas de grade no ListView

            listContatos.Columns.Add("ID", 30, HorizontalAlignment.Left); // Adiciona a coluna 'ID'
            listContatos.Columns.Add("Nome", 150, HorizontalAlignment.Left); // Adiciona a coluna 'Nome'
            listContatos.Columns.Add("E-mail", 150, HorizontalAlignment.Left); // Adiciona a coluna 'E-mail'
            listContatos.Columns.Add("Telefone", 150, HorizontalAlignment.Left); // Adiciona a coluna 'Telefone'

            CarregaContato();
        }


        /// <summary>
        /// 
        /// SALVAR | instancia objeto conexao com a 'fonte dos dados, usuario, senha e destino'.
        /// cria o comando INSERT na variavel 'sql'.
        /// cria o objeto comando, com o código 'sql' e a 'Conexao' a ser usada como parâmetro.
        /// 
        /// </summary>
        /// <param name="sender">button1_Click</param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            alterarOuSalvarContato();
        }


        /// <summary>
        /// 
        /// BUSCAR | cria uma string 'q' com o que foi inserido no textbox txtBuscar
        /// conecta ao banco de dados
        /// cria a sentença sql com a busca do usuario
        /// cria o objeto comando com o código e a conexão a serem usadas
        /// cria o objeto reader para ler o resultado do comando e limpa a ListView listContatos caso já tenha dados anteriores   
        /// pega todos os resultados do comando sql e organiza em um vetor de strings e exibe na ListView listContatos
        /// 
        /// </summary>
        /// <param name="sender">button2_Click</param>
        /// <param name="e"></param>
        /// 
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Conexao = new MySqlConnection(data_source);
                Conexao.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;
                cmd.CommandText = "SELECT * FROM contato WHERE nome LIKE  @q  OR email LIKE @q";
                cmd.Parameters.AddWithValue("@q", "%" + txtBuscar.Text + "%");
                cmd.Prepare();
                MySqlDataReader reader = cmd.ExecuteReader();

                /*
                string q = "'%" + txtBuscar.Text + "%'";         //deve colocar aspas simples para o MySql entender como string 
                // criar conexão com MySql 
                Conexao = new MySqlConnection(data_source);
                string sql = "SELECT * FROM contato WHERE nome LIKE " + q + " OR email LIKE " + q;
                // Executar comando INSERT
                Conexao.Open();
                MySqlCommand comando = new MySqlCommand(sql, Conexao);
                MySqlDataReader reader = comando.ExecuteReader();
                */

                listContatos.Items.Clear();
                while (reader.Read())       //retorna true sempre que houver mais registros para ler
                {
                    string[] linha =        //armazena em um novo vetor os dados dos campos 0,1,2,3 da tabela contato
                    {
                        reader[0].ToString(),       // Converte qualquer tipo para string
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        /*
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        dessa forma, funcioona porém esse método considera que o dado buscado já seja string, e se tiver int dá erro
                        */
                    };
                    var linhaListView = new ListViewItem(linha);            //cria um objeto ListViewItem com os dados da linha
                    listContatos.Items.Add(linhaListView);          //exibe a variavel linhaListView na ListView listContatos

                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Number + " Ocorreu:" + ex.Message, "Erro",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.Close();
            }
        }


        /// <summary>
        /// 
        /// NOVO | reseta os textboxes e o idContatoSelecionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }


        /// <summary>
        /// 
        /// EXCLUIR | 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            excluirContato();
        }


        private void CarregaContato()
        {
            try
            {
                Conexao = new MySqlConnection(data_source);
                Conexao.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;
                cmd.CommandText = "SELECT * FROM contato ORDER BY id DESC";
                cmd.Prepare();
                MySqlDataReader reader = cmd.ExecuteReader();

                listContatos.Items.Clear();
                while (reader.Read())       //retorna true sempre que houver mais registros para ler
                {
                    string[] linha =        //armazena em um novo vetor os dados dos campos 0,1,2,3 da tabela contato
                    {
                        reader[0].ToString(),       // Converte qualquer tipo para string
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                    };
                    var linhaListView = new ListViewItem(linha);            //cria um objeto ListViewItem com os dados da linha
                    listContatos.Items.Add(linhaListView);          //exibe a variavel linhaListView na ListView listContatos
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Number + " Ocorreu:" + ex.Message, "Erro",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.Close();
            }
        }


        private void LimpaCampos()
        {
            idContatoSelecionado = null;
            txtNome.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();

            txtNome.Focus();
            button4.Visible = false;
        }


        private void listContatos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListView.SelectedListViewItemCollection itensSelecionados = listContatos.SelectedItems;

            foreach (ListViewItem item in itensSelecionados)
            {
                idContatoSelecionado = Convert.ToInt32(item.SubItems[0].Text);      //convert.toint32 aceita null como 0 sem lançar exeção (também aceita objetos)

                txtNome.Text = item.SubItems[1].Text;       //pega o texto do campo 1 (nome) e coloca no textbox txtNome
                txtTelefone.Text = item.SubItems[2].Text;   //pega o texto do campo 2 (telefone) e coloca no textbox txtTelefone
                txtEmail.Text = item.SubItems[3].Text;      //pega o texto do campo 3 (email) e coloca no textbox txtEmail  

                button4.Visible = true;
            }
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            excluirContato();
        }


        private void excluirContato()
        {
            try
            {
                DialogResult confirmacao = MessageBox.Show("Tem certeza que deseja excluir o registro?",
                                                            "CUIDADO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacao == DialogResult.Yes)
                {

                    Conexao = new MySqlConnection(data_source);
                    Conexao.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = Conexao;
                    cmd.CommandText = "DELETE FROM contato " +
                                      "WHERE id=@id";
                    cmd.Parameters.AddWithValue("@id", idContatoSelecionado);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Contato excluido com suceesso!", "Excluido", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CarregaContato();

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Number + " Ocorreu:" + ex.Message, "Erro",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.Close();
            }
        }


        private void alterarOuSalvarContato()
        {
            try
            {

                Conexao = new MySqlConnection(data_source);
                Conexao.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;

                if (idContatoSelecionado == null)
                {
                    cmd.CommandText = "INSERT INTO contato (nome, telefone, email) VALUES (@nome, @telefone, @email)";
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Contato inserido com sucesso!", "Sucesso!",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cmd.CommandText = "UPDATE contato " +
                                      "SET nome =@nome, email=@email, telefone=@telefone " +
                                      "WHERE id=@id";
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@id", idContatoSelecionado);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Contato atualizado com sucesso!", "Sucesso!",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                idContatoSelecionado = null;
                CarregaContato();       //mostra os contatos no listView
                LimpaCampos();          //limpa os textboxes

                /*
                 * código antigo
                
                // criar conexão com MySql usando a propriedade criada na classe
                Conexao = new MySqlConnection(data_source);         // objeto conexao com a fonte de dados como parâmetro

                string sql = "INSERT INTO contato (nome, telefone, email)" +
                           $" VALUES ('{txtNome.Text}','{txtTelefone.Text}','{txtEmail.Text}')";

                // Executar comando INSERT
                MySqlCommand comando = new MySqlCommand(sql, Conexao);

                Conexao.Open();

                comando.ExecuteReader();

                MessageBox.Show("Contato adicionado com sucesso!");
                */
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Number + " Ocorreu:" + ex.Message, "Erro",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.Close();
            }
        }
    }
}
