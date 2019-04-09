using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New SetNPCDataPoints")]
public class NPCDataPoints : UnityEngine.Object
{

    NPCReport m_parent;
    //known associates
    public Associate[] Family, WorkCol, Friends;

    //licenses
    public string[] licenses;


    //priors
    public int Priors;//used to create array lenghts
    public int[] prisonTime;
    public string[] crimeType;

    //class
    public int _class, income, bankBalance, citizenPoints;
    public string[] education;

    //Online Persona
    public int alerts;
    public string[] personaName, posts;

    //hobbies
    public string[] onlineSearchs, NPCContent;

    public NPCDataPoints GenCredentials(string name, NPCReport parent)
    {
        m_parent = parent;

        if (name == null)
        {
            int randint;
            randint = UnityEngine.Random.Range(0, 5);
            Family = new Associate[randint];

            for (int i = 0; i < Family.Length - 1; i++)
            {

                Family[i].name = m_parent.Name;
                string[] fname = Family[i].name.Split(new string[] { " " }, StringSplitOptions.None);
                fname[0] = m_parent.NameGenerator<String[]>(true)[0];
                Family[i].name = string.Join(" ", fname);



            }
        }
        if (name != null)
        {
            return Resources.Load<NPCDataPoints>("Predefined NPC's/" + name);

        }

        return this;

    }


}

