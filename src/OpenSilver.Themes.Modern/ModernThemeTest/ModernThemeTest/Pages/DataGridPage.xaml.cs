using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace ModernThemeTest.Pages
{
    public partial class DataGridPage : Page
    {
        public DataGridPage()
        {
            this.InitializeComponent();

            DataContext = new Data();
            Pager.IsTotalItemCountFixed = true;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }




    public class Data
    {
        List<Product> _products;

        public Data()
        {
            GroupedProducts = new PagedCollectionView(Products);
            GroupedProducts.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            GroupedProducts.GroupDescriptions.Add(new PropertyGroupDescription("Supplier"));

            PagedProducts = new PagedCollectionView(Products);
            PagedProducts.PageSize = 10;

        }

        public PagedCollectionView GroupedProducts;
        public PagedCollectionView PagedProducts;

        public List<Product> Products
        {
            get
            {
                if (_products == null)
                {
                    _products = GetProducts();
                }
                return _products;
            }
        }


        List<Product> GetProducts()
        {
            return new List<Product>
                {
                    new Product(1, "Laptop", "Electronics", "TechCorp", 999.99, 10, DateTime.Now.AddDays(-10)),
                    new Product(2, "Smartphone", "Electronics", "SmartTech", 799.99, 25, DateTime.Now.AddDays(-15)),
                    new Product(3, "Headphones", "Electronics", "SoundPlus", 199.99, 50, DateTime.Now.AddDays(-5)),
                    new Product(4, "T-Shirt", "Clothing", "FashionHub", 19.99, 100, DateTime.Now.AddDays(-30)),
                    new Product(5, "Jeans", "Clothing", "FashionHub", 49.99, 60, DateTime.Now.AddDays(-25)),
                    new Product(6, "Jacket", "Clothing", "StyleCo", 89.99, 20, DateTime.Now.AddDays(-20)),
                    new Product(7, "Socks", "Clothing", "FashionHub", 9.99, 200, DateTime.Now.AddDays(-7)),
                    new Product(8, "Novel", "Books", "BookWorld", 15.99, 80, DateTime.Now.AddDays(-40)),
                    new Product(9, "Cookbook", "Books", "CulinaryHouse", 25.99, 30, DateTime.Now.AddDays(-35)),
                    new Product(10, "Biography", "Books", "BookWorld", 29.99, 40, DateTime.Now.AddDays(-22)),
                    new Product(11, "Tablet", "Electronics", "TechCorp", 499.99, 15, DateTime.Now.AddDays(-8)),
                    new Product(12, "Bluetooth Speaker", "Electronics", "SoundPlus", 129.99, 45, DateTime.Now.AddDays(-14)),
                    new Product(13, "Shoes", "Clothing", "StyleCo", 69.99, 70, DateTime.Now.AddDays(-16)),
                    new Product(14, "Sunglasses", "Clothing", "StyleCo", 29.99, 150, DateTime.Now.AddDays(-18)),
                    new Product(15, "Mystery Novel", "Books", "BookWorld", 19.99, 65, DateTime.Now.AddDays(-45)),
                    new Product(16, "Science Textbook", "Books", "EduSupplies", 59.99, 25, DateTime.Now.AddDays(-50)),
                    new Product(17, "Monitor", "Electronics", "TechCorp", 199.99, 30, DateTime.Now.AddDays(-12)),
                    new Product(18, "Keyboard", "Electronics", "SmartTech", 49.99, 120, DateTime.Now.AddDays(-3)),
                    new Product(19, "Sweater", "Clothing", "FashionHub", 39.99, 80, DateTime.Now.AddDays(-17)),
                    new Product(20, "History Book", "Books", "EduSupplies", 34.99, 55, DateTime.Now.AddDays(-33)),
                };
        }
    }



    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }

        public Product(int id, string name, string category, string supplier, double price, int quantity, DateTime dateAdded)
        {
            Id = id;
            Name = name;
            Category = category;
            Supplier = supplier;
            Price = price;
            Quantity = quantity;
            DateAdded = dateAdded;
        }
    }


}
