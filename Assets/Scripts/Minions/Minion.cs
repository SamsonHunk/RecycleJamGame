using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion
{
    public bool isOnJob { set; get; }
    public bool isWorking {set; get; }

    private GameObject parentObject { set; get; }
   
    public float speed { set; get; }        //Speed stat
    public float lifeTimer { set; get; }    //Life Duration
    public float workSpeed { set; get; }    //Added to work task meter every second
    public float toughness { set; get; }    //HP Stat
    public float recyclePercentage { set; get; }    //Percentage Bones Dropped
    public float carryCapacity { set; get; }    

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
        hasDestination = false;
        destination = new Vector3(0, 0, 0);
        busy = false;

        //Get stats according to skeleton level
        speed = SkeletonStatTracker.moveSpeed[SkeletonStatTracker.GetSkeletonLevel()];
        lifeTimer = SkeletonStatTracker.lifeLength[SkeletonStatTracker.GetSkeletonLevel()];
        workSpeed = SkeletonStatTracker.workSpeed[SkeletonStatTracker.GetSkeletonLevel()];
        toughness = SkeletonStatTracker.toughness[SkeletonStatTracker.GetSkeletonLevel()];
        recyclePercentage = SkeletonStatTracker.recyclePercentage[SkeletonStatTracker.GetSkeletonLevel()];
        carryCapacity = SkeletonStatTracker.carryCapacity[SkeletonStatTracker.GetSkeletonLevel()];
    }

    private bool hasDestination;    //True as long as the minion has a destination and hasn't arrived
    private Vector3 destination;   //The Vec3 destination to travel towards

    float proximityThreshold = 0.01f;   //How close the minion has to be to the destination to be considered as arrived

    public void Update(float deltaTime)
    {
        lifeTimer -= deltaTime;
        if(hasDestination)
        {
            //Move towards destination
            parentObject.transform.position = Vector3.MoveTowards(parentObject.GetComponent<Transform>().transform.position, destination, speed * deltaTime);
            if (Vector3.Distance(parentObject.GetComponent<Transform>().transform.position, destination) < proximityThreshold )
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
    }

    //Pick up materials on the ground
    public void PickUp()
    {

    }
    //Deposit carried materials, returns amount carried and sets held amount to 0
    public int Deposit()
    {
        return 0;
    }

    //When timer runs out leave behind bone pile according to efficiency stat
    private void Expire()
    {
        //Instantiate bone pile prefab at current location then destroy self
        GameObject.Destroy(parentObject);
    }


}
