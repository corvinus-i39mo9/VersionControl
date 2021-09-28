using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName;
            button1.Text = Resource1.Add;
            button2.Text = Resource1.Export;
            button3.Text = Resource1.Delete;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User u1 = new User();
            u1.FullName = textBox1.Text;
            users.Add(u1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);

                foreach (var u in users)
                {
                    sw.Write(u.ID);
                    sw.Write(u.FullName);
                    sw.WriteLine(u.ID.ToString() + ',' + u.FullName);
                }
                sw.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User u1 = (User)listBox1.SelectedItem;
            users.Remove(u1);
        }
    }
}
