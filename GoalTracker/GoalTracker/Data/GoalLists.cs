using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalTracker.Data
{
    public static class GoalLists
    {
        public static List<Goals> activeGoals = new List<Goals>();
        public static List<Goals> completedGoals = new List<Goals>();

        
        public static List<Goals> dailyGoals  = new List<Goals>();
        public static List<Goals> weeklyGoals = new List<Goals>();
    }

}
