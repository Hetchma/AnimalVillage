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

    //[SerializeField] MissionPanelManager missionPanelManager;
    Event newEvent;
    float eventTimer = 10.0f;

    GameObject animal;
    GameObject balloon_eat;
    GameObject ballon_medicine;

    public enum Event
    {
        eat,
        medicine,
    }


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        m_navMeshAgent.enabled = false;

        animal = transform.root.gameObject;
        balloon_eat = animal.transform.Find("Canvas/balloon_eat").gameObject;
        ballon_medicine = animal.transform.Find("Canvas/balloon_medicine").gameObject;
    }

    void Update()
    {
        if (!m_navMeshAgent.enabled)
        {
            m_navMeshAgent.enabled = true;
        }

        eventTimer -= Time.deltaTime;
        if (eventTimer <= 0)
        {
            newEvent = EventSelecter();
            RunEvent(newEvent);
        }

        ControllPlayer();

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

    //イベント発生時間決定
    float EventTimer()
    {
        float number = Random.Range(120, 600);
        return number;
    }

    //イベント選択
    Event EventSelecter()
    {
        int number = Random.Range(1, 100);

        if (number <= 80)
        {
            return Event.eat;
        }
        else
        {
            return Event.medicine;
        }
    }

    //イベント実行
    void RunEvent(Event newEvent)
    {
        if (!balloon_eat.activeSelf && !ballon_medicine.activeSelf)
        {
            if (newEvent == Event.eat)
            {
                balloon_eat.SetActive(true);
                //イベント実行

            }
            else if (newEvent == Event.medicine)
            {
                ballon_medicine.SetActive(true);
                //イベント実行
            }
        }
    }
}
