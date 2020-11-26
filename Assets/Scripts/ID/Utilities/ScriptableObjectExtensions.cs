using System.IO;
using UnityEditor;
using UnityEngine;

namespace ID.Utilities
{
    public static class ScriptableObjectExtensions
    {
        public static T[] GetAllInstances<T>() where T : ScriptableObject
        {
            string[] guids = AssetDatabase.FindAssets("t:"+ typeof(T).Name);  //FindAssets uses tags check documentation for more info
            T[] a = new T[guids.Length];
            for(int i =0;i<guids.Length;i++)         //probably could get optimized 
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
                            
                AssetDatabase.SaveAssets ();
                AssetDatabase.Refresh();
            }
 
            return a;
 
        }
        
        //returns the first element that found
        public static T GetInstance<T>() where T : ScriptableObject
        {
            string[] guids = AssetDatabase.FindAssets("t:"+ typeof(T).Name);  //FindAssets uses tags check documentation for more info
            T[] a = new T[guids.Length];
            for(int i =0;i<guids.Length;i++)         //probably could get optimized 
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
                            
                AssetDatabase.SaveAssets ();
                AssetDatabase.Refresh();
            }
                
            if (a.Length > 0)
            {
                return a[0];
            }
            return null;
 
        }
        
        public static T CreateAsset<T> (string name, string newPath = "") where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T> ();
 
            string path = AssetDatabase.GetAssetPath (Selection.activeObject);

            if (path == "") 
            {
                path = "Assets";
            } 
            if (newPath != "")
            {
                path = path + "/" + newPath;
            }
            else if (Path.GetExtension (path) != "") 
            {
                path = newPath.Replace (Path.GetFileName (AssetDatabase.GetAssetPath (Selection.activeObject)), "");
            }

 
            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (path + "/" + name + ".asset");
 
            AssetDatabase.CreateAsset (asset, assetPathAndName);
            
            AssetDatabase.SaveAssets ();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow ();
            Selection.activeObject = asset;
            return asset;
        }
    } 
}

