using UnityEngine;

[CreateAssetMenu(fileName = "ItemLaunchWeightedStrategy", menuName = "Item Launcher/Weighted Strategy", order = 2)]
public class ItemLaunchWeightedStrategySO : ScriptableObject
{
    public ItemLaunchStrategySO strategy;
    public float weight;
}