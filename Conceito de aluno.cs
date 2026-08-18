using System;

class Program
{
    static void Main()
    {
        int aulasDadas;

        Console.Write("Quantidade de aulas dadas: ");
        aulasDadas = int.Parse(Console.ReadLine());

        int quantidadeAlunos;
        Console.Write("Quantidade de alunos: ");
        quantidadeAlunos = int.Parse(Console.ReadLine());

        int[] faltas = new int[quantidadeAlunos];
        float[] frequencia = new float[quantidadeAlunos];
        float[] notasAV1 = new float[quantidadeAlunos];
        float[] notasAV2 = new float[quantidadeAlunos];
        float[] notasAVF = new float[quantidadeAlunos];
        float[] mediaFinal = new float[quantidadeAlunos];
        string[] nomeAluno = new string[quantidadeAlunos];
        string[] situacao = new string[quantidadeAlunos];

        for (int i = 0; i < quantidadeAlunos; i++)
        {
            Console.Write($"Nome do aluno {i + 1}: ");
            nomeAluno[i] = Console.ReadLine();

            Console.Write($"Quantidade de faltas do aluno {i + 1}: ");
            faltas[i] = int.Parse(Console.ReadLine());

            Console.Write($"Nota da AV1 do aluno {i + 1}: ");
            notasAV1[i] = float.Parse(Console.ReadLine());

            Console.Write($"Nota da AV2 do aluno {i + 1}: ");
            notasAV2[i] = float.Parse(Console.ReadLine());

            frequencia[i] = CalculadoraFrequencia(faltas[i], aulasDadas);

            if (frequencia[i] >= 75)
            {
                mediaFinal[i] = CalculadoraMedia(notasAV1[i], notasAV2[i]);

                if (mediaFinal[i] >= 6)
                {
                    situacao[i] = "Aprovado";
                }
                else if (mediaFinal[i] >= 4)
                {
                    Console.Write($"Nota da AVF do aluno {i + 1}: ");
                    notasAVF[i] = float.Parse(Console.ReadLine());

                    mediaFinal[i] = (mediaFinal[i] + notasAVF[i]) / 2;

                    if (mediaFinal[i] >= 6)
                    {
                        situacao[i] = "Aprovado na AVF";
                    }

                    else
                    {
                        situacao[i] = "Reprovado na AVF";
                    }
                }
                else
                {
                    situacao[i] = "Reprovado por nota";
                }
            }
            else
            {
                situacao[i] = "Reprovado por falta";
            }
        }

        for (int i = 0; i < quantidadeAlunos; i++)
        {
            Console.WriteLine($"\nAluno: {nomeAluno[i]} - {situacao[i]}");
        }

    }

    static float CalculadoraMedia(float num1, float num2)
    {
        float media = (num1 + num2) / 2;
        return media;
    }

    static float CalculadoraFrequencia(int faltas, int aulasDadas)
    {
        float frequencia = ((aulasDadas - faltas) / (float)aulasDadas) * 100;
        return frequencia;

    }

}