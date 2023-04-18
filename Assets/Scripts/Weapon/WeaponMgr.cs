using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMgr : MonoBehaviour
{

    [SerializeField] PlayerInfoPanel playerInfoPanel;    

    public Weapon curWeapon;   //현재무기 확인하기 위한 오브젝트
    [SerializeField] Weapon[] weapons; //가지고 있는 무기 배열

    private void Awake()
    {
        weapons = GetComponentsInChildren<Weapon>();
        for (int i = 0; i < weapons.Length; i++)
            weapons[i].Init();
    }


    private void Start()
    {
        curWeapon = weapons[0];
        curWeapon.Equiped();
    }

    public void SetWeapon(string _key)
    {
        if (curWeapon == null)
            curWeapon = weapons[0];

        if (curWeapon.key.Equals(_key))
            return;

        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].key.Equals(_key))
            {
                curWeapon = weapons[i];
                curWeapon.Equiped();
                playerInfoPanel.SetWeapon(weapons[i]);
                playerInfoPanel.SetWeaponBullet(weapons[i].curBulletCount, weapons[i].maxBullet);
                break;
            }
        }
    }
}
