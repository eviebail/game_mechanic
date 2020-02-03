using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    Text txt;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Lives: " + PlayerController.lives + "     Time Elapsed: " + PlayerController.time;
    }
}
