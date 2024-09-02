using UnityEngine;

[CreateAssetMenu(fileName = "ItemLaunchItemBank", menuName = "Item Launcher/Item Bank", order = 1)]
public class ItemLaunchItemBankSO : ScriptableObject
{
    public GameObject[] itemPrefabs;
}