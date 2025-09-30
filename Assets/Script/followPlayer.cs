using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public float offSet;
    public float mouseSensitivity = 100f;
    public float distanceFromPlayer = 5f;
    public float cameraHeight = 2f;
    public float rotationSmoothTime = 0.1f;

    private float yaw;   // Horizontal rotation
    private float pitch; // Vertical rotation
    private Vector3 currentRotation;
    private Vector3 rotationSmoothVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Hide and lock cursor
        Debug.Log("hi this is diwakar");
    }

    void LateUpdate()
    {
        // 1️⃣ Read mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 2️⃣ Accumulate yaw & pitch
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -30f, 60f); // Prevent camera from flipping too far

        // 3️⃣ Smooth camera rotation
        Vector3 targetRotation = new Vector3(pitch, yaw);
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);

        // 4️⃣ Position and rotate camera
        transform.eulerAngles = currentRotation;
        transform.position = playerTransform.position - transform.forward * distanceFromPlayer + Vector3.up * cameraHeight;

        // 5️⃣ Rotate player based on camera yaw
        playerTransform.rotation = Quaternion.Euler(0, currentRotation.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // follow to player z axis
        Vector3 cameraPos = transform.position;
        cameraPos.z = playerTransform.position.z - offSet;
        transform.position = cameraPos;
    }
}
