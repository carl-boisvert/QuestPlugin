using UnityEngine;
using UnityEditor;

public class AddObjective : ObjectiveView
{

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
            return "Add objective";
        }
    }

    public void setQuest(Quest quest){
        this.quest = quest;
    }

    protected override void OnClick()
    {
        this.createObjective();
        this.Close();
    }
   
}
