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
    public partial class ViewForm : FormBase
    {
        private АвторыTableAdapter authors_adapter;
        private КнигиФондаTableAdapter books_adapter;
        private РазделыКнигTableAdapter devisions_adapter;
        private СотрудникиTableAdapter employees_adapter;
        private ВыдачаКнигTableAdapter giving_adapter;
        private ВидыКнигTableAdapter kinds_adapter;

        public ViewForm(Form prev = null):base(prev)
        {
            InitializeComponent();
            employees_adapter = new СотрудникиTableAdapter();
            books_adapter = new КнигиФондаTableAdapter();
            giving_adapter = new ВыдачаКнигTableAdapter();
            authors_adapter = new АвторыTableAdapter();
            devisions_adapter = new РазделыКнигTableAdapter();
            kinds_adapter = new ВидыКнигTableAdapter();

            employees_adapter.Fill(ds.Сотрудники);
            books_adapter.Fill(ds.КнигиФонда);
            giving_adapter.Fill(ds.ВыдачаКниг);
            authors_adapter.Fill(ds.Авторы);
            devisions_adapter.Fill(ds.РазделыКниг);
            kinds_adapter.Fill(ds.ВидыКниг);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            int index = lb.SelectedIndex;
            if (index < 0) return;
            switch (index)
            {
                case 0:
                    dataGridView1.DataSource = ds.КнигиФонда.DefaultView;
                    break;
                case 1:
                    dataGridView1.DataSource = ds.Авторы;
                    break;
                case 2:
                    dataGridView1.DataSource = ds.Сотрудники;
                    break;
                case 3:
                    dataGridView1.DataSource = ds.ВыдачаКниг;
                    break;
                case 4:
                    dataGridView1.DataSource = ds.РазделыКниг;
                    break;
                case 5:
                    dataGridView1.DataSource = ds.ВидыКниг;
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            employees_adapter.Update(ds.Сотрудники);
            books_adapter.Update(ds.КнигиФонда);
            giving_adapter.Update(ds.ВыдачаКниг);
            authors_adapter.Update(ds.Авторы);
            devisions_adapter.Update(ds.РазделыКниг);
            kinds_adapter.Update(ds.ВидыКниг);

            employees_adapter.Fill(ds.Сотрудники);
            books_adapter.Fill(ds.КнигиФонда);
            giving_adapter.Fill(ds.ВыдачаКниг);
            authors_adapter.Fill(ds.Авторы);
            devisions_adapter.Fill(ds.РазделыКниг);
            kinds_adapter.Fill(ds.ВидыКниг);
        }

        private void ViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            previous.Close();
        }
    }
}
