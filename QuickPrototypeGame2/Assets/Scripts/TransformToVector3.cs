using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToVector3
{
    public Vector3[] ConvertToVector3(Transform[] transforms)
    {
        Vector3[] converted = new Vector3[transforms.Length];
        for(int i = 0; i < transforms.Length; i++)
        {
            converted[i] = transforms[i].position;
        }
        return converted;
    }
}
