using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(Print());
    }

    IEnumerator Print()
    {
        for(int i =0; i<5; i++)
        {
            Debug.Log(i);

            yield return new WaitForSeconds(1.0f);  //0~3������Ҷ����� MoveNext�� true�� (�������Ұ� ��������)

        }
    }
}
