using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    public float moveSpeed = 3f; // Скорость движения ИИ
    public float stoppingDistance = 2f; // Расстояние, на котором ИИ должен остановиться

    void Update()
    {
        if (player != null)
        {
            // Вычисляем направление к игроку
            Vector3 direction = (player.position - transform.position).normalized;

            // Проверяем расстояние до игрока
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > stoppingDistance)
            {
                // Вычисляем вектор перемещения
                Vector3 movement = direction * moveSpeed * Time.deltaTime;

                // Перемещаем ИИ
                transform.Translate(movement);
            }
        }
    }
}