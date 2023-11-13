using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Main_Manager : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI lastScore;

    private float updownTime;
    public TextMeshProUGUI touchtoStart;

    public GameObject backGround;

    public GameObject tutorial_Background;
    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject tutorial3;

    public GameObject setting;
    public Button sound_on;
    public Button sound_off;

    public AudioSource button_audio;
    public AudioSource bk_audio;

    private void Start()
    {
        //Data.Instance.gameData.is_tutorial = false;
        setting.gameObject.SetActive(false);

        if (Data.Instance.gameData.is_tutorial == false)
        {
            Sound_On();
            tutorial_Background.gameObject.SetActive(true);
            tutorial1.gameObject.SetActive(true);
            tutorial2.gameObject.SetActive(false);
            tutorial3.gameObject.SetActive(false);
        }
        else
        {
            tutorial_Background.gameObject.SetActive(false);
        }


        updownTime = 0.5f;
        highScore.text = Data.Instance.gameData.high_Score.ToString("N1");
        lastScore.text = Data.Instance.gameData.last_Score.ToString("N1");
        Time.timeScale = 1;
    }

    private void Update()
    {
        updownTime -= Time.deltaTime;
        if (updownTime <= 0)
        {
            UpDowunTime();
            updownTime = 0.5f;
        }

        if (Data.Instance.gameData.sound == true)
        {
            button_audio.volume = 1;
            bk_audio.volume = 1;
            sound_on.interactable = false;
            sound_off.interactable = true;
        }
        else
        {
            button_audio.volume = 0;
            bk_audio.volume = 0;
            sound_on.interactable = true;
            sound_off.interactable = false;
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void UpDowunTime()
    {
        if(touchtoStart.alpha ==1)
        {
            touchtoStart.alpha = 0;
            return;
        }
        else
        {
            touchtoStart.alpha = 1;
            return;
        }
    }


    public void Next_()
    {
        if(tutorial1.gameObject.activeSelf == true)
        {
            button_audio.Play();
            tutorial1.gameObject.SetActive(false);
            tutorial2.gameObject.SetActive(true);
            tutorial3.gameObject.SetActive(false);

            return;
        }
        if (tutorial2.gameObject.activeSelf == true)
        {
            button_audio.Play();
            tutorial1.gameObject.SetActive(false);
            tutorial2.gameObject.SetActive(false);
            tutorial3.gameObject.SetActive(true);

            return;
        }
        if (tutorial3.gameObject.activeSelf == true)
        {
            button_audio.Play();
            Data.Instance.gameData.is_tutorial = true;
            tutorial1.gameObject.SetActive(false);
            tutorial2.gameObject.SetActive(false);
            tutorial3.gameObject.SetActive(false);

            tutorial_Background.gameObject.SetActive(false);

            Data.Instance.SaveGameData();

            return;
        }
    }

    public void Before_()
    {
        if (tutorial2.gameObject.activeSelf == true)
        {
            button_audio.Play();
            tutorial1.gameObject.SetActive(true);
            tutorial2.gameObject.SetActive(false);
            tutorial3.gameObject.SetActive(false);

            return;
        }
        if (tutorial3.gameObject.activeSelf == true)
        {
            button_audio.Play();
            tutorial1.gameObject.SetActive(false);
            tutorial2.gameObject.SetActive(true);
            tutorial3.gameObject.SetActive(false);

            return;
        }
    }

    public void Setting()
    {
        button_audio.Play();
        setting.gameObject.SetActive(true);
    }
    public void Settng_Cancel()
    {
        button_audio.Play();
        setting.gameObject.SetActive(false);
    }
    public void Explain()
    {
        button_audio.Play();
        tutorial_Background.gameObject.SetActive(true);
        tutorial1.gameObject.SetActive(true);
        tutorial2.gameObject.SetActive(false);
        tutorial3.gameObject.SetActive(false);
    }
    public void Sound_On()
    {
        Data.Instance.gameData.sound = true;
        sound_on.gameObject.GetComponent<Button>().interactable = false;
        sound_off.gameObject.GetComponent<Button>().interactable = true;
        button_audio.Play();
        Data.Instance.SaveGameData();
    }
    public void Sound_Off()
    {
        Data.Instance.gameData.sound = false;
        sound_on.gameObject.GetComponent<Button>().interactable = true;
        sound_off.gameObject.GetComponent<Button>().interactable = false;
        Data.Instance.SaveGameData();
    }

    public void HomePage()
    {
        Application.OpenURL("https://cafe.naver.com/runblockrun");
    }
    public void Personal()
    {
        Application.OpenURL("https://cafe.naver.com/runblockrun/staff/1");
    }
}
