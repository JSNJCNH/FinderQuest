using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinderQuest
{
    public class WalkAreas : Areas
    {
        private int noArea;
        private List<People> listPeople;

        #region Constructor
        public WalkAreas(string name, Image background, int noArea) : base(name, background) 
        {
            this.NoArea = noArea;
            this.ListPeople = new List<People>();
        }
        #endregion

        #region Properties
        public int NoArea { get => noArea; set => noArea = value; }
        public List<People> ListPeople { get => listPeople; set => listPeople = value; }
        #endregion

        #region Methods
        public override string DisplayData()
        {
            return "No. Area : " + this.noArea + " - " +base.DisplayData();
        }

        public void AddPerson(int no, string name, Image image, Size size, Point location, string dialog)
        {
            People person = new People(no, name, image, size, location, dialog);
            this.ListPeople.Add(person);
        }

        public void DisplayPeople(Control container)
        {
            foreach(People person in this.ListPeople)
            {
                person.DisplayPicture(container);
            }
        }

        public void RemoveAllPeople()
        {
            foreach(People person in this.ListPeople)
            {
                person.Picture.Dispose();
            }
            this.ListPeople.Clear();
        }

        public bool CheckTouchPerson(Players player, out People touchPerson)
        {
            foreach(People person in this.ListPeople)
            {
                if (player.Picture.Bounds.IntersectsWith(person.Picture.Bounds))
                {
                    touchPerson = person;
                    return true;
                }
            }
            touchPerson = null;
            return false;
        }

        public bool CheckFinishAllQuestions()
        {
            int numSolved = 0;
            foreach(People person in this.ListPeople)
            {
                if(person.SolvedStatus == true)
                {
                    numSolved++;
                }
            }

            if(numSolved == this.ListPeople.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}