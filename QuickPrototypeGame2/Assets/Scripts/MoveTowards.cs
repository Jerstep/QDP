using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveTowards
{
    public void MoveTowardsTargets(Vector3[] targets, Vector3 playerPosition, float moveSpeed)
    {
        for(int i = 0; i < targets.Length; i++)
        {
            float dist = Vector3.Distance(playerPosition, targets[i]);
            for(float e = dist; e > 2f; e--)
            {
                playerPosition = Vector3.MoveTowards(playerPosition, targets[i], moveSpeed);
            }
        }
    }
}
