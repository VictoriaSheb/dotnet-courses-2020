using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Reward 
    {

        public int Id { get; }
        public string Title { set; get; }
        public string Description { set; get; }

        public Reward(int id, string title, string description) 
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
        }

    }
}
