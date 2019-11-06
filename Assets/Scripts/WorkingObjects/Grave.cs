using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : WorkableObject
{
    public int corpseCounter;
    Grave()
    {
        corpseCounter = 4;
    }


    protected override void objectUpdate()
    {
        if (currentWork < 0)
        {//if the grave has been dug up spawn a corpse and despawn the grave
            --corpseCounter;
            for (int i = 0; i < minions.Count; ++i)
            {
                if (minions[i].isWorking)
                {
                    minions[i].currentCommand = Minion.Commands.Deposit;
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
                        }
                    }

                    //Destroy self
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