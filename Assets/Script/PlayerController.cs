﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rigid2D;
    Animator animator;
    GameObject director;
    float jumpForce = 600.0f;
    float walkForce = 30.3f;
    float maxWalkSpeed = 2.0f;
    public bool jumpMode;

	// Use this for initialization
	void Start () {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.director = GameObject.Find("GameDirector");
        jumpMode = true;
    }
	
	// Update is called once per frame
	void Update () {
        
        // 점프
        if (jumpMode)
        {
            if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
            {
                this.animator.SetTrigger("JumpTrigger");
                this.rigid2D.AddForce(transform.up * this.jumpForce);
                GetComponent<AudioSource>().Play();
            }
        }
        
        // 좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // 플레이어 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // 스피트 제한
        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 움직이는 방향에 따라 이미지 반전
        if(key!=0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // 플레이어의 속도에 맞춰 애니메이션 속도를 바꾼다.
        if(this.rigid2D.velocity.y==0)
        {
            this.animator.speed = speedx / 2.0f;
        } else
        {
            this.animator.speed = 1.0f;
        }
        
        // 플레이어가 화면 밖으로 나갔다면 게임오버
        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("OverScene");
        }

    }
    
    // Collision 충돌 판정
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag != "cloud4")
        {
            jumpMode = true;
        }
       
    }
    void OnCollisionStay2D(Collision2D other) {
        // 번개 구름
        if (other.gameObject.tag == "cloud2" &&
            (other.transform.position.x + 0.7f > this.transform.position.x
            && other.transform.position.x - 0.7f < this.transform.position.x)
            )
        {
            director.GetComponent<GameDirector>().SlowDecreaseHp();
        }
        // 별 구름(점프 게이지 효과)
        if (other.gameObject.tag == "cloud4" && other.transform.position.y < this.transform.position.y &&
            (other.transform.position.x + 1.5f > this.transform.position.x
            && other.transform.position.x - 1.5f < this.transform.position.x))
        {
            jumpMode = false;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        // 밟으면 사라지는 구름
        if (other.gameObject.tag == "cloud1" && other.transform.position.y < this.transform.position.y &&
            (other.transform.position.x+0.8f>this.transform.position.x
            && other.transform.position.x-0.8f<this.transform.position.x))
        {
            Destroy(other.gameObject);
        }
    }
  
    // Trigger 충돌 판정
    void OnTriggerEnter2D(Collider2D other)
    {
        // 슈퍼모드
        if(other.tag == "super")
        {
            director.GetComponent<GameDirector>().Super();

            GameObject super = GameObject.Find(other.name);
            Destroy(super);
        }
    }

}
