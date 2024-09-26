using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Quantos dolares você quer ter? US$ ");
            decimal dolar = decimal.Parse(Console.ReadLine());

            decimal totalReais = Math.Round( dolar / 0.18m, 2);

            Console.WriteLine();
            Console.WriteLine($"Para ter {dolar}US$ você precisa de {totalReais} R$ ");
            Console.Write($"Você já tem {totalReais}R$ guardado (s/n): ");
            char resposta = char.Parse( Console.ReadLine());
            while (resposta != 's' && resposta != 'n')
            {
                Console.WriteLine("Valor Invalido! ");
                Console.Write($"Você já tem {totalReais}R$ guardado (s/n): ");
                resposta = char.Parse(Console.ReadLine());
                
            }
            if (resposta == 's')
            {
                Console.WriteLine("Você sabe quardar dinheiro :)");
            }
            else
            {
                resposta = 'n';
            }


            if (resposta == 'n')
            {
                Console.Write($"Você gostaria de simular um emprestimo, Para pegar {totalReais} emprestado? (s/n): ");
                char emprestimoResposta = char.Parse( Console.ReadLine());
                while(emprestimoResposta != 's' && emprestimoResposta != 'n')
                {
                    Console.WriteLine("Valor Invalido! ");
                    Console.Write($"Você gostaria de simular um emprestimo, Para pegar {totalReais} emprestado? (s/n): ");
                    emprestimoResposta = char.Parse(Console.ReadLine());
                    
                }


                if (emprestimoResposta == 's')
                {
              
                    Console.Write("O período é em meses ou anos? (Digite 'meses' ou 'anos'): ");
                    string unidade = Console.ReadLine();
                    while(unidade != "meses" &&  unidade != "anos")
                    {
                        Console.WriteLine("Valor Invalido!!");
                        Console.Write("O período é em meses ou anos? (Digite 'meses' ou 'anos'): ");
                        unidade = Console.ReadLine();
                    }
                    

                    if (unidade == "meses")
                    {
                        Console.Write("Em quantos meses deseja pagar?");
                        int meses = int.Parse(Console.ReadLine());
                        while(meses == 12)
                        {
                            Console.WriteLine("O valor que você informou é de 12 meses igual a 1 ano");
                            Console.WriteLine("Por favor, insira um valor em meses.");
                            Console.Clear();
                            Console.WriteLine();
                            Console.Write("Em quantos meses deseja pagar?");
                            meses = int.Parse(Console.ReadLine());
                        }
                        
                        if (meses <= 6)
                        {
                            decimal jurosMenor = 0.03m;
                            decimal contaJuros = totalReais * jurosMenor;
                            decimal ValorNovo = totalReais;
                            for (int i = 0; i < meses; i++)
                            {
                                ValorNovo += Math.Round(ValorNovo * jurosMenor,2);
                            }
                            decimal jurosPagos = ValorNovo - totalReais;

                            Console.WriteLine();
                            Console.WriteLine($"Em {meses} meses, a taxa de juros é de {jurosMenor} ao mês.");
                            Console.WriteLine($"Pegando {totalReais}R$ emprestado, você pagará um total de {jurosPagos}R$ em juros.");
                            Console.WriteLine($"O valor total do empréstimo será {ValorNovo}R$, somando principal + juros.");
                        }
                        else
                        {
                            decimal jurosMaior = 0.05m;
                            decimal ValorNovo = totalReais;
                            for(int i = 0; i < meses; i++)
                            {
                                ValorNovo += Math.Round(ValorNovo * jurosMaior,2);
                            }
                            decimal jurosPagos = ValorNovo - totalReais;

                            Console.WriteLine();

                            Console.WriteLine($"Em {meses} meses, a taxa de juros é de {jurosMaior}% ao mês.");
                            Console.WriteLine($"Pegando {totalReais}R$ emprestado, você pagará um total de {jurosPagos}R$ em juros.");
                            Console.WriteLine($"O valor total do empréstimo será {ValorNovo}R$, somando principal + juros.");
                        }

                    }
                    else if (unidade == "anos")
                    {
                        Console.Write("Em quantos anos deseja pagar?");
                        int anos = int.Parse(Console.ReadLine());
                        
                        while(anos == 12)
                        {
                            Console.WriteLine("O valor que você informou é igual 12.");
                            Console.WriteLine("Por favor, informe os anos em número inteiros.");
                            Console.Write("Em quantos anos deseja pagar");
                            anos = int.Parse(Console.ReadLine());
                        }
                        int converter = 12 * anos;
                        decimal jurosAnual = 0.07m;
                        decimal ValorNovo = totalReais;
                        for(int i = 0; i < converter; i++)
                        {
                            ValorNovo += Math.Round(ValorNovo * jurosAnual, 2);
                        }
                        decimal jurosPagos = ValorNovo - totalReais;
                        Console.WriteLine();

                        Console.WriteLine($"Em {anos} anos, a taxa de juros é de {jurosAnual} ao mês.");
                        Console.WriteLine($"Pegando {totalReais}R$ emprestado, você pagará um total de {jurosPagos}R$ em juros.");
                        Console.WriteLine($"O valor total do empréstimo será {ValorNovo}R$, somando principal + juros.");
                    }

                }
                else
                {
                    emprestimoResposta = 'n';
                    Console.WriteLine("Tenha um bom dia!");
                }
            }


            Console.ReadKey();
        }
    }
}
