﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private readonly List<Product> products;

        public Person(string name, decimal money)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            if (money < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.Name = name;
            this.Money = money;

            this.products = new List<Product>();
            this.Products = this.products.AsReadOnly();
        }

        public string Name { get;}
        public decimal Money { get; private set; }
        public IReadOnlyCollection<Product> Products { get; }

        public bool TryPurchase(Product product)
        {
            if (product.Cost > this.Money)
            {
                return false;
            }

            this.products.Add(product);
            this.Money -= product.Cost;
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.Name);
            sb.Append(" - ");

            if(this.Products.Count == 0) 
            {
                sb.Append("Nothing bought");
            }
            else
            {
                sb.Append(string.Join(", ", this.Products.Select(p => p.Name)));
            }

            return sb.ToString();
        }
    }
}