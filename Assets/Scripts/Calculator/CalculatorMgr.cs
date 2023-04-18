using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalculatorMgr : MonoBehaviour
{
    private static CalculatorMgr instance;
    public static CalculatorMgr Instance
    {
        get { return instance; }
    }

    [SerializeField] TMP_Text displayText;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    [SerializeField] string curNum;
    [SerializeField] string savedNum;
    [SerializeField] string curOperateKey;

    private void Start()
    {
        curNum = "0";
        savedNum = "";
        curOperateKey = "";
        UpdateDisplayNumber();
    }

    public void EnterNumber(string _n)
    {
        curNum += _n;
        if (string.IsNullOrEmpty(curOperateKey))
        {
            int _curNum = int.Parse(curNum);
            if (_curNum == 0)
                curNum = "0";
        }
        curNum = int.Parse(curNum).ToString();
        UpdateDisplayNumber();
    }

    public void EnterFunction(string _key)
    {

        switch (_key)
        {
            case "Cancel":
                curNum = "0";
                savedNum = "";
                curOperateKey = "";
                UpdateDisplayNumber();
                break;
            case "Enter":
                if (string.IsNullOrEmpty(curOperateKey) || string.IsNullOrEmpty(savedNum))
                    return;

                int _v1 = int.Parse(savedNum);
                int _v2 = int.Parse(curNum);

                curNum = Operate(curOperateKey, _v1, _v2).ToString();
                UpdateDisplayNumber();
                curOperateKey = "";

                break;
            case "Add":
            case "Sub":
            case "Multi":
                if (!string.IsNullOrEmpty(curOperateKey))
                {
                    _v1 = int.Parse(savedNum);
                    _v2 = int.Parse(curNum);

                    curNum = Operate(curOperateKey, _v1, _v2).ToString();
                    UpdateDisplayNumber();
                    savedNum = curNum;
                }
                else
                {
                    savedNum = curNum;
                    UpdateDisplayNumber();
                }
                curNum = "0";
                curOperateKey = _key;
                break;
        }
    }

    int Operate(string _o, int _v1, int _v2)
    {
        switch (_o)
        {
            case "Add":
                return _v1 + _v2;
            case "Sub":
                return _v1 - _v2;
            case "Multi":
                return _v1 * _v2;
        }
        return 0;
    }

    void UpdateDisplayNumber()
    {
        displayText.text = curNum;
    }
}