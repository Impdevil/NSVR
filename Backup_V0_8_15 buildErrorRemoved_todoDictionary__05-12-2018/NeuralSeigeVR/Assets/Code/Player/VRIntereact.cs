using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRIntereact : MonoBehaviour
{

    public float distancePT_UI = 8;
    public Vector3 offsetmenu_q = new Vector3(20, 30, 0);// get offset struct from camera points(not setup yet). randomization is now way more difficult


    public GameObject PRFB_targetSelectionUI;

    public GameObject PlayerTarget
    {
        get
        {
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            return Player.GetComponent<PlayerVision>().GetPlayerTarget;
        }
    }
    BaseNPC TargetDetails
    {
        get { return PlayerTarget.GetComponent<BaseNPC>(); }
    }
    GameObject prev_playerTarget;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTarget != null)
        {
            PRFB_targetSelectionUI.SetActive(true);
            SetUILocationOnSphere();

            PRFB_targetSelectionUI.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(PRFB_targetSelectionUI.transform.position - this.transform.position), Vector2.up);

            //PRFB_targetSelectionUI.GetComponentInChildren<Text>().text = PlayerTarget.gameObject.GetComponent<NPCAgent>().npc_Details.name;
            if (prev_playerTarget != PlayerTarget)
                SetTargetInfoUI();
        }
        if (PlayerTarget == null)
        {
            PRFB_targetSelectionUI.SetActive(false);
        }
        prev_playerTarget = PlayerTarget;
    }

    /// <summary>
    /// 
    /// </summary>
    void SetUILocationOnSphere()
    {
        RaycastHit hit;
  


        Quaternion menu_Q;
        Vector3 direction = Vector3.Normalize(new Vector3(this.transform.position.x - PlayerTarget.transform.position.x, this.transform.position.y - PlayerTarget.transform.position.y, this.transform.position.z - PlayerTarget.transform.position.z));
        Vector3 n_PosUI, positionScale;
        menu_Q = new Quaternion(0, 0.5f, 0, -0.4f);


        if (Physics.Raycast(PlayerTarget.transform.position, direction, out hit, Mathf.Infinity, ((1 << 5))))
        {
            #region //trig version that doesnt work
            /*
            //Debug.Log(hit.point);
            Debuf of a_MPT
            Debug.Lg.DrawLine(PlayerTarget.transform.position, this.transform.position);
            //hal
            a_PTM = (Mathf.Deg2Rad*180) - (a_MPT + Mathf.Deg2Rad * 90);
            dis_PM = Mathf.Cos(a_MPT) * (Vector3.Distance(this.transform.position, hit.point));
            Debug.Log("potato1og(distancePT_UI + " | " + distancePT_UI * 0.5f + " | " + circleRadi);
            a_MPT = Mathf.Asin(((0.5f) * distancePT_UI) / (circleRadi));
            : "+ a_MPT + " | " + a_PTM + " | " + dis_PM);
            Ray radi_dist_m;
            Vector3 direction1 = new Vector3();
            
            direction1.x = Mathf.Cos(a_PTM) + Mathf.Cos(a_MPT);
            direction1.y = Mathf.Sin(a_PTM) + Mathf.Sin(a_MPT);
            direction1.z = Mathf.Tan(a_PTM) + Mathf.Tan(a_MPT) ;

            Debug.Log("potato2"+direction1 + " | " + a_PTM);
            radi_dist_m = new Ray(this.transform.position, direction1);
            m = radi_dist_m.GetPoint(dis_PM);
            Debug.DrawLine(this.transform.position, m);
            Debug.DrawLine(m, hit.point);

            PRFB_targetSelectionUI.transform.position = m;


            */
            #endregion

            positionScale = hit.point - this.transform.position;


            
            ///Gimblo lock may be a lot better to use considering workspace
            #region Quaternion version -- 

            //Debug.Log(target_Q + " | " + positionScale);

            //menu_Q =  target_Q * offsetmenu_q;
            //menu_Q = Quaternion.LookRotation(hit.point) * Quaternion.AngleAxis(Quaternion.Euler(offsetmenu_q.x,offsetmenu_q.y,offsetmenu_q.z), Vector3.left) ;
            menu_Q = Quaternion.Euler(offsetmenu_q) * Quaternion.LookRotation(hit.point, Vector3.up);

            Debug.DrawLine(this.transform.position, hit.point);
            Debug.DrawLine(this.transform.position, PRFB_targetSelectionUI.transform.position);
            Debug.DrawLine(PRFB_targetSelectionUI.transform.position, hit.point);


            n_PosUI = (menu_Q * positionScale) + this.transform.position;

            //n_PosUI.y = this.transform.position.y;
            //n_PosUI.y = Mathf.Clamp(PRFB_targetSelectionUI.transform.position.y, -2.3f, 10);

            PRFB_targetSelectionUI.transform.position = n_PosUI;
            PRFB_targetSelectionUI.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(this.transform.position - n_PosUI), Vector3.up);
            #endregion
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public void SetTargetInfoUI()
    {
        PRFB_targetSelectionUI.GetComponentInChildren<Text>().text = ("Name: " + TargetDetails.npc_details.Name + "\n Age: " + TargetDetails.npc_details.Age);

        for (int i = 0; i < TargetDetails.npc_details.NPC_augments.augmentations.Length; i++)
        {
            if (TargetDetails.npc_details.NPC_augments.augmentations[i] != null)
            {
                PRFB_targetSelectionUI.gameObject.transform.Find("AugmentPanel").GetChild(i).GetChild(0).GetComponent<Text>().text = TargetDetails.npc_details.NPC_augments.augmentations[i].augName;
            }

            if (TargetDetails.npc_details.NPC_augments.augmentations[i] != null && TargetDetails.npc_details.NPC_augments.augmentations[i].GS_illegal == true)
            {
                PRFB_targetSelectionUI.gameObject.transform.Find("AugmentPanel").GetChild(i).GetComponent<Image>().color = Color.red;
                PRFB_targetSelectionUI.gameObject.transform.Find("AugmentPanel").GetChild(i).GetComponent<Image>().sprite = TargetDetails.npc_details.NPC_augments.augmentations[i].UIAugSprite;
            }
            else if (TargetDetails.npc_details.NPC_augments.augmentations[i] != null && TargetDetails.npc_details.NPC_augments.augmentations[i].GS_illegal == false)
            {
                PRFB_targetSelectionUI.gameObject.transform.Find("AugmentPanel").GetChild(i).GetComponent<Image>().sprite = TargetDetails.npc_details.NPC_augments.augmentations[i].UIAugSprite;
                PRFB_targetSelectionUI.gameObject.transform.Find("AugmentPanel").GetChild(i).GetComponent<Image>().color = Color.white;
            }
            else
            {
                PRFB_targetSelectionUI.gameObject.transform.Find("AugmentPanel").GetChild(i).GetComponent<Image>().color = Color.green;
                PRFB_targetSelectionUI.gameObject.transform.Find("AugmentPanel").GetChild(i).GetChild(0).GetComponent<Text>().text = "N/A";
            }
        }
    }

}
