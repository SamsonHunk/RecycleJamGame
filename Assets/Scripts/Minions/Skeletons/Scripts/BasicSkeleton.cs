using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSkeleton : Minion
{
    MinionManager minionManager;

    // Start is called before the first frame update
    void Start()
    {
        minionManager = FindObjectOfType<MinionManager>();
        if(minionManager != null)
        {
            minionManager.Register(this);            
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
