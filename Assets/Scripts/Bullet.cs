using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector3.forward * 30 * Time.deltaTime); // 子弹速度和持续时间
    }
}
