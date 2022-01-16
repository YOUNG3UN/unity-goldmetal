using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playerTransform;
    Vector3 Offset;

    void Awake()
    {
        // �־��� �±׷� ������Ʈ �˻�
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // ī�޶� ��ġ - Player ��ġ
        Offset = transform.position - playerTransform.position;
    }

    // Update ���Ŀ� ����
    // UI ������Ʈ�� ī�޶� �̵��� ���� ���� ���� LateUpdate
    void LateUpdate()
    {
        transform.position = playerTransform.position + Offset;
    }
}
