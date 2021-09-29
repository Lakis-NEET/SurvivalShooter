using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        //Mencari gameObject yang memiliki tag "Player"
        player = GameObject.FindGameObjectWithTag ("Player");
        
        //Mendapatkan komponen player health
        playerHealth = player.GetComponent <PlayerHealth> ();

        //Mendapatkan Health enemy
        enemyHealth = GetComponent<EnemyHealth>();

        //mendapatkan komponen Animator
        anim = GetComponent <Animator> ();
    }

    //Jika suatu objek masuk ke dalam trigger
    void OnTriggerEnter (Collider other)
    {
        //Menempatkan player dalam jangkauan
        if(other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = true;
        }
    }

    //Jika ada objek yang keluar dari trigger
    void OnTriggerExit (Collider other)
    {
        //Menempatkan player tidak dalam jangkauan
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange/* && enemyHealth.currentHealth > 0*/)
        {
            Attack ();
        }

        //Memutar animasi PlayerDead ketika Health player <= 0
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }
    }


    void Attack ()
    {
        //Reset timer
        timer = 0f;

        //Player menerima damage ketika Health > 0
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
