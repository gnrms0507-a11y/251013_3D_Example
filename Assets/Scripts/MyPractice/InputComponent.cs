using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    private float _horInput;
    private float _verInput;

    //������Ƽ ���� - ���ٽ� 
    public float HorInput => _horInput;
    public float VerInput => _verInput;


    private void Update()
    {
        //GetAxisRaw -> Ű�� ���� �ٷ� �� ���� , GetAxis ->Ű�� ���� ������ ����(���ǿ� �̲���������)
        _horInput = Input.GetAxisRaw("Horizontal");
        _verInput = Input.GetAxisRaw("Vertical");

        //Debug.Log($"HorInput = {_horInput}");
        //Debug.Log($"VerInput = {_verInput}");
    }
}
