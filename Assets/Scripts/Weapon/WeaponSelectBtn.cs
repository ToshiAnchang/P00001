using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectBtn : MonoBehaviour
{
    [SerializeField] string weaponName;
    Button btn;
    private void Start()
    {    
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClickedBtn);
    }


    void OnClickedBtn()
    {
        Player.Instance.SetWeapon(weaponName);
    }
}
