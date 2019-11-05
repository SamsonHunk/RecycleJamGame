using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion
{
    private GameObject parentObject { set; get; }

    public float speed { set; get; }        //Speed stat
    public float lifeTimer { set; get; }    //Life Duration
    public float workSpeed { set; get; }    //Added to work task meter every second
    public float toughness { set; get; }    //HP Stat
    public float recycleEfficiency { set; get; }    //Percentage Bones Dropped

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
