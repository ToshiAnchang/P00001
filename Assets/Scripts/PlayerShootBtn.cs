using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerShootBtn : MonoBehaviour
{
    Button btn;
    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClickedShootBtn);
/*        btn.onClick.AddListener(OnClickedShootBtn1);
        btn.onClick.AddListener(OnClickedShootBtn2);
*/
    }

    public void OnClickedShootBtn()
    {
        Player.Instance.Shoot();
    }
/*
    public void OnClickedShootBtn1()
    {
        //Player.Instance.Shoot(Vector2.up);
        print("Btn 2");
    }
    public void OnClickedShootBtn2()
    {
        //Player.Instance.Shoot(Vector2.up);
        print("Btn 3");
    }*/
}
