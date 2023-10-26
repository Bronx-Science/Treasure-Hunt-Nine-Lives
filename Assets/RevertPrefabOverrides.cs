using UnityEngine;
using UnityEditor;

public class RevertPrefabOverrides : EditorWindow
{
    [MenuItem("Tools/Revert Prefab Overrides Except Transform")]
    static void RevertAllPrefabs()
    {
        GameObject[] selectedObjects = Selection.gameObjects;

        foreach (GameObject prefab in selectedObjects)
        {
            // Store transform properties
            Vector3 position = prefab.transform.position;
            Quaternion rotation = prefab.transform.rotation;
            Vector3 scale = prefab.transform.localScale;

            // Revert prefab overrides
            PrefabUtility.RevertPrefabInstance(prefab, InteractionMode.AutomatedAction);

            // Restore transform properties
            prefab.transform.position = position;
            prefab.transform.rotation = rotation;
            prefab.transform.localScale = scale;
        }

        Debug.Log("Overrides reverted for selected prefabs except transform.");
    }
}