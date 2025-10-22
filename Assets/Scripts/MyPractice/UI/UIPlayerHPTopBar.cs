using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHPTopBar : MonoBehaviour , IPlayerOberver
{
    [SerializeField] private Image _imgBar;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player.AddHPObserver(this);
    }
    private void OnDestroy()
    {
        _player.RemoveHPObserver(this);
    }

    public void OnPlayerHpChanged(float currentHp, float MaxHp)
    {
        _imgBar.fillAmount = currentHp / MaxHp;
    }
}
