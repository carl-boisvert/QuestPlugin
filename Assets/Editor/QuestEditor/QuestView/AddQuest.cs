using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class AddQuest : QuestView
{
    
    protected override string actionButtonText
    {
        get
        {
            return "Create Quests";
        }
    }

    protected override string windowTitle
    {
        get
        {
            return "New Quests";
        }
    }

    protected override string objectiveButtonText
    {
        get
        {
            return "Add objective";
        }
    }

    protected override void OnClick()
    {
        quest.QuestName = questName;
        quests.AddQuest(quest);
        QuestFileManager.SaveFile(quests);
        this.Close();
    }

    protected override void OnObjectiveClick(Objective obj)
    {
        AddObjective addObjective = (AddObjective)EditorWindow.GetWindow(typeof(AddObjective));
        addObjective.setQuest(quest);
        addObjective.Show();
    }
}