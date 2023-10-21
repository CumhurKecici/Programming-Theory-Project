using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Polymorphism
public class Carrier : Worker
{
    void Start()
    {
        //Accessing inherited variables
        Debug.Log("Carrier Stamina: " + Stamina);
        Debug.Log("Carrier Job Status: " + JobStatus);
    }

    public override void StartJob()
    {
        //code for work steps
        DecreaseStamina(10);
    }
}
