using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

public class GetItemObjective : Objective {

    [SerializeField]
    Item item;

    public void setItem(Item item){
        this.item = item;
    }

    public Item getItem(){
        return item;
    }

    public override JSONObject toJson()
    {
        JSONObject jobject = new JSONObject();
        jobject.Add("Type", type);
        jobject.Add("Item", item.gameObject.name);
        return jobject;
    }

    public override void fromJson(JSONNode data)
    {
        throw new System.NotImplementedException();
    }
}
