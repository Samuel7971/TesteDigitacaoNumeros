using System;
using System.Collections.Generic;
using System.IO;

namespace TesteDigitacaoNumeros
{
    class Program
    {
        static void Main(string[] args)
        {
            var lstNumber = new List<decimal>();
            string str = "";
            bool end = false;

            //Questão 1:
            Console.WriteLine("Digite qualquer (Letra) para finalizar.");
            while (end == false)
            {
                Console.Write("Digite o número desejado: ");
                var number = Console.ReadLine();
                if (IsNumeric(number))
                {
                    var num = ConvertToDecimal(number);
                    lstNumber.Add(num);
                }
                else
                {
                    Console.WriteLine("");
                    lstNumber.Sort();
                    foreach (var item in lstNumber)
                    {
                        Console.WriteLine($"- {item.ToString()}");
                        str += ($" - {item} \n");
                    }
                    CriateAFile(str);
                    end = true;
                }
            }
            Console.ReadKey();
        }

        //Questão 2:
        public static void CriateAFile(string text)
        {
            TextWriter file = new StreamWriter("Numeros Escolhidos");
            file.WriteLine(text);
            file.Close();
            Console.WriteLine(@"Arquivo texto criado em: Testes\TesteDigitacaoNumeros\TesteDigitacaoNumeros\bin\Debug\net5.0");
        }

        public static bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }

        public static decimal ConvertToDecimal(string strNumber)  // Converte a string strNumber em decimal
        {
            if (decimal.TryParse(strNumber, out decimal decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
    }
}

