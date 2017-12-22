using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsGiver : MonoBehaviour {

    List<Quest> quests;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addQuest(Quest quest)
    {
        quests.Add(quest);
    }
}
