using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : WorkableObject
{
    Vector3 towerPosition;
    public int corpseCounter;

    private void Start()
    {
        towerPosition = GameObject.Find("Tower").GetComponent<Tower>().gameObject.transform.position;
        Debug.Log("Grave Start Tower Pos: " + towerPosition.ToString());
        corpseCounter = 4;
        buildingType = BuildingManager.BuildingType.Grave;
        maxWorkers = 3;
    }

    protected override void objectUpdate()
    {
        if (currentWork < 0)
        {//if the grave has been dug up spawn a corpse and despawn the grave
            --corpseCounter;
            currentWork = workCapacity;

            for (int i = 0; i < minions.Count; ++i)
            {
                if (minions[i].isWorking)
                {
                    minions[i].currentCommand = Minion.Commands.Deposit;
                    minions[i].SetDestination(towerPosition);
                    minions[i].isWorking = false;
                    minions[i].carryAmount = 6;
                }
                //If grave depleted
                if (corpseCounter == 0)
                {
                    //Make each other worker idle
                    int depositingWorker = i;
                    for (int j = 0; j < minions.Count; ++j)
                    {
                        if (j != i)
                        {
                            minions[j].currentCommand = Minion.Commands.Idle;
                            minions[j].isWorking = false;
                        }
                    }

                    Debug.Log("Grave Emptied");

                    //Mark self for deletion
                    deletable = true;
                }
                else
                {
                    break;
                }
            }
        }
    }
}