//using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateBtn : MonoBehaviour
{
    [SerializeField] string function;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickedBtn);        
    }


    void OnClickedBtn()
    {
        CalculatorMgr.Instance.EnterFunction(function);
        print(function + " ¿‘¥œ¥Ÿ");
    }
}