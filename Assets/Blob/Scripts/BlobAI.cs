using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobAI : MonoBehaviour
{
    public Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    public GameObject head;
    public GameObject child;
    public float minRotationX = 13f;
    public float maxRotationX = -47f;
    private float distanceToTarget;
    private GameObject body;
    public float rotationSmoothing = 20000f;
    
    void Awake(){
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindWithTag("Player").transform.LookAt(target);
        agent.destination = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        calculateDistance();
        if(agent.stoppingDistance <= distanceToTarget) {
            //adjustHeadPosition();
        }
    }

    void calculateDistance(){
        distanceToTarget = Vector3.Distance(transform.position,target.transform.position);
    }

    void adjustHeadPosition(){

        Quaternion targetRotation = transform.rotation;
        if(target.rotation.x >= maxRotationX){
            targetRotation.x = maxRotationX;
            Debug.Log("maxRotationX Set");
        } else if (target.rotation.x <= minRotationX){
            targetRotation.x = minRotationX;
            Debug.Log("min Rotation Set");
        }
        head.transform.rotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSmoothing);
    }
}
