using QuizLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;

namespace QuizProj.Controllers
{
    public class QuestionApiController : ApiController
    {
        private static IQuizRepository _quizRepo;

        public QuestionApiController()
        {
            if (_quizRepo == null)
            {
                _quizRepo = new QuizRepositoryEf();
            }
        }

        public QuestionApiController(IQuizRepository newRepo)
        {
            _quizRepo = newRepo;
        }

        // GET: api/QuestionApi
        public QuestionViewModel Get()
        {
            return _quizRepo.GetQuestion();
        }


        [Route("api/QuestionApi/CorrectAnswer")]
        [HttpGet]
        public AnswerResults CorrectAnswer(int questionId, int answerId)
        {
            var question = _quizRepo.GetQuestionById(questionId);
            AnswerResults results = new AnswerResults();
            var selectedAnswer = question.Answers.First(a => a.AnswerId == answerId);

            if (selectedAnswer != null)
            {
                results.IsCorrect = selectedAnswer.IsCorrect;
            }

            return results;
        }

        // GET: api/QuestionApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/QuestionApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/QuestionApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/QuestionApi/5
        public void Delete(int id)
        {
        }
    }
}
