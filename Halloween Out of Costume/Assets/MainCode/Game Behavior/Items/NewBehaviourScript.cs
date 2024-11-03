using UnityEngine;

public class DragWithLeash : MonoBehaviour
{
    private Rigidbody2D rb; // Ссылка на Rigidbody2D объекта
    private Camera cam; // Ссылка на камеру
    private SpringJoint2D springJoint; // Ссылка на SpringJoint2D
    private bool isDragging = false; // Флаг, указывающий, перетаскивается ли объект

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
        cam = Camera.main; // Получаем основную камеру
    }

    private void OnMouseDown()
    {
        isDragging = true; // Устанавливаем флаг перетаскивания в true

        // Создаем SpringJoint2D
        springJoint = gameObject.AddComponent<SpringJoint2D>();
        springJoint.autoConfigureDistance = false; // Отключаем автоматическую настройку
        springJoint.distance = 0; // Устанавливаем расстояние в 0
        springJoint.dampingRatio = 1; // Можно настроить, чтобы сделать движение более плавным
        springJoint.frequency = 10; // Настройка частоты пружины для устойчивости
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Получаем позицию мыши в мировых координатах
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            // Перемещаем объект на позицию мыши
            rb.MovePosition(mousePos); // Объект следует за курсором

            // Обновляем расстояние поводка, чтобы стремиться к 0
            springJoint.distance = 0; // Всегда устанавливаем дистанцию в 0
        }
    }

    private void OnMouseUp()
    {
        isDragging = false; // Устанавливаем флаг перетаскивания в false

        // Удаляем поводок при отпускании мыши
        if (springJoint != null)
        {
            Destroy(springJoint); // Удаляем SpringJoint2D
        }
    }
}
