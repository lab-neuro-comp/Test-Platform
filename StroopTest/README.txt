StroopTest - Version 1.0 - 2015
Laboratorio de Neurociencia e Comportamento
Universidade de Brasilia

************************************************************************
LEIA-ME
************************************************************************

(1) A aplicao executa um teste Stroop a partir da leitura de um arquivo
do tipo 'programa.pgr' contendo uma programacao para o teste. Tal 
arquivo deve ser salvo em um novo diretorio 'StroopTestFiles' criado no
diretorio do executavel;

(2) Cada programa tem como parametros nomes de arquivos contendo listas
de estimulos e de cores ('words.lst', 'colors.lst'), tambem dispostos no
diretorio 'Stroop';

(3) Tal Programa eh constituido de parametros(*) que devem ser escritos
linearmente e separados por espacos;

(4) Pode-se executar o 'Programa Padrao' - 'padrao.pgr' que eh sempre
gerado. Ele eh configuracao padr‹o da aplicacao;

(5) A saida eh dada em outro arquivo nomeado
'nomeUsuario_nomePrograma.txt' e contem os valores gerados durante o
teste.

************************************************************************
Parametros da programacao do teste:
************************************************************************

[0]	nome do programa
[1]	numero de exposicoes 
[2]	tempo de exposicao (millisec)
[3]	exposicao randomica (bool)
[4]	tempo de intervalo (millisec)
[5]	tempo de intervalo randomico (bool)
[6]	lista de palavras
[7]	lista de cores
[8]	cor de fundo da tela
[9]	captura de audio (bool)
[10]	legenda
[11]	localizacao da legenda
[12]	cor da legenda


************************************************************************
Exemplo (Programa Padrao):

padrao 16 2000 false 1800 false words.lst colors.lst false false false 0 false


************************************************************************
Codigo de cores basicas:

************************************************************************

amarelo		#F8E000

azul		#007BB7

verde		#7EC845

vermelho	#D01C1F


