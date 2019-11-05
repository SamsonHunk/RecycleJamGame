using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : WorkableObject
{
    protected override void objectUpdate()
    {
        if (currentWork < 0)
        {//if the grave has been dug up spawn a corpse and despawn the grave
            
        }
    }
}
