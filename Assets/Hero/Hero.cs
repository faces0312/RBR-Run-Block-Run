using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    public GameObject camera_updown;
    public float camera_cnt;
    public bool is_updown;

    public GameObject plus10;
    public GameObject plus15;


    public Manager manager;
    //파티클시스템(이펙트)
    public bool playAura = true; //파티클 제어 bool
    public ParticleSystem particleObject_red; //파티클시스템
    public ParticleSystem particleObject_green; //파티클시스템
    public ParticleSystem particleObject_blue; //파티클시스템
    public ParticleSystem particleObject_white; //파티클시스템

    public GameObject jump;//점프
    public GameObject change_red;//색변경_빨강
    public GameObject change_green;//색변경_빨강
    public GameObject change_blue;//색변경_빨강
    private int change_btn;

    private Rigidbody2D rigidbody;

    public int jumpCnt=0;
    public bool is_jump=false;//점프 중 인지
    public int jumpPower;// 점프 정도

    public GameObject red;
    public GameObject green;
    public GameObject blue;
    public GameObject white;
    public GameObject white_shield;
    public bool red_mode;//빨강 모드
    public bool green_mode;//초록 모드
    public bool blue_mode;//파랑
    public bool white_mode;//흰색모드

    private float white_time;//무적시간

    public GameObject change_cnt1;
    public GameObject change_cnt2;
    public GameObject change_cnt3;
    public int change_cnt;
    public float change_Cool;
    private float change_CoolNow;


    private int memory_color;//흰색으로 바뀌었을때 전 색깔을 기억

    public AdmobManager admob;
    private void Start()
    {
        is_updown = false;

        plus10.gameObject.SetActive(false);
        plus15.gameObject.SetActive(false);

        jumpPower = 35;
        gameObject.layer = 6;
        gameObject.tag = "Red";
        change_cnt = 3;
        change_CoolNow = change_Cool;
        red_mode = true;
        green_mode = false;
        blue_mode = false;
        white_mode = false;
        rigidbody = GetComponent<Rigidbody2D>();

        playAura = true;
        particleObject_red.Play();
        particleObject_green.Stop();
        particleObject_blue.Stop();
        particleObject_white.Stop();

        change_btn = Random.Range(1, 3);
    }
    private void Update()
    {
        
        if(jumpCnt >= 2)
        {
            is_jump = true;
        }
        //0이면 다음은 빨간색, 1이면 초록색, 2면 파란색
        if(change_btn == 0)
        {
            change_red.gameObject.SetActive(true);
            change_green.gameObject.SetActive(false);
            change_blue.gameObject.SetActive(false);
        }
        else if (change_btn == 1)
        {
            change_red.gameObject.SetActive(false);
            change_green.gameObject.SetActive(true);
            change_blue.gameObject.SetActive(false);
        }
        else if (change_btn == 2)
        {
            change_red.gameObject.SetActive(false);
            change_green.gameObject.SetActive(false);
            change_blue.gameObject.SetActive(true);
        }

        //흰색 버전이면 흰색 검은색 버전이면 검은색
        if (red_mode == true)
        {
            red.gameObject.SetActive(true);
            green.gameObject.SetActive(false);
            blue.gameObject.SetActive(false);
            white.gameObject.SetActive(false);
        }
        if (green_mode == true)
        {
            red.gameObject.SetActive(false);
            green.gameObject.SetActive(true);
            blue.gameObject.SetActive(false);
            white.gameObject.SetActive(false);
        }
        if (blue_mode == true)
        {
            red.gameObject.SetActive(false);
            green.gameObject.SetActive(false);
            blue.gameObject.SetActive(true);
            white.gameObject.SetActive(false);
        }
        if (white_mode == true)
        {
            red.gameObject.SetActive(false);
            green.gameObject.SetActive(false);
            blue.gameObject.SetActive(false);
            white.gameObject.SetActive(true);
            white_time -= Time.deltaTime;
            if (white_time <= 0)
            {
                white_mode = false;
                if (memory_color == 1)
                {
                    red_mode = true;
                    green_mode = false;
                    blue_mode = false;
                    gameObject.layer = 6;
                    gameObject.tag = "Red";
                }
                else if(memory_color ==2)
                {
                    red_mode = false;
                    green_mode = true;
                    blue_mode = false;
                    gameObject.layer = 7;
                    gameObject.tag = "Green";
                }
                else if(memory_color ==3)
                {
                    red_mode = false;
                    green_mode = false;
                    blue_mode = true;
                    gameObject.layer = 8;
                    gameObject.tag = "Blue";
                }
            }
        }


        if (change_cnt == 3)
        {
            change_cnt3.gameObject.SetActive(true);
            change_cnt2.gameObject.SetActive(true);
            change_cnt1.gameObject.SetActive(true);
        }
        else if (change_cnt == 2)
        {
            change_cnt3.gameObject.SetActive(false);
            change_cnt2.gameObject.SetActive(true);
            change_cnt1.gameObject.SetActive(true);
        }
        else if (change_cnt == 1)
        {
            change_cnt3.gameObject.SetActive(false);
            change_cnt2.gameObject.SetActive(false);
            change_cnt1.gameObject.SetActive(true);
        }
        else if (change_cnt == 0)
        {
            change_cnt3.gameObject.SetActive(false);
            change_cnt2.gameObject.SetActive(false);
            change_cnt1.gameObject.SetActive(false);
        }

        if (change_cnt<3)
        {
            change_CoolNow -= Time.deltaTime;
            if(change_CoolNow <= 0)
            {
                change_CoolNow = change_Cool;
                change_cnt++;
            }
        }

        if (playAura && red_mode)
        {
            particleObject_red.Play();
            particleObject_green.Stop();
            particleObject_blue.Stop();
            particleObject_white.Stop();
        }
        if (playAura && green_mode)
        {
            particleObject_red.Stop();
            particleObject_green.Play();
            particleObject_blue.Stop();
            particleObject_white.Stop();
        }
        if (playAura && blue_mode)
        {
            particleObject_red.Stop();
            particleObject_green.Stop();
            particleObject_blue.Play();
            particleObject_white.Stop();
        }
        if (playAura && white_mode)
        {
            particleObject_red.Stop();
            particleObject_green.Stop();
            particleObject_blue.Stop();
            particleObject_white.Play();
        }
        if (!playAura)
        {
            particleObject_red.Stop();
            particleObject_green.Stop();
            particleObject_blue.Stop();
            particleObject_white.Stop();
        }
    }
    public void JumpBtn()
    {
        if (is_jump == false)
        {
            playAura = false;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpCnt++;
        }
        else
            return;
    }

    public void Change_Red()
    {
        if(white_mode == false)
        {
            if (change_cnt > 0)
            {
                red_mode = true;
                green_mode = false;
                blue_mode = false;
                gameObject.layer = 6;
                gameObject.tag = "Red";
                change_cnt--;
                change_btn = Random.Range(1, 3);
                return;
            }
        }
    }
    public void Change_Green()
    {
        if(white_mode == false)
        {
            if (change_cnt > 0)
            {
                red_mode = false;
                green_mode = true;
                blue_mode = false;
                gameObject.layer = 7;
                gameObject.tag = "Green";
                change_cnt--;
                change_btn = Random.Range(0, 2);
                if (change_btn == 1)
                    change_btn = 2;
                return;
            }
        }
    }
    public void Change_Blue()
    {
        if (white_mode == false)
        {
            if (change_cnt > 0)
            {
                red_mode = false;
                green_mode = false;
                blue_mode = true;
                gameObject.layer = 8;
                gameObject.tag = "Blue";
                change_cnt--;
                change_btn = Random.Range(0, 2);
                return;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            playAura = true;
            jumpCnt = 0;
            is_jump = false;
        }
        if (collision.gameObject.tag == "Die")
        {
            Data.Instance.gameData.total_Try++;
            if ((Data.Instance.gameData.total_Try + 1) % 3 == 0)
            {
                Data.Instance.gameData.last_Score = manager.score;
                if (manager.score > Data.Instance.gameData.high_Score)
                    Data.Instance.gameData.high_Score = manager.score;
                Data.Instance.SaveGameData();
                admob.ShowFrontAd();
            }
            else
            {
                Data.Instance.gameData.last_Score = manager.score;
                if (manager.score > Data.Instance.gameData.high_Score)
                    Data.Instance.gameData.high_Score = manager.score;
                Data.Instance.SaveGameData();
                SceneManager.LoadScene("Main");
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlusScore")
        {
            plus10.gameObject.SetActive(true);
            StopCoroutine(nameof(MovePlus10));
            plus10.gameObject.transform.localPosition = gameObject.transform.position * 110;
            StartCoroutine(nameof(MovePlus10));
            manager.score += 10;
            if (change_cnt < 3)
            {
                change_CoolNow = change_Cool;
                change_cnt++;
            }
        }
        if (collision.gameObject.tag == "PlusPlusScore")
        {
            plus15.gameObject.SetActive(true);
            StopCoroutine(nameof(MovePlus15));
            plus15.gameObject.transform.localPosition = gameObject.transform.position * 110;
            StartCoroutine(nameof(MovePlus15));

            lest_time = 0;
            white_time = 7f;
            white_shield.gameObject.SetActive(true);
            StopCoroutine(nameof(DisShield));
            
            StartCoroutine(nameof(DisShield));
            manager.score += 15;
            if (red_mode == true)
                memory_color = 1;
            if (green_mode == true)
                memory_color = 2;
            if (blue_mode == true)
                memory_color = 3;

            red_mode = false;
            green_mode = false;
            blue_mode = false;
            white_mode = true;

            gameObject.layer = 17;
            gameObject.tag = "White";

            if (change_cnt < 3)
            {
                change_CoolNow = change_Cool;
                change_cnt++;
            }
        }

        if (collision.gameObject.tag == "UpDown")
        {
            is_updown = true;
            manager.score += 10;
            if(camera_updown.gameObject.transform.rotation.z >100)
            {
                StopCoroutine(nameof(UpDown));
                camera_cnt = 9;
                StartCoroutine(nameof(UpDown));
            }
            else
            {
                camera_cnt = 9;
                camera_updown.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                StartCoroutine(nameof(UpDown));
            }
        }
    }
    IEnumerator UpDown()
    {
        yield return new WaitForSeconds(camera_cnt);
        camera_updown.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        is_updown = false;
    }
    private int lest_time;
    IEnumerator DisShield()
    {
        yield return new WaitForSeconds(3f);
        for(int i=40;i>0;i--)
        {
            if (white_shield.gameObject.activeSelf == true)
                white_shield.gameObject.SetActive(false);
            else
                white_shield.gameObject.SetActive(true);
            lest_time++;
            if(lest_time<=2)
                yield return new WaitForSeconds(0.45f);
            else if (lest_time <= 4)
                yield return new WaitForSeconds(0.4f);
            else if (lest_time <= 6)
                yield return new WaitForSeconds(0.35f);
            else if (lest_time <= 8)
                yield return new WaitForSeconds(0.3f);
            else if (lest_time <= 10)
                yield return new WaitForSeconds(0.25f);
            else if (lest_time <= 12)
                yield return new WaitForSeconds(0.2f);
            else if (lest_time <= 14)
                yield return new WaitForSeconds(0.15f);
            else
                yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator MovePlus10()
    {
        for(int i=0;i<100;i++)
        {
            plus10.gameObject.transform.localPosition = new Vector2(plus10.gameObject.transform.localPosition.x, plus10.gameObject.transform.localPosition.y + 1.5f);
            yield return new WaitForSeconds(0.01f);
        }
        plus10.gameObject.SetActive(false);
    }

    IEnumerator MovePlus15()
    {
        for (int i = 0; i < 100; i++)
        {
            plus15.gameObject.transform.localPosition = new Vector2(plus15.gameObject.transform.localPosition.x, plus15.gameObject.transform.localPosition.y + 1.5f);
            yield return new WaitForSeconds(0.01f);
        }
        plus15.gameObject.SetActive(false);
    }
}
