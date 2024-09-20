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
            dt.Columns.AddRange(new DataColumn[]{id,nom,des});
            //dt.PrimaryKey = new DataColumn[] {id};
            dt.Constraints.Add("Clave primaria",id, true);

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
            DataColumn fk = new DataColumn("id_dep", typeof(int));
            dt1.Columns.AddRange(new DataColumn[] { idprod, nomInv, can, pre,fk });
            dt1.PrimaryKey = new DataColumn[] { idprod };

            //RELACIONES

            ds.Tables.AddRange(new DataTable[]{dt,dt1});
            ds.Relations.Add(fk,idprod);

            //FILAS

            dt.Rows.Add(null,"Electrodomesticos", "Licuadoras,tostadoras,etc");
            dt.Rows.Add(null, "Linea blanca", "Lavadoras, neveras");
            dt.Rows.Add(null, "Sonido", "Equipos de sonido");
            dt.Rows.Add(null, "TV", "Televisotes");
            DataRow drDep = dt.NewRow();
            drDep["Nombre"] = "Computacion";
            drDep["Descripcion"] = "PCs y accesorios";
            dt.Rows.Add(drDep);

            int ide;
            DataRow buscar;
            ide = 2;
            buscar = dt.Rows.Find(ide);
            MessageBox.Show(buscar[1].ToString());

          //  for (int i = dt.Rows.Count - 1; i >= 0; i-- )
          //  {
          //     DataRow row = dt.Rows[i];
          //      if (row[1].ToString() == "Sonido")
          //      {
          //          row.Delete();
          //      }
          //  }
          //dt.AcceptChanges();

            dt1.Rows.Add(null, "Licuadora",25,50.00,1);
            dt1.Rows.Add(null, "Lavadora", 10, 800.00, 2);
            dt1.Rows.Add(null, "Mini componente", 15, 150.00, 3);
            dt1.Rows.Add(null, "TV LED", 5, 300.00, 4);
            dt1.Rows.Add(null, "Laptop", 20, 550.00, 5);
         
            dgvDep.DataSource = dt;
            dgvInv.DataSource = dt1;

            ds.WriteXml("Store.xml");
          
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



