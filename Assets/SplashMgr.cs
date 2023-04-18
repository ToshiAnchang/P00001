using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashMgr : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(TimerCoroutine());
    }
    



    IEnumerator TimerCoroutine() {
        yield return new WaitForSeconds(3);
        SceneMgr.Instance.LoadScene("Lobby");
    }

    
}
