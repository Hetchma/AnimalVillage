using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 3;
    public float jumpForce = 300;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
    Animator anim;
    Rigidbody rb;
    NavMeshAgent m_navMeshAgent;

    float eatTime;
    float medicineTime;
    bool CanEat;
    bool CanMedicine;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        m_navMeshAgent.enabled = false;
        eatTime = 1.0f;
    }

    void Update()
    {
        if (!m_navMeshAgent.enabled)
        {
            m_navMeshAgent.enabled = true;
        }

        ControllPlayer();
        eatTime -= Time.deltaTime;

        if (eatTime <= 0)
        {
            CanEat = EatFlag();
        }
    }

    void ControllPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);
        }
        else
        {
            anim.SetInteger("Walk", 0);
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        if (Input.GetButtonDown("Jump") && Time.time > canJump)
        {
            rb.AddForce(0, jumpForce, 0);
            canJump = Time.time + timeBeforeNextJump;
            anim.SetTrigger("jump");
        }
    }

    bool EatFlag()
    {
        eatTime = 1.0f;


        return true;
    }

}
