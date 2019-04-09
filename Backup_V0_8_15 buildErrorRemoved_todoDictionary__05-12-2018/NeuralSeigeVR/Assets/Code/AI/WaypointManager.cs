using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NSVR_States;

/// <summary>
///helper class for waypoint managment
/// </summary>
public static class WaypointManager
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="NPC_Pos"></param>
    /// <param name="Game_Manager"></param>
    /// <returns></returns>
    public static Waypoint FindClosestWaypoint(Vector3 NPC_Pos, BaseGameManager Game_Manager)
    {

        if (Game_Manager.waypoints_NPC.Count < 1) return null;
        int lastDist, currDist, closest = 0;

        lastDist = (int)Vector3.Distance(NPC_Pos, Game_Manager.waypoints_NPC[closest].transform.position);
        for (int i = 1; i < Game_Manager.waypoints_NPC.Count; i++)
        {
            currDist = (int)Vector3.Distance(NPC_Pos, Game_Manager.waypoints_NPC[i].transform.position);
            if (currDist < lastDist)
            {
                lastDist = currDist;
                closest = i;
            }

        }
        return Game_Manager.waypoints_NPC[closest];
    }


    /// <summary>
    /// finds the closest exit waypoint for an npc to leave through
    /// </summary>
    /// <param name="NPC_Pos"></param>
    /// <returns></returns>
    public static  Waypoint FindClosestExitWaypoint(Vector3 NPC_Pos, BaseGameManager Game_Manager)
    {
        if (Game_Manager.waypoints_NPC.Count < 1) return null;
        int lastDist, currDist, closest = 0;

        if (Game_Manager.exitID.Count > 1)
        {
            lastDist = (int)Vector3.Distance(NPC_Pos, Game_Manager.waypoints_NPC[Game_Manager.exitID[0]].transform.position);
            for (int i = 1; i < Game_Manager.exitID.Count; i++)
            {
                currDist = (int)Vector3.Distance(NPC_Pos, Game_Manager.waypoints_NPC[Game_Manager.exitID[i]].transform.position);
                if (currDist < lastDist)
                {
                    lastDist = currDist;
                    closest = i;
                }

            }
            return Game_Manager.waypoints_NPC[Game_Manager.exitID[closest]];
        }
        else return Game_Manager.waypoints_NPC[Game_Manager.exitID[0]];
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="checkedWaypoint">waypoint the npc needs to check</param>
    /// <param name="destinationWaypoint">final destination</param>
    /// <param name="prevWaypoint"></param>
    /// <returns></returns>
    public static Waypoint FindNextWaypointToTarget(Waypoint checkedWaypoint, Waypoint destinationWaypoint, Waypoint prevWaypoint, BaseGameManager Game_Manager)
    {
        int lastDist, currDist, closest = 0;

        if (checkedWaypoint.connectedWaypoints.Count >= 1 && prevWaypoint != null)
        {
            lastDist = (int)Vector3.Distance(checkedWaypoint.connectedWaypoints[0].transform.position, destinationWaypoint.transform.position);
            for (int i = 1; i < checkedWaypoint.connectedWaypoints.Count; i++)
            {
                currDist = (int)Vector3.Distance(checkedWaypoint.connectedWaypoints[i].transform.position, destinationWaypoint.transform.position);
                if (currDist < lastDist && (prevWaypoint.transform.position != checkedWaypoint.connectedWaypoints[i].transform.position))
                {
                    lastDist = currDist;
                    closest = i;
                }
            }
            return checkedWaypoint.connectedWaypoints[closest];
        }
        else if (prevWaypoint == null)
        {
            lastDist = (int)Vector3.Distance(checkedWaypoint.connectedWaypoints[0].transform.position, destinationWaypoint.transform.position);
            for (int i = 1; i < checkedWaypoint.connectedWaypoints.Count; i++)
            {
                currDist = (int)Vector3.Distance(checkedWaypoint.connectedWaypoints[i].transform.position, destinationWaypoint.transform.position);
                if (currDist < lastDist)
                {
                    lastDist = currDist;
                    closest = i;
                }
            }
            return checkedWaypoint.connectedWaypoints[closest];
        }
        else return checkedWaypoint.connectedWaypoints[0];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="position"></param>
    /// <param name="CreateWaypoint"></param>
    /// <returns></returns>
    public static Waypoint CreateQuickWaypoint(Vector3 position, bool CreateWaypoint)
    {
        Waypoint temp;
        temp = new Waypoint();


        temp.transform.position = position;

        if (!CreateWaypoint)
        {
            GameObject.Destroy(temp, 2f);
            return temp.GetComponent<Waypoint>();
        }
        else
            return temp.GetComponent<Waypoint>();
    }


    public static Waypoint NextWaypoint(Waypoint checkedWaypoint, BaseNPC NPC)
    {
        Waypoint nextWaypoint;
        if(NPC.curr_State == NPCStateType.Wander )
        {
            nextWaypoint = checkedWaypoint.connectedWaypoints[Random.Range(0, checkedWaypoint.connectedWaypoints.Count )];

            while(true)
            {
                if((nextWaypoint.type == WaypointType.Waypoint || nextWaypoint.type == WaypointType.Crossing)  && nextWaypoint != NPC.nav_prevWyPoint)
                {
                    break;
                }

                nextWaypoint = checkedWaypoint.connectedWaypoints[Random.Range(0, checkedWaypoint.connectedWaypoints.Count )];
            }

            return nextWaypoint;
        }
        else
        {
            nextWaypoint = checkedWaypoint.connectedWaypoints[Random.Range(0, checkedWaypoint.connectedWaypoints.Count - 1)];
            return nextWaypoint;
        }
        Debug.LogError("Failed to find a waypoint attached at " + checkedWaypoint.name + ", Location: " + checkedWaypoint.G_Pos);
        return checkedWaypoint;
    }
}