using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(MoveComponent))]
public class Player : MonoBehaviour
{
    ObjectManager objectManager;
    [SerializeField] private Transform PlayerStartPos;  //플레이어 시작위치
    [SerializeField] private Weapon weapon;
    [SerializeField] private int PlayerHp = 3;

    private int currentHp;

    private List<IPlayerOberver> _hpObservers = new List<IPlayerOberver>();

    public void AddHPObserver(IPlayerOberver Observer) => _hpObservers.Add(Observer);
    public void RemoveHPObserver(IPlayerOberver Observer) => _hpObservers.Remove(Observer);

    //처음에 hp바 비활성화시키기위해 가져오는 오브젝트배열
    GameObject[] playerHpBar;

    //타이머 추가
    private IPlayTimer playTimer;

  
    private void Awake() // 어웨이크시 플레이어 hp 초기화
    {
        //플레이어와 플레이어 체력바는 처음에 비활성화 되어있음
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
            transform.position = PlayerStartPos.position; // 스타팅위치로 이동
            currentHp = PlayerHp;
            //hp바 활성화
            foreach (var hpBar in playerHpBar) { hpBar.SetActive(true); }
            NotifyHpUpdate();   //hp바 표현
        }
    }

    private void RegistPlayer() //게임매니저의 온스타트 액션이벤트에 구독함.
    {
        GameManager.Instance.OnGameStartAction += Init;
    }

    private void setComponent()
    {
        weapon = GetComponent<Weapon>();
        Debug.Log("무기장착 완료");
        Debug.Log($"플레이어 목숨은{PlayerHp}");
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
        Debug.Log($"플레이어 목숨 감소! 현재 {currentHp}");

        NotifyHpUpdate();

        if (currentHp <= 0)
        {
            Debug.Log($"플레이어 사망");
            currentHp = 0;
            GameManager.Instance.ChangeGameState(); // 플레이어 사망시 게임상태 변경해줌
            gameObject.SetActive(false);
        }
    }

}
