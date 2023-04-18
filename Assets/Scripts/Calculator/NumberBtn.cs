using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NumberBtn : MonoBehaviour
{
    Button btn;

    [SerializeField] string value;

    private void Start()
    {
        value = GetComponentInChildren<TMP_Text>().text;
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClickedBtn);
    }


    void OnClickedBtn()
    {
        CalculatorMgr.Instance.EnterNumber(value);
    }
}