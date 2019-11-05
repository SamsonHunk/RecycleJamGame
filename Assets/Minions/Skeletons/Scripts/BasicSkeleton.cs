using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSkeleton : MonoBehaviour
{
    Minion skeletonInfo;
    JobManager jobManager; 

    // Start is called before the first frame update
    void Start()
    {
        skeletonInfo = new Minion(this.gameObject);
        jobManager = GameObject.Find("JobManager").GetComponent<JobManager>();
        if(jobManager == null)
        {
            Debug.Log("NO JOB MANAGER FOUND");
        }
        else
        {
            jobManager.Register(ref skeletonInfo);


            //Debug.Log("JobManager testString: " + jobManager.testString);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
