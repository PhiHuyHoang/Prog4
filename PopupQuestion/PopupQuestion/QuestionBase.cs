using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopupQuestion
{
    class QuestionBase : Binable
    {
        private string question;
        private string correctAnswer;
        private List<string> answers;
        public string Question { get => question; set => SetField(ref question, value); }
        public string CorrectAnswer { get => correctAnswer; set => SetField(ref correctAnswer, value); }
        public List<string> Answers { get => answers; set => SetField(ref answers, value); }
    }
}
