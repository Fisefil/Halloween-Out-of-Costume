using UnityEngine;

public class DragWithLeash : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera cam;
    private SpringJoint2D springJoint;
    private bool isDragging = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        isDragging = true;
        springJoint.distance = 0;
        springJoint = gameObject.AddComponent<SpringJoint2D>();
        springJoint.autoConfigureDistance = false;
        springJoint.dampingRatio = 1;
        springJoint.frequency = 10;
        springJoint.enableCollision = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            springJoint.connectedAnchor = mousePos;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        if (springJoint != null)
        {
            Destroy(springJoint);
        }
    }
}
