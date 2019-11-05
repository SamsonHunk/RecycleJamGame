﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkableObject : InteractableObject
{
    public float workCapacity = 100;
    public int maxWorkers = 99;
    protected List<Minion> minions = new List<Minion>();
    protected bool playerIsWorking = false;
    float timer = 0;
    public float currentWork;
    public bool deletable = false;
    protected PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        currentWork = workCapacity;
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    protected void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            //each second reduce the work value by all the minions currently working the object
            foreach (Minion minion in minions)
            {
                if (minion.isWorking)
                {
                    currentWork -= minion.workSpeed;
                }
            }
            if (playerIsWorking)
            {
                currentWork -= 15;
            }
            timer = 0;
        }

        if ((Input.GetKeyUp(KeyCode.E)) && Vector3.Distance(player.transform.position, this.transform.position) < minDistance)
        {
            player.working = !player.working;
            playerIsWorking = !playerIsWorking;
        }

        if (currentWork <= 0)
        {
            //when work capacity is done minions are set to not busy
            foreach (Minion minion in minions)
            {
                minion.currentCommand = Minion.Commands.Idle;
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
