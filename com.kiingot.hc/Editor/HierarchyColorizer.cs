using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

// This class initializes automatically and hooks into the Hierarchy window event.
[InitializeOnLoad]
public static class HierarchyColorizer
{
    private static Dictionary<string, Color> tagColorMapping = new Dictionary<string, Color>();

    static HierarchyColorizer()
    {
        // Load saved settings or use default mappings.
        LoadSettings();
        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
    }

    private static void OnHierarchyGUI(int instanceID, Rect selectionRect)
    {
        // Get the GameObject for the current hierarchy item.
        GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (obj == null)
            return;

        // If a mapping exists for the object's tag, draw the colored background.
        if (tagColorMapping.TryGetValue(obj.tag, out Color color))
        {
            EditorGUI.DrawRect(selectionRect, color);
        }
    }

    // Called from the settings window to update the mapping.
    public static void UpdateMapping(Dictionary<string, Color> newMapping)
    {
        tagColorMapping = newMapping;
        SaveSettings();
        // Force a repaint of the Hierarchy window to reflect changes.
        EditorApplication.RepaintHierarchyWindow();
    }

    // Save the mapping as JSON in EditorPrefs.
    private static void SaveSettings()
    {
        var list = new List<TagColorEntry>();
        foreach (var kvp in tagColorMapping)
        {
            list.Add(new TagColorEntry() { tagName = kvp.Key, color = kvp.Value });
        }
        string json = JsonUtility.ToJson(new TagColorList() { entries = list });
        EditorPrefs.SetString("HierarchyColorizer_Settings", json);
    }

    // Load the mapping from EditorPrefs (or use a default if not found).
    private static void LoadSettings()
    {
        if (EditorPrefs.HasKey("HierarchyColorizer_Settings"))
        {
            string json = EditorPrefs.GetString("HierarchyColorizer_Settings");
            var tagColorList = JsonUtility.FromJson<TagColorList>(json);
            if (tagColorList != null && tagColorList.entries != null)
            {
                tagColorMapping.Clear();
                foreach (var entry in tagColorList.entries)
                {
                    if (!string.IsNullOrEmpty(entry.tagName))
                        tagColorMapping[entry.tagName] = entry.color;
                }
            }
        }
        else
        {
            // Default mappings: adjust or add more as needed.
            tagColorMapping.Clear();
            tagColorMapping["Player"] = new Color(0.5f, 1f, 0.5f, 0.3f); // light green
            tagColorMapping["Enemy"] = new Color(1f, 0.5f, 0.5f, 0.3f);  // light red
            tagColorMapping["Untagged"] = new Color(1f, 1f, 1f, 0f);       // transparent
            SaveSettings();
        }
    }

    // Provides the current mapping (used by the settings window).
    public static Dictionary<string, Color> GetMapping()
    {
        return tagColorMapping;
    }
}

// Serializable helper classes for saving/loading settings.
[System.Serializable]
public class TagColorEntry
{
    public string tagName;
    public Color color;
}

[System.Serializable]
public class TagColorList
{
    public List<TagColorEntry> entries;
}
