using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reader
{
    public partial class Form1 : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rd;

        public Form1()
        {
            InitializeComponent();
        }
        public void Read()
        {
            string cadena = "Data Source=.;Initial Catalog=MusicListDB;Integrated Security=True";
            string sql = "SELECT * FROM Temas";
            con = new SqlConnection(cadena);
            con.Open();
            cmd = new SqlCommand(sql, con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                lsvLista.Items.Add(rd[1].ToString());
            }
            rd.Close();
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Read();
        }
    }

}



