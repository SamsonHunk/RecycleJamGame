using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    Tower tower;
    public BonePile targetPile { set; get; }
    public WorkableObject targetWorkplace { set; get; }
    public BonePile bonePilePrefab;

    MinionManager minionManager;

    public enum Commands { Job, PickUp, Deposit, Idle};
    public bool isWorking {set; get; }   
    public float speed { set; get; }        //Speed stat
    public float lifeTimer { set; get; }    //Life Duration
    public float workSpeed { set; get; }    //Added to work task meter every second
    public float toughness { set; get; }    //HP Stat
    public float recyclePercentage { set; get; }    //Percentage Bones Dropped
    public float carryCapacity { set; get; }    //Max amount carryable
    public float carryAmount { set; get; }  //Current amount carried

    public Commands currentCommand { set; get; }

    protected void Start()
    {
        minionManager = GameObject.Find("GameManager").GetComponent<MinionManager>();
        minionManager.Register(this);

        hasDestination = false;
        destination = new Vector3(0, 0, 0);
        tower = GameObject.Find("Tower").GetComponent<Tower>();

        //Get stats according to skeleton level
        speed = SkeletonStatTracker.moveSpeed[SkeletonStatTracker.GetSkeletonLevel()];
        lifeTimer = SkeletonStatTracker.lifeLength[SkeletonStatTracker.GetSkeletonLevel()];
        workSpeed = SkeletonStatTracker.workSpeed[SkeletonStatTracker.GetSkeletonLevel()];
        toughness = SkeletonStatTracker.toughness[SkeletonStatTracker.GetSkeletonLevel()];
        recyclePercentage = SkeletonStatTracker.recyclePercentage[SkeletonStatTracker.GetSkeletonLevel()];
        carryCapacity = SkeletonStatTracker.carryCapacity[SkeletonStatTracker.GetSkeletonLevel()];

        currentCommand = Commands.Idle;

        gameObject.GetComponent<Canvas>().worldCamera = GameObject.Find("Canmera").GetComponent<Camera>();
    }

    private bool hasDestination;    //True as long as the minion has a destination and hasn't arrived
    private Vector3 destination;   //The Vec3 destination to travel towards

    float proximityThreshold = 0.01f;   //How close the minion has to be to the destination to be considered as arrived

    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if(hasDestination)
        {
            //Move towards destination
            this.transform.position = Vector3.MoveTowards(this.GetComponent<Transform>().transform.position, destination, speed * Time.deltaTime);
            if (Vector3.Distance(this.GetComponent<Transform>().transform.position, destination) < proximityThreshold )
            {
                //We've arrived
                hasDestination = false;
                destination = new Vector3(0, 0, 0);

                //SWITCH BASED ON COMMAND
                switch (currentCommand)
                {
                    case Commands.Job:
                        //Start Working on the target job
                        isWorking = true;
                        break;
                    case Commands.Deposit:
                        Deposit();
                        break;
                    case Commands.PickUp:
                        PickUp();
                        break;
                    case Commands.Idle:
                        //Probably shouldn't happen unless job is lost while travelling toward it
                        break;
                    default:
                        Debug.Log("Error: Hit Debug in switch statement");
                        break;
                }

            }
        }

        if (lifeTimer <= 0)
        {
            Expire();
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
        if (targetPile.boneAmount > carryCapacity)
        {
            targetPile.boneAmount -= carryCapacity;
            carryAmount = carryCapacity;
            targetPile.hasPickUp = false;
        }
        else
        {
            carryAmount = targetPile.boneAmount;
            GameObject.Destroy(targetPile.gameObject);
        }

        hasDestination = true;
        destination = tower.GetComponent<Transform>().position;
        targetPile = null;
        currentCommand = Commands.Deposit;
    }
    //Deposit carried materials, returns amount carried and sets held amount to 0
    public int Deposit()
    {
        tower.bones += (int)carryAmount;
        carryAmount = 0;
        currentCommand = Commands.Idle;
        return 0;
    }

    //When timer runs out leave behind bone pile according to efficiency stat
    private void Expire()
    {
        //Instantiate bone pile prefab at current location then destroy self
        BonePile.Instantiate(bonePilePrefab, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);
        if(targetPile != null)
        {
            targetPile.hasPickUp = false;
        }
    }
}
