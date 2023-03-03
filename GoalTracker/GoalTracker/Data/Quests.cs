using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalTracker.Data
{

    //public class Quests
    //{
    //    public string questName;
    //    public string questDesc;
    //    public bool questCompleted = false;
    //    public int timeLimit;
    //    public string questType;
    //    public int points;
    //    public int totalPoints;

    //    public Quests(string questName, string questDesc, string questType)
    //    {
    //        this.questName = questName;
    //        this.questDesc = questDesc;
    //        this.questType = questType;
    //        questCompleted = false;
    //        totalPoints = 0;
    //    }


    //}

    public abstract class Quests
    {
        public string questName;
        public string questDesc;
        public bool questCompleted = false;
        public int timeLimit;
        public string questType;
        public int points;
        public int totalPoints;

        protected Quests()
        {
            questCompleted = false;
            //totalPoints = 0;
        }


    }

    public class DailyQuests : Quests
    {
        public DailyQuests(string questName, string questDesc, string questType)
        {
            this.questName = questName;
            this.questDesc = questDesc;
            this.timeLimit = 24;
            this.questType = questType;
            points = 5;


        }
    }

    public class EventQuests : Quests
    {
        public EventQuests(string questName, string questDesc, string questType)
        {
            this.questName = questName;
            this.questDesc = questDesc;
            this.timeLimit = 168;
            this.questType = questType;
            points = 10;
        }

    }

    public class SpecialQuests : Quests
    {
        public SpecialQuests(string questName, string questDesc, string questType)
        {
            this.questName = questName;
            this.questDesc = questDesc;
            this.questType = questType;
            points = 50;
        }

    }
}
