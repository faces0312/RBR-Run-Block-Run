using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Manager : MonoBehaviour
{
    public float time;

    public TextMeshProUGUI applyScore;
    public float score;

    public AudioSource soundSource;

    private void Start()
    {
        Data.Instance.gameData.speed_Lv = 0f;
        time = 0f;
    }

    private void Update()
    {
        if (Data.Instance.gameData.sound == true)
        {
            soundSource.volume = 1;
        }
        else
        {
            soundSource.volume = 0;
        }

        applyScore.text = score.ToString("N1");
        score += Time.deltaTime / 10 * 3;
        time += Time.deltaTime;
        if(Data.Instance.gameData.speed_Lv<15f)
            Data.Instance.gameData.speed_Lv = time / 10 * 2f;
    }


}
