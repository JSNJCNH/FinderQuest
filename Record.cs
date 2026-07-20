using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeApplication;

namespace FinderQuest
{
    [Serializable]
    public class Record
    {
        private string name;
        private int score;
        private Time time;

        public Record(string name, int score, Time time)
        {
            this.Name = name;
            this.Score = score;
            this.Time = time;
        }

        public string Name
        {
            get => name;
            set
            {
                if (value != "")
                    name = value;
                else
                {
                    throw new Exception("Name can't be empty.");
                }
            }

        }

        public int Score { get => score; set => score = value; }
        public Time Time { get => time; set => time = value; }

        public string DisplayData()
        {
            Time time = new Time(0, 0, 0);
            time.AddWithSecond(this.Time.ConvertToSecond());

            return $"{this.Name}\t\t\t{time.DisplayData()}"; 
        }
    }
}