using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TestAPP
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = Text + " v" + Application.ProductVersion + " "; //change form title
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.checkBox1.Click += new System.EventHandler(this.textBox1_TextChanged);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox1.Text, out parsedValue))
            {
                textBox1.Text = "0";
            }

            if (checkBox1.Checked) // -50% Commission
            {
                int gold_sales = Convert.ToInt32(textBox1.Text);
                decimal market_commission = (decimal)(gold_sales * 0.035);
                decimal market_taxes = (decimal)(0.3);

                decimal total_market_taxes = market_commission * market_taxes;
                decimal overall_taxes = market_commission + total_market_taxes;
                decimal total_income = gold_sales - overall_taxes;

                this.label1.Text = Convert.ToString(market_commission);
                this.label2.Text = Convert.ToString(total_market_taxes);
                this.label9.Text = Convert.ToString(overall_taxes);
                this.label7.Text = Convert.ToString(total_income);
            }

            else if (!checkBox1.Checked)
            {
                int gold_sales = Convert.ToInt32(textBox1.Text);
                decimal market_commission = (decimal)(gold_sales * 0.07);
                decimal market_taxes = (decimal)(0.3);

                decimal total_market_taxes = market_commission * market_taxes;
                decimal overall_taxes = market_commission + total_market_taxes;
                decimal total_income = gold_sales - overall_taxes;

                this.label1.Text = Convert.ToString(market_commission);
                this.label2.Text = Convert.ToString(total_market_taxes);
                this.label9.Text = Convert.ToString(overall_taxes);
                this.label7.Text = Convert.ToString(total_income);
            }

        }
    }
}
