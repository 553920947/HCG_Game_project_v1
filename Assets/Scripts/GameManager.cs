using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static WeaponData CurrentWeaponData; // 当前武器数据
    public static Action<WeaponData> OnWeaponChanged;

    public static void UploadWeapon()
    {
        OnWeaponChanged?.Invoke(CurrentWeaponData);
    }
}
