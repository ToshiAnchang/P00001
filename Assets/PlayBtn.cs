using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayBtn : MonoBehaviour
{

    [SerializeField] Button playBtn;
    public void Start()
    {
        playBtn.onClick.AddListener(OnclickPlayBtn);
    }

    public void OnclickPlayBtn()
    {
        SceneMgr.Instance.LoadScene("InGame");
    }
}
