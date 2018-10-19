using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class HeartController : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<AudioSource>().Play();

        GameObject director = GameObject.Find("GameDirector");
        director.GetComponent<GameDirector>().IncreaseHp();

        Destroy(gameObject, 0.2f);
    }
}
