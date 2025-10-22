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


    //���� ������ ���������� Ȯ��
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

    ////���� �ε�Ǿ��ִ¾� �ٽð�������
    //public void OnclickButton()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}
}
