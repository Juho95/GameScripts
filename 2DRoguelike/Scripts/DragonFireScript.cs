using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFireScript : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    public int dragonFireDamage;
    private PlayerHealth PH;
    public Animator animator;
    Vector2 moveDir;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        bulletRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        PH = target.GetComponent<PlayerHealth>();
        moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2f);
    }

    private void Update()
    {
        float AngleRad = Mathf.Atan2(player.transform.position.y - gameObject.transform.position.y, player.transform.position.x - gameObject.transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            PH.DecreaseHealth(dragonFireDamage);
            animator.SetBool("explosion", true);
            Destroy(gameObject, 0.1f);
        }
    }

}
