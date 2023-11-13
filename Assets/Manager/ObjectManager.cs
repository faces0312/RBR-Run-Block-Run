using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Hero hero;
    public Manager manager;

    public ObjectPool objectPool;

    //장애물 생성 위치
    public GameObject startObPos1;
    public GameObject startObPos2;
    public GameObject startObPos3;
    public GameObject startObPos4;
    //장애물 생성 랜덤값
    private int ran_floor1;
    private int ran_floor2;
    private int ran_floor3;
    private int ran_floor4;
    //장애물 생성 시간
    private int ran_CoolTime;
    public float obCoolTime;
    private float applyObCoolTime;

    private string[] ob_str;

    private void Awake()
    {
        ob_str = new string[] { "Red1", "Green1", "Blue1" , "Glass1", "Black1", "Red2", "Green2", "Blue2", "Glass2", "Black2", 
                                "Red3", "Green3", "Blue3", "Glass3", "Black3", "Red4", "Green4", "Blue4", "Glass4", "Black4", "PlusScore" , "PlusPlusScore" , "UpDown"};
    }
    private void Start()
    {
        ran_CoolTime = Random.Range(1, 4);
        obCoolTime = ran_CoolTime;
        applyObCoolTime = obCoolTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (applyObCoolTime >= 0)
            applyObCoolTime -= Time.deltaTime;
        else
        {
            if(manager.score <= 40)
                ObRespawn();
            else
                ObRespawn_Hard();
            ran_CoolTime = Random.Range(1, 4);
            obCoolTime = ran_CoolTime;
            applyObCoolTime = obCoolTime;
        }
    }

    void ObRespawn()
    {
        ran_floor1 = Random.Range(0, 4);
        ran_floor2 = Random.Range(5, 9);
        ran_floor3 = Random.Range(10, 14);

        int ran_Plus = Random.Range(0, 2);
        int ran_PlusLocation = Random.Range(0, 3);

        if(ran_Plus == 1)
        {
            if(ran_PlusLocation == 0)
            {
                GameObject plus = objectPool.MakeObj(ob_str[20]);
                plus.transform.position = startObPos1.transform.position;
            }
            else if (ran_PlusLocation == 1)
            {
                GameObject plus = objectPool.MakeObj(ob_str[20]);
                plus.transform.position = startObPos2.transform.position;
            }
            else if (ran_PlusLocation == 2)
            {
                GameObject plus = objectPool.MakeObj(ob_str[20]);
                plus.transform.position = startObPos3.transform.position;
            }
        }

        GameObject mob1 = objectPool.MakeObj(ob_str[ran_floor1]);
        mob1.transform.position = startObPos1.transform.position;
        
        GameObject mob2 = objectPool.MakeObj(ob_str[ran_floor2]);
        mob2.transform.position = startObPos2.transform.position;

        GameObject mob3 = objectPool.MakeObj(ob_str[ran_floor3]);
        mob3.transform.position = startObPos3.transform.position;
    }

    void ObRespawn_Hard()
    {
        ran_floor1 = Random.Range(0, 5);
        ran_floor2 = Random.Range(5, 10);
        ran_floor3 = Random.Range(10, 15);
        ran_floor4 = Random.Range(15, 20);

        int ran_Plus = Random.Range(0, 2);//아이템 생성 할지 말지 변수
        int ran_PlusPlus = Random.Range(1, 5);
        int ran_PlusLocation = Random.Range(0, 3);

        int ran_UpDown = Random.Range(0, 5);
        int ran_UpDownLocation = Random.Range(0, 3);

        if(hero.is_updown==false)
        {
            if ( ran_UpDown == 2 )
            {
                if (ran_UpDownLocation == 0)
                {
                    GameObject updouwn = objectPool.MakeObj(ob_str[22]);
                    updouwn.transform.position = startObPos1.transform.position;
                }
                else if (ran_UpDownLocation == 1)
                {
                    GameObject updouwn = objectPool.MakeObj(ob_str[22]);
                    updouwn.transform.position = startObPos2.transform.position;
                }
                else if (ran_UpDownLocation == 2)
                {
                    GameObject updouwn = objectPool.MakeObj(ob_str[22]);
                    updouwn.transform.position = startObPos3.transform.position;
                }
            }
        }


        if (ran_Plus == 1)
        {
            if(ran_PlusPlus == 3)
            {
                if (ran_PlusLocation == 0)
                {
                    GameObject plus = objectPool.MakeObj(ob_str[21]);
                    plus.transform.position = startObPos1.transform.position;
                }
                else if (ran_PlusLocation == 1)
                {
                    GameObject plus = objectPool.MakeObj(ob_str[21]);
                    plus.transform.position = startObPos2.transform.position;
                }
                else if (ran_PlusLocation == 2)
                {
                    GameObject plus = objectPool.MakeObj(ob_str[21]);
                    plus.transform.position = startObPos3.transform.position;
                }
            }
            else
            {
                if (ran_PlusLocation == 0)
                {
                    GameObject plus = objectPool.MakeObj(ob_str[20]);
                    plus.transform.position = startObPos1.transform.position;
                }
                else if (ran_PlusLocation == 1)
                {
                    GameObject plus = objectPool.MakeObj(ob_str[20]);
                    plus.transform.position = startObPos2.transform.position;
                }
                else if (ran_PlusLocation == 2)
                {
                    GameObject plus = objectPool.MakeObj(ob_str[20]);
                    plus.transform.position = startObPos3.transform.position;
                }
            }
        }

        GameObject mob1 = objectPool.MakeObj(ob_str[ran_floor1]);
        mob1.transform.position = startObPos1.transform.position;

        GameObject mob2 = objectPool.MakeObj(ob_str[ran_floor2]);
        mob2.transform.position = startObPos2.transform.position;

        GameObject mob3 = objectPool.MakeObj(ob_str[ran_floor3]);
        mob3.transform.position = startObPos3.transform.position;

        GameObject mob4 = objectPool.MakeObj(ob_str[ran_floor4]);
        mob4.transform.position = startObPos4.transform.position;
    }
}
