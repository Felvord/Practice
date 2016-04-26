using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_oop
{
       public interface IFIOtoString
    {
        string FIOtoString();
    }

    #region классы (кафе, сотрудник,блюдо, заказ и др.) и интерфейсы

    public class ListShop
    {
        public List<Worker> AllWorker = new List<Worker>();
        public List<Food> AllFood = new List<Food>();
        public List<Sale> AllSale = new List<Sale>();
    }

    public class Man
    {
        string name;
        string surname;
        string ot;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Ot
        {
            get { return ot; }
            set { ot = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public Man()
        {
            name = "";
            surname = "";
            ot = "";

        }

        public Man(string Name, string Surname, string Ot)
        {
            name = Name;
            surname = Surname;
            ot = Ot;
        }
    }

    
    public class Worker : Man, IFIOtoString
    {
        DateTime ustrdate;
        string twnumber;
        string wmail;

        public DateTime Ustrdate
        {
            get { return ustrdate; }
            set { ustrdate = value; }
        }

        public string Twnumber
        {
            get { return twnumber; }
            set { twnumber = value; }
        }

        public string Mail
        {
            get { return wmail; }
            set { wmail = value; }
        }

        public string FIOtoString()
        {
            return Name + " " + Ot + " " + Surname;
        }
    }

  
    public class Food
    {
        int id;
        string name;
        string ingr;
        int price;
        int kol;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Kol
        {
            get { return kol; }
            set { kol = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Ingr
        {
            get { return ingr; }
            set { ingr = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }


    }

   
    public class Sale : Worker, IFIOtoString
    {
        Food foodsale;
        DateTime date;
        Worker worker;
        int kolv;

        public Food Food
        {
            get { return foodsale; }
            set { foodsale = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public Worker Worker
        {
            get { return worker; }
            set { worker = value; }
        }

        public int Kolv
        {
            get { return kolv; }
            set { kolv = value; }
        }

        public Sale()
        {

            foodsale = new Food();
            date = new DateTime();
            worker = new Worker();
        }


        public Sale(Food Food, DateTime Date, Worker Worker)
        {
            foodsale = Food;
            date = Date;
            worker = Worker;
        }
    }
}
    #endregion