using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        Destroy(col.gameObject);
    }
}
