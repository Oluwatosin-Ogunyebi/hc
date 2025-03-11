using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class HierarchyColorSettingsWindow : EditorWindow
{
    private List<TagColorEntry> entries = new List<TagColorEntry>();

    // Add a menu item to open the settings window.
    [MenuItem("Tools/Hierarchy Color Settings")]
    public static void ShowWindow()
    {
        GetWindow<HierarchyColorSettingsWindow>("Hierarchy Color Settings");
    }

    private void OnEnable()
    {
        // Load the current mappings from the HierarchyColorizer.
        Dictionary<string, Color> mapping = HierarchyColorizer.GetMapping();
        entries = new List<TagColorEntry>();
        foreach (var kvp in mapping)
        {
            entries.Add(new TagColorEntry() { tagName = kvp.Key, color = kvp.Value });
        }
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Configure Tag Color Mapping", EditorStyles.boldLabel);

        // Display a list of current tag–color entries.
        for (int i = 0; i < entries.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            entries[i].tagName = EditorGUILayout.TextField("Tag", entries[i].tagName);
            entries[i].color = EditorGUILayout.ColorField("Color", entries[i].color);
            if (GUILayout.Button("Remove", GUILayout.Width(60)))
            {
                entries.RemoveAt(i);
                break;
            }
            EditorGUILayout.EndHorizontal();
        }

        // Button to add a new mapping.
        if (GUILayout.Button("Add New Mapping"))
        {
            entries.Add(new TagColorEntry() { tagName = "NewTag", color = new Color(1, 1, 1, 0.3f) });
        }

        // Button to save changes.
        if (GUILayout.Button("Save Settings"))
        {
            Dictionary<string, Color> newMapping = new Dictionary<string, Color>();
            foreach (var entry in entries)
            {
                if (!string.IsNullOrEmpty(entry.tagName))
                    newMapping[entry.tagName] = entry.color;
            }
            HierarchyColorizer.UpdateMapping(newMapping);
        }
    }
}
