  Projeto: CRUD em C# com MySQL
Este projeto foi desenvolvido como um exercício de aprendizado para implementar operações CRUD (Create, Read, Update, Delete) em C# utilizando o Windows Forms e o banco de dados MySQL. Ele explora conceitos 
fundamentais de manipulação de dados, integração com banco de dados e uso de controles visuais no .NET.

Estrutura do Projeto:

1.	Banco de Dados:
•	O projeto utiliza um banco de dados MySQL chamado db_agenda com uma tabela contato contendo os campos id, nome, email e telefone.

3.	Conexão com o Banco:
•	A conexão é gerenciada pela classe MySqlConnection do pacote NuGet MySql.Data.
•	A string de conexão (data_source) contém as informações de acesso ao banco.

4.	Interface Gráfica:
•	A interface foi construída com Windows Forms.
•	O controle ListView é usado para exibir os contatos em formato de tabela, com colunas para ID, Nome, E-mail e Telefone.

5.	Operações CRUD:
•	Create (Salvar): Implementado no método alterarOuSalvarContato(). Insere um novo contato ou atualiza um existente, dependendo do valor de idContatoSelecionado.
•	Read (Buscar): Implementado no método button2_Click. Realiza buscas no banco com base no texto inserido no campo de busca.
•	Update (Alterar): Também gerenciado pelo método alterarOuSalvarContato(). Atualiza os dados de um contato selecionado.
•	Delete (Excluir): Implementado no método excluirContato(). Remove o contato selecionado após confirmação.

6.	Outros Recursos:
•	Carregamento Inicial: O método CarregaContato() exibe todos os contatos no ListView ao iniciar o programa.
•	Limpeza de Campos: O método LimpaCampos() reseta os campos de texto e oculta o botão de exclusão.
•	Seleção de Contatos: O evento listContatos_ItemSelectionChanged permite carregar os dados do contato selecionado nos campos de texto para edição.

Observações Importantes
•	Tratamento de Erros: O projeto inclui blocos try-catch para capturar exceções do MySQL e gerais, exibindo mensagens de erro amigáveis.
•	Boas Práticas:
•	Uso de parâmetros no SQL (@nome, @email, etc.) para evitar injeção de SQL.
•	Conexões com o banco são sempre fechadas no bloco finally.

•	Melhorias Futuras:
•	Implementar validações nos campos de entrada (ex.: verificar se o e-mail é válido).
•	Refatorar o código para separar a lógica de banco de dados em uma camada específica (ex.: DAO ou Repository).
•	Adicionar paginação na exibição de contatos para melhorar a performance com grandes volumes de dados.
