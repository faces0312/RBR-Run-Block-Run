using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOb : MonoBehaviour
{
    private float life_Time;
    public float speed;

    private void Start()
    {
        life_Time = 7f;
        speed = 5;
    }
    private void OnEnable()
    {
        life_Time = 10f;
        speed = 5;
    }
    // Update is called once per frame
    void Update()
    {
        if (life_Time <= 0)
            gameObject.SetActive(false);
        life_Time -= Time.deltaTime;
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.left * (speed + Data.Instance.gameData.speed_Lv) * Time.deltaTime;
        transform.position = curPos + nextPos;
    }
}
