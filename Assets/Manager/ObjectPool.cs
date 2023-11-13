using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject red1Prefab;
    public GameObject green1Prefab;
    public GameObject blue1Prefab;
    public GameObject glass1Prefab;
    public GameObject black1Prefab;

    public GameObject red2Prefab;
    public GameObject green2Prefab;
    public GameObject blue2Prefab;
    public GameObject glass2Prefab;
    public GameObject black2Prefab;

    public GameObject red3Prefab;
    public GameObject green3Prefab;
    public GameObject blue3Prefab;
    public GameObject glass3Prefab;
    public GameObject black3Prefab;

    public GameObject red4Prefab;
    public GameObject green4Prefab;
    public GameObject blue4Prefab;
    public GameObject glass4Prefab;
    public GameObject black4Prefab;

    public GameObject plusScorePrefab;
    public GameObject plusplusScorePrefab;//¹«Àû
    public GameObject upDownPrefab;

    GameObject[] red1;
    GameObject[] green1;
    GameObject[] blue1;
    GameObject[] glass1;
    GameObject[] black1;

    GameObject[] red2;
    GameObject[] green2;
    GameObject[] blue2;
    GameObject[] glass2;
    GameObject[] black2;

    GameObject[] red3;
    GameObject[] green3;
    GameObject[] blue3;
    GameObject[] glass3;
    GameObject[] black3;

    GameObject[] red4;
    GameObject[] green4;
    GameObject[] blue4;
    GameObject[] glass4;
    GameObject[] black4;


    GameObject[] plusScore;
    GameObject[] plusplusScore;

    GameObject[] upDown;

    GameObject[] targetPool;

    private void Awake()
    {
        red1 = new GameObject[20];
        green1 = new GameObject[20];
        blue1 = new GameObject[20];
        glass1 = new GameObject[20];
        black1 = new GameObject[20];

        red2 = new GameObject[20];
        green2 = new GameObject[20];
        blue2 = new GameObject[20];
        glass2 = new GameObject[20];
        black2 = new GameObject[20];

        red3 = new GameObject[20];
        green3 = new GameObject[20];
        blue3 = new GameObject[20];
        glass3 = new GameObject[20];
        black3 = new GameObject[20];

        red4 = new GameObject[20];
        green4 = new GameObject[20];
        blue4 = new GameObject[20];
        glass4 = new GameObject[20];
        black4 = new GameObject[20];

        plusScore = new GameObject[20];
        plusplusScore = new GameObject[10];
        upDown = new GameObject[10];
        Generate();
    }

    void Generate()
    {
        for (int index = 0; index < red1.Length; index++)
        {
            red1[index] = Instantiate(red1Prefab);
            red1[index].SetActive(false);
        }
        for (int index = 0; index < green1.Length; index++)
        {
            green1[index] = Instantiate(green1Prefab);
            green1[index].SetActive(false);
        }
        for (int index = 0; index < blue1.Length; index++)
        {
            blue1[index] = Instantiate(blue1Prefab);
            blue1[index].SetActive(false);
        }
        for (int index = 0; index < glass1.Length; index++)
        {
            glass1[index] = Instantiate(glass1Prefab);
            glass1[index].SetActive(false);
        }
        for (int index = 0; index < black1.Length; index++)
        {
            black1[index] = Instantiate(black1Prefab);
            black1[index].SetActive(false);
        }

        for (int index = 0; index < red2.Length; index++)
        {
            red2[index] = Instantiate(red2Prefab);
            red2[index].SetActive(false);
        }
        for (int index = 0; index < green2.Length; index++)
        {
            green2[index] = Instantiate(green2Prefab);
            green2[index].SetActive(false);
        }
        for (int index = 0; index < blue2.Length; index++)
        {
            blue2[index] = Instantiate(blue2Prefab);
            blue2[index].SetActive(false);
        }
        for (int index = 0; index < glass2.Length; index++)
        {
            glass2[index] = Instantiate(glass2Prefab);
            glass2[index].SetActive(false);
        }
        for (int index = 0; index < black2.Length; index++)
        {
            black2[index] = Instantiate(black2Prefab);
            black2[index].SetActive(false);
        }

        for (int index = 0; index < red3.Length; index++)
        {
            red3[index] = Instantiate(red3Prefab);
            red3[index].SetActive(false);
        }
        for (int index = 0; index < green3.Length; index++)
        {
            green3[index] = Instantiate(green3Prefab);
            green3[index].SetActive(false);
        }
        for (int index = 0; index < blue3.Length; index++)
        {
            blue3[index] = Instantiate(blue3Prefab);
            blue3[index].SetActive(false);
        }
        for (int index = 0; index < glass3.Length; index++)
        {
            glass3[index] = Instantiate(glass3Prefab);
            glass3[index].SetActive(false);
        }
        for (int index = 0; index < black3.Length; index++)
        {
            black3[index] = Instantiate(black3Prefab);
            black3[index].SetActive(false);
        }

        for (int index = 0; index < red4.Length; index++)
        {
            red4[index] = Instantiate(red4Prefab);
            red4[index].SetActive(false);
        }
        for (int index = 0; index < green4.Length; index++)
        {
            green4[index] = Instantiate(green4Prefab);
            green4[index].SetActive(false);
        }
        for (int index = 0; index < blue4.Length; index++)
        {
            blue4[index] = Instantiate(blue4Prefab);
            blue4[index].SetActive(false);
        }
        for (int index = 0; index < glass4.Length; index++)
        {
            glass4[index] = Instantiate(glass4Prefab);
            glass4[index].SetActive(false);
        }
        for (int index = 0; index < black4.Length; index++)
        {
            black4[index] = Instantiate(black4Prefab);
            black4[index].SetActive(false);
        }


        for (int index = 0; index < plusScore.Length; index++)
        {
            plusScore[index] = Instantiate(plusScorePrefab);
            plusScore[index].SetActive(false);
        }

        for (int index = 0; index < plusplusScore.Length; index++)
        {
            plusplusScore[index] = Instantiate(plusplusScorePrefab);
            plusplusScore[index].SetActive(false);
        }

        for (int index = 0; index < upDown.Length; index++)
        {
            upDown[index] = Instantiate(upDownPrefab);
            upDown[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "Red1":
                targetPool = red1;
                break;
            case "Green1":
                targetPool = green1;
                break;
            case "Blue1":
                targetPool = blue1;
                break;
            case "Glass1":
                targetPool = glass1;
                break;
            case "Black1":
                targetPool = black1;
                break;
            case "Red2":
                targetPool = red2;
                break;
            case "Green2":
                targetPool = green2;
                break;
            case "Blue2":
                targetPool = blue2;
                break;
            case "Glass2":
                targetPool = glass2;
                break;
            case "Black2":
                targetPool = black2;
                break;
            case "Red3":
                targetPool = red3;
                break;
            case "Green3":
                targetPool = green3;
                break;
            case "Blue3":
                targetPool = blue3;
                break;
            case "Glass3":
                targetPool = glass3;
                break;
            case "Black3":
                targetPool = black3;
                break;
            case "Red4":
                targetPool = red3;
                break;
            case "Green4":
                targetPool = green3;
                break;
            case "Blue4":
                targetPool = blue3;
                break;
            case "Glass4":
                targetPool = glass3;
                break;
            case "Black4":
                targetPool = black3;
                break;
            case "PlusScore":
                targetPool = plusScore;
                break;
            case "PlusPlusScore":
                targetPool = plusplusScore;
                break;
            case "UpDown":
                targetPool = upDown;
                break;
        }
        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }

        return null;
    }
}
