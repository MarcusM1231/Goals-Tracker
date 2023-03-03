using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalTracker.Data
{
    internal class User
    {
        string firstName;
        string lastName;
        public int totalPoints;

        public int TotalPoints()
        {
            

            foreach (Quests quest in QuestLists.quests)
            {
                totalPoints += quest.points;
            }

            return totalPoints;
        }
    }
}
