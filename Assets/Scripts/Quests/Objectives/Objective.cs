using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

[System.Serializable]
public abstract class Objective{

    public static string[] objectiveTypes = { "GetItem", "Kill", "TalkTo" };

    [SerializeField]
    protected string objectiveName;
    protected string type;

    public string getObjectiveName(){
        return objectiveName;
    }

    public void setObjectiveName(string objName)
    {
        objectiveName = objName;
    }

    public void setObjectiveType(string type){
        this.type = type;
    }

    public string getObjectiveType()
    {
        return type;
    }

    public abstract JSONObject toJson();
    public abstract void fromJson(JSONNode data);
}
