using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeWeaponObject
{
    [MenuItem("Assets/create/Weapon Object")]
    public static void Create()
    {
        WeaponObject asset = ScriptableObject.CreateInstance<WeaponObject> ();
        AssetDatabase.CreateAsset(asset, "Assets/NewWeaponObject.asset");
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;

    }

}
