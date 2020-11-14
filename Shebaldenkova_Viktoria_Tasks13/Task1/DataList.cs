using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    static class DataList
    {
        

        public static BindingList<Reward> rewards = new BindingList<Reward>
        {
            new Reward(0,"Букеровская премия", "За лучший оригинальный роман, написанный в английском языке"),
            new Reward(1,"Нобелевская премия", "За выдающиеся научные исследования, революционные изобретения или крупный вклад в культуру или развитие общества.")

        };
        
        public static BindingList<User> users = new BindingList<User> 
        {
            new User(0, "Иван", "Иванов", new DateTime(2000, 11, 11), new List<Reward>(){ DataList.rewards[1] }),
            new User(1, "Елена", "Соловьева", new DateTime(2000, 9, 9)),
            new User(2, "Михаил", "Звонарев", new DateTime(2000, 8, 8))
        };

    }
}
