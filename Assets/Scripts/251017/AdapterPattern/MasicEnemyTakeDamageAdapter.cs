using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasicEnemyTakeDamageAdapter : MonoBehaviour , ITakeDamageAdapter
{
    [SerializeField] private float _weaknerss;

    //¾îµªÆ¼
    private MasicEnemy _enemy;

    //Åë¿ª
    private void Start()
    {
        _enemy = GetComponent<MasicEnemy>();

        if(_enemy == null)
        {
            gameObject.SetActive(false);
        }
    }

    //Å¸°Ù
    public void OnTakeDamage(float damage)
    {
        _enemy?.OnTakeMasicDamage(damage, _weaknerss);
    }
}
