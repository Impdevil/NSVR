using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NSVR_States
{
    public class Wandering : State<BaseNPC>
    {

        static Wandering _instance;

        private Wandering()
        {
            if (_instance != null)
            {
                return;
            }

            _instance = this;
        }

        public static Wandering Instance
        {
            get
            {
                if (_instance == null)
                {
                    new Wandering();
                }

                return _instance;
            }
        }


        public override void EnterState(BaseNPC owner)
        {
            if (owner.pre_state == NPCStateType.Shop)
            {
                owner.Nav_Agent.isStopped = false;
                
            }
            else {
                owner.nav_currWyPoint = WaypointManager.FindClosestWaypoint(owner.transform.position, owner.Game_Manager);

            }
            owner.curr_State = NPCStateType.Wander;
            Debug.Log("potato 3S: Entered Wandering, Moving to " + owner.nav_currWyPoint.name);
            
        }

        public override void ExitState(BaseNPC owner)
        {
            owner.pre_state = NPCStateType.Wander;
        }

        
        public override void UpdateState(BaseNPC owner)
        {
            if (owner.MoveTooWaypoint() == true)
            {
                #region NPC Shopping AI
                ///this area is to determine if the Shopping NPC will go into a connectedShop at random
                ///and then switch states to going into the shop

                if (owner is NPC_ShoppingAi && owner.nav_currWyPoint.connectedShop == true)
                {
                    int RNG = Random.Range(0, 100);

                    if (RNG <= 25 && ((NPC_ShoppingAi)owner).maxNumbShops > ((NPC_ShoppingAi)owner).shopsEntered)
                    {
                        Debug.Log("Potato 7a NPC  " + owner.name + " ||| RNG: " + RNG);
                        for (int i = 0; i < owner.nav_currWyPoint.connectedWaypoints.Count; i++)
                        {
                            if (owner.nav_currWyPoint.connectedWaypoints[i].type == WaypointType.Shop)
                            {
                                owner.nav_nextWyPoint = owner.nav_currWyPoint.connectedWaypoints[i];
                                Debug.Log("Potato 7b NPC " + owner.name + "| " + owner.nav_currWyPoint.name + " to " + owner.nav_nextWyPoint.name);
                                owner.GS_StateMachine.ChangeState(Gointoshop.Instance);
                            }
                        }
                    }
                    #endregion
                    else
                    {
                        Debug.Log("Potato 6: RNG fail:" + RNG);
                        owner.nav_nextWyPoint = WaypointManager.NextWaypoint(owner.nav_currWyPoint, owner);
                    }
                }
                else
                    owner.nav_nextWyPoint = WaypointManager.NextWaypoint(owner.nav_currWyPoint, owner);


                if (owner.type == NPCType.Captured)
                {
                    owner.GS_StateMachine.ChangeState(Captured.Instance);
                }
            }

        }
    }
}
