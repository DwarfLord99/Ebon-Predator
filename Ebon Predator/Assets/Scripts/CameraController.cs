using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float sensitivity;
    [SerializeField] int lockVertMin, lockVertMax;
    [SerializeField] bool invertY;

    [SerializeField] Transform playerCharacter;
    //[SerializeField] Slider slider;

    private float rotationX;

    // Start is called before the first frame update
    void Start()
    {
        sensitivity = PlayerPrefs.GetFloat("currentSensitivity", 100);
        //slider.value = sensitivity;

        //sets cursor invisible on-screen
        Cursor.visible = false;
        //locks the cursor to the current position when game starts
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("currentSensitivity", sensitivity);

        //get input
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        //invert Y camera
        if (!invertY)
            rotationX -= mouseY;
        else
            rotationX += mouseY;

        //clamp the rotationX on the x-axis
        rotationX = Mathf.Clamp(rotationX, lockVertMin, lockVertMax);

        //rotate the camera on the x-axis
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        //rotate the player on the y-axis
        playerCharacter.transform.Rotate(Vector3.up * mouseX);

    }
    public void AdjustSpeed(float mouseSpeed)
    {
        sensitivity = mouseSpeed * 10;
    }
}
