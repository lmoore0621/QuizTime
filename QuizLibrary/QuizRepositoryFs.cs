using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLibrary
{
    class QuizRepositoryFs : IQuizRepository
    {
        public void AddQuestion(Question newQuestion)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestion()
        {
            throw new NotImplementedException();
        }

        public Question GetQuestionById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetQuestions()
        {
            throw new NotImplementedException();
        }

        public List<Question> GetQuestions(int maxNumberOfQuetsions)
        {
            throw new NotImplementedException();
        }

        public void UpdateQuestion(Question updateQuestion)
        {
            throw new NotImplementedException();
        }

        QuestionViewModel IQuizRepository.GetQuestion()
        {
            throw new NotImplementedException();
        }
    }
}
