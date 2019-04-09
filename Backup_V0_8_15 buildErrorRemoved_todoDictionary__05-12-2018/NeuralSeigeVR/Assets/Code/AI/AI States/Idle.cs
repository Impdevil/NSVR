using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NSVR_States;

namespace NSVR_States
{
    /// <summary>
    /// First state all NPC agents start of as, from here the next step is determined
    /// </summary>
    public class Idle : State<BaseNPC>
    {

        static Idle _instance;

        private Idle()
        {
            if (_instance != null)
            {
                return;
            }

            _instance = this;
        }

        public static Idle Instance
        {
            get
            {
                if (_instance == null)
                {
                    new Idle();
                }

                return _instance;
            }
        }

        public override void EnterState(BaseNPC owner)
        {
            Debug.Log("entering Idle state ");
            owner.curr_State = NPCStateType.Idle;
        }


        /// <summary>
        ///  go too next state
        /// </summary>
        /// <param name="owner"></param>
        public override void ExitState(BaseNPC owner)
        {
            Debug.Log("Exiting Idle state ");

            
        }

        public override void UpdateState(BaseNPC owner)
        {
            Debug.Log("Waiting for new State");
        }
    }
}