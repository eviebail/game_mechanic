using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Vector3 destination;
	float v_x, v_y, v_z = 0.0f;
	float movementSpeed = 5f;
	float RotateSpeed = 50f;
	bool turnL, turnR;
	// Start is called before the first frame update
	void Start()
    {
		destination = transform.position;
    }

    void Move()
	{
		//Vector3 pos = new Vector3(transform.position.x, transform.position.y + v_y, transform.position.z + v_z);
		//destination = new Vector3(Vector3.forward.x * pos.x, Vector3.forward.y * pos.y, Vector3.forward.z * pos.z);//

		//Vector3 p = Vector3.MoveTowards(transform.position, destination, speed);
		//GetComponent<Rigidbody>().MovePosition(p);
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
		} else if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += transform.forward * Time.deltaTime * movementSpeed;
		} else if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position -= transform.forward * Time.deltaTime * movementSpeed;
		} else
		{
			v_z = 0;
		}

        if (Input.GetKey(KeyCode.Space))
		{
			transform.position += transform.up * Time.deltaTime * movementSpeed;
		}
	}
    void OnCollisionEnter(Collision other)
	{
		//Debug.Log("Hello " + other.gameObject.name);
        if (other.gameObject.name.Contains("interactable"))
		{
			Material m_Material = other.gameObject.GetComponent<Renderer>().material;
			m_Material.color = Color.yellow;
			other.gameObject.GetComponent<PlatformController>().enabled = true;
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.name.Contains("interactable"))
		{
			Material m_Material = other.gameObject.GetComponent<Renderer>().material;
			m_Material.color = new Color(255f/255f, 81f/255f, 143f/255f, 255f/255f);
			other.gameObject.GetComponent<PlatformController>().enabled = false;
			transform.parent = null;
		}
	}
}
