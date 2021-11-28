using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    Animator myAnimator;
    public int fireBallDMG;
    public float stunDamageAmount = 1f;
    private AttackDetails attackDetails;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        fireBallDMG = player.GetComponent<PlayerCombat>().fireBallDamage;
        attackDetails.damageAmount = fireBallDMG;
        attackDetails.position = transform.position;
        attackDetails.stunDamageAmount = stunDamageAmount;
    }

    // Update is called once per frame
    void Update()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.transform.SendMessage("Damage", attackDetails);
            myAnimator.SetBool("explosion", true);
            Destroy(gameObject, 0.1f);
        }
        else if (collision.gameObject.CompareTag("Dragon") || collision.gameObject.CompareTag("Bee"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Enemy>().TakeDamage(fireBallDMG);
            myAnimator.SetBool("explosion", true);
            Destroy(gameObject, 0.1f);
        }
    }
}
