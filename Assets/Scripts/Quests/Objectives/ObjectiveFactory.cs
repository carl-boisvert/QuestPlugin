using UnityEngine;
using System.Collections;

public class ObjectiveFactory
{
    public static Objective create(string type)
    {
        switch(type){
            case "GetItem":
                return new GetItemObjective();
            case "Kill":
                return new KillObjective();
            case "TalkTo":
                return new TalkToObjective();
            default:
                Debug.LogException(new System.ArgumentException("Can't create "+type+" type of objective"));
                return null;
        }
    }
}
