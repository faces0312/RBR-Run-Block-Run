using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
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
        Vector3 nextPos = Vector3.left * (speed + Data.Instance.gameData.speed_Lv/2) * Time.deltaTime;
        transform.position = curPos + nextPos;

        if (transform.position.x <= startPos.transform.position.x)
        {
            transform.position = endPos.transform.position;
        }
    }
}
