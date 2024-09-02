using UnityEngine;

public enum ItemLaunchLocationStrategy
{
    CENTER,
    RANDOM_LOCATION,
    ON_TOP_OF_PLAYER,
    PREFER_LOWER_SIDE,
    PREFER_HIGHER_SIDE,
    RANDOM_STRATEGY
}

public static class ItemLaunchLocationStrategyExtensions
{
    // Generate a pair of floats from 0 to 1 representing the fraction of the distance between min and max on the x and z axes
    public static float[] GenerateLaunchLocation(this ItemLaunchLocationStrategy strategy, Transform posXPosZ, Transform negXNegZ, Transform playerTransform)
    {
        ItemLaunchLocationStrategy myStrategy = strategy;
        if (myStrategy == ItemLaunchLocationStrategy.RANDOM_STRATEGY)
        {
            myStrategy = (ItemLaunchLocationStrategy)Random.Range(0, 5);
        }
        
        switch (myStrategy)
        {
            case ItemLaunchLocationStrategy.CENTER:
                return new[] {0.5f, 0.5f};
            case ItemLaunchLocationStrategy.RANDOM_LOCATION:
                return new[] {Random.Range(0f, 1f), Random.Range(0f, 1f)};
            case ItemLaunchLocationStrategy.PREFER_LOWER_SIDE:
                // Check whether a transform on pos X side or neg X side have a lower y value
                if (posXPosZ.position.y > negXNegZ.position.y)
                {
                    return new[] {Random.Range(0f, 0.5f), Random.Range(0f, 1.0f)};
                }
                else
                {
                    return new[] {Random.Range(0.5f, 1.0f), Random.Range(0f, 1.0f)};
                }
            case ItemLaunchLocationStrategy.PREFER_HIGHER_SIDE:
                // Check whether a transform on pos X side or neg X side have a higher y value
                if (posXPosZ.position.y > negXNegZ.position.y)
                {
                    return new[] {Random.Range(0.5f, 1.0f), Random.Range(0f, 1.0f)};
                }
                else
                {
                    return new[] {Random.Range(0f, 0.5f), Random.Range(0f, 1.0f)};
                }
            case ItemLaunchLocationStrategy.ON_TOP_OF_PLAYER:
                // Determine where player is in relation to the platform
                Bounds bounds = new Bounds();
                bounds.Encapsulate(posXPosZ.transform.position);
                bounds.Encapsulate(negXNegZ.transform.position);
                
                float playerX = playerTransform.position.x;
                float playerZ = playerTransform.position.z;
                
                return new[] { (playerX - bounds.min.x) / bounds.size.x, (playerZ - bounds.min.z) / bounds.size.z };
            default:
            case ItemLaunchLocationStrategy.RANDOM_STRATEGY:
                // Should never get here
                return new[] {Random.Range(0f, 1f), Random.Range(0f, 1f)};
        }
    }
}