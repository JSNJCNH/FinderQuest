using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinderQuest
{
    public abstract class Areas
    {
        private Image background;
        private string name;

        public Areas(string name, Image background)
        {
            this.Background = background;
            this.Name = name;
        }

        public Image Background { get => background; set => background = value; }
        public string Name
        {
            get => name;
            set
            {
                if (value != "")
                {
                    name = value;
                }
                else
                {
                    throw new Exception("Level name can't be empty.");
                }
            }
        }

        public virtual string DisplayData()
        {
            return this.Name;
        }

        public void DisplayPicture(Control container)
        {
            container.BackgroundImage = this.Background;
        }
    }
}