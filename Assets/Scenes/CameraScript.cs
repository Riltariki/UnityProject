using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform RocketShip; // Ссылка на объект, на который нужно смотреть

    private void Update()
    {
        if (RocketShip != null)
        {
            // Получаем вектор направления от камеры к целевому объекту
            Vector3 direction = RocketShip.position - transform.position;

            // Вычисляем новый поворот камеры, чтобы смотреть на целевой объект
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Применяем новый поворот камеры
            transform.rotation = rotation;
        }
    }
}
