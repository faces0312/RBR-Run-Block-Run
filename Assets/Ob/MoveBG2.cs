using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG2 : MonoBehaviour
{
    public Manager manager;
    public float speed;

    public GameObject startPos;
    public GameObject endPos;


    private void Start()
    {
        speed = 3;
    }
    void Update()
    {
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.left * (speed + manager.time / 10) * Time.deltaTime;
        transform.position = curPos + nextPos;

        if (transform.position.x <= endPos.transform.position.x)
        {
            transform.position = startPos.transform.position;
        }
    }
}
