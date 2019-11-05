using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    JobManager jobManager;
    MinionManager minionManager;
    // Start is called before the first frame update
    void Start()
    {
        jobManager = this.gameObject.GetComponent<JobManager>();
        minionManager = this.gameObject.GetComponent<MinionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            jobManager.AddJob(new Job(GameObject.Find("Test Workable Object").GetComponent<WorkableObject>(), 1));  //TODO: REMOVE
            Debug.Log("Job Created");
        }
    }
}
