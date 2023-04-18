using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
public class PlayerInfoPanel : MonoBehaviour
{
    [SerializeField] TMP_Text bulletCountText; // �Ѿ� ���� ����� 5/10 ���� 
    [SerializeField] TMP_Text weaponText; //���� �̸� �����

    [SerializeField] Image reloadingImg;

    void Start()
    {
        reloadingImg.fillAmount = 0;
    }

    //�� ��ü �� ȣ�� 
    public void SetWeapon(Weapon _w)
    {
        weaponText.text = _w.key;

    }

    //�� ��ü & �� �߻��Ҷ� ȣ�� 
    public void SetWeaponBullet(int _curCount, int _maxCount)
    {
        bulletCountText.text = $"{_curCount}/{_maxCount}";
    }

    //������ �� ȣ�� 
    public void SetReloadingBar(float _v)
    {
        reloadingImg.fillAmount = _v;
    }
}