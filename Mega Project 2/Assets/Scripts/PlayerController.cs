using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float horizontalInput;
    public float verticalInput;
    Vector3 turn;
    float spamTime;
    float impulseTime;
    public GameObject impulse;
    public Camera mainCamera;
    public Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        impulse = GameObject.FindWithTag("Impulse");
        impulse.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        inputKeys();
    }
    private void FixedUpdate()
    {
        movement();
        //enable collider on mouse button down and disable on mouse button up
        spamTime += Time.deltaTime;
        if (Input.GetMouseButton(0) && spamTime > 1)
        {
            impulse.SetActive(true);
            spamTime = 0;
        }
        if (Input.GetMouseButtonUp(0))
            impulse.SetActive(false);
    }
    private void inputKeys()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = 0f;
    }
    private void movement()
    {
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime, Space.World);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime, Space.World);
        transform.LookAt(mousePosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
