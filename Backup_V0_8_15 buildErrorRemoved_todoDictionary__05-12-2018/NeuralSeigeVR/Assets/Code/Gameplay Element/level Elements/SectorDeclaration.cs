using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[CreateAssetMenu(fileName = "New Sector Declaration")]
[System.Serializable]
public class SectorDeclaration : ScriptableObject {

    public SectorTypes sectorType;

    public Weightings[] WeightingRelation = new Weightings[StoredData_DataPoints.RelationType.Length];

    public Weightings[] WeightingOccupation = new Weightings[StoredData_DataPoints.Occupation.Length];

    public Weightings[] WeightingPriors = new Weightings[StoredData_DataPoints.Priors.Length];

    public Weightings[] WeightingLicences = new Weightings[StoredData_DataPoints.Licences.Length];

    public Weightings[] WeightingEducation = new Weightings[StoredData_DataPoints.Education.Length];

    public Weightings[] WeightingOnlineSearchs = new Weightings[StoredData_DataPoints.OnlineSearchs.Length];

    public Weightings[] WeightingNpcContent = new Weightings[StoredData_DataPoints.NPCContent.Length];

    public Weightings[] WeightingIncome = new Weightings[StoredData_DataPoints.Income.Length];

    public Weightings[] WeightingPosts = new Weightings[StoredData_DataPoints.Posts.Length];

    public string[] dataTypes = new string[] { "WeightingRelation", "WeightingOccupation", "WeightingPriors", "WeightingLicences", "WeightingEducation", "WeightingOnlineSearchs", "WeightingNpcContent", "SkjAbd", "WeightingPosts" };


    /// <summary>
    /// 
    /// </summary>
    /// stupidity saved by DMGregory -- stackExchange
    /// <param name="variableName"></param>
    /// <returns></returns>
    public Weightings[] GetVariName(string variableName)
    {
        Debug.Log("Reflections SD string: " + variableName);
        Type this_class = Type.GetType("SectorDeclaration");// using reflections to dynamically build a list for the 
        System.Reflection.FieldInfo fieldtype = this_class.GetField(variableName);
        Debug.Log("Reflections SD fieldtype: " + fieldtype);
        Weightings[] fieldFind = (Weightings[])fieldtype.GetValue(this);
        return (Weightings[])fieldFind;

    }


}

