using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TimerUI : MonoBehaviour, IPlayTimer
{
    [SerializeField] private TextMeshProUGUI timeText;  //텍스트 매시프로 가져올 텍스트

    private float playTime;

    private void Update()
    {
        OnPlayerTime();
    }

    public void OnPlayerTime()
    {
        //게임이 진행중일때만 플레이타임 증가
        if (GameManager.Instance.IsPlaying == true)
        {
            playTime += Time.deltaTime;
            timeText.text = $"Play Time :{string.Format("{0:F2}", playTime)}";
        }
        else
        {
            playTime = 0;
        }
    }
}
