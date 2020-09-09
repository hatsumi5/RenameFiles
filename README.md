# RenameFiles
Projeto criado para renomear vários arquivos de uma só vez.

# Objetivo
Este projeto tem como objetivo para facilitar a renomear vários arquivos ou pastas com nomes em padrão.

# Como funciona
## Exemplo 1 - Renomear vários arquivos com somente um nome enumerado.
Imagine que temos vários arquivos que precisa renomear em padrão com uma enumeração ao lado, por exemplo, na figura abaixo tem vários arquivos com nome 'testerenamefiles#.txt'.
Neste exemplo irá renomear todos os arquivos em Teste - ##.txt.
1. Abra o executável RenameFiles após a compilação.
1. Puxe os arquivos ou pastas que precisam renomear.
Veja que terá o mesmo comportamento da figura abaixo.
![RenameDefault](/renomear%20padrão.PNG)
1. Modifique o Nome do arquivo que será substituído para todos os arquivos.
No caso do exemplo foi utilizado Teste.
1. Alterar número de início.
Em padrão começa por número 1.
Se caso precisa começar por outro número altere Nº Início.
1. Alterar formatação de número.
Em padrão será em sequência de 2 números. (Está do lado do Nº Início).
Por exemplo, com 2, terá sequência de 01, 02, 03..., com 3 terá 001, 002, 003...
1. Alterar formato do texto.
Em padrão será escrito como {NOME} - {NUM}. Ou seja, no exemplo foi usado Teste no NOME separando número com ' - ', que ficaria 'Teste - 01', 'Teste - 02'...
Caso por exemplo precisa 'Teste01', então o formato deverá ser {NOME}{NUM}.
Se não tiver nome, ser somente número então só utilizar {NUM}.
1. Clicar no botão Nomear.
Nesse momento ainda não foi renomeado, mas mostrará como será substituído os nomes dos arquivos/pastas ao finalizar o processo.
1. Clicar no botão Salvar.
Veja que será renomeado todos os arquivos assim como mostra na figura abaixo.
![RenamedDefault](/renomeado%20padrão.PNG)

## Exemplo 2 - Renomear vários arquivos substituindo somente uma parte do nome
Imagine que temos vários arquivos que precisa renomear só uma parte do nome, por exemplo na figura abaixo tem vários arquivos com prefixo A_, B_, C_ e D_ com nome testerenamefiles ao lado e finalmente com enumeração.
Neste exemplo irá mostrar como mantenha os prefixos e a enumeração e assim substituir a parte _testerenamefiles com renomeado.
1. Abra o executável RenameFiles após a compilação.
1. Puxe os arquivos ou pastas que precisam renomear.
![RenamePart](/renomear%20substituindo%20a%20parte.PNG)
1. Clicar no botão Mesmo Nome.
Será copiado o mesmo nome para poder substituir depois.
1. Alterar campo para substituir texto.
Fica em baixo do campo Nome a esquerda. Na figura abaixo está sendo usado _testerenamefiles.
1. Alterar campo que será substituído.
Fica ao lado direita do campo citado no passo anterior. Na figura abaixo está sendo usado renomeado.
1. Clicar no botão Substituir Nome.
Será substituído o texto que está ao campo esquerdo com o campo direito. No caso da figura abaixo está sendo substituído de _testerenamesfiles com renomeado.
Nesse momento ainda não foi renomeado, mas mostrará como será substituído os nomes dos arquivos/pastas ao finalizar o processo.
Estes passos 2~4 poderá ser feita várias vezes caso queira alterar mais.
Por exemplo, atualmente o resultado que terá nesse exemplo seria Arenomeado1, Brenomeado2...
Mas se por acaso quer tirar renomeado poderá preencher campo esquerda com renomeado e o campo direita estaria vazia. Assim, o resultado estaria A1, B2...
1. Clicar no botão Salvar.
Veja que será renomeado todos os arquivos assim como mostra na figura abaixo.
![RenamedPart](/renomeado%20substituindo%20a%20parte.PNG)



## Observação
- Se caso quiser modificar nome de um arquivo poderá ser alterado na coluna New Name.
- Pode existir bugs, que quando ocorrer algum erro recomendável fechar e abrir o programa.
- (Exemplo 2) Existe um bug que quando substitui a parte, está sendo adicionado mais uma extensão, por exemplo no exemplo está com mais que 1 .txt. Se caso acontecer isso, é possível ter um desvio fazendo o mesmo procedimento dos passos 2~4, preenchendo o campo a esquerda com que está repetindo e o campo a direita vazio. No nosso exemplo seria .txt.
