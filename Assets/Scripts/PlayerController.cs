using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	Vector3 destination;
	float v_x, v_y, v_z, m_gx, m_gy, m_gz = 0.0f;
	float movementSpeed = 5f;
	float RotateSpeed = 50f;
	bool turnL, turnR;
	Vector3 startPos;
	public static int lives = 3;
	public static float time = 0f;
	AudioClip jump, swoosh;
	AudioSource audio;

	// Start is called before the first frame update
	void Start()
    {
		startPos = transform.position;
		destination = transform.position;
		m_gy = 0.15f;
		Debug.Log("AT Start: " + startPos);
		InvokeRepeating("passTime", 0.0f, 1.0f);
		jump = (AudioClip) Resources.Load("jump_07");
		swoosh = (AudioClip) Resources.Load("jump_27");
		audio = GetComponent<AudioSource>();
    }

    void Move()
	{
		destination = new Vector3(transform.position.x + v_x - m_gx, transform.position.y + v_y - m_gy, transform.position.z + v_z - m_gz);
		//destination = new Vector3(Vector3.forward.x * pos.x, Vector3.forward.y * pos.y, Vector3.forward.z * pos.z);//

		Vector3 p = Vector3.MoveTowards(transform.position, destination, movementSpeed);
		GetComponent<Rigidbody>().MovePosition(p);
	}

	void passTime() {
		time+=1;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		if (Input.GetKey(KeyCode.RightArrow))
		{
			v_x = 0.15f;
			transform.position += transform.right * Time.deltaTime * movementSpeed;
		} else if (Input.GetKey(KeyCode.LeftArrow))
		{
			v_x = -0.15f;
			transform.position -= transform.right * Time.deltaTime * movementSpeed;
		} else {
			v_x = 0.0f;
		}

        if (Input.GetKey(KeyCode.Space))
		{
			v_y = 0.15f;
			transform.position += transform.up * Time.deltaTime * movementSpeed * 2.0f;
		} else {
			v_y = 0.0f;
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			audio.PlayOneShot(jump);
		}

		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S)
		|| Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W)) {
			audio.PlayOneShot(swoosh);
		}

		
		//Move();
	}
    void OnCollisionEnter(Collision other)
	{
		//Debug.Log("Hello " + other.gameObject.name);
        if (other.gameObject.name.Contains("Crystals"))
		{
			GameObject lvl = GameObject.Find("LevelOrientation");
			lvl.GetComponent<LevelController>().rotateToZero();

			
			GameObject refPoint = GameObject.Find("LevelOrientation/Start");
			Debug.Log("owie!! " + transform.position + " >> " + refPoint.transform.position);
			transform.position = new3Vector(refPoint.transform.position, -1.0f*Vector3.forward);

			lives -= 1;

			if (lives <= 0f) {
				//ded
				SceneManager.LoadScene("End");
			}
		}
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name.Contains("Goal1")) {
			SceneManager.LoadScene("Level2");
		}
		if (other.gameObject.name.Contains("Goal2")) {
			SceneManager.LoadScene("End");
		}
	}

	Vector3 new3Vector(Vector3 v1, Vector3 offset)
	{
		return new Vector3(v1.x + offset.x, v1.y + offset.y, v1.z + offset.z);
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
