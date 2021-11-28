using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System.Transactions;
using UnityEngine;

public class PowerUp : MonoBehaviour
{


    [SerializeField] GameObject player;
    [SerializeField] float moveSpeed = 0.5f;


    AudioSource myAudioSource;
    [SerializeField] AudioClip[] powerUpSounds;

    int rngNum;
    [Header("Projectile")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.5f;


    [SerializeField] GameObject ball;


    // Start is called before the first frame update
    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
        ball = GameObject.FindWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
        gameObject.transform.Rotate(360 * Time.deltaTime, 0 , 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with trigger object " + collision.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioClip clip = powerUpSounds[0];
            myAudioSource.PlayOneShot(clip);
            rngNum = Random.Range(1, 4);
            Debug.Log(rngNum);

            if (rngNum == 1)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                StartCoroutine(ScaleOverTime(7));
            }
            else if (rngNum == 2)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                Debug.Log("Ampuminen");
                StartCoroutine(Fire(6));
            }
            else if (rngNum == 3) 
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                StartCoroutine(EnlargeBall(5));
                Debug.Log("Pallo kasvaa");
            }
        }

    }


     IEnumerator ScaleOverTime(float time)
    {

        Vector3 originalScale = player.transform.localScale;
        Vector3 destinationScale = new Vector3(2.0f, 1f, 1f);

        float currentTime = 0.0f;

        do
        {
            player.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;

        } while (currentTime <= time);

        player.transform.localScale = new Vector3(1, 1, 1);
        Destroy(gameObject);

    }

    IEnumerator Fire(float time)
    {
        float currentTime = 0.0f;
        float waitTime = 1.0f;
        float shootTime = 0.0f; 
        do
        {
            
            shootTime += Time.deltaTime;
            if (shootTime > waitTime)
            {
                GameObject projectile = Instantiate(projectilePrefab, player.transform.position, Quaternion.identity) as GameObject;
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

                shootTime = 0;
            }
            currentTime += Time.deltaTime;
            yield return null;
        }
        while(currentTime <= time);
        Destroy(gameObject);
    }

    IEnumerator EnlargeBall(float time)
    {

        Vector3 originalScale = ball.transform.localScale;
        Vector3 destinationScale = new Vector3(2.0f, 2.0f, 1f);


        float currentTime = 0.0f;

        do
        {
            ball.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            ball.GetComponent<Renderer>().material.color = Color.yellow;
            currentTime += Time.deltaTime;
            yield return null;

        } while (currentTime <= time);

        ball.transform.localScale = new Vector3(1, 1, 1);
        ball.GetComponent<Renderer>().material.color = Color.white;
        Destroy(gameObject);

    }
}





