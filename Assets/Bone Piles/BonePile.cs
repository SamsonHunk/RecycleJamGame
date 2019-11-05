using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePile : MonoBehaviour
{
    GameManager gameManager;

    public Vector3 location { get; set; }
    public float boneAmount { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.RegisterBonePile(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
