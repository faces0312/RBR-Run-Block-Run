using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Red" || collision.gameObject.tag == "Green" || collision.gameObject.tag == "Blue" || collision.gameObject.tag == "White")
        {
            gameObject.SetActive(false);
        }
    }
}
