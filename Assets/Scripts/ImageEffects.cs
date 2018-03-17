using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageEffects : MonoBehaviour {

    private Image fadeImage;
    private float timer;
    [SerializeField]private bool fade = false;
    [SerializeField]private bool scale = false;

    // Use this for initialization
    void Start () {
        fadeImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (fade)
        {
            Fade();
        }
        if (scale)
        {
            Scale();
        }
    }

    void Fade()
    {
        timer += Time.deltaTime;
        fadeImage.color = new Color(255f, 255f, 255f, Mathf.Lerp(0f,1, timer/1.4f)); 
    }

    public void ResetTimer()
    {
        timer = 0f;
    }

    void Scale()
    {
        timer += Time.deltaTime*1.5f;
        if (timer < 1)
        {
            fadeImage.transform.localScale = new Vector2(timer, timer);
        }
    }

    public void ResetScale()
    {
        fadeImage.transform.localScale = new Vector2(0, 0);
    }
}
