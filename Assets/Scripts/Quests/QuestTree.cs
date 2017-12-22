using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTree {

    private List<Quest> quests = new List<Quest>();

    public void AddQuest(Quest quest)
    {
        quests.Add(quest);
    }

    public List<Quest> GetQuests(){
        return quests;
    }

    public void Empty(){
        quests.Clear();
    }


    public void UpdateQuest(Quest oldQuest, Quest newQuest){
        int index = quests.FindIndex(quest => quest.QuestName == oldQuest.QuestName);
        if(index != -1){
            quests[index] = newQuest;
            QuestFileManager.DeleteQuest(oldQuest);
        } else{
            Debug.LogException(new System.ArgumentException("Can't find quest: " + oldQuest.QuestName));
        }
    }
}
