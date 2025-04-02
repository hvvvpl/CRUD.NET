using MySql.Data.MySqlClient;  // diretiva do pacote NuGet MySql.Data


namespace WinFormsApp1
{

    public partial class Form1 : Form
    {
        private MySqlConnection Conexao;            // propriedade que conecta o programa com o MySql pelo pacote NuGet
        private string data_source = "datasource=localhost; username=root; password=; database=db_agenda";          // fonte de dados
        public Form1()
        {
            InitializeComponent();

            listContatos.View = View.Details;   // Define o modo de exibi��o do ListView para 'Details', exibindo itens em uma grade com colunas
            listContatos.LabelEdit = true;      // Permite a edi��o do texto do item, mesmo que a funcionalidade de edi��o ainda n�o exista no aplicativo
            listContatos.AllowColumnReorder = true;     // Permite a reordena��o das colunas
            listContatos.FullRowSelect = true;      // Seleciona a linha inteira ao clicar em um item
            listContatos.GridLines = true;      // Exibe linhas de grade no ListView

            listContatos.Columns.Add("ID", 30, HorizontalAlignment.Left); // Adiciona a coluna 'ID'
            listContatos.Columns.Add("Nome", 150, HorizontalAlignment.Left); // Adiciona a coluna 'Nome'
            listContatos.Columns.Add("E-mail", 150, HorizontalAlignment.Left); // Adiciona a coluna 'E-mail'
            listContatos.Columns.Add("Telefone", 150, HorizontalAlignment.Left); // Adiciona a coluna 'Telefone'

        }

        /// <summary>
        /// 
        /// instancia objeto conexao com a 'fonte dos dados, usuario, senha e destino'.
        /// cria o comando INSERT na variavel 'sql'.
        /// cria o objeto comando, com o c�digo 'sql' e a 'Conexao' a ser usada como par�metro.
        /// 
        /// </summary>
        /// <param name="sender">button1_Click</param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // criar conex�o com MySql usando a propriedade criada na classe
                Conexao = new MySqlConnection(data_source);         // objeto conexao com a fonte de dados como par�metro

                string sql = "INSERT INTO contato (nome, telefone, email)" +
                           $" VALUES ('{txtNome.Text}','{txtTelefone.Text}','{txtEmail.Text}')";

                // Executar comando INSERT
                MySqlCommand comando = new MySqlCommand(sql, Conexao);

                Conexao.Open();

                comando.ExecuteReader();

                MessageBox.Show("Contato adicionado com sucesso!");
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
        /// cria uma string 'q' com o que foi inserido no textbox txtBuscar
        /// conecta ao banco de dados
        /// cria a senten�a sql com a busca do usuario
        /// cria o objeto comando com o c�digo e a conex�o a serem usadas
        /// cria o objeto reader para ler o resultado do comando e limpa a ListView listContatos caso j� tenha dados anteriores   
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
                string q = "'%" + txtBuscar.Text + "%'";         //deve colocar aspas simples para o MySql entender como string 

                // criar conex�o com MySql 
                Conexao = new MySqlConnection(data_source);

                string sql = "SELECT * FROM contato " +
                            "WHERE nome LIKE " + q + " OR email LIKE " + q;


                // Executar comando INSERT
                Conexao.Open();

                MySqlCommand comando = new MySqlCommand(sql, Conexao);

                MySqlDataReader reader = comando.ExecuteReader();

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
                        dessa forma, funcioona por�m esse m�todo considera que o dado buscado j� seja string, e se tiver int d� erro
                        */
                    };
                    var linhaListView = new ListViewItem(linha);            //cria um objeto ListViewItem com os dados da linha

                    listContatos.Items.Add(linhaListView);          //exibe a variavel linhaListView na ListView listContatos
                }
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
