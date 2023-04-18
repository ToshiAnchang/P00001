using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public string key;

    [SerializeField] protected Bullet bullet;
    [SerializeField] protected Transform shootTr;
    [SerializeField] ParticleSystem shootEffect;

    public int maxBullet;
    public float reloadingSec;
    public float curReloadingTimer;

    //PlayerInfoPanel playerInfoPanel;

    bool reloading;

    [SerializeField] public int curBulletCount;

    public void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        curBulletCount = maxBullet;
        shootEffect = GetComponentInChildren<ParticleSystem>();
    }

    public virtual void Equiped() //���� ���� �� ȣ�� 
    {
        Player.Instance.playerInfoPanel.SetWeapon(this);
        Player.Instance.playerInfoPanel.SetWeaponBullet(curBulletCount, maxBullet);
        Player.Instance.playerInfoPanel.SetReloadingBar(curReloadingTimer / reloadingSec);
    }

    [SerializeField] AudioSource audioSource;
    public virtual void Shoot(Vector2 dir) //�� �߻� �� ȣ�� 
    {
        curBulletCount--;
        if(curBulletCount <= 0) {
            StartCoroutine(Reload_Ammo());
        }
        audioSource.Play();
        shootEffect.Play();
        Player.Instance.playerInfoPanel.SetWeaponBullet(curBulletCount, maxBullet);
    }

    public virtual void Shoot() //���� ����̳� �ٸ� �Լ�
    {

    }

    IEnumerator Reload_Ammo()
    {
        float _reloadTimer = reloadingSec;
        reloading = true;
        while (true)
        {
            yield return null;
            _reloadTimer -= Time.deltaTime;
            //playerInfoPanel.SetReloadingBar(_reloadTimer / reloadingSec);
            Player.Instance.playerInfoPanel.SetReloadingBar(_reloadTimer / reloadingSec);

            if (_reloadTimer <= 0) { break; }
        }

        curBulletCount = maxBullet;
        reloading = false;
        //ammoCount_Text.text = ammoCount + " / 5";
    }
}