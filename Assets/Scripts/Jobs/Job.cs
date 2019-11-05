using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job
{
    public readonly WorkableObject workObject;

    private int numberOfMinionsToAssign;


    public Job(WorkableObject workObject, int numberOfMinionsToAssign)
    {
        this.workObject = workObject;
        this.numberOfMinionsToAssign = numberOfMinionsToAssign;
    }

    //Retruns true if job has been fulfilled
    public bool AssignMinion(Minion minion)
    {
        workObject.AssignMinion(minion);
        numberOfMinionsToAssign--;
        if (numberOfMinionsToAssign == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
