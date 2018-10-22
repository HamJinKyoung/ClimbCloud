using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lv1_FlagController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
            SceneManager.LoadScene("Lv1_Clear");
    }
}