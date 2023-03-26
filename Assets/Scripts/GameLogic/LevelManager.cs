using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary> Script for loading scenes as levels </summary>
public class LevelManager : MonoBehaviour
{
    public string[] levels;

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(levels[index]);
    }
}
