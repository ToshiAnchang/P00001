using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shotgun : Weapon
{
    public override void Init()
    {
        base.Init();
        key = "shotgun";
    }

    public override void Shoot(Vector2 _dir)
    {
        if (curBulletCount <= 0) return;
        base.Shoot(_dir);

        // ���ÿ� 3�� �����µ� ���� �Ѿ˰� ������ ���缭 ������ ��
        // ���Ϳ� ���� ������ ���ϱ� ���� �ڵ� - �ϱ�!!
        // �ޱ� ���� +,- 45�� ���ϴ� �Լ�
        float angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;

        float rightQuaternionZ = Quaternion.AngleAxis(angle + 45, Vector3.forward).eulerAngles.z;
        float leftQuaternionZ = Quaternion.AngleAxis(angle - 45, Vector3.forward).eulerAngles.z;

        Vector2 _rightV = new Vector2(Mathf.Cos(rightQuaternionZ * Mathf.Deg2Rad), Mathf.Sin(rightQuaternionZ * Mathf.Deg2Rad)).normalized;
        Vector2 _leftV = new Vector2(Mathf.Cos(leftQuaternionZ * Mathf.Deg2Rad), Mathf.Sin(leftQuaternionZ * Mathf.Deg2Rad)).normalized;

        Bullet _b = Instantiate(bullet);
        _b.Shoot(shootTr.position, _dir);

        _b = Instantiate(bullet);
        _b.Shoot(shootTr.position, _rightV);

        _b = Instantiate(bullet);
        _b.Shoot(shootTr.position, _leftV);
    }    
}