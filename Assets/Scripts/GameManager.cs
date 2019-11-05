using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    JobManager jobManager;
    // Start is called before the first frame update
    void Start()
    {
        jobManager = GameObject.Find("JobManager").GetComponent<JobManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            jobManager.AddJob(new Job(GameObject.Find("Test Workable Object").GetComponent<WorkableObject>(), 1));
            Debug.Log("Job Created");
        }
    }
}
