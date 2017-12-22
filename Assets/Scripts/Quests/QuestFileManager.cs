using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class QuestFileManager {

    private static string filename = "Quests";

    public static void SaveFile(QuestTree data)
    {
        List<Quest> quests = data.GetQuests();
        if(!Directory.Exists(Application.dataPath + "/Quests/")){
            Directory.CreateDirectory(Application.dataPath + "/Quests/");
        }
        foreach(Quest quest in quests){
            string path = Application.dataPath+ "/Quests/" + filename + "_" + quest.QuestName + ".json";
            File.Delete(path);
            StreamWriter writer = new StreamWriter(File.OpenWrite(path), System.Text.Encoding.UTF8);
            Debug.Log(QuestFileManager.serializeQuest(quest));
            writer.Write(QuestFileManager.serializeQuest(quest));
            writer.Close();
        }
    }

    public static QuestTree LoadFile(){
        QuestTree tree = new QuestTree();
        string[] files = Directory.GetFiles(Application.dataPath + "/Quests/", "*.json");

        foreach (string filepath in files){
            StreamReader reader = new StreamReader(filepath, System.Text.Encoding.UTF8);
            string json = reader.ReadToEnd();

            Quest quest = new Quest();
            quest.fromJson(JSON.Parse(json));
            tree.AddQuest(quest);
            reader.Close();
        }
        return tree;
    }

    public static void DeleteQuest(Quest quest){
        string path = Application.dataPath + "/Quests/" + filename + "_" + quest.QuestName + ".json";
        if (File.Exists(path)){
            File.Delete(path);
        } else{
            
        }
    }

    public static string serializeQuest(Quest quest){
        JSONObject rootNode = new JSONObject();
        rootNode.Add("Quest", quest.toJson());
        return rootNode.ToString();
    }
}
