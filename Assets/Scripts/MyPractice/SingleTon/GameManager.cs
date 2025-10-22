using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private bool isPlaying = false;

    public bool IsPlaying { get { return isPlaying; } }

    [field :SerializeField] public event Action OnGameStartAction;

    [field: SerializeField] public UnityEvent OnGameEndAction { get; private set; } = new UnityEvent();


    //현재 게임이 진행중인지 확인
    public void ChangeGameState()
    {
        isPlaying = !isPlaying;

        if (isPlaying)
        {
            OnGameStartAction?.Invoke();
        }
        else
        {
            OnGameEndAction?.Invoke();
        }
    }

    ////현재 로드되어있는씬 다시가져오기
    //public void OnclickButton()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}
}
