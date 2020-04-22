using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Repositories.Faqs
{
    /// <summary>
    /// Service to obtain FAQ data.
    /// </summary>
    public interface IFaqRepository
    {
        /// <summary>
        /// Load all the available questions.
        /// </summary>
        /// <returns>List of available questions.</returns>
        Task<List<string>> LoadQuestionsAsync();

        /// <summary>
        /// Load all the data for FAQ.
        /// </summary>
        /// <returns>List of questions and related answers.</returns>
        Task<List<FAQ>> LoadAllFaqAsync();

        /// <summary>
        /// Load answer to given question.
        /// </summary>
        /// <param name="question">Question to be answered.</param>
        /// <returns>Answer to given question.</returns>
        string LoadAnswerForQuestionAsync(string question);
    }
}