using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NSVR_States;

public class Gointoshop : State<BaseNPC> {

    static Gointoshop _instance;
    

    private Gointoshop()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static Gointoshop Instance
    {
        get
        {
            if (_instance == null)
            {
                new Gointoshop();
            }


            return _instance;
        }
    }


    /// <summary>
    /// 
    ////// </summary>
    /// <param name="owner"></param>
    public override void EnterState(BaseNPC owner)
    {
        doOnce = false;
        timer1 = 0;
        Debug.Log("Potato 7C | EnteringShop");
        owner.curr_State = NPCStateType.Shop;
        if (owner is NPC_ShoppingAi)
        {
            ((NPC_ShoppingAi)owner).shopsEntered++;
        }
        if (owner.MoveTooWaypoint() == true)
        {
            foreach (Waypoint wypnts in owner.nav_currWyPoint.connectedWaypoints)
            {
                if (wypnts.type == WaypointType.Shop)
                {
                    owner.nav_nextWyPoint = wypnts;
                    break;
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="owner"></param>
    public override void ExitState(BaseNPC owner)
    {
        //owner.StopCoroutine("WaitSetTime");
        Debug.Log("Potato 8 || Leaving shop " + owner.name);
        owner.Nav_Agent.velocity = Vector3.zero;
        owner.Nav_Agent.isStopped = true;
        owner.pre_state = NPCStateType.Shop;
        owner.nav_nextWyPoint = WaypointManager.NextWaypoint(owner.Curr_WorldVolume.mainWaypoint, owner);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="owner"></param>
    public override void UpdateState(BaseNPC owner)
    {
        if (owner is NPC_ShoppingAi && !((NPC_ShoppingAi)owner).inShop && owner.MoveTooWaypoint())
        {
            if (!doOnce)
            {
                Debug.Log("potato 7D| " + owner.name);
                //owner.StartCoroutine(WaitSetTime(12));
                doOnce = true;
            }
            
        }
        if (((NPC_ShoppingAi)owner).inShop)
        {
            Debug.Log("Potato 7G || "+ owner.name +" inShop |_| current timer  " + timer1  + " | Remender: " + ((int)timer1 % 3));
            ShopBrwsingAreas temp = ((NPC_ShoppingAi)owner).Curr_WorldVolume as ShopBrwsingAreas;
            
            if (owner.MoveTooWaypoint() && ((int)timer1 % 3) == 0) 
            {
                owner.nav_nextWyPoint = temp.GoToInternalLocation(false);
            }

            timer1 += Time.deltaTime;
            if (timer1 > 12f || waitBool)
            {
                Debug.Log("Potato 7H| Time Finished");
                owner.GS_StateMachine.ChangeState(Wandering.Instance);
            }
        }

        //Debug.Log("Potato 7F|" + owner.name + " time " + timer1);
    }
}
