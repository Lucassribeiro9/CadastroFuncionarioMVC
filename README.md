<h1 align="center">
FuncionariosMVC
</h1>
<h6 align="right">Versão 1.0</h6>

![image](https://user-images.githubusercontent.com/57766036/193074337-5881ecb5-511f-49da-b829-86a822087498.png)


# 📖 Descrição do projeto
O projeto consiste em ter uma CRUD (Create, Read, Update and Delete) para cadastro de funcionários. Sua primeira versão possibilita ao usuário criar, excluir, consultar e atualizar o cadastro de um funcionário. No decorrer do documento, será mostrado as funcionalidades do projeto e as ferramentas necessárias para sua execução, junto com as ferramentas utilizadas para seu desenvolvimento. Esta é sua primeira versão e serão incrementadas mais funcionalidades no futuro.

# ✔️ Tecnologias utilizadas
[![My Skills](https://skills.thijs.gg/icons?i=cs)](https://skills.thijs.gg)
<img width="48" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/microsoftsqlserver/microsoftsqlserver-plain-wordmark.svg"/>
<img width="48" src="https://static.wikia.nocookie.net/logopedia/images/e/ec/Microsoft_Visual_Studio_2022.svg" alt="vs-logo"/>
<img width="48" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg"/>
          

## 📁 Acesso ao projeto
O código fonte está disponibilizado neste repositório. Você pode cloná-lo ou baixá-lo. Caso não esteja habituado a usar o Git e GitHub, <a href="https://github.com/rafaballerini/GitTutorial">clique aqui</a>

## 🛠️ Abrir e rodar o projeto
Após baixar o projeto, você pode abrir com o Visual Studio. Com o programa aberto, clique em:

- Open a project or solution (ou algo similar)
- Procure o local onde o projeto está salvo (caso esteja zipado, extraia o arquivo primeiro antes de procurar)
- Clique em Ok

O Visual Studio irá carregar o projeto e logo após, poderá ser executado.

⚠️ Antes de executar o projeto, verifique o arquivo <b>Program.cs</b> e <b>appsettings.json</b> caso faça uso do banco de dados. Altere a connectionString de acordo com seu banco, pois a migration será gerada conforme o banco utilizado.



<h4>Program.cs</h4>

~~~csharp
builder.Services.AddDbContext<FuncionariosMVCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FuncionariosMVCContext") ?? throw new InvalidOperationException("Connection string 'FuncionariosMVCContext' not found.")));

~~~

<h4>appsettings.json</h4>

```json
"ConnectionStrings": {
    "FuncionariosMVCContext": "Server=(localdb)\\mssqllocaldb;Database=FuncionariosMVCdb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
```

<a href="https://juniorb2s.medium.com/migrations-o-porque-e-como-usar-12d98c6d9269">O que são Migrations?</a>

<h4>Adicionando Migration</h4>

```
 Add-Migration inicial
```
Após a criação da migration, para a criação das tabelas e adaptação do CRUD, atualize sua base com o seguinte comando: 

```
 update-database
```

Para remover:

```
remove-migration "nome da migration"
```

# 🔨 Funcionalidades
- Criação do cadastro


- Tela inicial dos funcionários 



- Editar cadastro




- Excluir cadastro






