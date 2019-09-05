using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isMobile = false;
    [Header("Mobile")]
    public MasterController rotationJoystick;
    public GameObject mobileDisplay;
    public float rotSpeed = 10f;
    [Header("Not Mobile")]
    public PlayerShoot playerShoot;
    public float sensitivity = 15f;
    public float minY = -60f;
    public float maxY = 60f;
    public float rotationY = 0f;

    void Start()
    {
        if (isMobile == true)
        {
            if (GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().freezeRotation = true;
            }
            mobileDisplay.SetActive(true);
        }
        else
        {
            mobileDisplay.SetActive(false);
        }
    }

    void Update()
    {
        if (isMobile == true)
        {
            transform.Rotate(new Vector2(-rotationJoystick.Vertical, rotationJoystick.Horizontal), rotSpeed * Time.deltaTime);
        }
        else
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
            rotationY += Input.GetAxis("Mouse Y") * sensitivity;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            playerShoot.Shoot();
        }
    }
}