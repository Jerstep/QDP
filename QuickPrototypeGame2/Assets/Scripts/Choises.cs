using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choises : MonoBehaviour
{
    public List<GameObject> pipes;
    public List<GameObject> pipes2;

    public Renderer[] childrenRenders;
    public GameObject buttons;

    private int choiseState = 0;

    private void Start()
    {
        SetRandom();
    }

    public void SetRandom()
    {
        Debug.Log("SetRandom");
        ResetAllColors(pipes);
        int randomIndex = Random.Range(0, pipes.Count);
        for(int i = 0; i < pipes.Count; i++)
        {
            pipes[i].GetComponentInParent<Pipes>().isBad = true;
        }
        pipes[randomIndex].GetComponentInParent<Pipes>().isBad = false;
        //SetBadColor(randomIndex, pipes);
    }

    //public void ChoiseMade()
    //{
    //    //choiseState++;
    //    switch(choiseState) {
    //        case 0:
    //            {
    //                SetRandom(pipes);
    //                //kiezen tussen 1,2,3
    //                break;
    //            }

    //        case 1:
    //            {
    //                SetRandom(pipes2);
    //                //kiezen tussen 1,2,3,4

    //                break;
    //            }

    //        //case 2:
    //        //    {
    //        //        //kiezen tussen 2,3
    //        //        break;
    //        //    }

    //        //case 3:
    //        //    {
    //        //        //kiezen tussen 3,4
    //        //        //Choises of left and right
    //        //        break;
    //        //    }
    //    }
    //}

    //DEBUG

    public void ResetAllColors(List<GameObject> pipes)
    {
        for(int i = 0; i < pipes.Count; i++)
        {
        childrenRenders = pipes[i].GetComponentsInChildren<Renderer>();
        Debug.Log("childRender: " + i);
            for(int e = 0; e < childrenRenders.Length; e++)
            {
                childrenRenders[e].material.color = Color.gray;
            }
        }
    }

    public void SetBadColor(int randomIndex, List<GameObject> pipes)
    {
        childrenRenders = pipes[randomIndex].GetComponentsInChildren<Renderer>();

        for(int i = 0; i < childrenRenders.Length; i++)
        {
            childrenRenders[i].material.color = Color.green;
        }
    }

    public void BadChoisehelp()
    {
        for(int i = 0; i < pipes.Count; i++)
        {
            if(pipes[i].GetComponent<Pipes>().isBad)
            {
                childrenRenders = pipes[i].GetComponentsInChildren<Renderer>();
                Debug.Log("childRender: " + i);
                for(int e = 0; e < childrenRenders.Length; e++)
                {
                    childrenRenders[e].material.color = Color.red;
                }
                break;
            }
        }
    }
}
