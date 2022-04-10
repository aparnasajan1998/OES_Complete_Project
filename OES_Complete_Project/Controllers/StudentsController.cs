#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OES_Complete_Project.Data;
using OES_Complete_Project.Models;

namespace OES_Complete_Project.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext db;

        public StudentsController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await db.Students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await db.Students
                .FirstOrDefaultAsync(m => m.User_ID == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("User_ID,Full_Name,Email,Password,City,Mobile_No,State,Qualification,YearOfCompletion")] Students students)
        {
            if (ModelState.IsValid)
            {
                db.Add(students);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(students);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await db.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("User_ID,Full_Name,Email,Password,City,Mobile_No,State,Qualification,YearOfCompletion")] Students students)
        {
            if (id != students.User_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(students);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(students.User_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(students);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await db.Students
                .FirstOrDefaultAsync(m => m.User_ID == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var students = await db.Students.FindAsync(id);
            db.Students.Remove(students);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsExists(string id)
        {
            return db.Students.Any(e => e.User_ID == id);
        }

        [HttpGet]
        public IActionResult Register()                 //register
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Students student)     //register function
        {
            
            if (ModelState.IsValid)
            {
                var result = db.Students.Find(student.User_ID);
                if (result == null)
                {
                    Students s = new Students();
                    s.User_ID = student.User_ID;
                    s.Full_Name = student.Full_Name;
                    s.Email = student.Email;
                    s.Password = student.Password;
                    s.City = student.City;
                    s.Mobile_No = student.Mobile_No;
                    s.State = student.State;
                    s.Qualification = student.Qualification;
                    s.YearOfCompletion = student.YearOfCompletion;
                    db.Students.Add(s);
                    db.SaveChanges();

                    ViewBag.Message = "Registered Successfully!!!";

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "User ID already exists..please try again!!";
                    return View();
                }
            }
            return View();
        }


        [HttpGet]
        public IActionResult Login()            //login
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(Login logins)       //login
        {
            if (ModelState.IsValid)
            {
                var result = (from s in db.Students
                              where s.Email == logins.Email &&
                              s.Password == logins.Password
                              select s).FirstOrDefault();

                if (result != null)
                {
                    TempData["username"] = logins.Email;
                    TempData.Keep();
                    return RedirectToAction("LoginHomePage", "Students");
                }
                else
                {
                    ViewBag.Message = "Invalid Login Id or Password..Try again.";
                }
            }
            return View();
        }

        public IActionResult Logout()       //logout function
        {

            return RedirectToAction("Index", "Home");
        }

        public IActionResult LoginHomePage()
        {
            return View();
        }



        public IActionResult NewExam()      //new exam
        {
            /*return RedirectToAction("NewExam", "Students");   */  ///redirecting to newexam portal 
            return View();
        }

        public IActionResult ExamWindowPge()
        {
            //return RedirectToAction("ExamPge", "Students");
            return View();
        }

        //public IActionResult StartExam(string tech) //tech->technology name
        //{
        //    //var res = db.Questions;
        //    //var d = (from e in db.Questions where e.technology.Technology_Name == tech && e.Level == 1 select e).SingleOrDefault();
        //    //var data = db.Questions.FirstOrDefault(x => x.technology.Technology_Name == tech && x.Level == 1);

        //    //if(data != null)
        //    //{
        //    //    return View(d);
        //    //}
        //    //else
        //    //{
        //    //    ViewBag.not = "No exam found";
        //    //    return View();
        //    //}
        //    //return View();

        //    var result = db.Questions;
        //    var res = db.Questions
        //        .Where(q => q.technology.Technology_Name == tech)
        //        .Select(t => new Questions()
        //        {
        //            Question_ID = t.Question_ID,
        //            Question = t.Question,
        //            technology = new Technology()
        //            {
        //                Technology_Name = t.technology.Technology_Name,
        //            },
        //            Option_1 = t.Option_1,
        //            Option_2 = t.Option_2,
        //            Option_3 = t.Option_3,
        //            Option_4 = t.Option_4,
        //        }).SingleOrDefault();
        //    return View(result);



        //    //var result = db.Questions;
        //    //var res = db.Questions
        //    //    .Where(q => q.technology.Technology_ID == tech)
        //    //    .Select(t => new Questions()
        //    //    {
        //    //        Question_ID = t.Question_ID,
        //    //        Question = t.Question,
        //    //        Option_1 = t.Option_1,
        //    //        Option_2 = t.Option_2,
        //    //        Option_3 = t.Option_3,
        //    //        Option_4 = t.Option_4,
        //    //        technology = t.technology

        //    //    }).ToList();

        //    //var d = (from e in db.Questions where e.technology.Technology_Name == tech && e.Level == 1 select e).SingleOrDefault();
        //    //var data = db.Questions.FirstOrDefault(x => x.technology.Technology_Name == tech && x.Level == 1);
        //    //List<Questions> li = db.Questions.Where(x => x.technology.Technology_Name == tech && x.Level == 1).ToList();
        //    //Queue<Questions> queue = new Queue<Questions>();
        //    //foreach (Questions a in li)
        //    //{
        //    //    queue.Enqueue(a);
        //    //}
        //    //TempData["questions "] = queue;
        //    //TempData["score"] = 0;
        //    //TempData["i"] = 1;
        //    //TempData["id"] = tech;
        //    //TempData["sno"] = 0;
        //    //TempData.Keep();

        //    //if (data != null)
        //    //{

        //    //    ViewBag.examid = d.Question_ID;
        //    //    ViewBag.examtext = d.Question;
        //    //    ViewBag.categoryid = d.technology.Technology_Name;
        //    //    ViewBag.lid = d.Level;




        //    //    TempData["level"] = d.Level;
        //    //    TempData["examid"] = d.Question_ID;

        //    //    TempData["des"] = d.Question;
        //    //    TempData.Keep();

        //    //    return View(d);
        //    //}
        //    //else
        //    //{
        //    //    ViewBag.not = "No exam found";
        //    //    return View();
        //    //}


        //}


        //PENDING
        //public IActionResult Results(string id)      //get the report or result
        //{
        //var result = db.Reports;
        //var res = db.Reports
        //    .Where(s => s.Students.User_ID == id)
        //    .Select(x => new Reports()
        //    {
        //        Exam_ID = x.Exam_ID,
        //        Students=new Students()
        //        {
        //            User_ID= x.Students.User_ID
        //        },
        //        Marks1 = x.Marks1,
        //        Marks2 = x.Marks2,
        //        Marks3 = x.Marks3,
        //        technology = new Technology()
        //        {
        //            Technology_ID=x.technology.Technology_ID
        //        }
        //      }).FirstOrDefault();
        //    return View();
        //}

        //[HttpGet]
        public IActionResult Results(string id)     //report page
        {

            var result = db.Reports;
            var res = db.Reports
                .Where(s => s.technology.Technology_Name == id)
                .Select(s => new Reports()
                {
                    Exam_ID = s.Exam_ID,
                    Students = new Students()
                    {
                        User_ID = s.Students.User_ID
                    },
                    Marks1 = s.Marks1,
                    Marks2 = s.Marks2,
                    Marks3 = s.Marks3,
                    technology = new Technology()
                    {
                        Technology_Name = s.technology.Technology_Name
                    }

                }).SingleOrDefault();
            return View(result);
        }




        //to startexam upon clicking a technology


        //public IActionResult getdetails()   //code to get all questions from db
        //{
        //    var res = db.Questions;
        //    return View(res);
        //}
        //sample just to get details from db of students

        //public List<Students> GetAllDetails()
        //{

        //        var result=db.Students.
        //            Select(x=> new Students()
        //            {
        //                User_ID = x.User_ID,
        //                Email = x.Email,
        //                Password = x.Password,
        //                Full_Name= x.Full_Name,

        //            }).ToList();
        //    return result;
        //}

        //public IActionResult getdet(string id)      //to get detail of a student by id
        //{
        //    var result = db.Students;
        //    var res=db.Students
        //        .Where(s => s.User_ID == id)
        //        .Select(x => new Students()
        //        {
        //            User_ID = x.User_ID,
        //            Email = x.Email,

        //            Full_Name = x.Full_Name,

        //        }).FirstOrDefault();
        //    return View(result);
        //}

        //public IActionResult EndExam(Reports reports)      //to end exam
        //{
        //    var id = Convert.ToInt32(TempData["score"]);
        //    var level = Convert.ToInt32(TempData["level"]);
        //    TempData["score"] = id;
        //    TempData.Keep();
        //    var c = Convert.ToInt32(TempData["score"]);
        //    var u = (TempData["uid"]).ToString();
        //    var e = (TempData["examid"]).ToString();

        //    reports.Students.User_ID = u;
        //    reports.Exam_ID = e;
        //    //if (id >= p)
        //    //{
        //    //    reports.result_status = "pass";
        //    //}
        //    //else
        //    //{
        //    //    report.result_status = "fail";
        //    //}
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Reports.Add(reports);
        //            db.SaveChanges();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Notification = ex;
        //        return View();
        //        //return View();
        //    }
        //    return View()
        //}


        //public IActionResult getdetails()   //code to get all questions from db
        //{
        //    var res = db.Reports;
        //    return View(res);
        //}
        //sample just to get details from db of students

        //public List<Students> GetAllDetails()
        //{

        //    var result = db.Students.
        //        Select(x => new Students()
        //        {
        //            User_ID = x.User_ID,
        //            Email = x.Email,
        //            Password = x.Password,
        //            Full_Name = x.Full_Name,

        //        }).ToList();
        //    return result;
        //}

        //demoo

        
    }
}

