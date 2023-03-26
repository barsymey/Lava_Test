using System;
using UnityEngine;

[Serializable]
public class ResourceMapperItem
{
    public GameObject resourceObject;
    public Sprite icon; 
}

/// <summary> Container for objects linking ResourceTypes to corresponding prefabs and icons. </summary>
public class ResourceObjectsTypeMapper : MonoBehaviour
{
    [SerializeField] public ResourceMapperItem[] resourceObjectMap;

    public GameObject GetResObjectOfType(ResourceType type)
    {
        return resourceObjectMap[(int)type].resourceObject;
    }

    public Sprite GetResIcon(ResourceType type)
    {
        return resourceObjectMap[(int)type].icon;
    }
}
