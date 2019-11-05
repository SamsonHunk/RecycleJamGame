using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStatTracker
{

    private static int skeletonLevel = 0;

    public static readonly float[] moveSpeed = new float[3] { 1.0f, 1.25f, 1.5f };
    public static readonly int[] lifeLength = new int[3] { 300, 450, 600 };
    public static readonly int[] workSpeed = new int[3] { 5, 10, 15 };
    public static readonly int[] toughness = new int[3] { 10, 20, 30 };
    public static readonly int[] recyclePercentage = new int[3] { 50, 75, 100 };
    public static readonly int[] boneCost = new int[3] { 10, 9, 8 };
    public static readonly int[] carryCapacity = new int[3] { 6, 8, 10 };

    public static int GetSkeletonLevel()
    {
        return skeletonLevel + 1;
    }
    public static void IncreaseSkeletonLevel()
    {
        if (skeletonLevel < 2)
        {
            ++skeletonLevel;
        }
    }
}



public class GameManager : MonoBehaviour
{
    public List<BonePile> bonePiles = new List<BonePile>();


    public SkeletonStatTracker skeletonStats;
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

    public void RegisterBonePile(BonePile bonePile)
    {
        bonePiles.Add(bonePile);
    }
}
