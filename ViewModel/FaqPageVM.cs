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
		public void GetFAQ()
		{
			if(FAQs == null)
			{
				FAQs = (List<FAQ>)FaqService.LoadAllFaqAsync().Result;
			}
		}
		public List<String> GetQuestions()
		{
			if(Questions == null)
			{
				Questions = (List<String>)FaqService.LoadQuestionsAsync().Result;
			}
			return Questions;
		}
		public String GetAnswer(String Question)
		{
			return (String)FaqService.LoadAnswerForQuestionAsync(Question);
		}
    }
}
