using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotation : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, 22* Time.deltaTime);
    }
}
