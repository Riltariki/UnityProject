using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform RocketShip; // ������ �� ������, �� ������� ����� ��������

    private void Update()
    {
        if (RocketShip != null)
        {
            // �������� ������ ����������� �� ������ � �������� �������
            Vector3 direction = RocketShip.position - transform.position;

            // ��������� ����� ������� ������, ����� �������� �� ������� ������
            Quaternion rotation = Quaternion.LookRotation(direction);

            // ��������� ����� ������� ������
            transform.rotation = rotation;
        }
    }
}
