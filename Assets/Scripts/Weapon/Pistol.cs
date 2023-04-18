using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{



    public override void Init()
    {
        base.Init();
        key = "pistol";
    }

    /* 총알발사하는 코드
     * public override void Shoot(Vector2 dir)
        {
            Monster _mob = MonsterMgr.Instance.FindClosest(Player.Instance.transform.position);
            Bullet _b = Instantiate(bullet); //프리펩으로 총알 생성
            //_b.Shoot(shootTr.position, dir); //Bullet의 Shoot()함수 호출하기                 
            _b.Shoot2(shootTr.position, _mob); //Bullet의 Shoot2()함수 호출하기 - 총알이 따라가기
        }*/


    
    public override void Shoot(Vector2 _dir)
    {
        if (curBulletCount <= 0) return;
        base.Shoot(_dir);
        Bullet _b = Instantiate(bullet); //프리펩으로 총알 생성
        _b.Shoot(shootTr.position, _dir); //Bullet의 Shoot()함수 호출하기                 
    }
}

