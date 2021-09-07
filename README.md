# PCWebApp
> PCWebApp oferece uma API para leitura, cadastro, atualização e remoção de colaboradores de uma empresa.

<p style='text-align: justify;'>PCWebApp é uma aplicação Web destinada a auxiliar no processo de exibição de um perfil de colaboradores. Com esta interface, é possível utilizar técnicas que permitem a leitura, inclusão, atualização e exclusão de colaboradores envolvidos em uma empresa.</p>

<p style='text-align: justify;'>Desenvolvida com .NET 5, realiza o uso de REST. Além disso, armazena os dados em banco de dados PostgreeSQL, disponibilizando as entidades COLABORADOR, GRUPO e DEPARTAMENTO exibidas no Diagrama de Entidade Relacionamento (DER).</p>

<p align="center">
  <img src="DER - Perfil de Colaboradores.png"/>
</p>

## Instalação do SDK (.NET Core 5.0)

<strong>Linux (Snapcraft):</strong>

```sh
sudo snap install dotnet-sdk --classic
```

<strong>Distribuições Linux baseadas em Debian:</strong>

```sh
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-5.0
```
<strong>Windows:</strong>


Realizar o download do Visual Studio 2019 por meio deste [link](https://visualstudio.microsoft.com/pt-br/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2019).

## Execução

<strong>Distribuições Linux baseadas em Debian:</strong>

```sh
dotnet build
dotnet run environment=development
```