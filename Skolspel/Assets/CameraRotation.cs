using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private InputActionReference controls;
    [SerializeField] private float rotationSpeed;

    Vector2 angles = new Vector2 (0f, 0f);
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 input = controls.action.ReadValue<Vector2>();

        input *= rotationSpeed;

        angles.y += input.x;
        angles.x -= input.y;
        angles.x = Mathf.Clamp(angles.x, 0f, 90f);

        Vector3 cameraRotation = new Vector3(angles.x, angles.y, 0f);
        Vector3 playerRotation = new Vector3(0f, angles.y, 0f);

        transform.localRotation = Quaternion.Euler(cameraRotation);
        playerTransform.rotation = Quaternion.Euler(playerRotation);

        transform.position = playerTransform.position;
    }
}
