using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SectorTypes
{
    TestEnvironment,
    //trunk of the city
    Underground,
    UrbanSprawl,
    Factorium,
    MarketPlace,
    //high class
    DomeCenter,
    Plaza
    
}

public class BaseGameManager : MonoBehaviour
{

    /// <summary>
    /// Ai Managment
    /// </summary>

    public List<Augment> legalAugmentations, illegalAugmentations;
    public List<GameObject> NPC_List;
    public GameObject Ref_Target;
    public List<Waypoint> waypoints_NPC, waypoints_Trffc;
    public List<int> shopID, exitID;

    [SerializeField]
    public SectorDeclaration sector;
    public SectorTypes thisSector;
    public int spawnLimit_Npc, spawnLimit_Targets, spawnLimit_Redherring;



    void Awake()
    {
        Debug.Log("Potato1: Load Order Gamemanager|| Awake()");

        waypoints_NPC = new List<Waypoint>();
        waypoints_Trffc = new List<Waypoint>();
        shopID = new List<int>();
        exitID = new List<int>();

        if(StoredData_DataPoints.Education[0] == null) Debug.Log("Potato1c loader static field loaded"); 


        if (illegalAugmentations.Count < 1 && legalAugmentations.Count < 5)
            LoadAssets();
        else
        {
            legalAugmentations.Sort(delegate (Augment x, Augment y)
            {
                return x.placement.CompareTo(y.placement);
            });

            illegalAugmentations.Sort(delegate (Augment x, Augment y)
            {
                return x.placement.CompareTo(y.placement);
            });
        }
    }

    // Use this for initialization
    void Start()
    {
        NPC_List.AddRange(GameObject.FindGameObjectsWithTag("NPC"));
        foreach( GameObject temp in GameObject.FindGameObjectsWithTag("Waypoint"))
            waypoints_NPC.Add(temp.GetComponent<Waypoint>());
        
        Debug.Log("Potato1B | SectorGen:" + NPC_List.Count);
        InitializeNPCSystem();
    }


    public void InitializeNPCSystem ()
    {
        List<WeightedItem>[] test = new List<WeightedItem>[9];
        if(sector.WeightingEducation == null)
        {
            //loading: resourse\"Sector type" 
            sector = Resources.Load<SectorDeclaration>("SectorTypes/" + thisSector.ToString());
        }
        for (int i = 0; i < sector.dataTypes.Length; i++)
        {
               test[i] = StoredData_DataPoints.InitilizeSystem(sector.GetVariName(sector.dataTypes[i]), StoredData_DataPoints.Datatypes[i]);
            
        }
        Debug.Log("Potato 1D || list test: "+test[0][2].item + " & length : "+ test[0].Count);
    }

    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// Load assets from resources
    /// 
    /// </summary>
    private void LoadAssets()
    {
        legalAugmentations = new List<Augment>();
        legalAugmentations = new List<Augment>();
        legalAugmentations.AddRange(Resources.LoadAll<Augment>("Augments/Legal"));
        legalAugmentations.Sort(delegate (Augment x, Augment y)
        {
            return x.placement.CompareTo(y.placement);
        });

        Debug.Log("completed loading Legal Array of augments: " + legalAugmentations.Count);


        illegalAugmentations = new List<Augment>();
        illegalAugmentations.AddRange(Resources.LoadAll<Augment>("Augments/Illegal"));
        illegalAugmentations.Sort(delegate (Augment x, Augment y)
        {
            return x.placement.CompareTo(y.placement);
        });
        Debug.Log("completed loading illegal list of augments: " + illegalAugmentations.Count);
        if (illegalAugmentations.Count < 1 || legalAugmentations.Count < 1)
        {
            Debug.LogError("Resources failed to load please retry. Unknown error with unity android system and resources.");
            LoadAssets();
        }
    }
}
