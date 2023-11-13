using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData
{
    public float speed_Lv;//스피드 레벨

    public float high_Score;//최고 점수
    public float last_Score;//마지막 점수

    public int total_Try;//총 게임한 판수

    public bool is_tutorial;//튜토리얼 여부

    public bool sound;//사운드 여부
}
