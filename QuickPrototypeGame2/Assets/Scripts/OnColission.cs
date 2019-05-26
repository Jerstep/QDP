using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnColission : MonoBehaviour
{
    public bool wrongChoise;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wrong"))
        {
            wrongChoise = true;
        }
    }
}
