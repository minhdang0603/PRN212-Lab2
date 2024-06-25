using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        public static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }
        //-------------------------------------
        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            try
            {
                using var context = new MyStoreContext();
                products = context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        //-------------------------------------
        public Product GetProductById(int id)
        {
            var product = new Product();
            try
            {
                using var context = new MyStoreContext();
                product = context.Products.FirstOrDefault(p => p.ProductId == id);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);    
            }
            return product;
        }
        //-------------------------------------
        public void SaveProduct(Product product)
        {
            try
            {
                using var context = new MyStoreContext();
                context.Products.Add(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //-------------------------------------
        public void UpdateProduct(Product product)
        {
            try
            {
                using var context = new MyStoreContext();
                context.Products.Update(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //-------------------------------------
        public void DeleteProduct(Product product)
        {
            try
            {
                using var context = new MyStoreContext();
                context.Products.Remove(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
