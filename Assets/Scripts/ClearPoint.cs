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
        Debug.Log("ClearPoint 오브젝트 보이게 하기");
    }
    */


    IEnumerator ProcessWait()
    {
        print("호출전...");
        yield return new WaitForSeconds(5);
        print("호출됨");
        spr.SetActive(true);
        //gameObject.SetActive(true);
    }
}
