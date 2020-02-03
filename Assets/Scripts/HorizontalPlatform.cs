using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    Vector3 finalPos1, finalPos2, destination; //18.5, 4, -0.9
                                  //10, 4, -0.9
    float movementSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        finalPos1 = new Vector3(18.5f, 4.0f, -0.9f);
        finalPos2 = new Vector3(10.0f, 4.0f, -0.9f);
        destination = finalPos1;
    }
    void Move()
	{
		Vector3 p = Vector3.MoveTowards(transform.position, destination, movementSpeed);
		GetComponent<Rigidbody>().MovePosition(p);
        if (finalPos1.x == transform.position.x && finalPos1.y == transform.position.y) {
            destination = finalPos2;
        } else if (finalPos2.x == transform.position.x && finalPos2.y == transform.position.y) {
            destination = finalPos1;
        }
	}

    // Update is called once per frame
    void Update()
    {
        //Move();
    }
}
