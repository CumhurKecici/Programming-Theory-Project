using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Worker : MonoBehaviour
{

    //Encapsulation
    public int Stamina { get; private set; }
    //Encapsulation
    public JobState JobStatus { get; private set; }

    public enum JobState
    {
        Free,
        Working,
        Completed
    }

    public abstract void StartJob();

    //Abstraction
    public void DecreaseStamina(int value)
    {
        Stamina -= value;
    }
}
