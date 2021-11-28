using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoundEnemy : MonoBehaviour
{
    public Transform enemyLedgeDetector;
    private Transform player;
    public float distance = 2f;
    public float playerScannerDistance = 2f;
    public float runSpeed = 1;
    public int facingDirection;
    public bool isPlayerFound = false;
    [Header("Enemy Melee Attack")]
    public float meleeRange;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public float attackDamage;
    private Animator animator;

    private PlayerHealth PH;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        PH = player.GetComponent<PlayerHealth>();
        facingDirection = -1;
    }

    // Update is called once per frame
    void Update()
    {

        EnemyCheckForLedges();
        MoveHorizontally();

    }

    private void EnemyCheckForLedges()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(enemyLedgeDetector.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            transform.localScale = new Vector3(1 * facingDirection, 1, 1);
            runSpeed *= -1;
            facingDirection *= -1;
        }
    }


    private void MoveHorizontally()
    {
        transform.Translate(-runSpeed * Time.deltaTime, 0, 0);
    }



    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Koira osuu pelaajaan");
            PH.DecreaseHealth(attackDamage);

        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(enemyLedgeDetector.position, enemyLedgeDetector.position + (Vector3)(Vector2.down * distance));
        Gizmos.DrawWireSphere(transform.position, meleeRange);
    }

}
