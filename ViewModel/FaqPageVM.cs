using System;
using System.Collections.Generic;
using System.Text;
using DataServices.Services;
using DataServices;
using Model;

namespace ViewModel
{
    public class FaqPageVM
    {
		IFaqService FaqService;
		private List<FAQ> FAQs;
		private List<String> Questions;
		public FaqPageVM(IFaqService FaqService)
		{
			this.FaqService = FaqService;
		}
        /// <summary>
        /// Gets all questions with answers synchronously and saves them into inner list
        /// </summary>
		public void GetFAQ()
		{
			if(FAQs == null)
			{
				FAQs = (List<FAQ>)FaqService.LoadAllFaqAsync().Result;
			}
		}
        /// <summary>
        /// Get all questions from inner list and transform them into strings
        /// </summary>
        /// <returns>List of faq elements as strings</returns>
		public List<String> GetQuestions()
		{
			if(Questions == null)
			{
				GetFAQ();
				Questions = FAQs.ConvertAll<String>(x => x.Question);
			}
			return Questions;
		}
        /// <summary>
        /// Gets answer for question
        /// </summary>
        /// <param name="Question">Text of question to get answers on</param>
        /// <returns>Answer for question as string</returns>
		public String GetAnswer(String Question)
		{
			GetFAQ();
			return FAQs.Find(x => x.Question.Equals(Question)).Answer;		
		}
	}
}
