using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TimerUI : MonoBehaviour, IPlayTimer
{
    [SerializeField] private TextMeshProUGUI timeText;  //�ؽ�Ʈ �Ž����� ������ �ؽ�Ʈ

    private float playTime;

    private void Update()
    {
        OnPlayerTime();
    }

    public void OnPlayerTime()
    {
        //������ �������϶��� �÷���Ÿ�� ����
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
