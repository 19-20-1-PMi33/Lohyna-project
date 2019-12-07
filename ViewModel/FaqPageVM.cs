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
				GetFAQ();
				Questions = FAQs.ConvertAll<String>(x => x.Question);
			}
			return Questions;
		}
		public String GetAnswer(String Question)
		{
			GetFAQ();
			return FAQs.Find(x => x.Question.Equals(Question)).Answer;		
		}
	}
}
