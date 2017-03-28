using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLibrary
{
	public class QuestionViewModel
	{
		public QuestionViewModel()
		{
			Answers = new List<AnswerViewModel>();
		}

		public QuestionViewModel(Question question)
		{

			Answers = new List<AnswerViewModel>();

			QuestionId = question.QuestionId;
			Category = question.Category;
			Content = question.Content;
			QuestionType = question.QuestionType;

			foreach (var answer in question.Answers)
			{
				Answers.Add(new AnswerViewModel(answer));
			}
		}

		public int QuestionId { get; set; }
		public string Category { get; set; }
		public string Content { get; set; }
		public string QuestionType { get; set; }

		public List<AnswerViewModel> Answers { get; set; }
	}
}
