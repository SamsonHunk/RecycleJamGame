using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionManager : MonoBehaviour
{
    public List<Minion> minions = new List<Minion>();

    public void Register(Minion minionToAdd)
    {
        minions.Add(minionToAdd);
        Debug.Log("New Minion Registered\n" + "Number of Minions Registered: " + minions.Count.ToString());
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
