using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public float searchingRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool SearchUp()
    {

        RaycastHit hit;
        Ray lineRay = new Ray(transform.position, Vector3.up);
        Debug.DrawRay(transform.position, Vector3.up * searchingRange);

        if (Physics.Raycast(lineRay, out hit, searchingRange))
        {
            if (hit.collider.tag == "Cube")
            {
                Debug.Log(hit);
                return true;
            }
        }
        return false;
    }

    public bool SearchDown()
    {
        RaycastHit hit;
        Ray lineRay = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down * searchingRange);

        if (Physics.Raycast(lineRay, out hit, searchingRange))
        {
            if (hit.collider.tag == "Cube")
            {
                Debug.Log(hit);
                return true;
            }
        }

        return false;
    }
    public bool SearchRight()
    {

        RaycastHit hit;
        Ray lineRay = new Ray(transform.position, Vector3.right);
        Debug.DrawRay(transform.position, Vector3.right * searchingRange);

        if (Physics.Raycast(lineRay, out hit, searchingRange))
        {
            if (hit.collider.tag == "Cube")
            {
                Debug.Log(hit);
                return true;
            }
        }
        return false;
    }
    public bool SearchLeft()
    {

        RaycastHit hit;
        Ray lineRay = new Ray(transform.position, Vector3.left);
        Debug.DrawRay(transform.position, Vector3.left * searchingRange);

        if (Physics.Raycast(lineRay, out hit, searchingRange))
        {
            if (hit.collider.tag == "Cube")
            {
                Debug.Log(hit);
                return true;
            }
        }
        return false;
    }









    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, searchingRange);
    }

}
