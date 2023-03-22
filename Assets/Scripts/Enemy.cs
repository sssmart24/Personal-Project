using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private float distanceChecker=1;
    private Rigidbody enemyRB;
    private GameObject player;
    Animator anim;
    GameManagerDos gmDos;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        gmDos = GameObject.Find("GameManager").GetComponent<GameManagerDos>();
        if(player != null)
        {
            anim.SetTrigger("Walk");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        Vector3 lookDirection = (player.transform.position- transform.position).normalized;
        enemyRB.AddForce(lookDirection * speed);
        AttackPlayer();
    }
    
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject == player)
        {
            gmDos.UpdateLives(-1);
        }
    }

    void AttackPlayer()
    {
        float distance = Vector3.Distance(player.transform.position,transform.position);
        if(distance < distanceChecker)
        {
            anim.SetTrigger("Attack");
        }
        else 
        {
            anim.ResetTrigger("Attack");
        }
    }
}