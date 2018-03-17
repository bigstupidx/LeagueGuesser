using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckForFirstTime : MonoBehaviour {

    private SaveData saveName;
    [SerializeField]private GameObject panel;
    [SerializeField]private GameObject playButton;
    [SerializeField]private GameObject creditsButton;
    [SerializeField]private GameObject quitButton;

    [SerializeField]private GameObject profile;
	// Use this for initialization
	void Start () {
        saveName = GameObject.FindWithTag("DataObject").GetComponent<SaveData>();

        HidePanel();
    }

    public void HidePanel()
    {
        saveName.GetData();
        if (saveName.ShowPanel == false)
        {
            panel.SetActive(!panel.activeSelf);
            playButton.SetActive(true);
            creditsButton.SetActive(true);
            quitButton.SetActive(true);
            profile.SetActive(true);
        }
        else
        {
            playButton.SetActive(false);
            creditsButton.SetActive(false);
            quitButton.SetActive(false);
            profile.SetActive(false);
        }
    }
}
