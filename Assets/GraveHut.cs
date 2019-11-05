using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraveHut : WorkableObject
{
    JobManager jobs;
    Canvas menu;
    public Text workerCount;
    BuildingManager buildingManager;
    MinionManager minionManager;
    List<Minion> registeredMinions;

    // Start is called before the first frame update
    void Start()
    {
        jobs = FindObjectOfType<JobManager>();
        menu = GetComponentInChildren<Canvas>();
        currentWork = workCapacity;
        player = FindObjectOfType<PlayerController>();
        buildingManager = GameObject.Find("GameManager").GetComponent<BuildingManager>();
        minionManager = GameObject.Find("GameManager").GetComponent<MinionManager>();
        registeredMinions = minionManager.minions;
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

    public override void AddMinionButton()
    {
        //Get a grave
        foreach (Grave grave in buildingManager.buildings)
        {
            //Assign a minion to work on the grave
            //For each minion
            for (int j = 0; j < registeredMinions.Count; ++j)
            {
                //Check job requirements against minion
                if (registeredMinions[j].currentCommand == Minion.Commands.Idle)  //Only if not busy for now
                {
                    Debug.Log("Minion assigned to a grave!");
                    registeredMinions[j].currentCommand = Minion.Commands.Job;
                    registeredMinions[j].SetDestination(grave.gameObject.GetComponent<Transform>().position);  //Set minion destination equal to object position
                    registeredMinions[j].targetWorkplace = grave;
                    grave.AssignMinion(registeredMinions[j]);
                }
            }
        }
    }
}
