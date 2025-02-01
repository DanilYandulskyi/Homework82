using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public Vector3 Cast(Vector3 origin)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(origin);

        if (Physics.Raycast(ray, out hit))
        {
            return new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
        }

        return Vector3.zero;
    }
}
