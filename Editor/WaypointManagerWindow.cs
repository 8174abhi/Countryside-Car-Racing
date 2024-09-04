using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class WaypointManagerWindow:EditorWindow
{
    [MenuItem("Waypoint/Waypoints Editor Tools")]
    public static void ShowWindow()
    {
        GetWindow<WaypointManagerWindow>("Waypoint Editor Tools");

    }
    public Transform WaypointOrigin;
    private void OnGUI()
    {
        SerializedObject obj=new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("WaypointOrigin"));
        if(WaypointOrigin==null)
        {
            EditorGUILayout.HelpBox("Please assign a Waypoint origin transform ", MessageType.Warning);

        }
        else
        {
            EditorGUILayout.BeginVertical("Box");
            CreateButtons();
            EditorGUILayout.EndVertical();  
        }
        obj.ApplyModifiedProperties();

    }
        void CreateButtons()
        {
            if(GUILayout.Button("Create Waypoint"))
            {
                CreateWaypoint();
            }
        }
        void CreateWaypoint()
        {
            GameObject waypointObject = new GameObject("Waypoint" + WaypointOrigin.childCount, typeof(Waypoint));
           /* WaypointOrigin*/waypointObject.transform.SetParent(WaypointOrigin,false);
            Waypoint waypoint=waypointObject.GetComponent<Waypoint>(); 
            if(WaypointOrigin.childCount>1)
            {
               waypoint.PreviousWaypoint = WaypointOrigin.GetChild(WaypointOrigin.childCount - 2).GetComponent<Waypoint>();
               waypoint.PreviousWaypoint.NextWaypoint = waypoint;

               waypoint.transform.position=waypoint.PreviousWaypoint.transform.position;
               waypoint.transform.forward=waypoint.PreviousWaypoint.transform.forward;
            }
        Selection.activeObject = waypoint.gameObject;
        

        }


}
