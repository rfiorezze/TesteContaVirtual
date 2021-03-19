# ContaVirtual

Prezados,

No repositório acima encontra-se um projeto de gerencia contas virtuais de um determinado banco.

<b>Como executar:</b>

- Abra o projeto da api que se encontra na pasta: BackEnd\ApiContaVirtual.

- Va até o arquivo appsettings.json que se encontra na pasta raiz do projeto.

- Coloque sua string de conexão (SQL SERVER).

- Vá até o Package Manager Console e execute o comando do Entity Framework: Upadte-Database.

- Por padrão, mandei o EF incluir uma conta e 2 tipos de movimentação: 1: Crédito e 2: Débito.

<b>Observações: </b> A api permite cadastrar outras contas e outros tipos de movimentação além desses.

- Abra o projeto da api que se encontra na pasta: FrontEnd\ContaVirtual e execute os comandos: npm install e npm start, na sequência.

- Pronto, agora é só testar.

<b>Obsservações:</b> Lembrando que é necessário incluir algumas movimentações financeiras na conta testada para conseguir.
listar o extrato.

- Para incluir as movimentações acesse a documentação da Api pelo Swagger que lá possui o JSON Exemplo para o método.

<b>Algumas dificuldades:</b> Tive que habilitar o CORS na minha API, pois quando o Front chamava a API de um diferente endereço, dava erro no TypeScript.

<b>Funções implementadas:</b>

<b>BackEnd (ASPNET CORE 3.1)</b>

- Documentação de toda API no SWAGGER
- Incluir Conta virtual
- Listar Contas Virtuais
- Listar Conta Virtual
- Incluir Movimentação
- Listar Extrato
- Incluir Tipo Movimentação


<b>Front End (ANGULAR v11.2.6)</b>

- Listar Extrato
- Listar Tipo Movimentação (Campo da tela)
- Listar Extrato por período e por Tipo de movimentação
