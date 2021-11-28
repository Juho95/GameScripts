using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{

    [Header("Ability 1")]
    public Image abilityImage1;
    public float cooldown1 = 20;
    bool isCooldown = false;

    [Header("Ultimate: Firestorm")]
    [SerializeField] GameObject fireStorm;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed;
    int rngNum;


    [Header("Ability 2")]
    public Image abilityImage2;
    public float cooldown2 = 20;
    bool isCooldown2 = false;

    [Header("Ultimate: Tsunami")]
    [SerializeField] GameObject tsunamiPrefab;
    [SerializeField] GameObject tsunamiSpawn1;
    [SerializeField] GameObject tsunamiSpawn2;
    [SerializeField] float tsunamiSpeed;

    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
        Ability2();
    }

    void Ability1()
    {
        if (Input.GetKey(KeyCode.U) && isCooldown == false)
        {
            isCooldown = true;
            abilityImage1.fillAmount = 1;
            StartCoroutine(CastFireStorm(10));
        }

        if (isCooldown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if (abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    IEnumerator CastFireStorm(float time)
    {
        GameObject fireStormCloud = Instantiate(fireStorm, new Vector3(0.2f, 4.77f, 0), Quaternion.identity);
        Debug.Log("CASTING FIRESTOORM!!!");

        float currentTime = 0.0f;
        float waitTime = 1.0f;
        float shootTime = 0.0f;
        do
        {
            rngNum = Random.Range(0, 3);
            shootTime += Time.deltaTime;
            if (shootTime > waitTime)
            {
                GameObject projectile = Instantiate(projectilePrefab, fireStorm.transform.GetChild(rngNum).transform.position, Quaternion.identity) as GameObject;
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);

                shootTime = 0;
            }
            currentTime += Time.deltaTime;
            yield return null;
        }
        while (currentTime <= time);
        Destroy(fireStormCloud);
    }




    void Ability2()
    {
        if (Input.GetKey(KeyCode.Y) && isCooldown2 == false)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
            Debug.Log("MUUTUTAAN KARHUKSI!!!!");
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            StartCoroutine(BearForm(10f));
        }

        if (isCooldown)
        {
            abilityImage2.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    IEnumerator BearForm(float bearTime)
    {
        yield return new WaitForSeconds(bearTime);
        Debug.Log("Muututaan takaisin ihmiseksi!");
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
}