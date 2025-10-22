using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeExample : MonoBehaviour
{
    
    //해당 객체가 파괴되지않도록 설정
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // 업데이트에서 입력받아 씬전환
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(2);
        }
    }
}
