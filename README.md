# Microservices Application with .NET 6, Docker, and Docker Compose

Este é um exemplo de aplicação de microsserviços utilizando .NET 6 e Docker para orquestração dos containers. A aplicação consiste em três microsserviços:

1. **Serviço de Catálogo de Produtos:** Responsável por gerenciar o catálogo de produtos. Utiliza MongoDB como banco de dados.

2. **Serviço de Cesta de Produtos:** Responsável por gerenciar as cestas de produtos dos usuários. Utiliza Redis para armazenamento rápido de dados.

3. **Serviço de Desconto de Produtos:** Responsável por fornecer descontos para produtos. Utiliza PostgreSQL como banco de dados e GRPC para comunicação entre microsserviços.

## Pré-requisitos

Certifique-se de ter o seguinte instalado em sua máquina:

- .NET 6 SDK
- Docker
- Docker Compose

## Executando a Aplicação

Para executar a aplicação, siga estas etapas:

1. Clone este repositório em sua máquina local:

```bash
git clone https://github.com/seu-usuario/nome-do-repositorio.git
```

2. Navegue até o diretório raiz da aplicação:

```bash
cd nome-do-repositorio
```

3. Execute o Docker Compose para construir e iniciar os containers:

```bash
docker-compose up --build
```

Isso iniciará todos os microsserviços e seus bancos de dados associados.

4. Uma vez que os containers estejam em execução, você pode acessar cada microsserviço através dos seguintes endpoints:

   - **Serviço de Catálogo de Produtos:** (http://localhost:8000)
   - **Serviço de Cesta de Produtos:** (http://localhost:8001)
   - **Serviço de Desconto de Produtos:** (http://localhost:8002)

## Contribuindo

Se você quiser contribuir com este projeto, sinta-se à vontade para abrir uma issue ou enviar um pull request. Toda contribuição é bem-vinda!

## Licença

Este projeto é licenciado sob a [MIT License](LICENSE).

---

Sinta-se à vontade para personalizar este README de acordo com as necessidades específicas do seu projeto!
