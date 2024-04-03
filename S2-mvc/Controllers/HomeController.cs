using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Entitys;
using DataLogicLayer;
using DataLogicLayer.Entitys;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using S2_mvc.Models;
using System.Configuration;
using System.Diagnostics;
using System.Reflection.Metadata;


namespace S2_mvc.Controllers
{
    public class HomeController : Controller
    {
        DatabaseConnection connection = new DatabaseConnection();
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        

        
        
        public IActionResult Blogs()
        {
            BlogBusinessLogic blogBusinessLogic = new BlogBusinessLogic();
            List<Blog> blogs = blogBusinessLogic.SetBlogs();

            BlogViewModel blogViewModel = new BlogViewModel();
            blogViewModel.BlogList = blogs;

            //Blog blogModel = new Blog();
            //List<Blog> blogs;
            //blogs.Add(blogModel);
   

            return View(blogViewModel);
        }


        public IActionResult Index()
        {
            CategorieBusinessLogic categorieBusinessLogic = new CategorieBusinessLogic();
            List<Categorie> categories = categorieBusinessLogic.SetList();
            
            CategorieViewModel categorieViewModel = new CategorieViewModel();
            categorieViewModel.Categories = categories;

            return View(categorieViewModel);
        }

        [HttpPost]
        public IActionResult CreateBlog(Blog blog)
        {
            string query = "INSERT INTO blog (Title, Text) VALUES (@Title, @Text)";
            using (var connection = new MySqlConnection("SERVER=127.0.0.1;DATABASE=blog database;UID=root;PASSWORD="))
            {
                connection.Open();
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Title", blog.Title);
                    cmd.Parameters.AddWithValue("@Text", blog.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            
            return RedirectToAction("Blogs");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

  
}
