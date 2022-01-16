using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    public int itemCount;
    public GameManager manager;
    bool isJump;
    Rigidbody rigid;
    AudioSource audioS;

    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audioS.Play();
            // Item 오브젝트 비활성화
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }
        else if(other.tag == "Finish")
        {
            // Find 계열 함수는 부하를 초래할 수 있으므로 피하는 것을 권장
            if(itemCount == manager.totalItemCount)
            {
                // Game Clear! && Next Stage
                if (manager.stage == 3)
                    SceneManager.LoadScene(0);
                else
                    SceneManager.LoadScene(manager.stage);
            }
            else
            {
                // Restart Stage
                // SceneManager: 장면을 관리하는 기본 클래스
                // LoadScene(): 주어진 장면을 불러오는 함수
                SceneManager.LoadScene(manager.stage-1);
            }
            
        }    
    }
}
