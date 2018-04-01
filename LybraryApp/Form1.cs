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
    public partial class Form1 : FormBase
    {
        private СотрудникиTableAdapter adapter;

        public Form1(Form prev = null):base(prev)
        {
            InitializeComponent();
            adapter = new СотрудникиTableAdapter();
            adapter.Fill(ds.Сотрудники);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var results = from myRow in ds.Сотрудники.AsEnumerable()
                          where myRow.Field<string>("Логин") == textBox1.Text
                          select myRow;
            if (results.Count() >0 && results.First().Пароль == textBox2.Text)
            {
                new ViewForm(this).Open();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new RegisterForm(this).Open();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, new EventArgs());
            }
        }
    }
}
