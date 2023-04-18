using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterABC : Monster
{
    [SerializeField] Bullet_mob bullet;
    [SerializeField] Transform shootTr;
    [SerializeField] GameObject circle2D;

    SpriteRenderer sprR;
        
    private bool _canShoot;
    private float _coolTime = 0;
    float distance;

    private void Start()
    {
        StartCoroutine(CoolTime());
    }

    public override void Update()
    {
        if (!Player.Instance) { return; }
        
        transform.position = Vector2.MoveTowards(transform.position, Player.Instance.transform.position, spd * Time.deltaTime);
        
        distance = Vector2.Distance(transform.position, Player.Instance.transform.position);
        if (monsterType == 'b')
        {
            if (distance < 20 && _canShoot){
                ShootToPlayer();
            }
        }       
    }


    IEnumerator CoolTime()
    {
        while (true)
        {
            _coolTime += 1;            
            if(_coolTime % 60 == 0)  { print("�д��� �߰� �Ǿ���"); }
            if(_coolTime % 2 == 0) { _canShoot = true; }            
            yield return new WaitForSeconds(1);
        }
            
    }

    private void ShootToPlayer()
    {
        _canShoot = false;
        Vector2 _dir = (Player.Instance.transform.position - transform.position).normalized; //normalized : ���� ���� ���ϱ�(=ũ�Ⱑ 1�� ����)
        Bullet_mob _b = Instantiate(bullet); //���������� �Ѿ� ����
        _b.Shoot(shootTr.position, _dir, monsterDamage); //Bullet�� Shoot()�Լ� ȣ���ϱ�
        
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (monsterType)
        {
            case 'a':
                if (collision.CompareTag("Player") && _canShoot)
                {
                    if (!_canShoot) { return; }
                    collision.GetComponent<Player>().TakeDamage(monsterDamage);                    
                }
                break;

/*            case 'b':
                if (collision.CompareTag("Player"))
                {
                    collision.GetComponent<Player>().TakeDamage(monsterDamage);
                    Vector2 _dir = (Player.Instance.transform.position - transform.position).normalized; //normalized : ���� ���� ���ϱ�(=ũ�Ⱑ 1�� ����)
                    Bullet_mob _b = Instantiate(bullet); //���������� �Ѿ� ����
                    _b.Shoot(shootTr.position, _dir, monsterDamage); //Bullet�� Shoot()�Լ� ȣ���ϱ�
                }
                break;*/

            case 'c':
                if (collision.CompareTag("Player"))
                {
                    print("C�� �ε�����");
                    if (!_canShoot) { return; }
                                       
                    GameObject c2d = circle2D;
                    sprR = c2d.GetComponent<SpriteRenderer>();
                    sprR.color = Random.ColorHSV();

                    if (Player.Instance.moveSpd >= 10)
                    {
                        Player.Instance.moveSpd = Player.Instance.moveSpd / 5;
                    }
                    _canShoot = false;
                    Invoke("DieDie", 3);
                }
                break;
        }
    }

    private void DieDie() {
        Destroy(gameObject);
        Player.Instance.moveSpd *= 5;
        if (distance < 1.5) { Player.Instance.TakeDamage(monsterDamage); print("����!! �������� �������ϴ�  -  " + monsterDamage); }
    }
}
