using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
public class PlayerInfoPanel : MonoBehaviour
{
    [SerializeField] TMP_Text bulletCountText; // 총알 개수 노출용 5/10 형태 
    [SerializeField] TMP_Text weaponText; //무기 이름 노출용

    [SerializeField] Image reloadingImg;

    void Start()
    {
        reloadingImg.fillAmount = 0;
    }

    //총 교체 시 호출 
    public void SetWeapon(Weapon _w)
    {
        weaponText.text = _w.key;

    }

    //총 교체 & 총 발사할때 호출 
    public void SetWeaponBullet(int _curCount, int _maxCount)
    {
        bulletCountText.text = $"{_curCount}/{_maxCount}";
    }

    //재장전 중 호출 
    public void SetReloadingBar(float _v)
    {
        reloadingImg.fillAmount = _v;
    }
}