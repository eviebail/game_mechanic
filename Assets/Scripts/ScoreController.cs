using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    TextMesh title, subtitle;
    // Start is called before the first frame update
    void Start()
    {
        title = GameObject.Find("Title").GetComponent<TextMesh>();
        subtitle = GameObject.Find("Subtitle").GetComponent<TextMesh>();

        if (PlayerController.lives <= 0) {
            title.text = "You Lose!";
            subtitle.text = "Tap to Play Again!";
        } else {
            title.text = "You Win!";
            subtitle.text = "Time: " + PlayerController.time + "\n" + "Tap to Play Again!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            PlayerController.time = 0;
            PlayerController.lives = 3;
            SceneManager.LoadScene("Level1");
        }  
    }
}
