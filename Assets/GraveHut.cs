using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraveHut : WorkableObject
{
    JobManager jobs;
    Canvas menu;
    public Text workerCount;
    // Start is called before the first frame update
    void Start()
    {
        jobs = FindObjectOfType<JobManager>();
        menu = GetComponentInChildren<Canvas>();
        currentWork = workCapacity;
        player = FindObjectOfType<PlayerController>();
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

    
}
