using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] public float spd;
    [SerializeField] public int hp;
    [SerializeField] public int currenthp;
    [SerializeField] public int monsterDamage;
    //[SerializeField] public Player player;       memory 낭비
    [SerializeField] public char monsterType;
    [SerializeField] Image hpBarIMG;
    [SerializeField] Rigidbody2D rd2D;

    bool alive;

   public virtual void Start()
    {
        // player = Player.Instance;       memory 낭비
        currenthp = hp;        
    }

    public virtual void Attack(Player target)
    {
        target.TakeDamage(monsterDamage);
    }

    public virtual void Update()
    {
        //transform.position = (Vector2)transform.position + Vector2.down * spd;    //transform.position의 기본값은 Vector3 이다
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(transform.position, Player.Instance.transform.position, spd * Time.deltaTime);
        
        hpBarIMG.fillAmount = (float)currenthp/hp;


        Vector2 _dir = (Player.Instance.transform.position - transform.position).normalized;
        rd2D.velocity = _dir * spd;

    }

    public virtual void TakeDamage(int damage)
    {
        currenthp -= damage;
  //      print("몬스터에게 데미지("+ damage +")를 주었습니다");

        if(currenthp <= 0)
        {
            Die();
        }
    }

    public virtual void Spawn(Vector2 _sPos)
    {        
        alive = true;
        transform.position = _sPos;
    }

    
    public void Die()
    {
        SoundMgr.Instance.PlaySound(SFXType.monster_die);
        EffectMgr.Instance.PlayEffect("monsterDie", transform.position);
        Destroy(gameObject);
        //MonsterMgr.Instance.WorldMonsterCount -= 1;
        MonsterMgr.Instance.DestroyMonster(this);
        WealthMgr.Instance.SpawnWealth(WealthType.gold, transform.position, Random.Range(5,9));
    }
}
