namespace ProductShop
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    using Data;
    using DTOs.Import;
    using Models;
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();
            dbContext.Database.Migrate();

            string jsonString = File.ReadAllText("../../../Datasets/categories-products.json");
            string result = ImportCategoryProducts(dbContext, jsonString);

            Console.WriteLine(result);
        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            string result = String.Empty;
            ImportUserDTO[]? userDTO = JsonConvert
                .DeserializeObject<ImportUserDTO[]>(inputJson);

            if (userDTO != null)
            {
                ICollection<User> usersToAdd = new List<User>();
                foreach (ImportUserDTO userDto in userDTO)
                {
                    if (!IsValid(userDto))
                    {
                        
                        continue;
                    }
                    int? userAge = null;
                    if (userDto.Age != null)
                    {
                        bool isAgeValid = int.TryParse(userDto.Age, out int parsedAge);
                        if (!isAgeValid)
                        {
                            continue;
                        }

                        userAge = parsedAge;
                    }

                    User user = new User()
                    {
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Age = userAge
                    };

                    usersToAdd.Add(user);
                }
                context.Users.AddRange(usersToAdd);
                context.SaveChanges();

                result = $"Successfully imported {usersToAdd.Count}";
            }

            return result;

        }
        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            string result = String.Empty;
            ImportProductDto[]? productDtos = JsonConvert
                .DeserializeObject<ImportProductDto[]>(inputJson);
            if (productDtos != null)
            {         
                ICollection<int> dbUsers = context
                    .Users
                    .Select(u => u.Id)
                    .ToArray();

                ICollection<Product> validProducts = new List<Product>();
                foreach (ImportProductDto productDto in productDtos)
                {
                    if (!IsValid(productDto))
                    {
                        continue;
                    }

                    bool isPriceValid = decimal
                        .TryParse(productDto.Price, out decimal productPrice);

                    bool isSellerValid = int
                        .TryParse(productDto.SellerId, out int sellerId);
                    if(!isPriceValid || !isSellerValid)
                    {
                        continue;
                    }

                    int? buyerId = null;
                    if(productDto.BuyerId != null)
                    {
                        bool isBuyerIdValid = int
                            .TryParse(productDto.BuyerId, out int parsedBuyerId);
                        if (!isBuyerIdValid)
                        {
                            continue;
                        }
                        //if (!dbUsers.Contains(parsedBuyerId))
                        //{
                        //    continue;
                        //}
                        buyerId = parsedBuyerId;
                    }
                    //if (!dbUsers.Contains(sellerId))
                    //{
                    //    continue;
                    //}

                    Product product = new Product()
                    {
                        Name = productDto.Name,
                        Price = productPrice,
                        SellerId = sellerId,
                        BuyerId = buyerId
                    };
                    validProducts.Add(product);
                }
                context.Products.AddRange(validProducts);
                context.SaveChanges();

                result = $"Successfully imported {validProducts.Count}";
            }
            return result;
        }
        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            string result = String.Empty;
            ImportCategoryDto[]? categoryDtos = JsonConvert
                .DeserializeObject<ImportCategoryDto[]>(inputJson);
            if (categoryDtos != null)
            {
                ICollection<Category> validCategories = new List<Category>();

                foreach (ImportCategoryDto categoryDto in categoryDtos)
                {
                    if (!IsValid(categoryDto))
                    {
                        continue;
                    }

                    Category category = new Category()
                    {
                        Name = categoryDto.Name!,
                    };

                    validCategories.Add(category);
                }
                context.Categories.AddRange(validCategories);
                context.SaveChanges();

                result = $"Successfully imported {validCategories.Count}";

            }
            return result;
        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportCategoryProductDto[]? catProdDtos = JsonConvert
                .DeserializeObject<ImportCategoryProductDto[]>(inputJson);
            if (catProdDtos != null)
            {
                ICollection<int> dbProducts = context
                    .Products
                    .Select(p => p.Id)
                    .ToArray();
                ICollection<int> dbCategories = context
                    .Categories
                    .Select(c => c.Id)
                    .ToArray();

                ICollection<CategoryProduct> validCatProd = new List<CategoryProduct>();
                foreach (ImportCategoryProductDto catProdDto in catProdDtos)
                {
                    if (!IsValid(catProdDto))
                    {
                        continue;
                    }

                    bool isProductIdValid = int
                        .TryParse(catProdDto.ProductId, out int productId);
                    bool isCategoryIdValid = int
                        .TryParse(catProdDto.CategoryId, out int categoryId);

                    if ((!isProductIdValid) || (!isCategoryIdValid))
                    {
                        continue;
                    }

                    CategoryProduct catProd = new CategoryProduct()
                    {
                        ProductId = productId,
                        CategoryId = categoryId
                    };

                    validCatProd.Add(catProd);
                }

                context.CategoriesProducts.AddRange(validCatProd);
                context.SaveChanges();

                result = $"Successfully imported {validCatProd.Count}";
            }

            return result;
        }
        private static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(dto, validateContext, validationResults, true);

            return isValid;
        }
    }
}