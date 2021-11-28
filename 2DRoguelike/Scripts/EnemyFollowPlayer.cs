using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{

    public float speed;
    public float lineOfSight;
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;

    public float rangedFireRate = 1f;
    private float nextFireTime;

    public float meleeRange;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public float attackDamage;
    private Transform player;
    private Animator animator;

    private PlayerHealth PH;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        PH = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (meleeRange < distanceFromPlayer && distanceFromPlayer < lineOfSight && distanceFromPlayer > shootingRange)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = player.transform.position.x > gameObject.transform.position.x;
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= meleeRange)
        {
            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("attack");
                PH.DecreaseHealth(attackDamage);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        else if(distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            animator.SetTrigger("shoot");
            //Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            //nextFireTime = Time.time + rangedFireRate;
        }



    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, meleeRange);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    public void ShootDragonFire()
    {
        Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
        nextFireTime = Time.time + rangedFireRate;
    }
}
