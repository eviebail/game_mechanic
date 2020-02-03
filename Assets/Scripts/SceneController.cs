using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    AudioClip space;
	AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        // space = (AudioClip) Resources.Load("Deep_In_Space");
		// music = GetComponent<AudioSource>();
        // music.loop(space);
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKey(KeyCode.B)) {
         DontDestroyOnLoad(this.gameObject);
         SceneManager.LoadScene("Level1");
     }   
    }

}
