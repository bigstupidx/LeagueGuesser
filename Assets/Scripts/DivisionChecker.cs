using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DivisionChecker : MonoBehaviour 
{
    public Division[] divisions;
    public Division currentDivision;
    [SerializeField]private Image eloIcon;
    [SerializeField]private Text eloText;

    public void SetCurrentDivisionWithPoints(int value)
    {
        for (int i = 0; i < divisions.Length; i++)
        {
            if (value >= divisions[i].minCap && value < divisions[i].maxCap)
            {
                if(divisions[i].divisionIndex > currentDivision.divisionIndex)
                {
                    //Promote
                }
                else if(divisions[i].divisionIndex < currentDivision.divisionIndex)
                {
                    //Demote
                }
                currentDivision = divisions[i];
                break;
            }
        }
        SetDivision();
    }

    private void SetDivision()
    {
        eloIcon.sprite = currentDivision.divisionIcon;
        eloText.text = currentDivision.divisionName;
    }

}

[System.Serializable]
public struct Division
{
    public string divisionName;
    public int divisionIndex;
    public Sprite divisionIcon;
    public int minCap;
    public int maxCap;
}
