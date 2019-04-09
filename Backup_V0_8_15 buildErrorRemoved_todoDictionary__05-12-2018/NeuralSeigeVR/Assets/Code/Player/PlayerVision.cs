using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVision : MonoBehaviour
{

    public Camera PLAYERCAMERA;
    public GameObject GetPlayerTarget
    {
        get { return playerTarget; }
    }
    public string TargetName;

    BaseGameManager Game_Manager;
    private GameObject playerTarget;

    // Use this for initialization
    void Start()
    {
        Game_Manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<BaseGameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            // Game_Manager.SendEnforcement();
        }
        if (Input.GetButtonDown("Submit"))
        {

            Debug.Log("potato 6: TestFiring");
            #region player input handling with unity raycast

            Debug.DrawRay(this.transform.position, PLAYERCAMERA.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, PLAYERCAMERA.transform.forward, out hit))
            {
                if (hit.transform.tag == "PlayerVisLocation")
                {
                    this.transform.position = hit.transform.position;
                }
                else if (hit.transform.tag == "NPC")
                {
                    playerTarget = hit.transform.gameObject;
                }
                /*else if (hit.transform.tag == "World")  // for testing
                {
                    playerTarget = null;
                }*/
                else if (hit.transform.tag == "WS_UI")
                {

                }
                else if (hit.transform.tag == "WS_UI_Button")
                {
                    if (hit.transform.name == "SendEnforcementBTTN")
                    {
                        //send enforcement
                        Debug.Log("hey buttons work");
                        //Game_Manager.SendEnforcement();

                    }
                }
            }
            else
            {
                playerTarget = null;
            }
            if (playerTarget != null)
                TargetName = playerTarget.gameObject.name;
        }
        #endregion
    }
}
