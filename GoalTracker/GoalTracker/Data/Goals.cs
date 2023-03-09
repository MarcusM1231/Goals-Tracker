using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalTracker.Data
{

    public abstract class Goals
    {
        public readonly string goalName;
        public string goalDesc;
        public int timeLimit;
        public string goalType;
        public int points;
        public int totalPoints;


        public string GetGoalName()
        {
            return goalName;
        }

        public string GetGoalDesc()
        {
            return goalDesc;
        }

        public int GetGoalPoints()
        {
            return points;
        }

        public string GetGoalType()
        {
            return goalType;
        }
    }

    public class DailyGoals : Goals
    {
        public DailyGoals(string goalName, string goalDesc, string goalType)
        {
            this.goalName = goalName;
            this.goalDesc = goalDesc;
            this.timeLimit = 24;
            this.goalType = goalType;
            points = 5;
        }
    }

    public class WeeklyGoals : Goals
    {
        public WeeklyGoals(string goalName, string goalDesc, string goalType)
        {
            this.goalName = goalName;
            this.goalDesc = goalDesc;
            this.timeLimit = 168;
            this.goalType = goalType;
            points = 10;
        }

    }

    public class LongtermGoals : Goals
    {
        public LongtermGoals(string goalName, string goalDesc, string goalType)
        {
            this.goalName = goalName;
            this.goalDesc = goalDesc;
            this.goalType = goalType;
            points = 50;
        }

    }
}
