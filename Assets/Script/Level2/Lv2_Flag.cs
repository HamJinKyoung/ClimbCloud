using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lv2_Flag : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("Lv2_Clear");
    }
}
