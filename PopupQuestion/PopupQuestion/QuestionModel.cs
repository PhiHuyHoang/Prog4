using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PopupQuestion
{
    class QuestionModel
    {
        static Random R = new Random();

        public List<QuestionBase> listOfQuestion { get; private set; }

        public QuestionBase currentQuestion { get; private set; }

        public RelayCommand getAnswer { get; private set; }
        public QuestionModel()
        {          
            listOfQuestion = new List<QuestionBase>();
            AddQuestion(listOfQuestion);
            currentQuestion = listOfQuestion.ElementAt(0);
            getAnswer = new RelayCommand((obj) => { CheckAnswer(currentQuestion, obj.ToString()); });
        }
        void CheckAnswer(QuestionBase question, string userAnswer)
        {
            if(userAnswer == question.CorrectAnswer)
            {
                MessageBox.Show("Yay");
                currentQuestion = listOfQuestion.ElementAt(listOfQuestion.IndexOf(question) + 1);
            }
            else
            {
                MessageBox.Show("No");
            }
        }
        void AddQuestion(List<QuestionBase> listOfQuestion)
        {
            dynamic jsonObject = JsonObject("https://opentdb.com/api.php?amount=3&category=9&difficulty=easy&type=multiple");
            foreach (var item in jsonObject.results)
            {
                QuestionBase quest = new QuestionBase() { Question = item.question, CorrectAnswer = item.correct_answer };
                quest.Question = WebUtility.HtmlDecode(quest.Question);
                quest.CorrectAnswer = WebUtility.HtmlDecode(quest.CorrectAnswer);
                List<String> tempAnswerList = new List<string>();
                foreach (var ans in item.incorrect_answers)
                {
                    string ans_temp = ans;
                    tempAnswerList.Add(WebUtility.HtmlDecode(ans_temp));
                }
                quest.Answers = new List<string>();
                List<string> shuffled_list = tempAnswerList.OrderBy(i => R.Next()).ToList();
                foreach (var ans in shuffled_list)
                {
                    quest.Answers.Add(ans);
                }
                quest.Answers.Add(quest.CorrectAnswer);
                listOfQuestion.Add(quest);
            }
        }

        object JsonObject(string url)
        {
            WebClient webClient = new WebClient();
            string json = webClient.DownloadString(url).ToString();
            byte[] bytes = Encoding.Default.GetBytes(json);
            json = Encoding.UTF8.GetString(bytes);
            dynamic jsonObject = JsonConvert.DeserializeObject(json);
            return jsonObject;
        }

    }
}
