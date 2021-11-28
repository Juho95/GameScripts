using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    [Header("Ranged Attack")]
    [SerializeField] GameObject ammoPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject ammoSpawn;
    float nextRangedAttackTime = 0f;
    public float rangedAttackRate;
    public int fireBallDamage = 2;


    private PlayerHealth PH;
    private AttackDetails attackDetails;

    public Vector2 playerLocalScale;
    [Header("Melee Attack")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;
    public int tempAttackDamage;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public float stunDamageAmount = 1f;

    [Header("Critical Hit")]
    public int critChance = 5;
    public int checkIfCriticalHit = 0;


    public GameObject floatingDamage;


    //State

    bool isAlive = true;

    //Cached component references
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    Collider2D myCollider2D;




    Coroutine firingCoroutine;
    //Message then methods
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
        PH = GetComponent<PlayerHealth>();
        tempAttackDamage = attackDamage;
    }

    // Update is called once per frame
    void Update()
    {
        AttackAnim();
        //TODO: FIX FIRING. MAKE NEW COOLDOWN
        Fire();
        playerLocalScale = gameObject.transform.localScale;
    }

    private void AttackAnim()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                checkIfCriticalHit = Random.Range(0, 100);
                if(critChance >= checkIfCriticalHit)
                {
                    attackDamage = attackDamage * 2;
                    myAnimator.SetTrigger("CriticalHit");
                }
                else
                {
                    myAnimator.SetTrigger("Attack");
                }
                //myAnimator.SetTrigger("Attack");
                //Attack(); //Huomaa, ett‰ t‰‰ toteutetaan animation eventtin‰.
                nextAttackTime = Time.time + 1f / attackRate;
            
            }

        }

    }

    public void Attack()
    {



        // myAnimator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        attackDetails.damageAmount = attackDamage;
        attackDetails.position = transform.position;
        attackDetails.stunDamageAmount = stunDamageAmount;

        foreach (Collider2D enemy in hitEnemies)
        {
            Instantiate(floatingDamage, enemy.transform.position, Quaternion.identity);
            floatingDamage.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = attackDamage.ToString();

            if (enemy.tag == "Enemy")
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }

            else
            {
                enemy.transform.SendMessage("Damage", attackDetails);
            }

        }
        attackDamage = tempAttackDamage;

    }

    public void Damage(AttackDetails attackDetails)
    {
        Debug.Log("Moi");


        PH.DecreaseHealth(attackDetails.damageAmount);

    }





    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    private void Fire()
    {
        if (Time.time >= nextRangedAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                InstantiateFireBall();
                nextRangedAttackTime = Time.time + 1f / rangedAttackRate;

            }
        }
    }

    private void InstantiateFireBall() 
    {
            GameObject ammo = Instantiate(ammoPrefab, ammoSpawn.transform.position, Quaternion.identity) as GameObject;
            ammo.transform.localScale = -playerLocalScale;
            ammo.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed * -transform.localScale.x, 0);

    }


}
