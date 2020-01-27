using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//figure out how to get platforms to stack with each other!!
//have some state manager that forms lists of connected platforms
//based on the direction of movement, figure out 'last position' of updatePosition
//have stateController call update position on head guy, have everyone else be a child of the transform?

public class PlatformController : MonoBehaviour
{
	public int gravity_direction = 1; //0 = x, 1 = y, 2 = z
	public bool positive = false;
	Vector3 final_position;
	public bool enabled = false;
	float movementSpeed = 1f;
	public bool final_destination = false;
	public int group = -1;
    public static int GLOBALID = 0;

	// Start is called before the first frame update
	void Start()
    {
		final_position = new3Vector(transform.position, new Vector3(0, 0, 0));
		Debug.Log(transform.position + ", " + final_position);
		gameObject.name = "interactable";
		gameObject.tag = "interactable";
    }

    void Move()
	{
		UpdatePosition();
		//X
		if (gravity_direction == 0 && System.Math.Abs(final_position.x - transform.position.x) < 0.1f)
		{
			//do nothing
			final_destination = true;
		}
        else if (gravity_direction == 0 && final_position.x >= transform.position.x)
		{
			transform.position += transform.right * Time.deltaTime * movementSpeed;
		} else if (gravity_direction == 0 && final_position.x <= transform.position.x)
		{
			transform.position -= transform.right * Time.deltaTime * movementSpeed;
		}

		//Y
		if (gravity_direction == 1 && System.Math.Abs(final_position.y - transform.position.y) < 0.1f)
		{
			//do nothing
			final_destination = true;
		}
		else if (gravity_direction == 1 && final_position.y > transform.position.y)
		{
			//Debug.Log("MOVING!");
			transform.position += transform.up * Time.deltaTime * movementSpeed;
		}
		else if (gravity_direction == 1 && final_position.y < transform.position.y)
		{
			transform.position -= transform.up * Time.deltaTime * movementSpeed;
		}

		//Z
		if (gravity_direction == 2 && System.Math.Abs(final_position.z - transform.position.z) < 0.1f)
		{
			//do nothing
			final_destination = true;
		}
		else if (gravity_direction == 2 && final_position.z > transform.position.z)
		{
			transform.position += transform.forward * Time.deltaTime * movementSpeed;
		}
		else if (gravity_direction == 2 && final_position.z < transform.position.z)
		{
			transform.position -= transform.forward * Time.deltaTime * movementSpeed;
		}
	}

    void UpdatePosition()
	{
        //keep moving the object until it collides with something (with a little buffer area)
        if (gravity_direction == 0) //X = Right
		{
			Vector3 direction = new Vector3(1, 0, 0);
            if (!positive)
			{
				direction = new Vector3(-1,0,0);
			}
			Vector3 test = new3Vector(final_position, direction);
			RaycastHit hit;
            if (positive)
			{
				Physics.Raycast(transform.position, transform.right, out hit, 1f);
			} else
			{
				Physics.Raycast(transform.position, -transform.right, out hit, 1f);
			}
			if (hit.transform == null || hit.transform.name.Equals("Player")
				|| hit.transform.name.Contains("interactable"))
			{
                final_position = test;
				//Debug.Log("update pos?");
			} else
			{
				final_position = transform.position;
				//Debug.Log("Hit." + hit.transform.name);
			}
			Debug.DrawRay(transform.position, transform.right * hit.distance, Color.red);
		} else if (gravity_direction == 1) //Y = Up
		{
			Vector3 direction = new Vector3(0, 4f, 0);
			if (!positive)
			{
				direction = new Vector3(0, -0.25f, 0);
			}
			Vector3 test = new3Vector(final_position, direction);
			RaycastHit hit;
            if (positive)
			{
				Physics.Raycast(new3Vector(transform.position, new Vector3(0,0.5f,0)), transform.up, out hit, 0.5f);
			} else
			{
				Physics.Raycast(transform.position, -transform.up, out hit, 0.5f);
			}
			if (hit.transform == null || hit.transform.name.Equals("Player")
				|| hit.transform.name.Contains("interactable"))
			{
				final_position = test;
			} else
			{
				//Debug.Log("Hit " + hit.transform.name);
				final_position = transform.position;
			}
		} else //Z == Forward
		{
			Vector3 direction = new Vector3(0, 0, 1);
			if (!positive)
			{
				direction = new Vector3(0, 0, -1);
			}
			Vector3 test = new3Vector(final_position, direction);
			RaycastHit hit;
            if (positive)
			{
				Physics.Raycast(transform.position, transform.forward, out hit, 1f);
			} else
			{
				Physics.Raycast(transform.position, -transform.forward, out hit, 1f);
			}
			
			if (hit.transform == null || hit.transform.name.Equals("Player")
				|| hit.transform.name.Contains("interactable"))
			{
				final_position = test;
			} else
			{
				//Debug.Log("Hit " + hit.transform.name);
				final_position = transform.position;
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
        if (enabled && Input.GetKey(KeyCode.Q))
		{
			gravity_direction = 0;
			positive = true;
			final_position = new3Vector(transform.position, new Vector3(1,0,0));
		} else if (enabled && Input.GetKey(KeyCode.W))
		{
			gravity_direction = 1;
			positive = true;
			final_position = new3Vector(transform.position, new Vector3(0, 1, 0));
			//Debug.Log(positive + ", " + gravity_direction);
		} else if (enabled && Input.GetKey(KeyCode.E))
		{
			gravity_direction = 2;
			positive = true;
			final_position = new3Vector(transform.position, new Vector3(0, 0, 1));
		} else if (enabled && Input.GetKey(KeyCode.A))
		{
			gravity_direction = 0;
			positive = false;
			final_position = new3Vector(transform.position, new Vector3(-1, 0, 0));
		}
		else if (enabled && Input.GetKey(KeyCode.S))
		{
			//Debug.Log("SSSSSSS");
			gravity_direction = 1;
			positive = false;
			final_position = new3Vector(transform.position, new Vector3(0, -1, 0));
		}
		else if (enabled && Input.GetKey(KeyCode.D))
		{
			gravity_direction = 2;
			positive = false;
			final_position = new3Vector(transform.position, new Vector3(0, 0, -1));
		}
	}

    void FixedUpdate()
	{
		Move();
	}

	void OnCollisionEnter(Collision other)
	{
		//Debug.Log("Collided with " + other.gameObject.name);
		if (other.gameObject.name.Contains("interactable"))
		{
			//
			//if (other_platform.group == -1)
			//{
			//	if (group == -1)
			//	{
			//		other_platform.group = GLOBALID;
			//		group = GLOBALID;
			//		GLOBALID++;
			//	} else
			//	{
			//		other_platform.group = group;
			//	}

			//} else
			//{
			//	group = other_platform.group;
			//}
			//
			PlatformController other_platform = other.gameObject.GetComponent<PlatformController>();
			bool active = other_platform.enabled;
			//Debug.Log("this : " + this.gravity_direction + " other " + other_platform.gravity_direction);
			if (active && !enabled)
			{
				enabled = active;
				GetComponent<Renderer>().material.color = Color.yellow;
				//this.gravity_direction = other_platform.gravity_direction;
				//this.positive = other_platform.positive;
				transform.parent = other.transform;
			}
		}
	}

    void OnTriggerEnter(Collider other)
	{
		Debug.Log("Triggered " + other.gameObject.name);
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.name.Contains("interactable"))
		{
			PlatformController other_platform = other.gameObject.GetComponent<PlatformController>();
			//other_platform.group = -1;

			bool active = other.gameObject.GetComponent<PlatformController>().enabled;
			if (active)
			{
				enabled = false;
				GetComponent<Renderer>().material.color = new Color(255f / 255f, 81f / 255f, 143f / 255f, 255f / 255f);
				transform.parent = null;
			}
		}
	}

	bool Equals(Vector3 v1, Vector3 v2)
	{
        return (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z);
	}

    Vector3 new3Vector(Vector3 v1, Vector3 offset)
	{
		return new Vector3(v1.x + offset.x, v1.y + offset.y, v1.z + offset.z);
	}

}
