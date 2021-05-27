using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public static float speed = 50;
    private void Update()
    {
        Vector3 direction = Vector3.back;
        transform.position += direction * speed * Time.deltaTime;
    }
}
