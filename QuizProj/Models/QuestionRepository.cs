using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizLibrary
{
    public class QuestionRepository
    {
        private static List<Question> _questionList = new List<Question>();
        private static int nextId = 0;

        public List<Question> GetQuestion()
        {
            return _questionList;
        }

        public Question GetQuestionById(int id)
        {
            return _questionList.Find(question => question.QuestionId == id);
        }

        public void AddQuestion(Question newQuestion)
        {
            newQuestion.QuestionId = nextId++;
            _questionList.Add(newQuestion);
        }

        public void UpdateQuestion(Question editQuestion)
        {
            _questionList.RemoveAll(question => question.QuestionId == editQuestion.QuestionId);
            _questionList.Add(editQuestion);
        }

        public void DeleteQuestion(int id)
        {
            _questionList.RemoveAll(question => question.QuestionId == id);
        }


    }
}