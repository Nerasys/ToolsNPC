using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class NPCTools : EditorWindow
{
    
    bool groupEnabled;
    [SerializeField] Texture aTexture;


    //--//
    private Rect leftPanel;
    private Rect rightPanel;
    private Rect rightUpPanel;

    private Rect resizer;
    private float sizeRatio = 0.3f;
    private float sizeRatioObject = 10.0f;
    private bool isResizing;
    private GUIStyle resizerStyle;
    Object[] objects = new Object[(int)ObjectEnum.SIZE];
    private enum ObjectEnum
    { 
        HEAD,
        EYES,
        HAIR,
        MOUTH,
        BODY,
        WEAPONR,
        WEAPONL,
        SIZE
    }
    //--//
    Object head;
    Object eyes;


    // Add menu named "My Window" to the Window menu
    [MenuItem("NPC/NPC Create")]
    static void Init()
    {
       

        // Get existing open window or if none, make a new one:
        NPCTools window = (NPCTools)EditorWindow.GetWindow(typeof(NPCTools));
       
        window.Show();
    }
    private void OnEnable()
    {
        resizerStyle = new GUIStyle();
        resizerStyle.normal.background = EditorGUIUtility.Load("icons/d_AvatarBlendBackground.png") as Texture2D;
    }

    void OnGUI()
    {
        DrawLeftPanel();
        DrawRightPanel();
        DrawResizer();
        ProcessEvents(Event.current);

        if (GUI.changed) Repaint();



    }

    private void DrawLeftPanel()
    {
        leftPanel = new Rect(0, 0, position.width * sizeRatio, position.height);

        GUILayout.BeginArea(leftPanel);
        GUILayout.Label("NPC visual", EditorStyles.boldLabel);
        GUI.DrawTexture(new Rect(20, 20, position.width * sizeRatio, position.height), aTexture);
        GUILayout.EndArea();
    }

    private void DrawRightPanel()
    {
        rightPanel = new Rect(position.width * sizeRatio, 0, position.width * (1 - sizeRatio), position.height);
        GUILayout.BeginArea(rightPanel);

        CreateMeshTools();


        GUILayout.EndArea();
    }

    private void DrawResizer()
    {
        resizer = new Rect((position.width * sizeRatio), 0, 10f, position.height);

        GUILayout.BeginArea(new Rect(resizer.position + (Vector2.up * 5f), new Vector2(2, position.height)), resizerStyle);
        GUILayout.EndArea();

        EditorGUIUtility.AddCursorRect(resizer, MouseCursor.ResizeHorizontal);

    }



    private void DrawResizerRight()
    {
        resizer = new Rect((position.width * sizeRatio), 0, 10f, position.height);

        GUILayout.BeginArea(new Rect(resizer.position + (Vector2.up * 5f), new Vector2(2, position.height)), resizerStyle);
        GUILayout.EndArea();

        EditorGUIUtility.AddCursorRect(resizer, MouseCursor.ResizeHorizontal);

    }






    private void CreateMeshTools()
    {
        rightUpPanel = new Rect(0, 0, rightPanel.width, rightPanel.height / 2.8f);
        GUILayout.BeginArea(rightUpPanel);
        GUILayout.BeginVertical();
        GUILayout.Label("MESH", EditorStyles.boldLabel);
        for (int i = 0; i < (int)ObjectEnum.SIZE; i++)
        {
            GUILayout.BeginHorizontal(i.ToString());

            GUILayout.Label(Trad(i), EditorStyles.boldLabel);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal(i.ToString());
            objects[i] = EditorGUILayout.ObjectField(objects[i], typeof(GameObject), false);
            if (GUILayout.Button("Set"))
            {
                Debug.Log("Clicked Button");
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    private void ProcessEvents(Event e)
    {
        switch (e.type)
        {
            case EventType.MouseDown:
                if (e.button == 0 && resizer.Contains(e.mousePosition))
                {
                    isResizing = true;
                }
                break;

            case EventType.MouseUp:
                isResizing = false;
                break;
        }

        Resize(e);
    }

    private void Resize(Event e)
    {
        if (isResizing)
        {
            sizeRatio = e.mousePosition.x / position.width;
            Repaint();
        }
    }




    private string Trad(int i)
    {
        switch (i)
        {
            case (int)ObjectEnum.EYES:
                return "EYES";
               
            case (int)ObjectEnum.HAIR:
                return "HAIR";
               
            case (int)ObjectEnum.HEAD:
                return "HEAD";
               
            case (int)ObjectEnum.MOUTH:
                return "MOUTH";
                
            case (int)ObjectEnum.BODY:
                return "BODY";
                ;
            case (int)ObjectEnum.WEAPONL:
                return "WEAPONL";
                
            case (int)ObjectEnum.WEAPONR:
                return "WEAPONR";
               
            default:
                return null;
                

        }

    }
}


