using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace QuizLibrary
{
    public class QuizRepositoryEf : IQuizRepository
    {
        private static Random _randy = new Random();

        public void AddQuestion(Question newQuestion)
        {
            using (var db = new QuizModel())
            {
                db.Questions.Add(newQuestion);
                db.SaveChanges();
            }
        }

            public void DeleteQuestion(int id)
        {
            using (var db = new QuizModel())
            {
                var question = db.Questions.Find(id);
                db.Questions.Remove(question);
                db.SaveChanges();
            }
        }

        public Question GetQuestionById(int id)
        {
            using (var db = new QuizModel())
            {
                var question = db.Questions.Find(id);
                db.Entry(question).Collection(q => q.Answers).Load();
                return question;
            }
        }

        public List<Question> GetQuestions()
        {
            using (var db = new QuizModel())
            {
                var questions = from q in db.Questions
                                orderby q.QuestionId descending
                                select q;

                return questions.ToList();
            }
        }

        public List<Question> GetQuestions(int maxNumberOfQuetsions)
        {
            using (var db = new QuizModel())
            {
                return db.Questions.Take(maxNumberOfQuetsions).ToList();
            }
        }

        public void UpdateQuestion(Question updateQuestion)
        {
            using (var db = new QuizModel())
            {
                db.Questions.Attach(updateQuestion);
                var entry = db.Entry(updateQuestion);
                entry.State = System.Data.Entity.EntityState.Modified;
                foreach (var answer in updateQuestion.Answers)
                {
                    var answerEntry = db.Entry(answer);
                    answerEntry.State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
        }

        QuestionViewModel IQuizRepository.GetQuestion()
        {
            using (var db = new QuizModel())
            {
                var questions = db.Questions.Include(question => question.Answers).ToList();
                return new QuestionViewModel(questions[_randy.Next(0,questions.Count)]);
            }
        }
    }
}