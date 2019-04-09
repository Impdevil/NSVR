using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NSVR_States;


public enum NPCStateType
{
    Idle,
    Wander,
    Shop,
    Exit,

}
public  enum NPCType
{
    Base,
    Captured,
    wanderer,
    Enforcer
}
[System.Serializable]
public class BaseNPC : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    public List<GameObject> List_NPC;
    public BaseGameManager Game_Manager;
    public NavMeshAgent Nav_Agent;
    public bool preset;


    public WorldVolume Curr_WorldVolume;

    /// <summary>
    /// 
    /// </summary>
    public Waypoint nav_prevWyPoint, nav_Destination;
    public Waypoint nav_currWyPoint, nav_nextWyPoint;
    public bool AtWaypoint(Waypoint wypnt)
    {
        if (Vector3.Distance(wypnt.transform.position, this.transform.position) < 2)
            return true;
        else
            return false;
    }

    /// <summary>
    /// movement states
    /// </summary>
    public StateMachine<BaseNPC> GS_StateMachine { get; set; }
    public NPCStateType curr_State;
    public NPCStateType pre_state;
    public NPCType type;


    

    [SerializeField]
    public NPCReport npc_details;

    void Awake()
    {
        Initialize();

    }

    public  virtual void Initialize()
    {
        List_NPC = new List<GameObject>();
        GS_StateMachine = new StateMachine<BaseNPC>(this);
        type = NPCType.wanderer;


        GS_StateMachine.ChangeState(Idle.Instance);

        Debug.Log("Potato 1 LoadOrder: BaseNPC name:" + this.name + " || Initialize() || Current State: " + GS_StateMachine.CurrentState.GetType().ToString());
        if (this.GetComponent<NavMeshAgent>() != null)
        {
            Nav_Agent = this.GetComponent<NavMeshAgent>();
        }
        else
        {
            Nav_Agent = this.gameObject.AddComponent(typeof(NavMeshAgent)) as NavMeshAgent;
        }

        npc_details = new NPCReport();
    }

    public virtual void SetupConnections ()
    {
        
        Game_Manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<BaseGameManager>();

        List_NPC = Game_Manager.NPC_List;
    }

	// Use this for initialization
    /// <summary>
    /// 
    /// </summary>
	private void Start ()
    {
        SetupConnections();
        if(!preset)
        {

            npc_details.RandomSetup();

        }
    }

    /// <summary>
    /// Setup npc for adding 
    /// </summary>
    public virtual Augment[] NPC_Setup()
    {
        //creates a temp array too be loaded into the NPC
        Augment[] tempLoadOut = new Augment[System.Enum.GetNames(typeof(Aug_Placement)).Length - 1];


        for (int i = 0; i < tempLoadOut.Length; i++)
        {//find the augments of a specific type
            int startLoca = 0, endLoca = 0;
            bool set = false;
            {
                for (int j = 0; j < Game_Manager.legalAugmentations.Count; j++)
                {
                    if ((int)Game_Manager.legalAugmentations[j].GS_placement == i && set == false)
                    {
                        startLoca = j;
                        set = true;
                    }
                    if ((int)Game_Manager.legalAugmentations[j].GS_placement - 1 == i && set == true)
                    {
                        endLoca = j;
                        break;
                    }
                }
                int RngAug = Random.Range(startLoca, endLoca);
                tempLoadOut[i] = Game_Manager.legalAugmentations[RngAug];
            }
        }
        return tempLoadOut;
    }
    // Update is called once per frame
    void Update ()
    {
        GS_StateMachine.Update();

        if(type == NPCType.wanderer && (curr_State != NPCStateType.Wander && curr_State != NPCStateType.Shop))
        {
            GS_StateMachine.ChangeState(Wandering.Instance);
        }
	}

    public virtual bool MoveTooWaypoint()
    {
        if (Vector3.Distance(nav_currWyPoint.transform.position, this.transform.position) < 1.75)
        {
            if (nav_nextWyPoint != null)
            {
                nav_prevWyPoint = nav_currWyPoint;
                nav_currWyPoint = nav_nextWyPoint;
            }
            return true;
        }
        if(nav_currWyPoint.G_Pos != Nav_Agent.destination)
            Nav_Agent.SetDestination(nav_currWyPoint.G_Pos);
        return false;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="loca"></param>
    /// <returns></returns>
    public virtual bool MoveTooLocation(Vector3 loca)
    {
        if (Nav_Agent.destination != loca)
            Nav_Agent.SetDestination(loca);
        if (Nav_Agent.destination == transform.position)
        {
            return true;
        }
        else
            return false;
    }
    public virtual bool ReachedLocation()
    {


        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(Nav_Agent != null)
            Gizmos.DrawLine(this.transform.position, Nav_Agent.destination);
    }
}
