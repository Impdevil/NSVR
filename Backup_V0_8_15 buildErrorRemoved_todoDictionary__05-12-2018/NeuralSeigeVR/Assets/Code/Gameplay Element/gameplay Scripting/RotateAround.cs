﻿
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateAround : MonoBehaviour
{


    public GameObject target;
    public int speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
