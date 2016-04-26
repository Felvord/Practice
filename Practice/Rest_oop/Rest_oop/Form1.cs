using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rest_oop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ListShop ListShops = new ListShop();
        int sel1 = 0;
        int sel2 = 0;
        int sel3 = 0;
        int sel4 = 0;

        private void button2_Click(object sender, EventArgs e) // добавление нового сотрудника
        {
            if ((textBox1.Text.Trim() == "") || (textBox2.Text.Trim() == "") || (textBox3.Text.Trim() == ""))
            {
                MessageBox.Show("Не все обязательные поля заполнены");
                return;
            }

            Worker wrk = new Worker();
            wrk.Name = textBox2.Text.Trim();
            wrk.Ot = textBox3.Text.Trim();
            wrk.Surname = textBox1.Text.Trim();
            wrk.Twnumber = textBox4.Text.Trim();
            wrk.Mail = textBox5.Text.Trim();
            wrk.Ustrdate = dateTimePicker1.Value;

            ListShops.AllWorker.Add(wrk);
            MessageBox.Show("Новый сотрудник добавлен");
            
            button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e) // обновление
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ListShops.AllWorker.Count; i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1[0, i].Value = ListShops.AllWorker[i].Surname;
                dataGridView1[1, i].Value = ListShops.AllWorker[i].Name;
                dataGridView1[2, i].Value = ListShops.AllWorker[i].Ot;
                dataGridView1[3, i].Value = ListShops.AllWorker[i].Ustrdate;
                dataGridView1[4, i].Value = ListShops.AllWorker[i].Twnumber;
                dataGridView1[5, i].Value = ListShops.AllWorker[i].Mail;
            }

            
            dataGridView2.Rows.Clear();
            for (int i = 0; i < ListShops.AllFood.Count; i++)
            {
                dataGridView2.Rows.Add(1);
                dataGridView2[0, i].Value = ListShops.AllFood[i].Name;
                dataGridView2[1, i].Value = ListShops.AllFood[i].Ingr;
                dataGridView2[2, i].Value = ListShops.AllFood[i].Price;

            }

            dataGridView3.Rows.Clear();
            for (int i = 0; i < ListShops.AllSale.Count; i++)
            {
                dataGridView3.Rows.Add(1);
                dataGridView3[0, i].Value = ListShops.AllSale[i].Food.Name;
                dataGridView3[1, i].Value = ListShops.AllSale[i].Date;
                dataGridView3[2, i].Value = ListShops.AllSale[i].Worker.Surname + " " + ListShops.AllSale[i].Worker.Name + " " + ListShops.AllSale[i].Worker.Ot;
                dataGridView3[3, i].Value = ListShops.AllSale[i].Kolv;                
            }
           
            if (ListShops.AllWorker.Count > 0)
            {
                comboBox4.Items.Clear();
                for (int i = 0; i < ListShops.AllWorker.Count; i++)
                {
                    comboBox4.Items.Add(ListShops.AllWorker[i].Surname + " " + ListShops.AllWorker[i].Name + " " + ListShops.AllWorker[i].Ot);
                }
            }

            if (ListShops.AllFood.Count > 0)
            {
                comboBox1.Items.Clear();
                for (int i = 0; i < ListShops.AllFood.Count; i++)
                {
                    comboBox1.Items.Add(ListShops.AllFood[i].Name + " " + ListShops.AllFood[i].Ingr + " ");
                }
            }            
        }

        private void button4_Click(object sender, EventArgs e) // добавление нового блюда
        {
            if ((textBox12.Text.Trim() == "") || (textBox13.Text.Trim() == "") ||  (textBox16.Text.Trim() == "") )
            {
                MessageBox.Show("Не все обязательные поля заполнены");
                return;
            }

            Food org = new Food();
            org.Name = textBox12.Text.Trim();
            org.Ingr = textBox13.Text.Trim();
            try
            {

                org.Price = int.Parse(textBox16.Text.Trim());

                int x = ListShops.AllFood.Count;
                if (x != 0)
                {
                    for (int i = 0; i < x; i++)
                    {

                            ListShops.AllFood.Add(org);
                            MessageBox.Show("Продукция успешно добавлена");
                        
                    }
                }
                else
                {
                    ListShops.AllFood.Add(org);
                    MessageBox.Show("Продукция успешно добавлена");
                }                        

                button1_Click(sender, e);
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат ввода");
            }

            
        }

        private void button5_Click(object sender, EventArgs e) // добавление нового заказа
        {
            if ((comboBox1.Text.Trim() == "") || (comboBox4.Text.Trim() == ""))
            {
                MessageBox.Show("Не все обязательные поля заполены");
                return;
            }

            Sale sl = new Sale();
            sl.Food = ListShops.AllFood[comboBox1.SelectedIndex];
            sl.Worker = ListShops.AllWorker[comboBox4.SelectedIndex];
            sl.Date = dateTimePicker3.Value;
            sl.Kolv = (byte)numericUpDown1.Value;

                ListShops.AllFood[comboBox1.SelectedIndex].Kol -= sl.Kolv;
                ListShops.AllSale.Add(sl);
                MessageBox.Show("Успешно добавлено!");
           
            
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            sel1 = e.RowIndex;
        }

        private void dataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            sel2 = e.RowIndex;
        }

        private void dataGridView3_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            sel3 = e.RowIndex;
        }

        private void dataGridView4_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            sel4 = e.RowIndex;
        }


        private void button6_Click(object sender, EventArgs e)  // удаление сотрудника
        {
            if (ListShops.AllWorker.Count > 0)
            {
                ListShops.AllWorker.RemoveAt(sel1);
                button1_Click(sender, e);
                sel1 = 0;
            }
        }

       
        private void button8_Click(object sender, EventArgs e) // удаление в  меню
        {
            if (ListShops.AllFood.Count > 0)
            {
                ListShops.AllFood.RemoveAt(sel1);
                button1_Click(sender, e);
                sel3 = 0;
            }
        }

        private void button9_Click(object sender, EventArgs e) // удаление в журнале заказов
        {
            if (ListShops.AllSale.Count > 0)
            {
                ListShops.AllSale.RemoveAt(sel1);
                button1_Click(sender, e);
                sel4 = 0;
            }
        }
    }
}