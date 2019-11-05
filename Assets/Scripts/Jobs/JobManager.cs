using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobManager : MonoBehaviour
{
    public readonly string testString = "Spooky Scary";
    public GameObject skeletonPrefab;
    //public GameObject zombeiePrefab;

    List<Job> jobs = new List<Job>();
    List<Minion> registeredMinions;

    // Start is called before the first frame update
    void Start()
    {
        registeredMinions = GameObject.Find("GameManager").GetComponent<MinionManager>().minions;
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
                    Debug.Log("Minion assigned to job!");
                    registeredMinions[j].SetBusy(true);
                    registeredMinions[j].SetDestination(jobs[i].workObject.gameObject.GetComponent<Transform>().position);  //Set minion destination equal to object position
                    if (jobs[i].AssignMinion(registeredMinions[j]))
                    {  
                        //Returns true if job full so remove from list and update position in list
                        jobs.RemoveAt(i);
                        i--;
                        //If at end of list break
                        if(i == jobs.Count)
                        {
                            break;
                        }
                    }
                    
                }
            }
        }
    }

    public void CreateNewSkeleton()
    {
        Instantiate(skeletonPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void AddJob(Job job)
    {
        jobs.Add(job);
    }
}
