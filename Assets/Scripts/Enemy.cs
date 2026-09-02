using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void FixedUpdate()
    {
        transform.Translate(Vector3.forward * 5 * Time.deltaTime); // 敌人速度和持续时间
    }

}
