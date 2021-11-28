using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFollowPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSight;

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

        if (distanceFromPlayer < lineOfSight)
        {
            animator.SetBool("move", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = player.transform.position.x > gameObject.transform.position.x;
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }
}
