using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class NPCReport {

    public string Name = "";
    public int Age = 18;
    public InventoryScript NPC_augments;
    public string priors;
    public NPCDataPoints data;





    BaseNPC Owner;

    //public Waypoint ExitWaypoint;
        

    public InventoryScript GS_NPC_Augments
    {
        get { return NPC_augments; }
        set { NPC_augments = value; }
    }
    // Use this for initialization
    public NPCReport () {
        NPC_augments = new InventoryScript();

        if(data == null)
        {
            data = new NPCDataPoints();

        }

	}
    /// <summary>
    /// names are purely random and are not meant to refer to anyone living or dead
    /// </summary>
    public void RandomSetup()
    {
       

        Name = NameGenerator<string>(false).ToString();
        Debug.Log(Name + Owner.name );

        Age = UnityEngine.Random.Range(18, 90);
        if (data == null)
        {
            data = new NPCDataPoints();
        }
        data = data.GenCredentials(null,this);
        

    }


    public T NameGenerator<T>(bool asArray)
    {
        Debug.Log("names are purely random and are not meant to refer to anyone living or dead");
        string[] genFirstName = new string[]{ "Von","Russ","Octavio","Jeffrey","Wilfred","Jackson","Alva",
                "Kennith","Jamey","Derick","Edgardo","Jonas","John","Wendell","Roosevelt","Palmer","Francesco","Nickolas","Abe",
                "Santos","Marion","Devin","Lenard","Keneth","Aurelio","Darrin","Valentin","Domingo","Osvaldo","Donovan", "Arron"};

        string[] genLastName = new string[] {"Leifker","Sengoku","Mayburn","Gasman","Naxen","Saeko","Brox","Tonnerre","Silus","Holson"
                ,"Grent","Maji","Hassel","Cleaves","Glynda","Uemura","Graw","Harune","Booze","Speers","Takimoto","Jannings"
                ,"Adlers","Wemma","Patri","Tata","Fidelis","Suze","Gennero","Heran","Marians","Scapelli","Torian","Anes","Henrique"
                ,"Haymer","Bruhl","Kuzco","Reaux","Burgermeister","Rosabel","Brueghel","Roseburg","Elora","Pardy","Sergeivich"
                ,"Gurov","Minnick","Keli","Knaus","Litz","Matts","Rokujo","Prindle","Reena","Russos","Abbs","Doragon","Mopps","Losstarot"
                ,"Jarmusch","Sarnoff","Vieux","Bech","Manfield","Brooster","Grieve","Clemence","Langman","Vassey","Arco","Hallis","Salcedo","Andreyev"
                ,"Vinnie","Saika","Valmer","Pelligrino","Macintire","Nassau"};

        if (asArray)
        {
            string[] returnValue;
            returnValue = new string[] { (string)genFirstName[UnityEngine.Random.Range(0, genFirstName.Length - 1)] , (string)genLastName[UnityEngine.Random.Range(0, genFirstName.Length - 1)]};
            return (T)Convert.ChangeType(returnValue, typeof(T));
        }
        else
        {
            string[] returnValue = { genFirstName[UnityEngine.Random.Range(0, genFirstName.Length - 1)], genLastName[UnityEngine.Random.Range(0, genFirstName.Length - 1)] };


            return (T)Convert.ChangeType(String.Join(" ", returnValue),typeof(T));
        }
    }

}




