using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication2
{
    public partial class MyConnection : Form
    {
        public OleDbConnection conn;
        public MyConnection()
        {
            InitializeComponent();
            conn = new OleDbConnection();
            conn.ConnectionString =
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
            Environment.CurrentDirectory + "\\PC_DB.accdb";
        }

        private void MyConnection_Load(object sender, EventArgs e)
        {

        }
    }
}
