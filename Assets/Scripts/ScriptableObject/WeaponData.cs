using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "Weapon_Data")]
public class WeaponData : ScriptableObject
{
    public string WeaponName; // 武器名称
    public GameObject WeaponPrefab; // 武器预制体
    public float FireRate; // 射击速率
    public int damage; // 伤害值
}
