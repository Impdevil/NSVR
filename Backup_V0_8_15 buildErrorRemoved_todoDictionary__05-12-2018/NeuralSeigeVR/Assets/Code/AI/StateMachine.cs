using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NSVR_States
{
    /// <summary>
    /// controls states for all NPC's taken from Youtube tutorial
    /// </summary>
    public class StateMachine<T>
    {
        public State<T> CurrentState { get; private set; }

        public T _owner;


        public StateMachine(T owner)
        {
            _owner = owner;
            CurrentState = null;
        }

        public void ChangeState(State<T> newState)
        {
            if (CurrentState != null)
            {
                CurrentState.ExitState(_owner);
            }
            CurrentState = newState;
            CurrentState.EnterState(_owner);
        }
        public void Update()
        {
            if (CurrentState != null)
            {
                CurrentState.UpdateState(_owner);
            }
        }


    }

    public abstract class State<T>
    {
        public bool waitBool;
        public bool doOnce;
        public int updateTurns;
        public abstract void EnterState(T owner);

        public abstract void ExitState(T owner);

        public abstract void UpdateState(T owner);

        public float timer1;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="duration"></param>
        /// <returns></returns>
        public IEnumerator WaitSetTime(float duration)
        {
            waitBool = false;
            Debug.Log("potato 7e || WaitSetTime Float duration = " + duration);
            yield return new WaitForSeconds(duration);   //Wait
            Debug.Log("potato 7e2" +" || End Wait() function and the time is: " + Time.time);
            waitBool = true;
            yield return null;
        }
    }

}
