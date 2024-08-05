using System;
using System.Security.Cryptography;
using WoodArtCons.Server.WoodArtCons.Persistence.Entities;

namespace WoodArtCons.Server.WoodArtCons.Persistence.Initializers
{
    public class DatabaseSeeder
    {
        public static void SeedDb(AppDbContext appDbContext)
        {
            AddUser(appDbContext);
            AddCategories(appDbContext);
            AddCategoryProducts(appDbContext);
        }

        private static void AddUser(AppDbContext appDbContext)
        {
            if (appDbContext.Users.Count() == 0)
            {
                {
                    var user = new User()
                    {
                        Email = "admin@admin.com",
                        UserName = "Admin",
                        Role = "Admin",
                    };

                    string password = "c=nT-4M6Sy,P{5)3DU+pNB";

                    CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;

                    appDbContext.Users.Add(user);
                }

                appDbContext.SaveChanges();
            }

            //string password2 = "qwe";
            //var userToEdit = await appDbContext.Users.Where(u => u.Email == "admin@admin.com").FirstOrDefault();

            //CreatePasswordHash(password2, out byte[] passwordHash2, out byte[] passwordSalt2);
            //userToEdit.PasswordHash = passwordHash2;
            //userToEdit.PasswordSalt = passwordSalt2;

            appDbContext.SaveChanges();
        }

        public static void AddCategories(AppDbContext appDbContext)
        {
            string catalogUrl = "/catalog/";
            string galeryUrl = "/galery/";

            if (appDbContext.Categories.Count() == 0)
            {
                CategoryModel category;
                    
                category = new CategoryModel { Id = "street-benches",  NameRo = "Bănci stradale",   NameRu = "Уличные скамейки",    NameEn = "Street Benches",     ImageSrc = "Images/Categories/banca_stradala.png", Link = catalogUrl + "street-benches", IsForGalery = false };
                appDbContext.Categories.Add(category);
                category = new CategoryModel { Id = "trash-boxes",     NameRo = "Coșuri de gunoi",  NameRu = "Урны",                NameEn = "Trash Boxes",        ImageSrc = "Images/Categories/urna.png",           Link = catalogUrl + "trash-boxes",    IsForGalery = false };
                appDbContext.Categories.Add(category);
                category = new CategoryModel { Id = "trays",           NameRo = "Platouri",         NameRu = "Лотки",               NameEn = "Trays",              ImageSrc = "Images/Categories/tray.png",           Link = catalogUrl + "trays",          IsForGalery = false };
                appDbContext.Categories.Add(category);
                category = new CategoryModel { Id = "furniture",       NameRo = "Mobilier",         NameRu = "Мебель",              NameEn = "Furniture",          ImageSrc = "Images/Categories/furniture.png",      Link = catalogUrl + "furniture",      IsForGalery = false };
                appDbContext.Categories.Add(category);
                category = new CategoryModel { Id = "houses",          NameRo = "Case din lemn",    NameRu = "Деревянные дома",     NameEn = "Wooden houses",      ImageSrc = "Images/Categories/aframe.png",         Link = galeryUrl + "houses",          IsForGalery = true } ;
                appDbContext.Categories.Add(category);
            }

            appDbContext.SaveChanges();
        }

        public static void AddCategoryProducts(AppDbContext appDbContext)
        {
            var imageBaseUrl = "Images/Products/";
            var imageGaleryBaseUrl = "Images/Galery/";

            if (appDbContext.Products.Count() == 0)
            {
                CategoryProductModel categoryProduct;

                categoryProduct = new CategoryProductModel { Id = "sb1", CategoryId = "street-benches",
                    NameRo = "Model M-01",
                    NameRu = "Модель M-01",
                    NameEn = "Model M-01",
                    ImageSrc = imageBaseUrl + "sbm01.png", Price = 3000,
                    Lenght = 1.6f,
                    Width = 0.6f,
                    Height = 0.8f,
                    DescriptionRo = "Scaun Model",
                    DescriptionRu = "Скамейка Модель",
                    DescriptionEn = "Model Bench",
                    MaterialRo = "Tablă din metal și lamele de lemn",
                    MaterialRu = "Металлический лист и деревянные рейки",
                    MaterialEn = "Metal sheet and wooden slats" };
                appDbContext.Products.Add(categoryProduct);
                categoryProduct = new CategoryProductModel { Id = "sb2", CategoryId = "street-benches",
                    NameRo = "Model M-02",
                    NameRu = "Модель M-02",
                    NameEn = "Model M-02",
                    Lenght = 1.6f,
                    Width = 0.6f,
                    Height = 0.8f,
                    ImageSrc = imageBaseUrl + "sbm02.png", Price = 3300 };
                appDbContext.Products.Add(categoryProduct);
                categoryProduct = new CategoryProductModel { Id = "sb3", CategoryId = "street-benches",
                    NameRo = "Model M-04",
                    NameRu = "Модель M-04",
                    NameEn = "Model M-04",
                    Lenght = 1.6f,
                    Width = 0.6f,
                    Height = 0.8f,
                    ImageSrc = imageBaseUrl + "sbm04.png", Price = 3500 };
                appDbContext.Products.Add(categoryProduct);
                categoryProduct = new CategoryProductModel { Id = "sb4", CategoryId = "street-benches",
                    NameRo = "Model M-05 ",
                    NameRu = "Модель M-05 ",
                    NameEn = "Model M-05 ",
                    Lenght = 1.6f,
                    Width = 0.6f,
                    Height = 0.8f,
                    ImageSrc = imageBaseUrl + "sbm05.png", Price = 3600 };
                appDbContext.Products.Add(categoryProduct);
                categoryProduct = new CategoryProductModel { Id = "sb5", CategoryId = "street-benches",
                    NameRo = "Model M-06",
                    NameRu = "Модель M-06",
                    NameEn = "Model M-06",
                    Lenght = 1.6f,
                    Width = 0.6f,
                    Height = 0.8f,
                    ImageSrc = imageBaseUrl + "sbm06.png", Price = 3900 };
                appDbContext.Products.Add(categoryProduct);
                categoryProduct = new CategoryProductModel { Id = "sb6", CategoryId = "street-benches",
                    NameRo = "Model M-FP",
                    NameRu = "Модель M-ФП",
                    NameEn = "Model M-FP",
                    Lenght = 1.6f,
                    Width = 0.6f,
                    Height = 0.8f,
                    ImageSrc = imageBaseUrl + "sbmfp.png", Price = 6000 };
                appDbContext.Products.Add(categoryProduct);
                categoryProduct = new CategoryProductModel { Id = "sb7", CategoryId = "street-benches",
                    NameRo = "Model M-01",
                    NameRu = "Модель M-01",
                    NameEn = "Model M-01",
                    ImageSrc = imageBaseUrl + "sbm01.png", Price = 3100,
                    Lenght = 2f,
                    Width = 0.6f,
                    Height = 0.8f,
                    DescriptionRo = "Scaun Model",
                    DescriptionRu = "Скамейка Модель",
                    DescriptionEn = "Model Bench",
                    MaterialRo = "Tablă din metal și lamele de lemn",
                    MaterialRu = "Металлический лист и деревянные рейки",
                    MaterialEn = "Metal sheet and wooden slats", };
                appDbContext.Products.Add(categoryProduct);
                categoryProduct = new CategoryProductModel { Id = "sb8", CategoryId = "street-benches",
                    NameRo = "Model M-02",
                    NameRu = "Модель M-02",
                    NameEn = "Model M-02",
                    Lenght = 2f,
                    Width = 0.6f,
                    Height = 0.8f,
                    ImageSrc = imageBaseUrl + "sbm02.png", Price = 3400 };
                appDbContext.Products.Add(categoryProduct);
                categoryProduct = new CategoryProductModel { Id = "sb9", CategoryId = "street-benches",
                    NameRo = "Model M-04",
                    NameRu = "Модель M-04",
                    NameEn = "Model M-04",
                    Lenght = 2f,
                    Width = 0.6f,
                    Height = 0.8f,
                    ImageSrc = imageBaseUrl + "sbm04.png", Price = 3700 };
                appDbContext.Products.Add(categoryProduct);
                categoryProduct = new CategoryProductModel { Id = "sb10", CategoryId = "street-benches",
                    NameRo = "Model M-05 ",
                    NameRu = "Модель M-05 ",
                    NameEn = "Model M-04 ",
                    Lenght = 2f,
                    Width = 0.6f,
                    Height = 0.8f,
                    ImageSrc = imageBaseUrl + "sbm05.png", Price = 3700 };
                appDbContext.Products.Add(categoryProduct);
                categoryProduct = new CategoryProductModel { Id = "sb11", CategoryId = "street-benches",
                    NameRo = "Model M-06",
                    NameRu = "Модель M-06",
                    NameEn = "Model M-06",
                    Lenght = 2f,
                    Width = 0.6f,
                    Height = 0.8f,
                    ImageSrc = imageBaseUrl + "sbm06.png", Price = 3800 };
                appDbContext.Products.Add(categoryProduct);
                categoryProduct = new CategoryProductModel { Id = "sb12", CategoryId = "street-benches",
                    NameRo = "Model M-FP",
                    NameRu = "Модель M-ФП",
                    NameEn = "Model M-FP",
                    Lenght = 2f,
                    Width = 0.6f,
                    Height = 0.8f,
                    ImageSrc = imageBaseUrl + "sbmfp.png", Price = 7000 };
                appDbContext.Products.Add(categoryProduct);
                categoryProduct = new CategoryProductModel { Id = "tb1",
                    CategoryId = "trash-boxes",
                    NameRo = "Coș de gunoi CS-6",
                    NameRu = "Корзина для мусора CS-6",
                    NameEn = "Trash box CS-6",
                    ImageSrc = imageBaseUrl + "cg-cs6.jpg",
                    Price = 1500 };
                appDbContext.Products.Add(categoryProduct);
                categoryProduct = new CategoryProductModel { Id = "t1",
                    CategoryId = "trays",
                    NameRo = "Platou 1",
                    NameRu = "Лоток 1",
                    NameEn = "Tray 1",
                    ImageSrc = imageBaseUrl + "tray.png", Price = 1300 };
                appDbContext.Products.Add(categoryProduct);
                categoryProduct = new CategoryProductModel { Id = "f1",
                    CategoryId = "furniture",
                    NameRo = "Mobilier 1",
                    NameRu = "Мебель 1",
                    NameEn = "Furniture 1",
                    ImageSrc = imageBaseUrl + "furniture.png", Price = 2700 };
                appDbContext.Products.Add(categoryProduct);
                categoryProduct = new CategoryProductModel
                {
                    Id = "house1",
                    CategoryId = "houses",
                    NameRo = "Casa Tip A Frame",
                    NameRu = "Дома Типa A Frame",
                    NameEn = "House Type A Frame",
                    ImageSrc = imageBaseUrl + "aframe.png",
                    Price = 1760000,
                    ListImagesSrc = new List<string>
                    {
                        imageGaleryBaseUrl + "aframe1.jpg",
                        imageGaleryBaseUrl + "aframe2.jpg",
                        imageGaleryBaseUrl + "aframe3.jpg",
                        imageGaleryBaseUrl + "aframe4.jpg",
                        imageGaleryBaseUrl + "aframe5.jpg",
                    }
                };
                //categoryProduct.ListImagesSrc = string.Join(",", categoryProduct.ListImagesSrcList);
                appDbContext.Products.Add(categoryProduct);
            }

            appDbContext.SaveChanges();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
