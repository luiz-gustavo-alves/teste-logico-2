## 1 - Estrutura de banco de dados
![image](https://github.com/luiz-gustavo-alves/teste-logico-2/assets/114351018/11f49408-c7e5-43da-bce5-667f1defa609)

**OBS**: O tipo do preço do pedágio está como `int` para resolver inconsistências comparado ao cálculo do desconto com o tipo `float/double`. Portanto, por exemplo, o preço 760 representa 7 reais e 60 centavos.

## 2 - Comandos de banco de dados para operar
```sql
SELECT * FROM "Condutor" WHERE "Id" = Condutor.Id;

SELECT * FROM "Pedagio" WHERE "Id" = Pedagio.Id;

SELECT * FROM "Passagem" WHERE "Id" = Passagem.Id;

INSERT INTO "Passagem" ("Id", "AnoAtual", "CondutorId", "Contador", "CreatedAt", "MesAtual", "PedagioId", "UpdatedAt") VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7);

UPDATE "Passagem" SET "Contador" = @p0, "UpdatedAt" = @p1, "MesAtual" = @p2, "AnoAtual" = @p3 WHERE "Id" = Passagem.Id;
```

## 3 - Algoritmo do processo
- Verificar condutor e pedágio existente
  - Caso não exista, retorne erro. 
- Verificar passagem existente
  - Dados condutor e pedágio, se a passagem não existir:
    - Cria uma nova passagem com contador igual a 1, mês e ano com valores atuais;
    - Não será atribuído desconto na passagem.
  - Dados condutor e pedágio, se a passagem existir:
    - Verificar e comparar o último mês e ano em que o condutor utilizou o pedágio com mês e ano atual.
      - Caso a comparação seja falsa, atualizar o valor do contador para 1 e atualizar mês e ano com as datas atuais;
      - Caso a comparação seja verdadeira, incrementar o valor do contador em 1 unidade;
      - Em ambos os casos, atualizar o atributo da passagem no banco de dados.
    - Verificar o valor do desconto que será atribuído a passagem:
      - Cálculo do desconto: INITIAL_DISCOUNT * (passagem.Contador / DISCOUNT_COUNTER);
        - INITIAL_DISCOUNT = 0.05;
        - DISCOUNT_COUNTER = 10;
        - passagem.Contador = contador de quantas vezes o condutor utilizou o mesmo pedágio.
      - Caso desconto seja igual a zero:
        - Não será atribuído desconto na passagem.
      - Caso desconto seja menor que o valor máximo da tarifa (20%):
        - Será aplicado o valor do desconto referente ao cálculo do desconto feito sobre a passagem.
      - Caso desconto seja maior ou igual ao valor máximo da tarifa (20%).
        - Será aplicado o valor do desconto igual a 20% sobre a passagem.

## Como executar o projeto
Clone este repositório com o comando `git clone https://github.com/luiz-gustavo-alves/teste-logico-2.git`
<br>
Acesse a pasta **Docker** e utilize os seguintes comandos dentro de um terminal shell:
```bash
cd Docker
docker compose up -d
```
API está sendo executada na porta 5000.

## Swagger
Com os containers do Docker ativos, a documentação dos endpoints da API está acessível com Swagger: [http://localhost:5000/swagger](http://localhost:5000/swagger)

