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

    private bool busy;
    
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

    private bool hasDestination;    //True as long as the minion has a destination and hasn't arrived
    private Vector3 destination;   //The Vec3 destination to travel towards

    float proximityThreshold = 0.01f;   //How close the minion has to be to the destination to be considered as arrived

    Minion()
    {
        hasDestination = false;
        destination = new Vector3(0, 0, 0);
        busy = false;
        speed = 0.5f;
    }


    public void Update(float deltaTime)
    {
        lifeTimer -= deltaTime;
        if(hasDestination)
        {
            //Move towards destination
            Vector3 previous = parentObject.GetComponent<Transform>().transform.position;
            Vector3 newDest = Vector3.MoveTowards(parentObject.GetComponent<Transform>().transform.position, destination, speed * deltaTime);

            parentObject.transform.position = newDest;//Vector3.MoveTowards(parentObject.GetComponent<Transform>().transform.position, destination, speed * deltaTime);
            if(Vector3.Distance(parentObject.GetComponent<Transform>().transform.position, destination) < proximityThreshold )
            {
                hasDestination = false;
                destination = new Vector3(0, 0, 0);
            }
        }
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        hasDestination = true;
        speed = 0.5f;
    }
}
