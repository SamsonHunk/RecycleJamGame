using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion
{
    private GameObject parentObject { set; get; }

    float speed { set; get; }        //Speed stat
    float lifeTimer { set; get; }    //Life Duration
    float workSpeed { set; get; }    //Added to work task meter every second
    float toughness { set; get; }    //HP Stat
    float recycleEfficiency { set; get; }    //Percentage Bones Dropped

    private bool busy = false;
    
    public bool IsBusy()
    {
        return busy;
    }
    public void SetBusy(bool toSet)
    {
        busy = toSet;
    }

    public Minion(GameObject parentObject)
    {
        this.parentObject = parentObject;
    }
}
