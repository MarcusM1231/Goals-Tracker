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
            

            foreach (Goals quest in GoalLists.activeGoals)
            {
                totalPoints += quest.points;
            }

            return totalPoints;
        }
    }
}
