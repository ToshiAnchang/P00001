using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_mob : MonoBehaviour
{
    [SerializeField] float speed = 10;

    int mob_Damage;

    bool shooting;
    int zero_value;
    Vector2 vec_dir;

    private void Start()
    {
        //shooting = false;
        //print("값은 " + zero_value);
    }

    public void Shoot(Vector2 _startPos, Vector2 _dir, int ddd)
    {
        shooting = true;
        transform.position = _startPos;
        vec_dir = _dir;
        mob_Damage = ddd;
        
    }

    private void Update()
    {
        if (!shooting)
            return;
        //많이 사용할 형태

        transform.position = (Vector2)transform.position + vec_dir * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage(mob_Damage);
            Destroy(gameObject);
        }
    }

}