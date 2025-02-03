using JQ_prj1.Data;
using JQ_prj1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JQ_prj1.Controllers
{
    public class AdminController : Controller
    {
        public readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context) {
            _context = context;
        }
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Blog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BlogList()
        {
            List<BlogModel>blogs = new List<BlogModel>();
            //blogs = [.. _context.TL_Blog];
            blogs =_context.TL_Blog.ToList();
            //return Json(blogs);
            return PartialView("_ListBlogDataView", blogs);
        }

        [HttpGet]
        public ActionResult BlogAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BlogAdd(BlogModel blogModel)
        {
            ResponceModel model=new ResponceModel();

            if (string.IsNullOrEmpty(blogModel.Title))
            {
                model.IsSuccess = false;
                model.ResponceCode = 400;
                model.ResponceMsz = "Title is empty";
                return Json(model);
            }
            if (string.IsNullOrEmpty(blogModel.Description))
            {
                model.IsSuccess = false;
                model.ResponceCode = 400;
                model.ResponceMsz = "Description is empty";
                return Json(model);
            }

            if (string.IsNullOrEmpty(blogModel.VideoPath))
            {
                model.IsSuccess = false;
                model.ResponceCode = 400;
                model.ResponceMsz = "VideoPath is empty";
                return Json(model);
            }

            blogModel.TotalView = 100;
            blogModel.CreatedDate=DateTime.Now;
            blogModel.IsActive = 1;

            _context.TL_Blog.Add(blogModel);
            _context.SaveChanges();

            model.IsSuccess = true;
            model.ResponceCode=200;
            model.ResponceMsz = "Success";

            return Json(model);
        }

        [HttpGet]
        public IActionResult BlogUpdate(int id)
        {
            BlogModel model = new BlogModel();
            model = _context.TL_Blog.Where(x => x.BlogId == id).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public IActionResult BlogUpdate(BlogModel blogModel)
        {
           var bmodel = _context.TL_Blog.Where(x => x.BlogId == blogModel.BlogId).FirstOrDefault();

            ResponceModel model = new ResponceModel();

            if (string.IsNullOrEmpty(blogModel.Title))
            {
                model.IsSuccess = false;
                model.ResponceCode = 400;
                model.ResponceMsz = "Title is empty";
                return Json(model);
            }
            if (string.IsNullOrEmpty(blogModel.Description))
            {
                model.IsSuccess = false;
                model.ResponceCode = 400;
                model.ResponceMsz = "Description is empty";
                return Json(model);
            }

            if (string.IsNullOrEmpty(blogModel.VideoPath))
            {
                model.IsSuccess = false;
                model.ResponceCode = 400;
                model.ResponceMsz = "VideoPath is empty";
                return Json(model);
            }

            bmodel.Title = blogModel.Title;
            bmodel.Description = blogModel.Description;
            bmodel.VideoPath = blogModel.VideoPath;


            _context.TL_Blog.Update(bmodel);
            _context.SaveChanges();

            model.IsSuccess = true;
            model.ResponceCode = 200;
            model.ResponceMsz = "Success";

            return Json(model);
        }

        

        [HttpGet]
        public IActionResult BlogDetail(int id)
        {
            var model = _context.TL_Blog.FirstOrDefault(x => x.BlogId == id);
            if (model == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult BlogDetailData(int id)
        {
            var model = _context.TL_Blog.FirstOrDefault(x => x.BlogId == id);
            if (model == null)
            {
                return Json(new { success = false, message = "No data found" });
            }
            return Json(model);
        }

        //[HttpPost]
        //public IActionResult BlogDetailData(int id)
        //{
        //    BlogModel model = new BlogModel();
        //    model = _context.TL_Blog.Where(x => x.BlogId == id).FirstOrDefault();
        //    return Json(model);
        //}


        [HttpPost]
        public IActionResult BlogDelete(int id)
        {
            ResponceModel model = new ResponceModel();
            BlogModel datamodel = new BlogModel();
            datamodel = _context.TL_Blog.Where(x => x.BlogId == id).FirstOrDefault();
            if (datamodel != null)
            {
                _context.Remove(datamodel);
                _context.SaveChanges();
                model.IsSuccess = true;
                model.ResponceCode = 200;
                model.ResponceMsz = "Success";

                return Json(model);
            }
            else
            {
                model.IsSuccess = false;
                model.ResponceCode = 400;
                model.ResponceMsz = "Invalid Id";

                return Json(model);
            }
            

        }
    }
}
