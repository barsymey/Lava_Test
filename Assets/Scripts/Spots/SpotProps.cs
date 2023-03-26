using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewSpotProps")]
/// <summary> Scriptable object for adjusting resource processor properties. </summary>
public class SpotProps : ScriptableObject
{
    [SerializeField]public float intakeDelay;
    [SerializeField]public SpotRecipe recipe;
}
