using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class EditQuest : QuestView
{
    protected override string actionButtonText
    {
        get
        {
            return "Edit Quests";
        }
    }

    protected override string windowTitle
    {
        get
        {
            return "Edit Quests";
        }
    }

    protected override string objectiveButtonText
    {
        get
        {
            return "Edit objectives";
        }
    }

    public void setQuest(Quest quest){
        this.quest = quest;
        questName = this.quest.QuestName;
    }

    protected override void OnClick()
    {
        Quest newQuest = new Quest();
        newQuest.QuestName = questName;
        foreach(Objective obj in quest.getObjectives()){
            newQuest.addObjective(obj);
        }

        quests.UpdateQuest(quest, newQuest);
        QuestFileManager.SaveFile(quests);
        this.Close();
    }

    protected override void OnObjectiveClick(Objective obj)
    {
        EditObjective editObjective = (EditObjective)EditorWindow.GetWindow(typeof(EditObjective));
        editObjective.setObjective(obj);
        editObjective.setQuest(quest);
        editObjective.Show();
    }
}