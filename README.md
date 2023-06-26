
# Como rodar projeto

## Configurando *appsettings.json*

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "Database": "Server=yourServerName;Database=DB_Controle_Pedidos;Integrated Security=SSPI; TrustServerCertificate=True"
  },
  "AllowedHosts": "*"
}
```

Este arquivo contém as seguintes configurações:

Logging: Define o nível de log para o aplicativo. Neste exemplo, o nível padrão é "Information" e o nível para logs específicos do ASP.NET Core é definido como "Warning".

ConnectionStrings: Define a string de conexão com o banco de dados. No exemplo fornecido, a string de conexão aponta para um servidor chamado "MATEUS", com um banco de dados chamado "DB_Cadastro_Pessoas". A autenticação usada é a autenticação integrada do Windows (SSPI) e o certificado do servidor é confiável (TrustServerCertificate=True).

AllowedHosts: Especifica quais hosts são permitidos para acessar o aplicativo. Neste exemplo, o valor "*" indica que todos os hosts são permitidos. Você pode ajustar essa configuração para restringir o acesso apenas a hosts específicos, se necessário.

Essas são apenas configurações de exemplo e você pode personalizá-las de acordo com as necessidades do seu projeto. Certifique-se de atualizar a string de conexão com os detalhes do seu próprio banco de dados.

## Migração do Banco de Dados
Durante a migração de um projeto ASP .NET Core, é comum que também seja necessário atualizar o esquema do banco de dados para refletir as alterações feitas no código-fonte. Para isso, utilizaremos os comandos *Add-Migration* e *Update-Database* do Entity Framework Core.
O comando *Add-Migration* é usado para criar uma nova migração com base nas alterações no modelo de dados. Essa migração representa as alterações que serão aplicadas ao esquema do banco de dados.
Para adicionar uma nova migração, abra o console do Gerenciador de Pacotes no Visual Studio e execute o seguinte comando:

```Add-Migration NomeDaMigracao```

Certifique-se de substituir NomeDaMigracao pelo nome significativo da migração que está sendo adicionada. O Entity Framework Core criará automaticamente um arquivo de migração com base nas alterações detectadas no modelo de dados.

O comando *Update-Database* é usado para aplicar as migrações pendentes ao banco de dados. Ele atualiza o esquema do banco de dados para corresponder às alterações definidas nas migrações.
Para atualizar o banco de dados, abra o console do Gerenciador de Pacotes no Visual Studio e execute o seguinte comando:

```Update-Database```

O Entity Framework Core executará todas as migrações que ainda não foram aplicadas ao banco de dados.
