using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Monster2Controller : MonoBehaviour {

    int dir;

    // Use this for initialization
    void Start () {
        dir = 1;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update() {

        // 좌우 이동
        transform.Translate(0.05f * dir, 0, 0);

        // 방향 전환
        if (transform.position.x > 0.4f)
        {
            dir = -1;
        }
        if (transform.position.x < -2.6f)
        {
            dir = 1;
        }

        // 움직이는 방향에 따라 이미지 반전
        if (transform.position.x < -2.6f || transform.position.x > 0.4f)
        {
            transform.localScale = new Vector3(0.15f * dir, 0.15f, 0.15f);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject director = GameObject.Find("GameDirector");
        director.GetComponent<GameDirector>().DecreaseHp();
    }

}
