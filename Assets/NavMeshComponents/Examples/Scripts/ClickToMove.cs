using UnityEngine;
using UnityEngine.AI;

// Use physics raycast hit from mouse click to set agent destination
[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    NavMeshAgent m_Agent;
    RaycastHit m_HitInfo = new RaycastHit();

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                m_Agent.destination = GeneratePoint(m_HitInfo.point);
        }
    }

    private void OnDrawGizmos()
    {
        if (!m_Agent)
            return;

        var offset = 0.25f * Vector3.up;

        if (m_Agent.path.corners.Length > 1)
        {
            Gizmos.color = Color.red;
            for (int i = 0; i < m_Agent.path.corners.Length - 1; i++)
                Gizmos.DrawLine(m_Agent.path.corners[i] + offset, m_Agent.path.corners[i+1] + offset);
        }
    }

    private Vector3 GeneratePoint(Vector3 target)
    {
        var range = Vector3.zero;// new Vector2(-2.5f, 2.5f);
        var offset = new Vector3
            (
                Random.Range(range.x, range.y),
                0.0f,
                Random.Range(range.x, range.y)
            );

        return target + offset;
    }
}
