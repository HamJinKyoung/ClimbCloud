using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lv2_Restart : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        // r버튼 누르면 재시작
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level2");
        }

    }
}
