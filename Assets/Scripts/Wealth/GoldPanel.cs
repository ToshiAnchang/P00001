using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldPanel : MonoBehaviour
{
    [SerializeField] TMP_Text goldText;
    void Start()
    {
        goldText.text = "0";
    }

    public void SetGold(int _gold)
    {
        goldText.text = _gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {       
    }
}
