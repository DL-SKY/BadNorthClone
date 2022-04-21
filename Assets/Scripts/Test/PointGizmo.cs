using UnityEngine;

namespace Test
{
    public class PointGizmo : MonoBehaviour
    {
        private RaycastHit m_HitInfo = new RaycastHit();


        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray.origin, ray.direction, out m_HitInfo);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(m_HitInfo.point + new Vector3(0.0f, 0.25f, 0.0f), 0.5f);
        }
    }
}
