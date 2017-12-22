using UnityEngine;
using UnityEditor;

public abstract class ObjectiveView : EditorWindow
{
    protected string objectiveName;
    protected string[] options = Objective.objectiveTypes;
    protected int selected = 0;
    protected Item item;
    protected GameObject target;
    protected Quest quest = new Quest();
    protected int howMany;

    public void OnGUI()
    {
        EditorGUILayout.LabelField(windowTitle, EditorStyles.boldLabel);
        objectiveName = EditorGUILayout.TextField("Name", objectiveName);
        selected = EditorGUILayout.Popup("Type", selected, options);
        EditorGUILayout.Separator();
        switch (options[selected])
        {
            case "GetItem":
                item = (Item)EditorGUILayout.ObjectField("Find Item", item, typeof(Item), true);
                break;
            case "Kill":
                howMany = EditorGUILayout.IntField(howMany);
                target = (GameObject)EditorGUILayout.ObjectField("Find Target", target, typeof(GameObject), true);
                break;
            case "TalkTo":
                target = (GameObject)EditorGUILayout.ObjectField("Find Target", target, typeof(GameObject), true);
                break;
            default:
                break;
        }
        EditorGUILayout.Separator();
        if (GUILayout.Button(actionButton))
        {
            OnClick();
        }
    }

    protected Objective createObjective(bool modify = false){
        switch (options[selected])
        {
            case "GetItem":
                GetItemObjective getItem = new GetItemObjective();
                getItem.setItem(item);
                getItem.setObjectiveType(options[selected]);
                getItem.setObjectiveName(objectiveName);
                if (!modify)
                    quest.addObjective(getItem);
                return getItem;
            case "Kill":
                KillObjective kill = new KillObjective();
                kill.setHowMany(howMany);
                kill.setObjectiveType(options[selected]);
                kill.setTarget(target);
                kill.setObjectiveName(objectiveName);
                if (!modify)
                    quest.addObjective(kill);
                return kill;
            case "TalkTo":
                TalkToObjective talk = new TalkToObjective();
                talk.setObjectiveType(options[selected]);
                talk.setTarget(target);
                talk.setObjectiveName(objectiveName);
                if (!modify)
                    quest.addObjective(talk);
                return talk;
            default:
                return null;
        }
    }

    protected Objective castObjective(Objective obj){
        switch (obj.getObjectiveType())
        {
            case "GetItem":
                GetItemObjective itemObj = (GetItemObjective)obj;
                item = itemObj.getItem();
                return itemObj;
            case "Kill":
                KillObjective objKill = (KillObjective)obj;
                howMany = objKill.getHowMany();
                target = objKill.getTarget();
                return obj;
            case "TalkTo":
                TalkToObjective talkObj = (TalkToObjective)obj;
                target = talkObj.getTarget();
                return obj;
            default:
                return null;
        }
    }
    protected abstract string actionButton
    {
        get;
    } 

    protected abstract string windowTitle
    {
        get;
    }

    protected abstract void OnClick();
}
