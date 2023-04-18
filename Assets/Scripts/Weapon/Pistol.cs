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

    /* �Ѿ˹߻��ϴ� �ڵ�
     * public override void Shoot(Vector2 dir)
        {
            Monster _mob = MonsterMgr.Instance.FindClosest(Player.Instance.transform.position);
            Bullet _b = Instantiate(bullet); //���������� �Ѿ� ����
            //_b.Shoot(shootTr.position, dir); //Bullet�� Shoot()�Լ� ȣ���ϱ�                 
            _b.Shoot2(shootTr.position, _mob); //Bullet�� Shoot2()�Լ� ȣ���ϱ� - �Ѿ��� ���󰡱�
        }*/


    
    public override void Shoot(Vector2 _dir)
    {
        if (curBulletCount <= 0) return;
        base.Shoot(_dir);
        Bullet _b = Instantiate(bullet); //���������� �Ѿ� ����
        _b.Shoot(shootTr.position, _dir); //Bullet�� Shoot()�Լ� ȣ���ϱ�                 
    }
}

