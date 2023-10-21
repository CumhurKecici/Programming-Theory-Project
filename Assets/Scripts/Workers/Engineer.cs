using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Polymorphism
public class Engineer : Worker
{
    void Start()
    {
        //Accessing inherited variables
        Debug.Log("Engineer Stamina: " + Stamina);
        Debug.Log("Engineer Job Status: " + JobStatus);
    }

    public override void StartJob()
    {
        //code for work steps
        DecreaseStamina(5);
    }
}
