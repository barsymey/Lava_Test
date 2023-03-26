using UnityEngine;

/// <summary> Entity taking resources from inventory and after processing dropping product. </summary>
public class ResourceProcessor
{
    float _processTime;
    SpotRecipe _recipe;
    IResourceEmitter _spawner;
    Inventory _inventory;

    bool _isProcessing;
    float _nextProcessingTime;
    
    public ResourceProcessor(float processTime, SpotRecipe recipe, IResourceEmitter spawner, Inventory inventory)
    {
        _processTime = processTime;
        _recipe = recipe;
        _spawner = spawner;
        _inventory = inventory;
    }

/// <summary> Manual update. Check if processing time passed and try to take resources from inventory. </summary>
    public void UpdateProcessor()
    {
        if(Time.timeSinceLevelLoad > _nextProcessingTime)
        {
            _nextProcessingTime = Time.timeSinceLevelLoad + _processTime;
            if(_isProcessing)
            {
                foreach(SpotRecipeItem item in _recipe.GetproducedResource())
                {
                    for(int i = 0; i < item.amount; i++)
                        _spawner.SpawnObject(item.type);
                }
            }
            _isProcessing = TryTakeResources();
        }
    }

    bool TryTakeResources()
    {
        foreach(SpotRecipeItem item in _recipe.GetRequiredResources())
        {
            if(_inventory.GetAmount(item.type) < item.amount)
                return false;
        }
        foreach(SpotRecipeItem item in _recipe.GetRequiredResources())
        {
            _inventory.RemoveResource(item.type, item.amount);
        }
        return true;
    }


}
