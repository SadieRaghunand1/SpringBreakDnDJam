using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontal;
    float vertical;
    Vector3 movement;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float cameraSpeed = 3;

    [SerializeField] private Vector3 jumpForce;
    public bool isGrounded;
    bool isJumping;

    public bool inSafeZone;

    float rotateOffset;

    public GameObject holdPos;

    [SerializeField] private Camera playerCamera;
    public float lookXLimit = 45f;
    private float rotationX = 0;

    //added for pause menu
    //public pauseMenu pMenu;

    #region Monobehaviour methods
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovementUpdate();
        Jump();
        RotateCam();

       
    }


    private void FixedUpdate()
    {
        MovementFixed(movement);
        RotatePlayer();


    }

    private void OnCollisionEnter(Collision collision) //Player lands after jumping
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Layer 6");
            // transform.parent = collision.gameObject.transform;
            // transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        CheckGrounded(collision, true);
        isJumping = false;
    }

    private void OnCollisionExit(Collision collision) //Player jumps
    {
        if (collision.gameObject.layer == 6)
        {
            /*transform.parent = null;
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);*/
        }
        CheckGrounded(collision, false);

    }

  
    #endregion

    void MovementUpdate()
    {
        //Movement
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0, vertical);

        //Rotation
        rotateOffset = (rotateOffset + Input.GetAxis("Mouse X") * cameraSpeed) % 360f;
    }

    void MovementFixed(Vector3 moveDirection)
    {
        moveDirection = rb.rotation * moveDirection;

        //rb.velocity = moveDirection * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Player rotates with mouse
    /// </summary>
    void RotatePlayer()
    {
        rb.MoveRotation(Quaternion.Euler(0, rotateOffset, 0));
    } //END RotatePlayer()


    void RotateCam()
    {
        //added for pause menu
        
            rotationX += -Input.GetAxis("Mouse Y") * cameraSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            //playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        
    }


    /// <summary>
    /// Player jump
    /// </summary>
    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || !isJumping))
        {
            //Debug.Log("Jump");
            isJumping = true;
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }
    } //END Jump()

    /// <summary>
    /// Change isGrounded
    /// </summary>
    void CheckGrounded(Collision _collision, bool _changeValue)
    {
        if (_collision.gameObject.layer == 6)
        {
            isGrounded = _changeValue;

        }
    } //END CheckGrounded()


}
