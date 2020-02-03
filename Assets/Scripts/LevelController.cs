using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    GameObject camera;
    Quaternion iniRot;
    float orient = 0.0f;
    void Start()
    {
        player = GameObject.Find("Player");
        camera = GameObject.Find("Main Camera");
        iniRot = camera.transform.rotation;
    }

    public void rotateToZero() {
            if (orient == 180.0f) {
                transform.RotateAround(new3Vector(player.transform.position, 0*Vector3.up), Vector3.forward, -180.0f);
                orient = 0.0f;
            }
            else if (orient == 90.0f) {
                transform.RotateAround(new3Vector(player.transform.position, 0*Vector3.up), Vector3.forward, -90.0f);
                orient = 0.0f;
            }
            else if (orient == 270.0f) {
                transform.RotateAround(new3Vector(player.transform.position, 0*Vector3.up), Vector3.forward, -270.0f);
                orient = 0.0f;
            }
    }

    void LateUpdate() {
        camera.transform.rotation = iniRot;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) { // orient = 90
			//toggle x
            if (orient == 0.0f) {
                transform.RotateAround(new3Vector(player.transform.position, 0.5f*Vector3.up), Vector3.forward, 90.0f);
                orient = 90.0f;
            } else if (orient == 180.0f) {
                transform.RotateAround(new3Vector(player.transform.position, 0.5f*Vector3.up), Vector3.forward, -90.0f);
                orient = 90.0f;
            }
            else if (orient == 270.0f) {
                transform.RotateAround(new3Vector(player.transform.position, 0.5f*Vector3.up), Vector3.forward, -180.0f);
                orient = 90.0f;
            }
        }
		if (Input.GetKeyDown(KeyCode.S)) { //orient = 180
			//toggle y
            //reverse y direction of everything
            if (orient == 0.0f) {
                transform.RotateAround(new3Vector(player.transform.position, 0.5f*Vector3.up), Vector3.forward, 180.0f);
                orient = 180.0f;
            }
            else if (orient == 90.0f) {
                transform.RotateAround(new3Vector(player.transform.position, 0.5f*Vector3.up), Vector3.forward, 90.0f);
                orient = 180.0f;
            }
            else if (orient == 270.0f) {
                transform.RotateAround(new3Vector(player.transform.position, 0.5f*Vector3.up), Vector3.forward, -90.0f);
                orient = 180.0f;
            }
		}
		if (Input.GetKey(KeyCode.Q)) { // orient = 270
			//toggle x
            if (orient == 0.0f) {
                transform.RotateAround(new3Vector(player.transform.position, 0.5f*Vector3.up), Vector3.forward, 270.0f);
                orient = 270.0f;
            } else if (orient == 180.0f) {
                transform.RotateAround(new3Vector(player.transform.position, 0.5f*Vector3.up), Vector3.forward, 90.0f);
                orient = 270.0f;
            }
            else if (orient == 90.0f) {
                transform.RotateAround(new3Vector(player.transform.position, 0.5f*Vector3.up), Vector3.forward, 180.0f);
                orient = 270.0f;
            }
        }
		if (Input.GetKeyDown(KeyCode.W)) { //orient = 0
			//toggle y
            //reverse y direction of everything
            if (orient == 180.0f) {
                transform.RotateAround(new3Vector(player.transform.position, 0.5f*Vector3.up), Vector3.forward, -180.0f);
                orient = 0.0f;
            }
            else if (orient == 90.0f) {
                transform.RotateAround(new3Vector(player.transform.position, 0.5f*Vector3.up), Vector3.forward, -90.0f);
                orient = 0.0f;
            }
            else if (orient == 270.0f) {
                transform.RotateAround(new3Vector(player.transform.position, 0.5f*Vector3.up), Vector3.forward, -270.0f);
                orient = 0.0f;
            }
		}
    }
    Vector3 new3Vector(Vector3 v1, Vector3 offset)
	{
		return new Vector3(v1.x + offset.x, v1.y + offset.y, v1.z + offset.z);
	}
}
