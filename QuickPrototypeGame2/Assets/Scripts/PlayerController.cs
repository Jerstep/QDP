using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Choises choisesScript;

    public Camera camera;
    public GameObject colliderObject;
    public GameObject playerObject;
    public TMP_Text scoreText;
    public TMP_Text helpText;
    public GameObject winScreen;

    public float lerpSpeed;
    public int amountSteps;
    public int helpAmount;
    private int stepsTaken = 0;
    private int score;

    private bool move = false;

    private void Awake()
    {
        choisesScript = GetComponent<Choises>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        { 
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit Something");
                GameObject hitobject = hit.transform.gameObject;

                if(hitobject.CompareTag("PipeTag"))
                {
                    if(!hitobject.GetComponentInParent<Pipes>().isBad)
                    {
                        NextPipes();
                        FollowPipe(hitobject.GetComponentInParent<Pipes>());
                    }
                    else
                    {
                        Renderer[] childrenRenders = hitobject.transform.parent.GetComponentsInChildren<Renderer>();
                        MakePipesRed(childrenRenders);
                        Death();
                    }

                    //if(hitobject.GetComponentInParent<Pipes>() != null)
                    //{
                    //    FollowPipe(hitobject.GetComponentInParent<Pipes>());
                    //    move = true;
                    //}
                    //else
                    //{
                    //    Debug.Log("Script not found");
                    //}
                }
                else
                {
                    Debug.Log("No Pipes Found");
                }
            }
            else
            {
                Debug.Log("No Hit");
            }
        }


    }

    void MakePipesRed(Renderer[] childrenRenders)
    {
        for(int i = 0; i < childrenRenders.Length; i++)
        {
            childrenRenders[i].material.color = Color.red;
        }
    }

    void FollowPipe(Pipes chosenPipe)
    {
        //playerObject.transform.position = chosenPipe.endLocation.position;

        //for(int i = 0; i < chosenPipe.followPoints.Count; i++)
        //{
        //    Vector3 positionPoints = chosenPipe.followPoints[i].position;
        //    if(move)
        //    {
        //        if(stepsTaken < amountSteps)
        //        {
        //            Debug.Log("Loop");
        //            playerObject.transform.position = new Vector3(Mathf.Lerp(playerObject.transform.position.x, positionPoints.x, lerpSpeed),
        //                Mathf.Lerp(playerObject.transform.position.y, positionPoints.y, lerpSpeed),
        //                playerObject.transform.position.z);
        //            stepsTaken++;
        //        }
        //        else
        //        {
        //            move = false;
        //            stepsTaken = 0;
        //        }
        //    }
        //}
    }

    private IEnumerator MoveToPosition(Vector3 endPos, float time)
    {
        float elapsedTime = 0;
        Vector3 startPos = transform.position;

        while(elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }

    private void Death()
    {
        score--;
        scoreText.text = "Score: " + score;
    }

    private void NextPipes()
    {
        score++;
        scoreText.text = "Score: " + score;
        choisesScript.SetRandom();

        if(score >= 5)
        {
            winScreen.SetActive(true);
        }
    }

    public void ShowOneWrong()
    {
        helpText.text = "Push To help | Help Left: " + helpAmount;
        
        if(helpAmount > 0)
        {
            choisesScript.BadChoisehelp();
            helpAmount--;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wrong"))
        {
            //Death, GAME OVER
        }
        else
        {
            //Continue, More pipes
        }
    }

}
