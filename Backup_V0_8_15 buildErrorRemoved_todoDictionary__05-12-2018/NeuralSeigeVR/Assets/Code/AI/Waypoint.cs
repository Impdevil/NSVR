using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public enum WaypointType
{
    Waypoint,
    Exit,
    Shop,
    Car,
    Crossing,
    Special,
    Internal
}


public class Waypoint : MonoBehaviour
{
    [SerializeField]
    public WaypointType type;
    [SerializeField]
    public List<Waypoint> connectedWaypoints;
    public Vector3 G_Pos
    {
        get { return this.transform.position; }
    }

    public bool connectedShop;

    //public string name;


    // Use this for initialization
    void Start()
    {
        InitializeWaypoint();
    }

    public void InitializeWaypoint()
    {
        if (type == WaypointType.Exit)
        {
            name += " Exit";
        }
        if (connectedWaypoints == null && type != WaypointType.Internal)
        {
            Debug.Log("find the waypoints around this waypoint: " + this.name);

            //work out a way to find out waypoints close to this one. xz axis to work out the rotation so it is automatic
        }
        for (int i = 0; i < connectedWaypoints.Count; i++)
        {
            if (connectedWaypoints[i].type == WaypointType.Shop)
                connectedShop = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 2);
        foreach (Waypoint temp in connectedWaypoints)
        {
            if (type != WaypointType.Exit || type != WaypointType.Car)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(this.transform.position, temp.transform.position);
                Debug.Log("Draw Test Lines");
            }
        }
    }
}



