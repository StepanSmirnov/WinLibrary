using LybraryApp.bibliotekaDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LybraryApp
{
    //Форма входа
    public partial class LoginForm : FormBase
    {
        private СотрудникиTableAdapter adapter;

        public LoginForm(Form prev = null):base(prev)
        {
            InitializeComponent();

            //Запрос на получение таблицы Сотрудники
            adapter = new СотрудникиTableAdapter();
            adapter.Fill(ds.Сотрудники);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Запрос на получение сотрудника с логином, указанным на форме
            var results = from myRow in ds.Сотрудники.AsEnumerable()
                          where myRow.Field<string>("Логин") == login_tb.Text
                          select myRow;
            //Если результат не пуст и пароль всотрудника совпадает с введенным на форме, переход на главную форму
            if (results.Count() >0 && results.First().Пароль == password_tb.Text)
            {
                new ViewForm(this).Open();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Переход на форму регистрации
            new RegisterForm(this).Open();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            //Переход на форму регистрации при нажатии Enter
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, new EventArgs());
            }
        }
    }
}
