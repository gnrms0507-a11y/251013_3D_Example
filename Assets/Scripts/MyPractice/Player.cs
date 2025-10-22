using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(MoveComponent))]
public class Player : MonoBehaviour
{
    ObjectManager objectManager;
    [SerializeField] private Transform PlayerStartPos;  //�÷��̾� ������ġ
    [SerializeField] private Weapon weapon;
    [SerializeField] private int PlayerHp = 3;

    private int currentHp;

    private List<IPlayerOberver> _hpObservers = new List<IPlayerOberver>();

    public void AddHPObserver(IPlayerOberver Observer) => _hpObservers.Add(Observer);
    public void RemoveHPObserver(IPlayerOberver Observer) => _hpObservers.Remove(Observer);

    //ó���� hp�� ��Ȱ��ȭ��Ű������ �������� ������Ʈ�迭
    GameObject[] playerHpBar;

    //Ÿ�̸� �߰�
    private IPlayTimer playTimer;

  
    private void Awake() // �����ũ�� �÷��̾� hp �ʱ�ȭ
    {
        //�÷��̾�� �÷��̾� ü�¹ٴ� ó���� ��Ȱ��ȭ �Ǿ�����
        gameObject.SetActive(false);
        playerHpBar = GameObject.FindGameObjectsWithTag("PlayerHpBar");
        foreach (var hpBar in playerHpBar) { hpBar.SetActive(false); }

        RegistPlayer();
    }
   
    private void Start()
    {
        setComponent();
    }

    private void Init()
    {
        if (GameManager.Instance.IsPlaying == true)
        {
            gameObject.SetActive(true);
            transform.position = PlayerStartPos.position; // ��Ÿ����ġ�� �̵�
            currentHp = PlayerHp;
            //hp�� Ȱ��ȭ
            foreach (var hpBar in playerHpBar) { hpBar.SetActive(true); }
            NotifyHpUpdate();   //hp�� ǥ��
        }
    }

    private void RegistPlayer() //���ӸŴ����� �½�ŸƮ �׼��̺�Ʈ�� ������.
    {
        GameManager.Instance.OnGameStartAction += Init;
    }

    private void setComponent()
    {
        weapon = GetComponent<Weapon>();
        Debug.Log("�������� �Ϸ�");
        Debug.Log($"�÷��̾� �����{PlayerHp}");
    }

    private void NotifyHpUpdate()
    {
        foreach(IPlayerOberver observer in _hpObservers)
        {
            observer.OnPlayerHpChanged(currentHp, PlayerHp);
        }
    }

    public void Demage()
    {
        currentHp -= 1;
        Debug.Log($"�÷��̾� ��� ����! ���� {currentHp}");

        NotifyHpUpdate();

        if (currentHp <= 0)
        {
            Debug.Log($"�÷��̾� ���");
            currentHp = 0;
            GameManager.Instance.ChangeGameState(); // �÷��̾� ����� ���ӻ��� ��������
            gameObject.SetActive(false);
        }
    }

}
