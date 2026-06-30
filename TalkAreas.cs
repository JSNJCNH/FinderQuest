using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FinderQuest
{
    public class TalkAreas : Areas
    {
        private People person;

        public TalkAreas(string name, Image background, People person) : base(name, background)
        {
            this.person = person;
        }

        public People Person { get => person; set => person = value; }

        public override string DisplayData()
        {
            return this.Person.Name +"'s Talk Area - " +base.DisplayData();
        }
    }
}