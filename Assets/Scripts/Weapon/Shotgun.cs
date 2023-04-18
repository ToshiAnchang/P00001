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

        // 동시에 3발 나가는데 기준 총알과 각도를 맞춰서 나가게 함
        // 벡터에 대한 각도를 구하기 위한 코드 - 암기!!
        // 앵글 기준 +,- 45도 구하는 함수
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