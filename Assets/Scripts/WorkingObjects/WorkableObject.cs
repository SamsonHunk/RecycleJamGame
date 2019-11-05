using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkableObject : InteractableObject
{
    public float workCapacity = 100;
    public int maxWorkers = 99;
    protected List<Minion> minions = new List<Minion>();
    float timer = 0;
    public float currentWork;
    public bool deletable = false;

    // Start is called before the first frame update
    void Start()
    {
        currentWork = workCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            //each second reduce the work value by all the minions currently working the object
            foreach (Minion minion in minions)
            {
                currentWork -= minion.workSpeed;
            }
            timer = 0;
        }

        if (currentWork <= 0)
        {
            //when work capacity is done minions are set to not busy
            foreach (Minion minion in minions)
            {
                minion.SetBusy(false);
            }
        }

        objectUpdate();
    }

    public void AssignMinion(Minion minion)
    {
        minions.Add(minion);
    }

    protected virtual void objectUpdate()
    {

    }
}
