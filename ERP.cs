using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class ERP : Form
    {
        public ERP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }   

        private void ERP_Load(object sender, EventArgs e)
        {
            this.radioButton1.Visible = false;
            this.radioButton2.Visible = false;
            this.radioButton3.Visible = false;
            this.radioButton4.Visible = false;
            this.radioButton5.Visible = false;
            this.radioButton6.Visible = false;
            this.radioButton7.Visible = false;
            this.radioButton8.Visible = false;
         
            this.radioButton10.Visible = false;
            this.radioButton12.Visible = false;
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = false;
            this.button4.Visible = false;
            this.button5.Visible = false;
            this.button7.Visible = false;
            this.button8.Visible = false;
            this.button9.Visible = false;
            this.button10.Visible = false;
            this.button20.Visible = false;
            this.button21.Visible = false;
            this.button13.Visible = false;
            this.button14.Visible = false;
            this.button15.Visible = false;
            
            this.button17.Visible = false;
            

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Search sh = new Search();
            sh.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Vendor v = new Vendor();
            v.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            VSearch vs = new VSearch();
            vs.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            PurchaseOrder po = new PurchaseOrder();
            po.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                this.button1.Visible = true;
                this.button2.Visible = true;
            }
            if (radioButton2.Checked == true)
            {
                this.button3.Visible = true;
                this.button4.Visible = true;
            }
            if (radioButton3.Checked == true)
            {
                this.button5.Visible = true;
                this.button8.Visible = true;
            }
            if (radioButton4.Checked == true)
            {
                this.button7.Visible = true;
            }
            if (radioButton5.Checked == true)
            {
                this.button9.Visible = true;
            }
            if (radioButton6.Checked == true)
            {
                this.button10.Visible = true;
            }
            if (radioButton12.Checked == true)
            {
                this.button21.Visible = true;
                this.button20.Visible = true;
            }
            if (radioButton10.Checked == true)
            {
                this.button17.Visible = true;
                this.button15.Visible = true;
            }
            
            if (radioButton8.Checked == true)
            {
                this.button14.Visible = true;
            }
            if (radioButton7.Checked == true)
            {
                this.button13.Visible = true;
            }
            
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Product p = new Product();
            p.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            ApprovePO ap = new ApprovePO();
            ap.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            GRN grn = new GRN();
            grn.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Invoice invoice=new Invoice();
            invoice.Show();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.radioButton1.Visible = true;
            this.radioButton2.Visible = true;
            this.radioButton3.Visible = true;
            this.radioButton4.Visible = true;
            this.radioButton5.Visible = true;
            this.radioButton6.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.radioButton7.Visible = true;
            this.radioButton8.Visible = true;
        
            this.radioButton10.Visible = true;
            this.radioButton12.Visible = true;

        }

        private void button21_Click(object sender, EventArgs e)
        {
            Client cl = new Client();
            cl.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            CSearch cs = new CSearch();
            cs.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            SaleOrder so = new SaleOrder();
            so.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ApproveSo aps = new ApproveSo();
            aps.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DChalan gdn = new DChalan();
            gdn.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            InvoiceRecieve invR = new InvoiceRecieve();
            invR.Show();
        }
    }
}
