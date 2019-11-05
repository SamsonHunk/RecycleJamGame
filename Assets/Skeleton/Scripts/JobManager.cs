using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobManager : MonoBehaviour
{
    public readonly string testString = "Spooky Scary";

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
    }

    void FillJobs()
    {
        //For each job
        //Check job requirements against list of skeletons

        //If check succeeds
        //Start job
        //Set skeletons as busy and to work
    }
}
