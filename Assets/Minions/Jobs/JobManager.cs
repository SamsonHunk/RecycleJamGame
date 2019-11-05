﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobManager : MonoBehaviour
{
    public readonly string testString = "Spooky Scary";
    public GameObject skeletonPrefab;
    //public GameObject zombeiePrefab;

    List<Minion> registeredMinions = new List<Minion>();
    List<Job> jobs = new List<Job>();

    public void Register(ref Minion minionToAdd)
    {
        registeredMinions.Add(minionToAdd);
        Debug.Log("New Minion Registered\n" + "Number of Minions Registered: " + registeredMinions.Count.ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FillJobs();
        if(Input.GetKeyDown(KeyCode.S))//TODO: TAKE ME OUT
        {
            CreateNewSkeleton();
        }
    }

    void FillJobs()
    {
        //For each job
        for(int i = 0; i < jobs.Count; ++i)
        {
            //For each minion
            for(int j = 0; j < registeredMinions.Count; ++j)
            {
                //Check job requirements against minion
                if(!registeredMinions[j].IsBusy())  //Only if not busy for now
                {
                    //Assign to interactible here
                    registeredMinions[j].SetBusy(true);
                }
            }
        }
    }

    public void CreateNewSkeleton()
    {
        Instantiate(skeletonPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}