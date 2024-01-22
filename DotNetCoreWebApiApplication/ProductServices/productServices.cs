using DotNetCoreWebApiApplication.Models;

namespace DotNetCoreWebApiApplication.ProductServices
{
    public class productServices
    {
        private static List<ProductModel> products = new List<ProductModel>();
        private static int lastProductId = 0;

        public List<ProductModel> GetAllProducts()
        {
            return products;
        }

        public ProductModel GetProductById(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public void AddProduct(ProductModel product)
        {
            product.Id = ++lastProductId;
            products.Add(product);
        }

        public void UpdateProduct(int id, ProductModel updatedProduct)
        {
            var existingProduct = products.Find(p => p.Id == id);
            if (existingProduct != null)
            {
                existingProduct.productName = updatedProduct.productName;
                existingProduct.productDescription = updatedProduct.productDescription;
            }
        }

        public void DeleteProduct(int id)
        {
            products.RemoveAll(p => p.Id == id);
        }
    }
}
