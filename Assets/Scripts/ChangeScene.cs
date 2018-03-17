using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    
    public void SwitchScene(int sceneInt)
    {
        SceneManager.LoadScene(sceneInt); 
    }

    public void Quit()
    {
        Application.Quit();
    }
}
