using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
	GameObject[] allInteractables;
	List<List<GameObject>> groups;
    // Start is called before the first frame update
    void Start()
    {
		allInteractables = GameObject.FindGameObjectsWithTag("interactable");
	}

    void formGroups()
	{
  //      for (int i = 0; i < allInteractables.Count; i++)
		//{

		//}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
