using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    //프로퍼티를 직렬화해서 사용
   [field : SerializeField] public UnityEvent OnPetCalled { get; private set; } = new UnityEvent();


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CallPet();
        }
    }

    private void CallPet()
    {
        OnPetCalled?.Invoke();
    }
}
