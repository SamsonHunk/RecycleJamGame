using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobRequirements
{
    //Jobs can have any number of requirements including 0
    //Jobs are only intiated if all requirements are filled
    struct Requirement
    {
        int numberRequired;

        public void Init(bool typeRequired, int number)
        {
            numberRequired = number;
        }
    }
}
