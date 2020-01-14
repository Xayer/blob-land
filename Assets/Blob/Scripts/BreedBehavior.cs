using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedBehavior : MonoBehaviour
{
    public GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            this.breedWithPlayer();
        }
    }

    void breedWithPlayer(){
        Vector3 position = transform.position;
        position.x += 1;
        position.y += 10;
        Instantiate(
                child,
                position,
                Quaternion.Euler(0f,0f,0f));
    }
}
