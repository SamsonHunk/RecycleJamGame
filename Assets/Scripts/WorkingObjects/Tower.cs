using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : WorkableObject
{
    BuildingManager manager;
    JobManager jobs;
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
            jobs.CreateNewSkeleton(transform.position, 20, GetComponent<Collider>().bounds.size.x / 2);
            currentWork = workCapacity;
        }
    }
}
