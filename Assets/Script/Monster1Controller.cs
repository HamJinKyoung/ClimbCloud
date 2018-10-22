using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Monster1Controller : MonoBehaviour {

    int dir;

	// Use this for initialization
	void Start () {
        dir = 1;
        
	}
	
	// Update is called once per frame
	void Update () {

        // 좌우 이동
        transform.Translate(0.02f * dir, 0, 0);

        // 방향 전환
        if (transform.position.x > 2.6f)
        {
            dir = -1;
        }
        if (transform.position.x < -2.6f)
        {
            dir = 1;
        }
        // 움직이는 방향에 따라 이미지 반전
        if (transform.position.x<0.4f || transform.position.x>2.6f)
            transform.localScale = new Vector3(0.15f*dir, 0.15f, 0.15f);
        // 맨 밑에 도착하면 사라짐
        if(transform.position.y<-6.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Player") {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
            GetComponent<AudioSource>().Play();
        }
    }
}
