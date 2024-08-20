using UnityEngine;

[CreateAssetMenu(fileName = "ItemLaunchStrategy", menuName = "Item Launcher/Strategy", order = 1)]
public class ItemLaunchStrategySO : ScriptableObject
{
    public ItemLaunchItemBankSO[] possibleItemBanks;
    public ItemLaunchChooseItemStrategy chooseItemStrategy;
    public ItemLaunchLocationStrategy locationStrategy;

    public GameObject[] PickItems()
    {
        ItemLaunchItemBankSO itemBank = possibleItemBanks[Random.Range(0, possibleItemBanks.Length)];
        switch (chooseItemStrategy)
        {
            case ItemLaunchChooseItemStrategy.ALL_ITEMS:
                return itemBank.itemPrefabs;
            default:
            //case ItemLaunchChooseItemStrategy.RANDOM_WITH_WEIGHT:
            // Not implemented, just waterfall to RANDOM for now
            //case ItemLaunchChooseItemStrategy.RANDOM:
                return new []{ itemBank.itemPrefabs[Random.Range(0, itemBank.itemPrefabs.Length)] };
        }
    }
}