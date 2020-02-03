using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    Vector3 destination; //2, -4, -0.9
                                  //2, 11, -0.9
    float movementSpeed = 0.15f;
    GameObject finalPos1, finalPos2; 


    // Start is called before the first frame update
    void Start()
    {
        finalPos1 = GameObject.Find("LevelOrientation/VDest1");
        finalPos2 = GameObject.Find("LevelOrientation/VDest2");
        destination = finalPos1.transform.position;
    }
    void Move()
	{
		Vector3 p = Vector3.MoveTowards(transform.position, destination, movementSpeed);
		GetComponent<Rigidbody>().MovePosition(p);
        if (finalPos1.transform.position.x == transform.position.x && finalPos1.transform.position.y == transform.position.y) {
            destination = finalPos2.transform.position;
        } else if (finalPos2.transform.position.x == transform.position.x && finalPos2.transform.position.y == transform.position.y) {
            destination = finalPos1.transform.position;
        }
	}

    // Update is called once per frame
    void Update()
    {
        //Move();
    }
}
