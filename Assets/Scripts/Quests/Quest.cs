using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;


[System.Serializable]
public class Quest{

    [SerializeField]
    private List<Objective> objectives = new List<Objective>();
    [SerializeField]
    private string questName;
    [SerializeField]
    private List<Quest> mustBeDone = new List<Quest>();

    public string QuestName
    {
        get
        {
            return questName;
        }

        set
        {
            questName = value;
        }
    }

    public void addDependency(Quest quest){
        mustBeDone.Add(quest);
    }

    public void addObjective(Objective obj){
        objectives.Add(obj);
    }

    public void updateObjective(Objective oldObj, Objective newObj){
        foreach(Objective obj in objectives){
            Debug.Log(obj.getObjectiveName());
        }
        int index = objectives.FindIndex(objective => objective.getObjectiveName() == oldObj.getObjectiveName());
        if (index != -1)
        {
            objectives[index] = newObj;
        }
        else
        {
            Debug.LogException(new System.ArgumentException("Can't find Objective: " + oldObj.getObjectiveName()));
        }
    }

    public List<Objective> getObjectives(){
        return objectives;
    }

    public JSONObject toJson(){
        JSONObject jsonObject = new JSONObject();
        jsonObject.Add("QuestName", questName);
        JSONArray jsonObjectives = new JSONArray();
        foreach(Objective obj in objectives){
            jsonObjectives.Add(obj.toJson());
        }
        jsonObject.Add("Objectives", jsonObjectives);
        return jsonObject;
    }

    public Quest fromJson(JSONNode data){
        JSONNode questData = data["Quest"].AsObject;
        questName = questData["QuestName"];
        foreach(JSONNode objectiveType in questData["Objectives"]){
            Objective obj = ObjectiveFactory.create(objectiveType["Type"]);
            obj.fromJson(objectiveType);
            objectives.Add(obj);
        }
        return this;
    }
}
