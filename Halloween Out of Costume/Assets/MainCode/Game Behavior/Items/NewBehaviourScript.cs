using UnityEngine;

public class DragWithLeash : MonoBehaviour
{
    private Rigidbody2D rb; // ������ �� Rigidbody2D �������
    private Camera cam; // ������ �� ������
    private SpringJoint2D springJoint; // ������ �� SpringJoint2D
    private bool isDragging = false; // ����, �����������, ��������������� �� ������

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // �������� ��������� Rigidbody2D
        cam = Camera.main; // �������� �������� ������
    }

    private void OnMouseDown()
    {
        isDragging = true; // ������������� ���� �������������� � true

        // ������� SpringJoint2D
        springJoint = gameObject.AddComponent<SpringJoint2D>();
        springJoint.autoConfigureDistance = false; // ��������� �������������� ���������
        springJoint.distance = 0; // ������������� ���������� � 0
        springJoint.dampingRatio = 1; // ����� ���������, ����� ������� �������� ����� �������
        springJoint.frequency = 10; // ��������� ������� ������� ��� ������������
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // �������� ������� ���� � ������� �����������
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            // ���������� ������ �� ������� ����
            rb.MovePosition(mousePos); // ������ ������� �� ��������

            // ��������� ���������� �������, ����� ���������� � 0
            springJoint.distance = 0; // ������ ������������� ��������� � 0
        }
    }

    private void OnMouseUp()
    {
        isDragging = false; // ������������� ���� �������������� � false

        // ������� ������� ��� ���������� ����
        if (springJoint != null)
        {
            Destroy(springJoint); // ������� SpringJoint2D
        }
    }
}
