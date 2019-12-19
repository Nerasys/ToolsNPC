using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class NPCTools : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    [SerializeField] Texture aTexture;
   Object head;
    // Add menu named "My Window" to the Window menu
    [MenuItem("NPC/NPC Create")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        NPCTools window = (NPCTools)EditorWindow.GetWindow(typeof(NPCTools));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal("Horizontal");
        GUILayout.Width(600);
        GUILayout.Height(800);
        GUI.Label(new Rect(30, 10, 100, 20), "NPC visual",EditorStyles.boldLabel);
        GUI.DrawTexture(new Rect(30, 30, 600, 800), aTexture);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal("Horizontal2");
     
        head = EditorGUILayout.ObjectField(head, typeof(GameObject), false);
        if (GUILayout.Button("Set"))
        { 
            Debug.Log("Clicked Button");
        }
     

        GUILayout.EndHorizontal();
       




        
      
        // myString = EditorGUILayout.TextField("Text Field", myString);

        // groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        // myBool = EditorGUILayout.Toggle("Toggle", myBool);
        // myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        // GUI.DrawTexture(new Rect(30, 30, 600, 800), aTexture);
        EditorGUILayout.EndToggleGroup();
    }
}