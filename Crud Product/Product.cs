using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Product
{
    class Product
    {
        protected string m_id;
        protected string m_name;
        protected double m_price;

        public Product(string id, string name, double price)
        {
            this.m_id = id;
            this.m_name = name;
            this.m_price = price;
        }

        public Product()
        {
            this.m_id = "0";
            this.m_name = "Default";
            this.m_price = 0.0;
        }

        public string Id
        {
            get => this.m_id;
            set => this.m_id = value;
        }

        public string Name
        {
            get => this.m_name;
            set => this.m_name = value;
        }

        public double Price
        {
            get => this.m_price;
            set => this.m_price = value;
        }

        public bool ValidData
        {
            get { 
                if (Id == null) { 
                    return false; 
                } 
                if (Id.Trim().Equals("")) {
                    return false; 
                } 
                if (Name == null) { 
                    return false; 
                } 
                if (Name.Trim().Equals("")) { 
                    return false; 
                } 
                if (Price < 0) { 
                    return false; 
                } 
                return true; }
        }

        public string Info
        {
            get => $"{this.Name} ( {this.Id} , {this.Price:N2} )";
        }

        public Product Clone() { 
            return new Product(m_id, m_name, m_price); 
        }
        public static Product CreateProduct(string id, string name, double price) { 
            return new Product(id, name, price); 
        }
        public void SetData(string id, string name, double price)
        {
            m_id = id;
            m_name = name;
            m_price = price;
        }
    }
}
