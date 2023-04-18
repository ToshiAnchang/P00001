using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10;


    bool _sgs = false;
    bool shooting;
    Vector2 vec_dir;

    Monster monster;


    private void Start()
    {
        //shooting = false;
    }

    public void Shoot(Vector2 _startPos, Vector2 _dir)
    {
        shooting = true;
        transform.position = _startPos;
        vec_dir = _dir;
    }

    public void Shoot2(Vector2 _startPos, Monster _mob)
    {
        monster = _mob;        
        shooting = true;
        transform.position = _startPos;        
        _sgs = true;
    }


    private void Update()
    {
        if (!shooting)
            return;
        //많이 사용할 형태
        if (_sgs)
        {
            if (monster == null) { _sgs = false; return; }
            transform.position = Vector2.MoveTowards(transform.position, monster.transform.position, 5 * Time.deltaTime);
        }
        else
        {
            transform.position = (Vector2)transform.position + vec_dir * Time.deltaTime * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("monster"))
        {
            //if(_sgs) { _sgs = false; }
            collision.GetComponent<Monster>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}