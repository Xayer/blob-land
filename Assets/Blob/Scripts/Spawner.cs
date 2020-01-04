using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int amountToSpawn = 12;
    private List<GameObject> spawnedObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < amountToSpawn; i++){
            spawnedObjects.Add(Instantiate(
                objectToSpawn,
                new Vector3(
                    Random.Range(-10f, 10f),
                    1.7f,
                    Random.Range(-10f, 10f)
                ),
                Quaternion.Euler(0f,0f,0f)));
        }
    }
    void FixedUpdate(){
        spawnedObjects.ForEach(delegate(GameObject spawnedObjectToModify) {
            spawnedObjectToModify.transform.Rotate(Random.Range(-90f, 0f) * Time.deltaTime, Random.Range(0f, 90f) * Time.deltaTime, 0f);
            Rigidbody RigidBody = spawnedObjectToModify.GetComponent<Rigidbody>();
            if(RigidBody){
                // RigidBody.AddForce(transform.right * (int)Random.Range(-0, 10) * 20, ForceMode.Force);
                // RigidBody.AddForce(transform.up * (int)Random.Range(0, 10) * 20, ForceMode.Force);
                // RigidBody.AddForce(transform.forward * (int)Random.Range(0, 10) * 20, ForceMode.Force);
            }
        });
    }
}
