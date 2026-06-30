using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinderQuest
{
    public class Questions
    {
        private string answer;
        private string question;
        private int score;

        public Questions(string question, string answer, int score)
        {
            this.Answer = answer;
            this.Question = question;
            this.Score = score;
        }

        public string Answer
        {
            get => answer;
            set
            {
                if(value != "")
                {
                    answer = value;
                }
                else
                {
                    throw new Exception("Answer can't be empty.");
                }
            }
        }
        public string Question
        {
            get => question;
            set
            {
                if (value != "")
                {
                    question = value;
                }
                else
                {
                    throw new Exception("Question can't be empty.");
                }
            }
        }
        public int Score
        {
            get => score;
            set
            {
                if (value >= 0)
                {
                    score = value;
                }
                else
                    score = 0;
            }
        }
    }
}