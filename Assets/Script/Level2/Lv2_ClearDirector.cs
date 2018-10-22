using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lv2_ClearDirector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("ClearScene");
        }

    }
}
