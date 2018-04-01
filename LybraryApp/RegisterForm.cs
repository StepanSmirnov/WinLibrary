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
            if (login_tb.Text == "")
            {
                login_tb.BackColor = Color.Red;
            }

            if (password_tb.Text == "")
            {
                password_tb.BackColor = Color.Red;
            }

            if (confirm_tb.Text == "")
            {
                confirm_tb.BackColor = Color.Red;
            }

            if (name_tb.Text == "")
            {
                name_tb.BackColor = Color.Red;
            }

            if (login_tb.BackColor == Color.Green && confirm_tb.BackColor == Color.Green)
            {
                bibliotekaDataSet.СотрудникиRow row = ds.Сотрудники.NewСотрудникиRow();
                row.ФИО_сотрудника = name_tb.Text;
                row.Логин = login_tb.Text;
                row.Пароль = password_tb.Text;
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
            if (password_tb.Text == confirm_tb.Text)
            {
                confirm_tb.BackColor = Color.Green;
                password_tb.BackColor = Color.Green;
            }
            else
            {
                confirm_tb.BackColor = Color.Red;
                password_tb.BackColor = Color.Red;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var results = from myRow in ds.Сотрудники.AsEnumerable()
                          where myRow.Field<string>("Логин") == login_tb.Text
                          select myRow;
            if (results.Count() > 0 || login_tb.Text == "")
            {
                login_tb.BackColor = Color.Red;
            }
            else
            {
                login_tb.BackColor = Color.Green;
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
