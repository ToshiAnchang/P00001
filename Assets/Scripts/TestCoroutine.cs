using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoroutine : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ACoroutine());
        StartCoroutine(BCoroutine());
    }

    IEnumerator ACoroutine()
    {
        while (true)
        {
            Debug.Log("A Coroutine");
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator BCoroutine()
    {
        while (true)
        {
            Debug.Log("B Coroutine");
            yield return new WaitForSeconds(3);
        }
    }

    /*
     * �ڷ�ƾ Ư¡
     * 1.StartCoroutine(func); ���� ȣ��
     * 2.IEnumerator 
     * 3. yield return
     */
}
