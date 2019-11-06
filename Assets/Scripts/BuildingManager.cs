﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public enum BuildingType { Unassigned, Tower, Grave, GraveHut};


    // Start is called before the first frame update
    public List<WorkableObject> buildings = new List<WorkableObject>();
    JobManager jobManager;

    void Start()
    {
        jobManager = GetComponent<JobManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //--Threw Errors when deleting objects--

        //foreach (WorkableObject building in buildings)
        //{
        //    if (building.deletable)
        //    {//if the building needs to be deleted, destroy it
        //        Debug.Log("Deleting Grave");
        //        buildings.Remove(building);
        //        Destroy(building.gameObject);
        //    }
        //}

        for(int i = 0; i < buildings.Count; ++i)
        {
            if (buildings[i].deletable)
            {//if the building needs to be deleted, destroy it
                Debug.Log("Deleting Grave");
                buildings.Remove(buildings[i]);
                Destroy(buildings[i].gameObject);
                --i;
                if(i == buildings.Count)
                {
                    break;
                }
            }

        }

    }
    public void upgrade(WorkableObject building, int minions)
    {//function to add upgrade job to list
        jobManager.AddJob(new Job(building, minions));
    }
}
