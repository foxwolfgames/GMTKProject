using UnityEngine;

[CreateAssetMenu(fileName = "ItemLauncher", menuName = "Item Launcher/Launcher", order = 1)]
public class ItemLauncherSO : ScriptableObject
{
    public ItemLaunchStrategySO[] strategies;
}