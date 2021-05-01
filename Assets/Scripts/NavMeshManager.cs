using UnityEngine;
using UnityEngine.AI;

public class NavMeshManager : MonoBehaviour
{
    [SerializeField] NavMeshSurface _surface;
    [SerializeField] MapManager mapManager;

    private void Start()
    {
        _surface.BuildNavMesh();
        mapManager.CanNavMesh = false;
    }

    public void Update()
    {
        if (mapManager.CanNavMesh)
        {
            // NavMeshをビルドする
            _surface.BuildNavMesh();
            mapManager.CanNavMesh = false;
            Debug.Log("メッシュ完了");
        }
    }
}
