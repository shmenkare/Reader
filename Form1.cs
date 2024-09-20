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
        private DataSet ds;
        private DataTable dt;
        private DataTable dt1;
       

        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            Read();

           //CREANDO DATA SET Y DATATABLE
            
            ds = new DataSet("Store");
            
           //TABLA DEPARTAMENTOS
          
            dt = new DataTable("Departamentos");
            DataColumn id = new DataColumn("id_dep", typeof(int));
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
            id.AllowDBNull = false;
            DataColumn nom = new DataColumn("Nombre", typeof(string));
            DataColumn des = new DataColumn("Descripcion", typeof(string));
            DataColumn fk = new DataColumn("id_prod", typeof(int));
            dt.Columns.AddRange(new DataColumn[]{id,nom,des,fk});
            dt.PrimaryKey = new DataColumn[] {id};

            //TABLA INVENTARIO

            dt1 = new DataTable("Inventario");
            DataColumn idprod = new DataColumn("id_prod", typeof(int));
            idprod.AutoIncrement = true;
            idprod.AutoIncrementSeed = 1;
            idprod.AutoIncrementStep = 1;
            idprod.AllowDBNull = false;
            DataColumn nomInv = new DataColumn("Nombre", typeof(string));
            DataColumn can = new DataColumn("Cantidad", typeof(int));
            DataColumn pre = new DataColumn("Precio", typeof(double));
            dt1.Columns.AddRange(new DataColumn[] { idprod, nomInv, can, pre });
            dt1.PrimaryKey = new DataColumn[] { idprod };

            //RELACIONES

            //ds.Relations.Add(idprod,fk);

            //FILAS

            
            




           
          

            dgvDep.DataSource = dt;
            dgvInv.DataSource = dt1;

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
    }
}



