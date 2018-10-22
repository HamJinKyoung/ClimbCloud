using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
