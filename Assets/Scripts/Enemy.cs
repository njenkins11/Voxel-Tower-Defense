using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{   
    [SerializeField] private float speed = 2f;
    [SerializeField] private float health = 10f;
    [SerializeField] private int damage = 5;
    [SerializeField] private int moneyDropped = 10;
    [SerializeField] private float rotationSpeed = 1f; 
    [SerializeField] private float destroyDeathTimer = 5f;
    [SerializeField] private float playerHitDeathTimer = 2f;
    [SerializeField] private Animator animator;
    private GameObject prev;
    private GameObject next;
    private bool hasHit = false;
    // Start is called before the first frame update
    void Start()
    {
        prev = PathGenerator.path[0];
        transform.position = prev.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Convert.ToInt32(prev.name) < PathGenerator.path.Count-1){
            next = PathGenerator.path[Convert.ToInt32(prev.name)+1];
            transform.position += (next.transform.position - transform.position).normalized * Time.deltaTime * speed;
            Quaternion rot = Quaternion.LookRotation((next.transform.position - transform.position).normalized);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotationSpeed);
            
            if(Vector3.Distance(transform.position, next.transform.position) <= 0.01f)
                prev = next;
        }
        else{
            if(!hasHit)
            GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerController>().TakeDamage(damage);
            hasHit = true;
            animator.SetTrigger("Attack");
            Destroy(gameObject, playerHitDeathTimer);
            tag = "Dead";
        }
    }

    public void TakeDamage(float damage, Tower tower)
    {
        health -= damage;
        animator.SetTrigger("Hit");
        
        if(health <= 0 && !hasHit)
        {
            PlayerController.SetMoney(PlayerController.GetMoney() + moneyDropped);
            animator.SetTrigger("Death");
            Destroy(gameObject, destroyDeathTimer);
            speed = 0;
            tag = "Dead";
            hasHit = true;
            tower.IncrementKillAmount();
        }
    }
}
