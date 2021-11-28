using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public Transform ledgeDetection;
    public float distance = 2f;

    public bool platformSpawned = false;
    public GameObject[] newPlatform;
    public bool canSpawnNewPlatform = false;
    public GameObject parentPlatform;
    public GameObject lastChild;

    public Vector2 newPlatformLocation;
    public float platformHeight = 0;

    public int randomPlatform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForLedges();
    }

    private void CheckForLedges()
    {

        newPlatformLocation = new Vector2(gameObject.transform.position.x + 8, platformHeight);

        RaycastHit2D groundInfo = Physics2D.Raycast(ledgeDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false && gameObject.transform.localScale.x == -1)
        {
            randomPlatform = Random.Range(0, newPlatform.Length);
            Debug.Log("RAJALLA");
            if (platformSpawned == false && canSpawnNewPlatform == true)
            {
                GameObject newPlatforms = Instantiate(newPlatform[randomPlatform], newPlatformLocation, Quaternion.identity);
                newPlatforms.transform.parent = parentPlatform.transform;
                GameObject.Find("GameInfo").GetComponent<ScoreScript>().scoreValue += 5f;
                platformSpawned = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            int lastChildIndex = parentPlatform.transform.childCount - 1;
            lastChild = parentPlatform.transform.GetChild(lastChildIndex).gameObject;

            if (collision.gameObject == lastChild)
            {
                Debug.Log("Ollaan uusimmalla platformilla");

                platformHeight = Random.Range(lastChild.transform.position.y - 1.5f, lastChild.transform.position.y + 1.5f);
                if(platformHeight < -4.45f)
                {
                    platformHeight = -4.45f;
                }

                else if (platformHeight > 3.4f)
                {
                    platformHeight = 3.4f;
                }

                canSpawnNewPlatform = true;
                platformSpawned = false;

            }
            else
            {
                canSpawnNewPlatform = false;
            }
        }
    }
}
