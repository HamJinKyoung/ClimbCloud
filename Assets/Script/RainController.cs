using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class RainController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // 프레임마다 등속으로 낙하시킨다.
        transform.Translate(0, -0.1f, 0);

        // 화면 밖으로 나오면 소멸시킨다.
        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<AudioSource>().Play();

            // 충돌하면 소멸시킨다.
            Destroy(gameObject, 0.1f);

            // 감독 스크립트에 플레이어와 빗방울이 충돌햇다고 전달한다.
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            

        }
    }
}
