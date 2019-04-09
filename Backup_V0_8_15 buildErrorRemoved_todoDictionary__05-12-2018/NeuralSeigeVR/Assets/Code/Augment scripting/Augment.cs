using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Aug_Placement
{
    head,
    body,
    lftArm,
    rghtArm,
    lftLeg,
    rghtLeg,
    hdAccssry,
    bckAccssry
}

/// <summary>
/// basic inventory script
/// 
/// 
/// </summary>
[CreateAssetMenu(fileName = "New Augment")]
[System.Serializable]
public class Augment : ScriptableObject
{
    //public GameObject augMesh;
    public Sprite UIAugSprite;
    public string augName;
    public Aug_Placement placement;
    public bool illegal;
    public int licenseLevel;
    public float size;
    public string Licence;



    public string GS_name
    {
        get { return name; }
        set { name = value; }
    }
    public Aug_Placement GS_placement
    {
        get { return placement; }
        set { placement = value; }
    }
    public bool GS_illegal
    {
        get { return illegal; }
        set { illegal = value; }
    }



}