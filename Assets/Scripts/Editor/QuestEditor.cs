using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomEditor(typeof(Quest))]
public class QuestEditor : Editor
{
    public VisualTreeAsset visualTree;

    private Quest quest;

    private Button randomQuestButton;
    private Button randomItemsButton;

    private PropertyField itemsToggle;
    private VisualElement itemsToHide;
    private SerializedProperty haveItems;

    private void OnEnable()
    {
        quest = (Quest)target;
        haveItems = serializedObject.FindProperty("haveItems");
    }

    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new();

        visualTree.CloneTree(root);

        randomQuestButton = root.Q<Button>("generate-quest-button");
        randomItemsButton = root.Q<Button>("generate-items-button");

        randomQuestButton.RegisterCallback<ClickEvent>((evt) => quest.GenerateQuest());
        randomItemsButton.RegisterCallback<ClickEvent>((evt) => quest.GenerateItems());

        itemsToggle = root.Q<PropertyField>("items-toggle");
        itemsToHide = root.Q<VisualElement>("items-container");

        itemsToggle.RegisterCallback<ChangeEvent<bool>>((evt) => ToggleItems());

        ToggleItems();

        return root;
    }

    private void ToggleItems()
    {
        if (haveItems.boolValue)
            itemsToHide.style.display = DisplayStyle.Flex;
        else
            itemsToHide.style.display = DisplayStyle.None;
    }
}
