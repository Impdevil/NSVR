using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBrwsingAreas : WorldVolume {

    public Waypoint[] interactZones;
    public int importantPosition;


    


    // Use this for initialization
    void Start()
    {
        interactZones = new Waypoint[this.gameObject.transform.childCount];
        for (int i = 0; i <= this.gameObject.transform.childCount; i++ )
        {
            interactZones[i] = this.gameObject.transform.GetChild(i).GetComponent<InteractZone>();
            if (interactZones[i].GetComponent<InteractZone>() != null && interactZones[i].GetComponent<InteractZone>().shopTarget == true)
            {
                importantPosition = i;
                break;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>() != null)
        {

            Debug.Log("Potato 7E | " + other.gameObject.name + " entered " + this.name);
            

            if (other.gameObject.GetComponent<NPC_ShoppingAi>() != null)
                other.gameObject.GetComponent<NPC_ShoppingAi>().inShop = true;
            other.gameObject.GetComponent<BaseNPC>().Curr_WorldVolume = this;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>() != null)
        {
            if (other.gameObject.GetComponent<NPC_ShoppingAi>() != null)
                other.gameObject.GetComponent<NPC_ShoppingAi>().inShop = false;

            other.gameObject.GetComponent<BaseNPC>().Curr_WorldVolume = null;
        }
    }

    public Waypoint GoToInternalLocation(bool TargetLoc)
    {
        if (!TargetLoc)
        {
            int RNG = Random.Range(0, interactZones.Length - 1);
            return interactZones[RNG].GetComponent<InteractZone>();
        }
        else
            return interactZones[importantPosition].GetComponent<InteractZone>();
    }


    /// <summary>
    /// volume box Red with a cross on x side.
    /// 
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        ///vertical lines
        
        Gizmos.DrawLine(new Vector3(transform.position.x - (this.GetComponent<BoxCollider>().size.x / 2), transform.position.y + (this.GetComponent<BoxCollider>().size.y / 2), transform.position.z - (this.GetComponent<BoxCollider>().size.z / 2)), 
                        new Vector3(transform.position.x - (this.GetComponent<BoxCollider>().size.x / 2), transform.position.y - (this.GetComponent<BoxCollider>().size.y / 2), transform.position.z - (this.GetComponent<BoxCollider>().size.z / 2)));

        Gizmos.DrawLine(new Vector3(transform.position.x + (this.GetComponent<BoxCollider>().size.x / 2), transform.position.y + (this.GetComponent<BoxCollider>().size.y / 2), transform.position.z - (this.GetComponent<BoxCollider>().size.z / 2)),
                        new Vector3(transform.position.x + (this.GetComponent<BoxCollider>().size.x / 2), transform.position.y - (this.GetComponent<BoxCollider>().size.y / 2), transform.position.z - (this.GetComponent<BoxCollider>().size.z / 2)));

        Gizmos.DrawLine(new Vector3(transform.position.x - (this.GetComponent<BoxCollider>().size.x / 2), transform.position.y + (this.GetComponent<BoxCollider>().size.y / 2), transform.position.z + (this.GetComponent<BoxCollider>().size.z / 2)),
                        new Vector3(transform.position.x - (this.GetComponent<BoxCollider>().size.x / 2), transform.position.y - (this.GetComponent<BoxCollider>().size.y / 2), transform.position.z + (this.GetComponent<BoxCollider>().size.z / 2)));

        Gizmos.DrawLine(new Vector3(transform.position.x + (this.GetComponent<BoxCollider>().size.x / 2), transform.position.y + (this.GetComponent<BoxCollider>().size.y / 2), transform.position.z + (this.GetComponent<BoxCollider>().size.z / 2)),
                        new Vector3(transform.position.x + (this.GetComponent<BoxCollider>().size.x / 2), transform.position.y - (this.GetComponent<BoxCollider>().size.y / 2), transform.position.z + (this.GetComponent<BoxCollider>().size.z / 2)));

        ///horizontal lines
        
        Gizmos.DrawLine(new Vector3(transform.position.x - (this.GetComponent<BoxCollider>().size.x / 2), transform.position.y + (this.GetComponent<BoxCollider>().size.y / 2), transform.position.z - (this.GetComponent<BoxCollider>().size.z / 2)), 
                        new Vector3(transform.position.x - (this.GetComponent<BoxCollider>().size.x / 2), transform.position.y - (this.GetComponent<BoxCollider>().size.y / 2), transform.position.z + (this.GetComponent<BoxCollider>().size.z / 2)));

        Gizmos.DrawLine(new Vector3(transform.position.x + (this.GetComponent<BoxCollider>().size.x / 2), transform.position.y + (this.GetComponent<BoxCollider>().size.y / 2), transform.position.z - (this.GetComponent<BoxCollider>().size.z / 2)),
                        new Vector3(transform.position.x + (this.GetComponent<BoxCollider>().size.x / 2), transform.position.y - (this.GetComponent<BoxCollider>().size.y / 2), transform.position.z + (this.GetComponent<BoxCollider>().size.z / 2)));

        Gizmos.DrawLine(new Vector3(transform.position.x - (this.GetComponent<BoxCollider>().size.x / 2), transform.position.y + (this.GetComponent<BoxCollider>().size.y / 2), transform.position.z + (this.GetComponent<BoxCollider>().size.z / 2)),
                        new Vector3(transform.position.x - (this.GetComponent<BoxCollider>().size.x / 2), transform.position.y - (this.GetComponent<BoxCollider>().size.y / 2), transform.position.z - (this.GetComponent<BoxCollider>().size.z / 2)));

        Gizmos.DrawLine(new Vector3(transform.position.x + (this.GetComponent<BoxCollider>().size.x / 2), transform.position.y + (this.GetComponent<BoxCollider>().size.y / 2), transform.position.z + (this.GetComponent<BoxCollider>().size.z / 2)),
                        new Vector3(transform.position.x + (this.GetComponent<BoxCollider>().size.x / 2), transform.position.y - (this.GetComponent<BoxCollider>().size.y / 2), transform.position.z - (this.GetComponent<BoxCollider>().size.z / 2)));



    }
}
