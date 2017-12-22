using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

public class TalkToObjective : Objective
{
    [SerializeField]
    GameObject target;

    public void setTarget(GameObject gameobject){
        target = gameobject;
    }

    public GameObject getTarget(){
        return target;
    }

    public override JSONObject toJson()
    {
        JSONObject jobject = new JSONObject();
        jobject.Add("Type", type);
        jobject.Add("Target", target.gameObject.name);
        jobject.Add("Name", objectiveName);
        return jobject;
    }

    public override void fromJson(JSONNode data)
    {
        type = data["Type"];
        target = GameObject.Find(data["Target"]).gameObject;
        objectiveName = data["Name"];
    }
}
