using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotator : MonoBehaviour
{
    public Transform target;
    public GameObject head;
    public float minRotationX = -27f;
    public float maxRotationX = 60f;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
