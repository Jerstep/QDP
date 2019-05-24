using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform[] targets1;
    public float moveSpeed;

    MoveTowards moveTowards = new MoveTowards();
    TransformToVector3 convertTransform = new TransformToVector3();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            for(int i = 0; i < targets1.Length; i++)
            {
                if()
                MoveToTarget(i);
            }
        }
        MoveToTarget(1);
    }

    private void MoveToTarget(int index)
    {
        float step = moveSpeed * Time.deltaTime;
        Vector3 target = targets1[index].position;
        if(Vector3.Distance(transform.position, target) < 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }
}
