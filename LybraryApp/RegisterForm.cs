using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LybraryApp.bibliotekaDataSetTableAdapters;
namespace LybraryApp
{
    public partial class RegisterForm : FormBase
    {
        private СотрудникиTableAdapter adapter;

        public RegisterForm(Form prev = null) : base(prev)
        {
            InitializeComponent();
            adapter = new СотрудникиTableAdapter();
            adapter.Fill(ds.Сотрудники);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.BackColor = Color.Red;
            }

            if (textBox2.Text == "")
            {
                textBox2.BackColor = Color.Red;
            }

            if (textBox3.Text == "")
            {
                textBox3.BackColor = Color.Red;
            }

            if (textBox4.Text == "")
            {
                textBox4.BackColor = Color.Red;
            }

            if (textBox1.BackColor == Color.Green && textBox3.BackColor == Color.Green)
            {
                bibliotekaDataSet.СотрудникиRow row = ds.Сотрудники.NewСотрудникиRow();
                row.ФИО_сотрудника = textBox4.Text;
                row.Логин = textBox1.Text;
                row.Пароль = textBox2.Text;
                ds.Сотрудники.Rows.Add(row);
                adapter.Update(ds.Сотрудники);
                MessageBox.Show("Вы зарегистрированы!");
                Back();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "")
                tb.BackColor = Color.Red;
            if (textBox2.Text == textBox3.Text)
            {
                textBox3.BackColor = Color.Green;
                textBox2.BackColor = Color.Green;
            }
            else
            {
                textBox3.BackColor = Color.Red;
                textBox2.BackColor = Color.Red;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var results = from myRow in ds.Сотрудники.AsEnumerable()
                          where myRow.Field<string>("Логин") == textBox1.Text
                          select myRow;
            if (results.Count() > 0 || textBox1.Text == "")
            {
                textBox1.BackColor = Color.Red;
            }
            else
            {
                textBox1.BackColor = Color.Green;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "")
            {
                tb.BackColor = Color.Red;
            }
            else
            {
                tb.BackColor = Color.Green;
            }
        }
    }
}
