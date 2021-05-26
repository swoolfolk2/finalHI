using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train_Movement : MonoBehaviour
{

    static public float speed = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.back;
        transform.position += direction * speed * Time.deltaTime;

    }
}
