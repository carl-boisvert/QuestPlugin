using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class QuestView : EditorWindow
{

    protected QuestTree quests = new QuestTree();
    protected Quest quest = new Quest();


    protected string questName;
    protected List<Objective> objectives;
    protected List<Quest> mustBeDone = new List<Quest>();
    protected int selected = 0;
    protected List<string> questsOptions = new List<string>();

    public void OnGUI()
    {
        EditorGUILayout.LabelField(windowTitle, EditorStyles.boldLabel);
        selected = EditorGUILayout.Popup("Parent Quest", selected, questsOptions.ToArray());
        questName = EditorGUILayout.TextField("Name", questName);
        if (GUILayout.Button(objectiveButtonText))
        {
            OnObjectiveClick(new GetItemObjective());
        }
        EditorGUILayout.Separator();
        foreach (Objective obj in quest.getObjectives())
        {
            if (GUILayout.Button(obj.getObjectiveName(), GUILayout.MaxWidth(100)))
            {
                OnObjectiveClick(obj);
            }
        }
        EditorGUILayout.Separator();
        foreach (Quest quest in mustBeDone)
        {
            if (GUILayout.Button(quest.QuestName, GUILayout.MaxWidth(100)))
            {
                //OnObjectiveClick(quest);
            }
        }
        if (GUILayout.Button(actionButtonText))
        {
            OnClick();
        }
    }

    public void setQuestTree(QuestTree questTree)
    {
        quests = questTree;
        questsOptions.Add("None");
        foreach (Quest quest in quests.GetQuests()) {
            Debug.Log(quest.QuestName);
            questsOptions.Add(quest.QuestName);
        }
    }

    protected abstract string actionButtonText
    {
        get;
    }

    protected abstract string objectiveButtonText
    {
        get;
    }
    
    protected abstract string windowTitle
    {
        get;
    }

    protected abstract void OnClick();
    protected abstract void OnObjectiveClick(Objective obj);
}
