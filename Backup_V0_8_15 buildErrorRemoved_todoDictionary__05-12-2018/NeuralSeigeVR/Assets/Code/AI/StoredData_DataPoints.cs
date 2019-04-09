using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Associate
{
    public string name, Relation, Occupation, priors;
    
}
[System.Serializable]
public class Weightings
{
    [SerializeField]
    public int normal = 0;
    [SerializeField]
    public int redHerring = 0;
    [SerializeField]
    public int Target = 0;

    //public Weightings(int lenght)
    //{
    //    normal = new int[lenght];
    //    redHerring = new int[lenght];
    //    Target = new int[lenght];
    //}
}
public class WeightedItem
{
    public Weightings weight;
    public string item;
    

    public WeightedItem()
    {
        weight = new Weightings
        {
            normal = 0,
            redHerring = 0,
            Target = 0
        };

        item = "";
    }
}

public static class StoredData_DataPoints
{
    public static System.Random RNG = new System.Random();

    public static string[] Datatypes = new string[] {"RelationType","Occupation","Priors","Licences","Education","OnlineSearchs","NPCContent","Income","Posts"};

    //Normal,Redherrings,Targets must be reorganised
    //10
    public static string[] RelationType = new string[] {    "Father" , "Mother", "Sibling", "Partner","Associate", "Cousin", "Aunt", "Uncle", "Friend", "Co-worker"};
    //39
    public static string[] Occupation = new string[] {      "Store clerk", "Mercenary", "Unknown", "Student", "CEO", "Street merchant", "Drone engineer","Programmer",
                                                            "CSpace Developer","Cspace Artist","Musician","Store Manager","Online retailer","Military", "Vertcal Farmer Operator", "Nurse", "Doctor", 
                                                            "unemployed", "Therapist", "Mechanic", "Accountant", "Lab Technician", "Loader", "Bartender", "Chemist",
                                                            "Augment Technicion/Augment Smith", "Dentist", "Data Entry Clerk", "Cook", "Teacher", "Receptionist", "Security Specialist",
                                                            "Retail", "Self Employed", "Other", "Graphic Artist", "Distribution Supervisor", "Botanist", "chief", 
                                                     };
    //42
    public static string[] Priors = new string[] {          "Charity Fraud", "Breaking and Entering", "Theft", "Protesting", "Redacted", "Conspiracy", "Assasination", "None", "Murder",
                                                            "Violent Protesting", "Illegal Immergrant", "Missing Entry", "Drone Hacking", "Car hacking", "Hacking", "Server farm hacking",
                                                            "Media manipulation", "Blackmail", "Industrial Espionage", "Augmentation Hacking", "Illegal Augmentation",
                                                            "Illegal Drug manufacturing", "Illegal arms trade", "Malware production", "Identity theft", "Vanderlism", "Corporate Espionage",
                                                            "Arson", "Extortion", "Embezzlement", "Bribery", "Assault", "Sexual Assault", "Burglary", "Tax Evasion", "Terrorism", "Smuggling",
                                                            "Manslaughter", "Possessing Stolen Property", "Licence Fraud", "Education Fraud", "Illegal Deep Web services", "Intellectual property theft",
                                                            "","",""
    };

    public static string[] Licences = new string[] {        "Work ", "Public ", "Heavy work ", "Social ", "deadly Weapons ", "Small arms ", "Entertainment ", "Corporate ", "Medical ","no " };


    public static string[] Education = new string[]{        "Secondary ", "Private Primary", "AI training", "AI educated", "University", "Self Taught", "Unknown", "Primary", "CSpace Lectures", "Private Secondary", "Direct Download" };
    //46
    public static string[] OnlineSearchs = new string[] {   "What is a solar Event","What caused the war?","Why are we in a dome?","What is Adam?","What are AI?","how to get laid",
                                                            "How to make a gun","gun 3D print", "Tech sales", "Where can I get a gun?", "how to grow plants?", "Who won the 2062 EGames?",
                                                            "why did the world to die?", "How to get a "+/* Licences[RNG.Next(0,Licences.Length-1)] +*/" Augment licence", "What is the darknet", "What is the deep web", "What are you(Android)?",
                                                            "How are Babies made?", "How are AI made?", "Local Jobs", "Porn", "CSpace", "VR Kit", "buy water", "Pharmacies in my area", "Dentists in my area", "MePipe Music",
                                                            "True Horizon jobs", "HEI jobs", "how to hack", "learn programming", "Whats outside the dome?", "Augmenter Smith in my area", "How to get an Augment Licences",
                                                            "Mine dogeCoin","tram time","CSpace Hosting", "3D Printer service",  "2nd hand Androids for sale", "Lofi Chill", "Who are the Ceers?","Lux Living", "Hydrogen News", "PresentNews",
                                                            "Merc Work"
                                                        };
    //22
    public static string[] NPCContent = new string[] {      "Anon News", "BreakingConspiracy", "'#Anti corporatocracy media'", "FakeScienceNN", "God@HomeNN", "'#Anarchistic media'", "'#Dystopian media'", "'#Communistic media'",
                                                            "'#Anti NeoLibral Media'", "TrueHorizonNN", "Braun Solar Sports Network", "'#Holistic Science'", "WebCinen", "'#HistoricalMedia'", "'#transhuman media'", "'#Celeb Gossip'",
                                                            "Present News", "Star News", "'#Esports'", "'#music'", "'#Alternative music'", "MusiCalSpace", "", "", ""
                                                     };


    /// <summary>
    /// God if i have a keylogger they are really wondering what the fuck im doing lol. 
    /// this is going to be one of the most important features of the random generator.
    /// this must be implemented in such a way to determine the rest of a random npc's idenity
    /// </summary>
    public static int[] Income = new int[]           {      -1,0,7500, 15000, 25000, 40000, 60000, 85000, 120000 };


    //redherrings, Targets
    /// <summary>
    /// any thing is this part is purely fictional and i dissagree fully with most if not all of these statements any connection to real life is purely coincedental
    /// though i still believe in free speech, i very much disagree with hate speech.
    /// </summary>
    ///18
    public static string[] Posts = new string[] {           "I'm going to kill my boss, he is the worst", "Can some one lend me a gun, im going to kill my co-worker", "Nazi's werent that bad",
                                                            "//Be me at work \n//see hottie \n//ask her number \n//get rejected\n//Track her on CSpace \n//find out shes a terf\n//dodge bullet\n//she didnt",
                                                            "They Deserved it", "I'm going to start growing weed, cant deal with so little money", "Wheres the next def wolves meet up", "I want too join the Ceers",
                                                            "Guys how do i build a bomb", "Cant stand this job anymore", "im done with people", "What is love, baby dont hurt me, Dont hurt me now more",
                                                            "Follow the white rabbit", "death is only the beginning.", "Soon we will take back this city", "Augs are so fucked up", "YTF would you want to become a aug, like its perverting humanity",
                                                            "this is a love crusade", "", "", "", };



  




    /// <summary>
    /// dynamically return a list with the correct weighting for the sector 
    /// as determined by the game controller
    /// 
    /// https://dotnetcodr.com/2014/10/17/dynamically-finding-the-value-of-a-static-field-with-reflection-in-net-c/
    /// </summary>
    /// <param name="weighting">class of arrays of weightings for the different arrays above</param>
    /// <param name="dataSet">which data set you wish to use: RelationType, Occupation,
    /// Priors, and anyothers that need to be implemented(please replace when written) </param>
    /// <returns></returns>
    public static List<WeightedItem> InitilizeSystem (Weightings[] weighting, String dataSet)
    {
        List<WeightedItem> tempList = new List<WeightedItem>();
        Debug.Log("Reflections DP string: " + dataSet);
        Type this_class = Type.GetType("StoredData_DataPoints");// using reflections to dynamically build a list for the 
        System.Reflection.FieldInfo stringtype = this_class.GetField(dataSet);//game controller for spawning npcs with data for the current sector
        WeightedItem temp = new WeightedItem();

        if (stringtype.FieldType == typeof(int[]))
        {
            int[] fieldFind = (int[])stringtype.GetValue(null);
            for (int i = 0; i < fieldFind.Length; i++)
            {

                //Debug.Log("Potato 1C Rep || i: " + i + " | " + dataSet + " | curr: " + fieldFind[i]);
                temp.weight.normal = weighting[i].normal;
                temp.weight.redHerring = weighting[i].redHerring;
                temp.weight.Target = weighting[i].Target;
                temp.item = fieldFind[i].ToString();

                tempList.Add(temp);
            }
        }
        else
        {
            string[] fieldFind = (string[])stringtype.GetValue(null);
            for (int i = 0; i < fieldFind.Length; i++)
            {

                Debug.Log("Potato 1C Rep || i: " + i + " | " + dataSet + " | curr: " + fieldFind[i]);
                temp.weight.normal = weighting[i].normal;
                temp.weight.redHerring = weighting[i].redHerring;
                temp.weight.Target = weighting[i].Target;
                temp.item = fieldFind[i];

                tempList.Add(temp);
            }
        }
        
        


        return tempList;

    }
    /// <summary>
    /// requires reworking
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="varibleName"></param>
    /// <returns></returns>
    public static T GetVeriName<T>(string varibleName)
    {
        Type this_class = Type.GetType("StoredData_DataPoints");// using reflections to dynamically build a list for the 
        System.Reflection.FieldInfo stringtype = this_class.GetField(varibleName);//game controller for spawning npcs with data for the current sector
        T fieldFind = (T)stringtype.GetValue(null);
        return fieldFind;
    }
        

    /// <summary>
    /// 
    /// Random Ramblings, Reviews and Remarks
    /// https://caspiancanuck.wordpress.com/2011/04/01/weightedrandom/
    /// 
    /// 
    /// <summary>
    /// Returns an object of type T randomly selected from the specified list 
    /// based on its weight (statistical frequency of occurrence).
    /// </summary>
    /// <param name="list">A collection whose values are the objects to be 
    /// randomly returned and whose keys are their distribution weights.</param>
    /// <returns></returns>
    public static T WeightedRandom<T> (SortedList<int, T> list)
    {
        int max = list.Keys[list.Keys.Count - 1];
        int random = RNG.Next(max);
        foreach (int key in list.Keys)
        {
            if (random <= key)
                return list[key];
        }
        return default(T);
    }

}



