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
    protected int selected = 0;
    protected string[] options = Objective.objectiveTypes;

    public void OnGUI()
    {
        EditorGUILayout.LabelField(windowTitle, EditorStyles.boldLabel);
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
        if (GUILayout.Button(actionButtonText))
        {
            OnClick();
        }
    }

    public void setQuestTree(QuestTree questTree)
    {
        quests = questTree;
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
