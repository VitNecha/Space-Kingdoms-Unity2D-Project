using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadNewGameScene() { SceneManager.LoadScene(1); }
    public void LoadLoadGameScene() { SceneManager.LoadScene(2); }
    public void LoadSettingsScene() { SceneManager.LoadScene(3); }
    public void LoadScene(int sceneID) { SceneManager.LoadScene(sceneID); }
}
