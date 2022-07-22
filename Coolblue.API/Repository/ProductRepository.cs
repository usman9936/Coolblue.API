
using Coolblue.API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Coolblue.API.Repository
{
    public class ProductRepository : IProductRespository
    {
        public List<Product> GetProducts()
        {
            string filePath = "Resources\\Products.json";
            var jsonData = ReadJsonFile(filePath);
            if (jsonData != null)
            {
                var products = JsonConvert.DeserializeObject<List<Product>>(jsonData); //deserialize object as a list of Products in accordance with Products.json file
                if (products == null || products.Count == 0) //if there's no data inside our list then return null
                {
                    return null;
                }
                return products;
            }
            return null;
        }
        public List<ProductType> GetProductTypes()
        {
            string filePath = "Resources\\ProductTypes.json";
            var jsonData = ReadJsonFile(filePath);
            if (jsonData != null)
            {
                var productTypes = JsonConvert.DeserializeObject<List<ProductType>>(jsonData); //deserialize object as a ProductTypes of users in accordance with ProductTypes.json file
                if (productTypes == null || productTypes.Count == 0) //if there's no data inside our list then return null
                {
                    return null;
                }
                return productTypes;
            }
            return null;
        }
        private string ReadJsonFile(string filePath)
        {
            var rootPath = System.AppDomain.CurrentDomain.BaseDirectory; //get the root path
            var fullPath = Path.Combine(rootPath, filePath); //combine the root path with that of our json file inside Resources directory
            var fileContent = System.IO.File.ReadAllText(fullPath); //read all the content inside the file
            if (string.IsNullOrWhiteSpace(fileContent))//if no data is present then return null
            {
                return null;
            }
            return fileContent;
        }
    }
}
