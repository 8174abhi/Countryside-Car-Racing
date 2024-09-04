using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad()]
public class WaypointEditor
{
    [DrawGizmo(GizmoType.NonSelected|GizmoType.Selected|GizmoType.Pickable)]

    public static void OnDrawSceneGizmos(Waypoint waypoint, GizmoType gizmoType)
    {
        if((gizmoType&GizmoType.Selected)!=0)
        {
            Gizmos.color = Color.blue;

        }
        else
        {
            Gizmos.color = Color.blue * .5f;

        }
        Gizmos.DrawSphere(waypoint.transform.position, -1f);
        Gizmos.color= Color.white;
        Gizmos.DrawLine(waypoint.transform.position + (waypoint.transform.right * waypoint.WaypointWidth / 2f), waypoint.transform.position - (waypoint.transform.right * waypoint.WaypointWidth / 2f));
        if(waypoint.PreviousWaypoint != null)
        {
            Gizmos.color = Color.red;
            Vector3 offset = waypoint.transform.right * waypoint.WaypointWidth / 2f;
            Vector3 offsetto = waypoint.PreviousWaypoint.transform.right * waypoint.WaypointWidth / 2f;
            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.PreviousWaypoint.transform.position + offsetto);
        }
        if(waypoint.NextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Vector3 offset = waypoint.transform.right * -waypoint.WaypointWidth / 2f;
            Vector3 offsetto = waypoint.PreviousWaypoint.transform.right * -waypoint.WaypointWidth / 2f;
            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.PreviousWaypoint.transform.position + offsetto);
        }
    }

  


}
