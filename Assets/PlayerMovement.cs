using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения игрока

    void Update()
    {
        // Получаем ввод от клавиатуры
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Определяем направление движения
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        // Вычисляем вектор перемещения
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;

        // Перемещаем игрока
        transform.Translate(movement);
    }
}
