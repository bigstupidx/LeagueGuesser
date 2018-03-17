using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[CreateAssetMenu()]
public class Question : ScriptableObject 
{
    public string questionString;
    public Sprite questionImage;
    public string[] questionAnswers;
}
