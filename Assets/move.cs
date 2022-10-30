using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] float punchTime;
    [SerializeField] float timer;
    Rigidbody rb;
    public float speed;
    Vector3 direction;
    [SerializeField] float jumpSpeed;
    bool isGrounded;
    public GameObject punch;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(x, 0, z);

        if (isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ActivatePunch();
            anim.SetBool("attack", true);
            Invoke("DeactivPunch", 0.5f);
        }

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetBool("attack", false);
        }

        if (direction.magnitude > 0)
        {
            anim.SetBool("Run", true);
        }
        
        else 
        {
            anim.SetBool("Run", false);
        } 
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other != null)
        {
            isGrounded = true;
            anim.SetBool("Jump", false);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
        anim.SetBool("Jump", true);
    }
    public void ActivatePunch()
    {
        punch.SetActive(true);
    }

    public void DeactivPunch()
    {
        punch.SetActive(false);
    }
}
