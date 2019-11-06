using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard : MonoBehaviour
{
    BuildingManager buildings;
    // Start is called before the first frame update
    public Grave[] gravePrefabs = new Grave[4];
    public int graveCount = 5;

    //randomly render 10 graves in a grid layout

    void Start()
    {
        buildings = FindObjectOfType<BuildingManager>();
        int rand;
        Vector3 offset;
        for (int y = 0; y < graveCount; y++)
        {
            for (int x = 0; x < graveCount; x++)
            {
                rand = Random.Range(0, 4);
                offset.x = x * 10;
                offset.z = y * 10;
                offset.y = 0;
                if (rand == 1 || rand == 2)
                {
                    buildings.buildings.Add(GameObject.Instantiate(gravePrefabs[rand], offset, Quaternion.Euler(0,180,0), this.transform));
                }
                else
                {
                    buildings.buildings.Add(GameObject.Instantiate(gravePrefabs[rand], offset, Quaternion.identity, this.transform));
                }
            }
        }
    }
}
