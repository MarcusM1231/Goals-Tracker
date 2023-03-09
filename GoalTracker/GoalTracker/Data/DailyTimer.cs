using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GoalTracker.Data
{
    public class DailyTimer
    {
        static DateTime currentTime;
        static DateTime resetTime;

        static TimeSpan timeUntilReset;

        public DailyTimer()
        {
            currentTime = DateTime.Now;
            resetTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 8, 0, 0);

            timeUntilReset = resetTime - currentTime;

            if (timeUntilReset < TimeSpan.Zero)
            {
                timeUntilReset = timeUntilReset.Add(TimeSpan.FromDays(1));
            }

            Timer timer = new Timer();
            timer.Interval = timeUntilReset.TotalMilliseconds;
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Start();  

        }


        static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            // Removes Daily quest from list of current quests
            foreach (var dailyQuest in GoalLists.activeGoals)
            {
                if (dailyQuest.GetGoalType() == "Daily")
                {
                    GoalLists.activeGoals.Remove(dailyQuest);
                }
            }

            // Re adds all of your daily quests to current quests 
            foreach(var dailyQuest in GoalLists.dailyGoals)
            {
                GoalLists.activeGoals.Add(dailyQuest);
            }
            
        }

    }
}
