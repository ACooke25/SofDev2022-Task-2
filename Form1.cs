using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SAC_1_Task_2_2nd
{
    public partial class Form1 : Form
    {
        float total = 0f;
        public Form1()
        {
            InitializeComponent();
            dgvSales.ColumnCount = 7;
            dgvSales.Columns[0].Name = "Textbook";
            dgvSales.Columns[1].Name = "Subject";
            dgvSales.Columns[2].Name = "Seller";
            dgvSales.Columns[3].Name = "Purchaser";
            dgvSales.Columns[4].Name = "Purchase Price";
            dgvSales.Columns[5].Name = "Sale Price";
            dgvSales.Columns[6].Name = "Profit";
            
        }

        private void btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                List<String> lines = new List<String>();
                lines = File.ReadAllLines(filePath).ToList();
                

                foreach (String line in lines)
                {
                    List<string> items = line.Split(',').ToList();
                    float profit;
                    float purchasedPrice = float.Parse(items[4]);
                    string salePrice = items[5];

                    if (float.TryParse(salePrice, out float _salePrice))
                    {

                        
                        profit = _salePrice - purchasedPrice;
                    }
                    else
                    {

                        profit = purchasedPrice * -1;
                    }
                    total += profit;

                    items.Add(profit.ToString());
                    dgvSales.Rows.Add(items.ToArray());
                }

               
                
               



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvSales.Rows.Add();
            int rowCount = dgvSales.Rows.Count;
            dgvSales.Rows[rowCount - 1].Cells[5].Value = ("Total Profit is: $").ToString();
            dgvSales.Rows[rowCount - 1].Cells[6].Value = total.ToString();
        }
    }

}


