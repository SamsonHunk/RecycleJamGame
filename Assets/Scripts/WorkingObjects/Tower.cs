using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : WorkableObject
{
    BuildingManager manager;
    JobManager jobs;
    MinionManager minionManager;
    public int tier = 0;
    public int bones = 10;
    Canvas menu;
    public Text workerCount;

    // Start is called before the first frame update
    void Start()
    {
        menu = GetComponentInChildren<Canvas>();
        menu.gameObject.SetActive(false);
        manager = FindObjectOfType<BuildingManager>();
        jobs = FindObjectOfType<JobManager>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        currentWork = workCapacity;
        minionManager = FindObjectOfType<MinionManager>();
    }



    protected override void objectUpdate()
    {
        workerCount.text = minions.Count.ToString() + "/" + maxWorkers.ToString();
    }

    protected override void OnMouseDown()
    {
        //when clicked open the building menu only if the player is close enough
        if (Vector3.Distance(player.transform.position, this.transform.position) < minDistance)
        {
           menu.gameObject.SetActive(true);
        }
    }

     

    public void upgrade()
    {

    }

    public void buildSkeleton()
    {
        if (bones >= 10 && currentWork <= 0)
        {
            jobs.CreateNewSkeleton(transform.position, 2, GetComponent<Collider>().bounds.size.x / 20);
            currentWork = workCapacity;
            bones -= 10;
        }
    }

    public override void AddMinionButton()
    {
        Debug.Log("Got call to work tower");
        if (minions.Count < maxWorkers)
        {
            for (int it = 0; it < minionManager.minions.Count; it++)
            {
                if (minionManager.minions[it].currentCommand == Minion.Commands.Idle)
                {
                    minionManager.minions[it].currentCommand = Minion.Commands.Job;
                    minionManager.minions[it].SetDestination(this.transform.position);
                    minionManager.minions[it].targetWorkplace = this;
                    this.AssignMinion(minionManager.minions[it]);
                }
            }
        }
    }
}
