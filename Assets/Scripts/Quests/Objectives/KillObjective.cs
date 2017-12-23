using UnityEngine;
using System.Collections;
using SimpleJSON;

public class KillObjective : Objective
{
    [SerializeField]
    private int howMany;
    [SerializeField]
    private GameObject target;



    public void setHowMany(int number) {
        howMany = number;
    }

    public int getHowMany(){
        return howMany;
    }

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
        jobject.Add("Name", objectiveName);
        jobject.Add("HowMany", howMany);
        jobject.Add("Target", target.gameObject.name);
        return jobject;
    }

    public override void fromJson(JSONNode data)
    {
        type = data["Type"];
        howMany = data["HowMany"];
        objectiveName = data["Name"];
        target = GameObject.Find(data["Target"]).gameObject;
    }
}
