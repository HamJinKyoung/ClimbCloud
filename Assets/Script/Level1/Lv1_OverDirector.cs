using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lv1_OverDirector : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Level1");
        }
    }
}