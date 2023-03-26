using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class SpotRecipeItem
{
    public ResourceType type;
    public int amount;
}


/// <summary> Scriptable object containing both required and produced resources for refining iteration. </summary>
[CreateAssetMenu(fileName = "NewRecipe")]
public class SpotRecipe : ScriptableObject
{

    [SerializeField]SpotRecipeItem[] requiredResources;
    [SerializeField]SpotRecipeItem[] producedResources;

    public SpotRecipeItem[] GetRequiredResources()
    {
        return requiredResources;
    }

    public SpotRecipeItem[] GetproducedResource()
    {
        return producedResources;
    }
}
