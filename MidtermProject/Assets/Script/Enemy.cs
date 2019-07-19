using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private gameMaster gm;
    public int health = 60;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health == 0)
        {
            Die();
        }
    }

    IEnumerator Wait()
    {
        gm.points++;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    public void Die()
    {
        GetComponent<Rigidbody2D>().SetRotation(-90);
        StartCoroutine(Wait());

    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
