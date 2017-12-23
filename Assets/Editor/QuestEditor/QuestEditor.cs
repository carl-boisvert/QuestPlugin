using UnityEngine;
using UnityEditor;
using System.Collections;

[InitializeOnLoad]
public class QuestEditor : EditorWindow
{

    private QuestTree quests = new QuestTree();
    
    [MenuItem("Window/Quest editor")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(QuestEditor));
    }

    public void OnGUI () {
        if(quests.GetQuests().Count == 0){
            quests = QuestFileManager.LoadFile();
        }

        if (GUILayout.Button("Add quest", GUILayout.MaxWidth(100)))
        {
            AddQuest addQuestEditor = (AddQuest)EditorWindow.GetWindow(typeof(AddQuest));
            addQuestEditor.setQuestTree(quests);
            addQuestEditor.Show();

        }
        if (GUILayout.Button("Reset quest", GUILayout.MaxWidth(100)))
        {
            foreach(Quest quest in quests.GetQuests()){
                QuestFileManager.DeleteQuest(quest);
            }
            quests.Empty();
        }
        
        EditorGUILayout.BeginScrollView(new Vector2(0,0), true, true);
        if(quests.GetQuests().Count != 0){
            int i = 1;
            foreach (Quest quest in quests.GetQuests())
            {
                if (GUI.Button(new Rect(i * 42, i * 42, 10*quest.QuestName.Length, 40), quest.QuestName))
                {
                    if (Event.current.button == 0) {
                        EditQuest editQuest = (EditQuest)EditorWindow.GetWindow(typeof(EditQuest));
                        editQuest.setQuestTree(quests);
                        editQuest.setQuest(quest);
                        editQuest.Show();
                    }
                }
                i++;
                /*if (GUILayout.Button(quest.QuestName, GUILayout.MaxWidth(100)))
                {
                    
                }*/
            }
        }
        EditorGUILayout.EndScrollView();
    }
}