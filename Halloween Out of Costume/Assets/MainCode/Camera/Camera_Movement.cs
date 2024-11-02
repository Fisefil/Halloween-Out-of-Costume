using UnityEngine;

public class CameraMove : MonoBehaviour  //Всё по шаблону, аж страшно
{
    public Transform target;
    public float speed = 5f;

    void Start()
    {

    }
    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}