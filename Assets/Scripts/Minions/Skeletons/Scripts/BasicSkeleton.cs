using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSkeleton : MonoBehaviour
{
    public Minion skeletonInfo;
    MinionManager minionManager; 

    // Start is called before the first frame update
    void Start()
    {
        skeletonInfo = new Minion(this.gameObject);
        minionManager = GameObject.Find("GameManager").GetComponent<MinionManager>();
        if(minionManager != null)
        {
            minionManager.Register(ref skeletonInfo);            
        }
        else
        {
            Debug.Log("NO MINION MANAGER FOUND");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
