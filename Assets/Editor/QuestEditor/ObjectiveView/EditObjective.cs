using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class EditObjective : ObjectiveView
{
    private Objective obj;

    protected override string actionButton
    {
        get
        {
            return "Add objective";
        }
    }

    protected override string windowTitle
    {
        get
        {
            return "Edit objective";
        }
    }

    public void setQuest(Quest quest)
    {
        this.quest = quest;
    }

    public void setObjective(Objective obj){
        this.obj = obj;
        selected = (ArrayUtility.IndexOf(options, obj.getObjectiveType()) != -1)? ArrayUtility.IndexOf(options, obj.getObjectiveType()) : 0;
        objectiveName = obj.getObjectiveName();
        castObjective(obj);
    }

    protected override void OnClick()
    {
        Objective newObj = this.createObjective(true);
        quest.updateObjective(obj, newObj);
        this.Close();
    }
}
