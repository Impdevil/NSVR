using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NSVR_States;


public class NPC_ShoppingAi : BaseNPC {


    //basic shop wandering AI varibles 
    public int shopsEntered, maxNumbShops;
    public bool inShop;


	// Use this for initialization
	void Awake() {
        Initialize();

	}
    public override void Initialize()
    {
        base.Initialize();

        
        shopsEntered = 0;
        maxNumbShops = Random.Range(1, 5);

    }


    void Start()
    {
        SetupConnections();

        npc_details.GS_NPC_Augments.augmentations = NPC_Setup();
        curr_State = NPCStateType.Wander;
        GS_StateMachine.ChangeState(Wandering.Instance);
    }


    // Update is called once per frame
    void Update ()
    {
        GS_StateMachine.Update();


    }

}
