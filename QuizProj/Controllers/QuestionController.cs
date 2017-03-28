using QuizProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizLibrary;

namespace QuizProj.Controllers
{
    [RequireHttps]
    public class QuestionController : Controller
    {

        private static IQuizRepository _questionRepo;

        public QuestionController()
        {
            if(_questionRepo == null)
            {
                _questionRepo = new QuizRepositoryEf();
            }
        }

        public QuestionController(IQuizRepository repo)
        {
            _questionRepo = repo;
        }

        // GET: Question
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(_questionRepo.GetQuestions());
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            return View(_questionRepo.GetQuestionById(id));
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(Question newQuestion, FormCollection collection)
        {
            try
            {
                _questionRepo.AddQuestion(newQuestion);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_questionRepo.GetQuestionById(id));
        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Question editQuestion, FormCollection collection)
        {
            try
            {
                _questionRepo.UpdateQuestion(editQuestion);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_questionRepo.GetQuestionById(id));
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _questionRepo.DeleteQuestion(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
