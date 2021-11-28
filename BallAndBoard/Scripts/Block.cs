using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] GameObject powerUpPrefab;
   

    int rngNum;

    Level level;
    [SerializeField] int timesHit; 
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            showNextHitSprite();
        }
    }

    private void showNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        rngNum = Random.Range(1, 6); //Chance to spawn PowerUp
        Debug.Log(rngNum);
        PlayBlockDestroySFX();
        Destroy(gameObject);
        if(rngNum == 1)
        {
            GameObject powerUp = Instantiate(powerUpPrefab, transform.position, Quaternion.identity) as GameObject;
        }
        level.BlockDestroyed();
        TriggerSparklesVFX();

    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameSession>().AddtoScore();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
