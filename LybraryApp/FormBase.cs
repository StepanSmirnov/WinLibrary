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
    //Базовый класс для форм
    public partial class FormBase : Form
    {
        protected bibliotekaDataSet ds;

        protected Form previous;

        public FormBase()
        {
            InitializeComponent();
        }

        public FormBase(Form prev = null)
        {
            InitializeComponent();
            ds = new bibliotekaDataSet();
            previous = prev;
        }

        //Перейти на форму и скрыть предыдущую
        public void Open()
        {
            if (previous == null) return;
            previous.Hide();
            Show();
        }

        //Перейти на предыдущую форму и скрыть текущую
        public void Back()
        {
            if (previous == null) return;
            previous.Show();
            Hide();
        }

        //Вызывается при закрытии формы
        private void FormBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Back();
        }
    }
}
