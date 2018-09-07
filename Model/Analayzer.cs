using System;
using System.Collections.Generic;
using System.Linq;

namespace FormulaParsing.Model
{
    class Analayzer
    {
        /// <summary>
        /// Метод разбивает полученную строку на список лексем, состоящий из чисел,
        /// скобок, знаков операций и переменной x
        /// </summary>
        /// <param name="str">строка с арифметическим выражением</param>
        /// <returns></returns>
        static internal List<string> SplitTheString(string str)
        {
            List <string> list = new List<string>();
            string num = "";
            int brackets = 0;
            str = str.Replace(" ", ""); //удаляем пробелы
            str = str.Replace('.', ','); //заменяем точки на запятые

            foreach (char c in str)
            {
                switch (c)
                {

                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case ',':
                        //цифру мы запоминаем и добавляем к предыдущей
                        num = num + c.ToString();
                        //если число идёт сразу после закрывающей скобки или переменной- ошибка!
                        if (list.Count > 0 && (list.Last().Last() == ')' || list.Last().Last() == 'x'))
                            throw new ArgumentException("Пропущен оператор перед числом!");
                        break;

                    case '(':
                    case ')':
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '^':
                        //если число не пустое, добавляем его в список
                        if (num != "")
                        {
                            list.Add(num);
                            num = "";
                        }
                        //добавляем в списко операцию
                        list.Add(c.ToString());
                        //считаем скобки
                        if (c == ')') brackets--;
                        if (c == '(') brackets++;
                        break;
                    case 'x': // имя переменной
                        //если переменная сразу после числа - ошибка!
                        //if (num != "") throw new ArgumentException("Пропущен оператор между числом и переменной!");
                        //если переменная идет сразу за числом - добавляем число и умножение.
                        if (num != "") 
                        {
                            list.Add(num);
                            num = "";
                            list.Add("*");
                        }
                        if (list.Last() == ")") list.Add("*");
                            list.Add(c.ToString());
                        break;
                    default: throw new ArgumentException("Недопустимые символы!");
                }
                //проверяем, не перепутаны ли скобки местами
                if (brackets < 0) throw new ArgumentException("Неверный порядок скобок!"); ;
            }
            //если есть, записываем последне число
            if (num != "") list.Add(num);
            //проверяем соответствие открывающих и закрывающих скобок
            if (brackets != 0) throw new ArgumentException("Несоответствие открывающих и закрывающих скобок!"); ;
            return list;
        }
    }
}
