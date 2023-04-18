using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPoint : MonoBehaviour
{

    [SerializeField] GameObject spr;
    Rigidbody2D rb2d;
    PolygonCollider2D polyCol;


    void Start()
    {
        //gameObject.SetActive(false);
        //Invoke("ActiveClearPoint", 3);
        StartCoroutine(ProcessWait());
        spr.SetActive(false);
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("Stage Clear");
        }
    }

    /*void ActiveClearPoint()
    {
        Debug.Log("ClearPoint ������Ʈ ���̰� �ϱ�");
    }
    */


    IEnumerator ProcessWait()
    {
        print("ȣ����...");
        yield return new WaitForSeconds(5);
        print("ȣ���");
        spr.SetActive(true);
        //gameObject.SetActive(true);
    }
}
