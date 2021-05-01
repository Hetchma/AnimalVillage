using UnityEngine;
//NavMeshAgent使うときに必要
using UnityEngine.AI;

//オブジェクトにNavMeshAgentコンポーネントを設置
[RequireComponent(typeof(NavMeshAgent))]

public class RandomMove : MonoBehaviour
{
    Transform central;

    private NavMeshAgent agent;
    [SerializeField] float radius = 10;
    [SerializeField] float waitTime = 5;
    [SerializeField] float time = 0;

    Animator anim;

    Vector3 pos;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        central = transform;


        agent.autoBraking = false;
        //NavMeshAgentで回転をしないようにする
        agent.updateRotation = false;

        //GotoNextPoint();
    }
    void GotoNextPoint()
    {
        agent.isStopped = false;
        float posX = Random.Range(-1 * radius, radius);
        float posZ = Random.Range(-1 * radius, radius);

        pos = central.position;
        pos.x += posX;
        pos.z += posZ;

        //Y軸だけ変更しない目標地点
        Vector3 direction = new Vector3(pos.x, transform.position.y, pos.z);

        //Y軸だけ変更しない目標地点から現在地を引いて向きを割り出す
        Quaternion rotation =
            Quaternion.LookRotation(direction - transform.position, Vector3.up);
        //このオブジェクトの向きを替える
        transform.rotation = rotation;

        agent.destination = pos;
    }

    void StopHere()
    {
        agent.isStopped = true;
        time += Time.deltaTime;

        if (time > waitTime)
        {
            GotoNextPoint();
            time = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (agent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            GotoNextPoint();
        }

    }

    void Update()
    {
        if (agent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                StopHere();          //navMeshAgentの操作
        }


        //anim.SetFloat("Blend", agent.velocity.sqrMagnitude);
    }
}
