using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playerTransform;
    Vector3 Offset;

    void Awake()
    {
        // 주어진 태그로 오브젝트 검색
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // 카메라 위치 - Player 위치
        Offset = transform.position - playerTransform.position;
    }

    // Update 이후에 실행
    // UI 업데이트나 카메라 이동에 관한 것은 보통 LateUpdate
    void LateUpdate()
    {
        transform.position = playerTransform.position + Offset;
    }
}
