using System;
using System.Collections.Generic;
using System.IO;

/*
Sample Input
10
64630 11735 14216 99233 14470 4978 73429 38120 51135 67060

Sample Output
43900.6
44627.5
4978
*/

class Solution {
    static void Main(String[] args) {
        // Le a quantidade de valores da entrada de valores
        int qtdValues = int.Parse(Console.ReadLine());

        // Le os valores de entrada separados por espaco e armazena em um array de string
        string[] inputValues = Console.ReadLine().Split(" ");

        // Cria uma lista para armazenar valores inteiros
        List<int> values = new List<int>();
        int sumValues = 0;

        // Loop para inserir os valores de entrada como string em uma lista de int e calcular sua soma
        for (int i = 0; i < qtdValues; i++)
        {
            values.Add(int.Parse(inputValues[i]));
            sumValues = sumValues + values[i];
        }

        // Calcula a media dos valores de entrada e imprime com uma casa decimal, sem separador de milhar
        double n = (double)sumValues / qtdValues;
        Console.WriteLine($"{n.ToString("F1")}");

        // Ordena a lista de valores
        values.Sort();

        // Verifica se o numero de valores e par ou impar e calcula a mediana
        if (qtdValues % 2 == 0)
        {
            n = ((double)values[qtdValues / 2] + values[qtdValues / 2 - 1]) / 2;
            Console.WriteLine($"{n.ToString("F1")}");
        }
        else
        {
            n = (double)values[qtdValues / 2];
            Console.WriteLine($"{n.ToString("F1")}");
        }

        // Inicializa variaveis para contar ocorrencias de valores
        int count = 0;
        int countMax = 0;
        int maxValue = int.MaxValue;

        // Loop aninhado para encontrar a moda (valor mais frequente) na lista
        for (int i = 0; i < qtdValues; i++)
        {
            for (int j = i; j < qtdValues; j++)
            {
                if (values[j] == values[i])
                {
                    count++;
                }
            }

            // Atualiza countMax e maxValue se uma frequencia mais alta for encontrada
            if (count == countMax && values[i] < maxValue)
            {
                countMax = count;
                maxValue = (int)values[i];
            }
            else if (count > countMax)
            {
                countMax = count;
                maxValue = (int)values[i];
            }

            // Reseta count para a proxima iteracao
            count = 0;
        }

        // Imprime a moda (valor mais frequente) na lista
        Console.WriteLine($"{maxValue}");
    }
}
