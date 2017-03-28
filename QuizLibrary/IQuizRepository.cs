using System.Collections.Generic;

namespace QuizLibrary
{
    public interface IQuizRepository
    {
        void AddQuestion(Question newQuestion);
        void DeleteQuestion(int id);
        QuestionViewModel GetQuestion();
        Question GetQuestionById(int id);
        List<Question> GetQuestions();
        List<Question> GetQuestions(int maxNumberOfQuetsions);
        void UpdateQuestion(Question updateQuestion);
    }
}