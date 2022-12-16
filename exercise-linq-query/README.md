# Boas-vindas ao repositório do exercício LINQ-QUERY

Para realizar o projeto, atente-se a cada passo descrito a seguir. Se tiver qualquer dúvida, nos envie por _Slack_! #vqv 🚀

Aqui você vai encontrar os detalhes de como estruturar o desenvolvimento do seu projeto a partir deste repositório, utilizando uma branch específica e um _Pull Request_ para colocar seus códigos.

# Termos e acordos

Ao iniciar este projeto, você concorda com as diretrizes do Código de Conduta e do Manual da Pessoa Estudante da Trybe.

# Orientações

<details>
  <summary><strong>‼️ Antes de começar a desenvolver</strong></summary><br />

  1. Clone o repositório

  - Use o comando: `git clone git@github.com:tryber/acc-csharp-0x-exercise-linq-query`.git`.
  - Entre na pasta do repositório que você acabou de clonar:
    - `cd acc-csharp-0x-exercise-linq-query`

  2. Instale as dependências
  
  - Entre na pasta `src/`.
  - Execute o comando: `dotnet restore`.
  
  3. Crie uma branch a partir da branch `master`

  - Verifique se você está na branch `master`
    - Exemplo: `git branch`
  - Se não estiver, mude para a branch `master`
    - Exemplo: `git checkout master`
  - Agora crie uma branch à qual você vai submeter os `commits` do seu projeto
    - Você deve criar uma branch no seguinte formato: `nome-de-usuario-nome-do-projeto`
    - Exemplo: `git checkout -b joaozinho-acc-0x-project/exercise-<ATUALIZAR>`

  4. Adicione as mudanças ao _stage_ do Git e faça um `commit`

  - Verifique que as mudanças ainda não estão no _stage_
    - Exemplo: `git status` (deve aparecer listada a pasta _joaozinho_ em vermelho)
  - Adicione o novo arquivo ao _stage_ do Git
    - Exemplo:
      - `git add .` (adicionando todas as mudanças - _que estavam em vermelho_ - ao stage do Git)
      - `git status` (deve aparecer listado o arquivo _joaozinho/README.md_ em verde)
  - Faça o `commit` inicial
    - Exemplo:
      - `git commit -m 'iniciando o projeto x'` (fazendo o primeiro commit)
      - `git status` (deve aparecer uma mensagem tipo essa: _nothing to commit_ )

  5. Adicione a sua branch com o novo `commit` ao repositório remoto

  - Usando o exemplo anterior: `git push -u origin joaozinho-acc-0x-project/exercise-<ATUALIZAR>`

  6. Crie um novo `Pull Request` _(PR)_

  - Vá até a página de _Pull Requests_ do [repositório no GitHub](https://github.com/tryber/acc-csharp-0x-project/exercise-<ATUALIZAR>`/pulls)
  - Clique no botão verde _"New pull request"_
  - Clique na caixa de seleção _"Compare"_ e escolha a sua branch **com atenção**
  - Coloque um título para a sua _Pull Request_
    - Exemplo: _"Cria tela de busca"_
  - Clique no botão verde _"Create pull request"_
  - Adicione uma descrição para o _Pull Request_ e clique no botão verde _"Create pull request"_
  - **Não se preocupe em preencher mais nada por enquanto!**
  - Volte até a [página de _Pull Requests_ do repositório](https://github.com/tryber/acc-csharp-0x-project/exercise-<ATUALIZAR>`/pulls) e confira que o seu _Pull Request_ está criado

</details>

<details>
  <summary><strong>⌨️ Durante o desenvolvimento</strong></summary><br/>

  - Faça `commits` das alterações que você fizer no código regularmente

  - Lembre-se sempre de, após um (ou alguns) `commits`, atualizar o repositório remoto

  - Os comandos que você utilizará com mais frequência são:
    1. `git status` _(para verificar o que está em vermelho - fora do stage - e o que está em verde - no stage)_
    2. `git add` _(para adicionar arquivos ao stage do Git)_
    3. `git commit` _(para criar um commit com os arquivos que estão no stage do Git)_
    4. `git push -u origin nome-da-branch` _(para enviar o commit para o repositório remoto na primeira vez que fizer o `push` de uma nova branch)_
    5. `git push` _(para enviar o commit para o repositório remoto após o passo anterior)_

</details>

<details>
  <summary><strong>🤝 Depois de terminar o desenvolvimento (opcional)</strong></summary><br/>

  Para sinalizar que o seu projeto está pronto para o _"Code Review"_, faça o seguinte:

  - Vá até a página **DO SEU** _Pull Request_, adicione a label de _"code-review"_ e marque seus colegas:

    - No menu à direita, clique no _link_ **"Labels"** e escolha a _label_ **code-review**;

    - No menu à direita, clique no _link_ **"Assignees"** e escolha **o seu usuário**;

    - No menu à direita, clique no _link_ **"Reviewers"** e digite `students`, selecione o time `tryber/students-sd-0x`.

  Caso tenha alguma dúvida, [aqui tem um video explicativo](https://vimeo.com/362189205).

</details>

<details>
  <summary><strong>🕵🏿 Revisando um pull request</strong></summary><br />

  Use o conteúdo sobre [Code Review](https://app.betrybe.com/course/real-life-engineer/code-review) para te ajudar a revisar os _Pull Requests_.

</details>

<details>
  <summary><strong>🎛 Linter</strong></summary><br />

  Usaremos o [NetAnalyzer](https://docs.microsoft.com/pt-br/dotnet/fundamentals/code-analysis/overview) para fazer a análise estática do seu código.

  Este projeto já vem com as dependências relacionadas ao _linter_ configuradas no arquivo `.csproj`.

  O analisador já é instalado pelo plugin da `Microsoft C#` no `VSCode`. Para isso, basta fazer o download do [plugin](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) e instalá-lo.
</details>

<details>
  <summary><strong>🛠 Testes</strong></summary><br />

  O .NET já possui sua própria plataforma de testes.
  
  Este projeto já vem configurado e com suas dependências.

  ### Executando todos os testes

  Para executar os testes com o .NET, execute o comando dentro do diretório do seu projeto `src/<project>` ou de seus testes `src/<project>.Test`!

  ```
  dotnet test
  ```

  ### Executando um teste específico

  Para executar um teste específico, basta executar o comando `dotnet test --filter Name~TestMethod1`.

  :warning: **Importante:** o comando irá executar testes cujo nome contém `TestMethod1`.

  :warning: **O avaliador automático não necessariamente avalia seu projeto na ordem em que os requisitos aparecem no readme. Isso acontece para deixar o processo de avaliação mais rápido. Então, não se assuste se isso acontecer, ok?**

  ### Outras opções para testes
  - Algumas opções que podem lhe ajudar são:
    -  `-?|-h|--help`: exibe a descrição completa de como utilizar o comando.
    -  `-t|--list-tests`: lista todos os testes, ao invés de executá-los.
    -  `-v|--verbosity <LEVEL>`: define o nível de detalhe na resposta dos testes.
      - `q | quiet`
      - `m | minimal`
      - `n | normal`
      - `d | detailed`
      - `diag | diagnostic`
      - Exemplo de uso: 
         ```
           dotnet test -v diag
         ```
         ou
         ```            
           dotnet test --verbosity=diagnostic
         ``` 
</details>

<details>
  <summary><strong>🗣 Nos dê feedbacks sobre o projeto!</strong></summary><br />

Ao finalizar e submeter o projeto, não se esqueça de avaliar sua experiência preenchendo o formulário. 
**Leva menos de 3 minutos!**

[FORMULÁRIO DE AVALIAÇÃO DE PROJETO](https://be-trybe.typeform.com/to/PsefzL2e)

</details>

<details>
  <summary><strong>🗂 Compartilhe seu portfólio!</strong></summary><br />

  Você sabia que o LinkedIn é a principal rede social profissional e que compartilhar aprendizados lá é muito importante para quem deseja construir uma carreira de sucesso? Compartilhe este projeto no seu LinkedIn, marque o perfil da Trybe (@trybe) e mostre para a sua rede toda a sua evolução.

</details>

# Requisitos

Como pessoa desenvolvedora, você sempre terá que lidar com um grande número de dados, e antes de esses dados chegarem à nossa amada pessoa usuária, você irá precisar refinar e tratar a informação, de modo que faça sentido aos olhos da pessoa que a solicitou.

Vamos criar uma pequena biblioteca que faz algumas consultas em uma fonte de dados que contém informações sobre ações.

Claro que, como boa pessoa desenvolvedora que você é, quer garantir que as informações que você retornará corresponderão ao que foi solicitado, criando testes bonitões com xUnit e FluentAssertions. 
 
## 1 - Criar uma função que retorne as informações da classe `Stock` com base no símbolo informado e seus testes

<details>
  <summary>A função `getStock` deve realizar uma consulta com base no parâmetro `symbol` informado e retornar uma classe `Stock` </summary><br />
  
  Desenvolva sua solução em `stock-options/StockOptions.cs`, no método `getStock()`.
    
    
  A consulta deve ser feita ao service `IStockService`, armazenado no atributo `stockOptions`, que pode nos fornecer uma coleção de Stocks através do método `stocks()`.
</details>

<details>
  <summary>Utilizando xUnit + FluentAssertions, realize testes unitários para se certificar de que a função está retornando uma classe `Stock` válida. </summary><br />
  
   A função `HasStock()` deve verificar se a função `getStock` localizada em `stock-options/StockOptions.cs` retorna um objeto da classe `Stock`.

 Utilize a lib `Moq` para fazer os mocks da classe`Stock` e da interface `ISockService`.

   Dica: você pode utilizar a interface `IStock` para criar o mock da classe `Stock`.

  A função deve receber cinco parâmetros:
  - `symbol`: uma `string` indicando qual o valor do campo `symbol` que o mock da classe `Stock` deve receber.
  - `findStock`:um `double` indicando qual o valor que a função `getStock` deve receber.

 O teste deve verificar se:
  - o valor de `symbol` é o mesmo que o passado para a função `getStock`

</details>

## 2 - Recomendar uma ação para a pessoa usuária conforme o tipo e o range de preço informado e seus testes

<details>
  <summary>A função `recomendStock` deve retornar qualquer objeto da classe `Stock` que atenda aos critérios de tipo e faixa de valor </summary><br />
  
  Desenvolva sua solução em `stock-options/StockOptions.cs`, no método `recomendStock()`.
    
    
  A consulta deve ser feita ao service `IStockService`, assim como no requisito 1.
</details>

<details>
  <summary>Utilizando xUnit + FluentAssertions, realize testes unitários para se certificar de que a função está retornando uma classe `Stock`. </summary><br />

  A função `HasStockRecomend()` deve verificar se a função `recomendStock` localizada em `stock-options/StockOptions.cs` retorna um objeto da classe `Stock`, assim como no requisito 3.

  A função deve receber cinco parâmetros:

  - `mockType`: uma `string` indicando qual o valor do campo `type` que o mock da classe `Stock` deve receber.
  - `findType`: uma `string` indicando o valor do campo `type` que a função `recomendStock` deve receber.
  - `price`: um `double` indicando qual o valor do campo `lastPrice` que o mock da classe `Stock` deve receber.
  - `minValue`: um `double` indicando o valor mínimo que a função `recomendStock` deve receber.
  - `maxValue`: um `double` indicando o valor máximo que a função `recomendStock` deve receber.

  O teste deve verificar se:
  - o valor de `lastPrice` está na faixa de preço `minValue` e `maxValue`;
  - o valor de  `type` é igual ao valor de `findType`
 
</details>

