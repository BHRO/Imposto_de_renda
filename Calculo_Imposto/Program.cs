using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Calculo_Imposto_De_Renda
{
    class imposto
    {
        public static double Renda1(double salario) //função da primeira aliquota
        {
            double imp;
            imp = salario * 0.075;
            return imp;
        }
        public static double Renda2(double salario) //função da segunda aliquota
        {
            double imp;
            imp = salario * 0.15;
            return imp;
        }
        public static double Renda3(double salario) //função da terceira aliquota
        {
            double imp;
            imp = salario * 0.225;
            return imp;
        }
        public static double Renda4(double salario) //função da quarta aliquota
        {
            double imp;
            imp = salario * 0.275;
            return imp;
        }


        static void Main(string[] args) //função principal
        {
            double totalretido=0, sal;
            int isentos=0, fun, op;
          
            
            do //laço de repetição para saber a quantidade de funcionários que serão cadastrados
            {
                Console.Clear();
                Console.WriteLine("Quantos funcionários deseja cadestrar? No mínimo 3 e no máximo 50");
                fun = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

            }while((fun<3) || (fun > 50));

            double[] funcionario = new double[fun]; //vetor que armazena o valor que será descontado de cada funcionário
            string[] nomes = new string[fun]; // vetor que armazena os nomes dos funcionários

            for (int i=0; i<fun;i++) //Laço de repetição para cadastro dos nomes e salários
            {
                Console.Clear();
                funcionario[i] = 0.0;
                Console.WriteLine("Digite o nome do funcionário");
                nomes[i] = Console.ReadLine();
                Console.WriteLine("Qual o salário? ");
                sal = Convert.ToDouble(Console.ReadLine());

                if (sal<= 1903.98) // Condição de isenção
                {

                    funcionario[i] = 0;
                    isentos = isentos + 1;
                    totalretido = totalretido + funcionario[i];
                    Console.Clear();

                }

                else if ((sal>1903.98)&& (sal<= 2826.65)) // Condição da primeira aliquota
                {
                    funcionario[i] = imposto.Renda1(sal);
                    totalretido = totalretido + funcionario[i];
                    Console.Clear();
                }
                else if ((sal>2826.65)&&(sal<= 3751.05)) // Condição da segunda aliquota
                {
                    funcionario[i] = imposto.Renda2(sal);
                    totalretido = totalretido + funcionario[i]; 
                    Console.Clear();
                }
                else if ((sal>3751.05)&&(sal<= 4664.68)) // Condição da terceira aliquota
                {
                    funcionario[i] = imposto.Renda3(sal);
                    totalretido = totalretido + funcionario[i];
                    Console.Clear();
                }
                else if(sal>4664.68)                    // Condição da quarta aliquota
                {
                    funcionario[i] = imposto.Renda4(sal);
                    totalretido = totalretido + funcionario[i];
                    Console.Clear();
                }

            }
            Console.Clear();

            Console.WriteLine("1-Listar os valores dos impostos de cada funcionário\t2-Mostrar o total de imposto retido na fonte\n3-Quantos funcionários são isentos"); // Menu de opções
            op = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch(op)
            {
                case 1:
                    Console.WriteLine("Lista de funcionários\t Valor do imposto de renda retido mensal\n"); //Primeira opção: Informação de video fornecida: Tabela dos funcionários e do valor que foi retido de cada um deles

                    for (int j=0; j<fun; j++)
                    {
                        Console.Write(nomes[j]);
                        Console.Write("\t\t\t" + funcionario[j].ToString("C", CultureInfo.CurrentCulture)); // CultureInfo.CurrentCulture foi usada para formatar o valor para R$
                        Console.WriteLine("\n");

                        
                    } Console.ReadKey();
                break;

                case 2: //Segunda opção: Informação de video fornecida: Total do imposto retido na fonte

                    Console.WriteLine("O total de imposto retido na fonte: " + totalretido.ToString("C", CultureInfo.CurrentCulture)); //CultureInfo.CurrentCulture foi usada para formatar o valor para R$
                    Console.ReadKey();

                break;

                case 3: // Terceira opção: Informação de video fornecida: Usuários isentos

                    Console.WriteLine("Funcionários isentos:  " +isentos);
                    Console.ReadKey();

                break;

                default: // Informa ao usuário que ele não seleciou opções válidas

                    Console.WriteLine("Opção invalida");

                break;
            }







                
            
        }   
    }

}
