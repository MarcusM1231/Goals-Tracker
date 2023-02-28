using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalTracker.Data
{
    public abstract class Quests
    {
        public string questName;
        public string questDesc;
        public bool questCompleted = false;
        public int timeLimit;
        public string questType;

        protected Quests()
        {
            questCompleted = false;
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
        }

    }

    public class SpecialQuests : Quests
    {
        public SpecialQuests(string questName, string questDesc, string questType)
        {
            this.questName = questName;
            this.questDesc = questDesc;
            this.questType = questType;
        }

    }
}
