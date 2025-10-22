using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    private float _horInput;
    private float _verInput;

    //프로퍼티 생성 - 람다식 
    public float HorInput => _horInput;
    public float VerInput => _verInput;


    private void Update()
    {
        //GetAxisRaw -> 키를 떼면 바로 딱 멈춤 , GetAxis ->키를 떼도 서서히 멈춤(빙판에 미끄러지듯이)
        _horInput = Input.GetAxisRaw("Horizontal");
        _verInput = Input.GetAxisRaw("Vertical");

        //Debug.Log($"HorInput = {_horInput}");
        //Debug.Log($"VerInput = {_verInput}");
    }
}
