using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NSVR_States
{
    public class Captured : State<BaseNPC>
    {

        static Captured _instance;

        private Captured()
        {
            if (_instance != null)
            {
                return;
            }

            _instance = this;
        }

        public static Captured Instance
        {
            get
            {
                if (_instance == null)
                {
                    new Captured();
                }

                return _instance;
            }
        }
        public override void EnterState(BaseNPC owner)
        {
            throw new System.NotImplementedException();
        }

        public override void ExitState(BaseNPC owner)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateState(BaseNPC owner)
        {

        }

    }
}

