using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform[] targets1;
    public GameObject player;
    public Camera camera;

    public float moveSpeed;
    public int playerScore;

    MoveTowards moveTowards = new MoveTowards();
    TransformToVector3 convertTransform = new TransformToVector3();
    
    void Update()
    {
        OnPipeClick();
    }

    IEnumerator MoveTo(Transform player, Transform[] targets, float speed)
    {
        int index = 0;

        while(Vector3.Distance(transform.position, targets[targets.Length-1].position) > 0.001f)
        {
            Vector3 destination = targets[index].position;
            while(player.position != destination)
            {
                player.position = Vector3.MoveTowards(
                player.position,
                destination,
                speed * Time.deltaTime);

                yield return null;
            }

            if(index < targets.Length - 1)
            {
                index++;
            }

            yield return null;
        }
    }

    private void OnPipeClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit Something");
                GameObject hitobject = hit.transform.gameObject;

                if(hitobject.CompareTag("ChoiseTag"))
                {
                    StartCoroutine(MoveTo(player.transform, hitobject.GetComponent<Choise>().pathPositions, moveSpeed));
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
}
