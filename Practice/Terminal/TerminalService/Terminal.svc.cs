using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace TerminalService
{
    public class Terminal : ITerminal
    {
        public string TestConnection()
        {
            return "OK";
        }
        public string GetCommand(string str)
        {
            char ch = '<';
            string temp = str;
            if (str.Contains(ch))
                str = str.Substring(0, str.IndexOf(ch) - 1);
            switch (str)
            {
                case "help":
                        return Help(str);
                 case "showstatus":
                        return Showstatus(str);
                case "store":
                        return Store(str, temp);
                case "free":
                        return Free(str, temp);
                default:
                       return string.Format("Введите корректную команду. Для справки наберите команду 'help'"); 
            }
        }
        public string Help(string help)
        {
            help = @"1. help – отображение отформатированной справки по всем поддерживаемым командам
2. showstatus  – отображение отформатированной таблицы загруженности всех ангаров на всех площадках склада
3. store <N> – разместить N контейнеров на складе, N – натуральное число
4. free <N> <H_ID> – выгрузить N контейнеров из ангара H_ID на складе, N – натуральное число
5. exit  – завершение работы";
            return help;
        }
        public string Showstatus(string show)
        {
            storageEntities storage = new storageEntities();
            List<hangar> value = storage.hangar.ToList();
            show = "Platform-------Hangar--------Total Amount------Used Amount\n";
            string result = "";
            for (int i = 0; i < value.Count(); i++)
            {
                var mark = value.ElementAt(i);
                result += mark.platformID + "                " + mark.hangarName
                    + "             " + mark.totalAmount
                    + "            " + mark.usedAmount + "\n ";
            };
            return string.Format("{0} {1}", show, result);
        }
        public string Store(string store, string str) 
        {
            storageEntities storage = new storageEntities();
            string[] arr = str.Split(' ');
            string box = Regex.Replace(arr[1], @"\D", string.Empty); 
            int chislo = Convert.ToInt32(box);
            List<hangar> value = storage.hangar.ToList();
            int temp;
            bool flag = false;
            try
            {
                for (int i = 0; i < value.Count(); i++)
                {

                    var mark = value.ElementAt(i);
                    if (mark.usedAmount == mark.totalAmount) continue;
                    else
                    {
                        temp = mark.usedAmount + chislo;
                        if (temp > mark.totalAmount)
                        {
                            mark.usedAmount = mark.totalAmount;
                            temp = temp - mark.totalAmount;
                        }
                        else
                        {
                            mark.usedAmount = temp;
                            temp = 0;
                            flag = true;
                        }
                    }
                    if (temp != 0) chislo = temp;
                    else break;
                }
                if (!flag)
                {
                    storage.SaveChanges();
                    return string.Format("Невозможно разместить {0} коробок", chislo);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error: {0}", ex.Message);
                storage.SaveChanges();
            }
            storage.SaveChanges();
            return string.Format("Успешно на складе размещено {0} контейнеров", box);
        }
        public string Free(string free, string str)
        {
            storageEntities storage = new storageEntities();
            string[] arr = str.Split(' ');
            string box = Regex.Replace(arr[1], @"\D", string.Empty);
            int count_box = Convert.ToInt32(box);
            string hname = Regex.Replace(arr[2], @"\W", string.Empty);
            List<hangar> value = storage.hangar.ToList();
            int temp;
            bool flag = false;
            try
            {
                for (int i = 0; i < value.Count(); i++)
                {
                    var mark = value.ElementAt(i);
                    if (mark.hangarName != hname) continue;
                    else
                    {
                        temp = mark.usedAmount - count_box;
                        if (temp < 0)
                        {
                            mark.usedAmount = 0;
                            count_box = Math.Abs(temp);
                            storage.SaveChanges();
                            return string.Format("Невозможно выгрузить {0} коробок", count_box);
                        }
                        else
                        {
                            mark.usedAmount = temp;
                            count_box = 0;
                            flag = true;
                            break;
                        }
                    }
                }
                if (!flag)
                    return string.Format("Не существует такого ангара. Введите корректный ангар");
            }
            catch (Exception ex)
            {
                Console.Write("Error: {0}", ex.Message);
                storage.SaveChanges();
            }
            storage.SaveChanges();
            return string.Format("Операция прошла успешно");
        }
    }
}