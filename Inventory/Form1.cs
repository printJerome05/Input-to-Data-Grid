using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class ProductClass
        {
            private int _Quantity;
            private double _SellingPrice;
            private string _ProductName, _Category, _ManufacturingDate, _ExpirationDate, _Description;

            public ProductClass(string ProductName, string Category, string MfgDate, string ExpDate,
            double Price, int Quantity, string Description)
            {
                this._Quantity = Quantity;
                this._SellingPrice = Price;
                this._ProductName = ProductName;
                this._Category = Category;
                this._ManufacturingDate = MfgDate;
                this._ExpirationDate = ExpDate;
                this._Description = Description;
            }
            public string productName
            {
                get
                {
                    return this._ProductName;
                }
                set
                {
                    this._ProductName = value;
                }
            }
            public string category
            {
                get
                {
                    return this._Category;
                }
                set
                {
                    this._Category = value;
                }
            }
            public string manufacturingDate
            {
                get
                {
                    return this._ManufacturingDate;
                }
                set
                {
                    this._ManufacturingDate = value;
                }
            }
            public string expirationDate
            {
                get
                {
                    return this._ExpirationDate;
                }
                set
                {
                    this._ExpirationDate = value;
                }
            }
            public string description
            {
                get
                {
                    return this._Description;
                }
                set
                {
                    this._Description = value;
                }
            }
            public int quantity
            {
                get
                {
                    return this._Quantity;
                }
                set
                {
                    this._Quantity = value;
                }
            }
            public double sellingPrice
            {
                get
                {
                    return this._SellingPrice;
                }
                set
                {
                    this._SellingPrice = value;
                }
            }
        }

        private string _ProductName, _Category, _MfgDate, _ExpDate, _Description;
        private int _Quantity;
        private double _SellPrice;
        BindingSource showProductList = new BindingSource();

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = { "Beverages", "Bread/Bakery", "Canned/Jarred Goods", "Dairy", "Frozen Goods", "Meat", "Personal Care", "Other" };
            foreach (string items in ListOfProductCategory)
            {
                cbCategory.Items.Add(items);
            }

        }
        public string Product_Name(string name)
        {
            if (Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                _ProductName = (name);
                return name;
            }
            else
            {
                //throws and popup a MessageBox showing this string inside it.
                throw new StringFormatException("Please input a valid product!");
            }
        }
        public int Quantity(string qty)
        {

            if (Regex.IsMatch(qty, @"^[0-9]"))
            {
                _Quantity = int.Parse(qty);
                return Convert.ToInt32(qty);
            }
            else if (txtQuantity.Text == "")
            {
                //throws and popup a MessageBox showing this string inside it.
                throw new StringFormatException("Please input a quantity!");
            }
            else
            {
                //throws and popup a MessageBox showing this string inside it.
                throw new NumberFormatException("Quantity field must be a number only!");
            }
        }
        public double SellingPrice(string price)
        {
            if (Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
            {
                _SellPrice = double.Parse(price);
                return Convert.ToDouble(price);
            }
            else if (txtSellPrice.Text == "")
            {
                //throws and popup a MessageBox showing this string inside it.
                throw new StringFormatException("Please indicate your selling price!");
            }
            else
            {
                //throws and popup a MessageBox showing this string inside it.
                throw new NumberFormatException("Sell Price field must be a number only!");
            }
        }

        //when the user input a string at quantity field and sell price field, this will execute.
        public class NumberFormatException : Exception
        {
            public NumberFormatException(string quantity) : base(quantity)
            {
            }

        }
        //when the user input a invalid product name, this will execute.

        public class StringFormatException : Exception
        {
            public StringFormatException(string product) : base(product)
            {
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Quantity(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);

                //to show at gridViewProductList
                showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
                _ExpDate, _SellPrice, _Quantity, _Description));
                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;
            }

            //execute when the user input a string at quantity/sell price field.
            catch (NumberFormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            //execute when the user input a invalid product name at product field.
            catch (StringFormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       }
    }

