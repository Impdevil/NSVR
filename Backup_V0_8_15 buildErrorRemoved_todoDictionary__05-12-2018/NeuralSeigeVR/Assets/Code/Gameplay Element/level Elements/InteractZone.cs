using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractZone : Waypoint {

    public bool shopTarget;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnDrawGizmos()
    {
        if (shopTarget)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(this.transform.position, 1);
    }

}
