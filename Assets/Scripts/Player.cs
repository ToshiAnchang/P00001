using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] public float moveSpd;
/*
    [SerializeField] Bullet bullet;
    [SerializeField] Transform shootTr;
*/
    [SerializeField] int playerHP;
    [SerializeField] FloatingJoystick joystick;
/*
    [SerializeField] int reload_Sec;
    [SerializeField] int ammoCount;
    [SerializeField] Image reloadIMG;
    [SerializeField] TMP_Text ammoCount_Text;
*/
    [SerializeField] string curAnimState;
    
    bool reloading;
    Vector2 _dir = Vector2.up;

    private static Player instance;
    public static Player Instance { get { return instance; } }

    Animator animator;

    public WeaponMgr weaponMgr;

    public PlayerInfoPanel playerInfoPanel;
    public GoldPanel goldPanel;

    Dictionary<string, PlayerItem> playerItemDic = new Dictionary<string, PlayerItem>();

    private void Start()
    {
        AddPlayerItem("pistol");
        curAnimState = "idle";
        animator = GetComponent<Animator>();
        AddWealth(WealthType.gold, PlayerPrefs.GetInt("gold", 0));
        
        for(int i=0; i < ShopMgr.Instance.itemDatas.Length; i++)
        {
            string result = PlayerPrefs.GetString(ShopMgr.Instance.itemDatas[i].key);
            if (result == "true")
            {
                AddPlayerItem(ShopMgr.Instance.itemDatas[i].key.ToString());
            }
        }


        /*
        ammoCount_Text.text = ammoCount + " / 5";
        */
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            weaponMgr = GetComponentInChildren<WeaponMgr>();            
        }
    }


    public void SetWeapon(string key)
    {
        weaponMgr.SetWeapon(key);
    }


    private void Update()
    {        
        transform.position = (Vector2)transform.position + joystick.Direction * Time.deltaTime * moveSpd;
        float dir = joystick.Direction.magnitude;
        if (dir > 0) {
            PlayAnim("run");
            curAnimState = "run";
        }
        else
        {
            PlayAnim("idle");
            curAnimState = "idle";
        }

/*      if (Input.GetMouseButtonDown(0))
        {
            Vector2 _dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition)
                - transform.position).normalized; //normalized : 단위 벡터 구하기(=크기가 1인 벡터)
            Bullet _b = Instantiate(bullet); //프리펩으로 총알 생성
            _b.Shoot(shootTr.position, _dir); //Bullet의 Shoot()함수 호출하기
            print(Time.deltaTime + "  :  델타타임의 값");
        }

       */
    /* if (Input.GetKeyDown(KeyCode.Space))
        {
            Bullet _b = Instantiate(bullet);
            _b.Shoot(shootTr.position, Vector2.up);
        }*//*

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - moveSpd * Time.deltaTime, transform.position.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + moveSpd * Time.deltaTime, transform.position.y);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpd * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpd * Time.deltaTime);
        }
*/
    }

    void PlayAnim(string _trg)
    {
        if (_trg != curAnimState)
        {
            animator.SetTrigger(_trg);            
        }
    }

    public void Shoot()
    {
        Monster _mon = MonsterMgr.Instance.FindClosest(transform.position); //가장 가까운 적 찾기
        Vector2 _shootDir = Vector2.up;
        if (_mon == null)
        {
            if (_dir != Vector2.zero)
                _shootDir = _dir.normalized;
        }
        else
        {
            _shootDir = (_mon.transform.position - transform.position).normalized;
        }

        weaponMgr.curWeapon.Shoot(_shootDir);
    }



    /** 플레이어 슈팅 관련 **/
    /*   public void Shoot()
       {
           if (ammoCount <= 0)
           {
               if (!reloading)
               {
                   StartCoroutine(Reload_Ammo());
               }
               return;
           }
           ammoCount--;
           ammoCount_Text.text = ammoCount + " / 5";

           Monster _mon = MonsterMgr.Instance.FindClosest(this.transform.position);

           if (_mon != null) {

               _dir = (_mon.transform.position - this.transform.position).normalized;
           }

           Bullet _b = Instantiate(bullet); //프리펩으로 총알 생성
           _b.Shoot(shootTr.position, _dir); //Bullet의 Shoot()함수 호출하기                 

           if (ammoCount <= 0 && !reloading)
           {
               StartCoroutine(Reload_Ammo());
           }
       }


       IEnumerator Reload_Ammo()
       {
           float _reloadTimer = reload_Sec;
           reloading = true;
           while (true)
           {            
               yield return null;
               _reloadTimer -= Time.deltaTime;
               reloadIMG.fillAmount = _reloadTimer / reload_Sec;

               if(_reloadTimer <= 0) { break; }
           }

           ammoCount = 5;
           reloading = false;
           ammoCount_Text.text = ammoCount + " / 5";
       }
    */



    public void TakeDamage(int damage)
    {
        playerHP -= damage;

        if (playerHP <= 0)
        {
            Destroy(gameObject);
        }
    }




   //내가 시도한 방법... 근데  Wealth에서 콜라이더 충돌확인을 하면 OnTrigger 함수가 너무 많이 호출 되어 안좋지 않나요?
   /* private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Wealth"))
        {
            Destroy(collision.gameObject);                        
        }        
    }*/
    
    public Dictionary<WealthType, int> playerWealthDic = new Dictionary<WealthType, int>();
    
    public void AddWealth(WealthType _wType, int _value)
    {
        if (!playerWealthDic.ContainsKey(_wType))
            playerWealthDic.Add(_wType, 0);

        playerWealthDic[_wType] += _value;

        if (_wType.Equals(WealthType.gold))
        {
            goldPanel.SetGold(playerWealthDic[WealthType.gold]);
            PlayerPrefs.SetInt(WealthType.gold.ToString(), playerWealthDic[WealthType.gold]);
        }
    }

    public int GetWealth(WealthType _wT)
    {
        if (!playerWealthDic.ContainsKey(_wT))
        {
            playerWealthDic.Add(_wT, 0);
        }
            return playerWealthDic[_wT];
    }

    public void AddPlayerItem(string _ikey)
    {
        PlayerItem _pItem = GetPlayerItem(_ikey);
        _pItem.own = true;
        PlayerPrefs.SetString(_pItem.key.ToString(), "true");
    }

    public PlayerItem GetPlayerItem(string _key)
    {
        if (playerItemDic.ContainsKey(_key))
        {
            return playerItemDic[_key];
        }

        PlayerItem _pItem = new PlayerItem();

        _pItem.key = _key;
        _pItem.own = false;

        playerItemDic.Add(_key, _pItem);
        return _pItem;
    }

}

public class PlayerItem
{
    public string key;
    public bool own;
}
