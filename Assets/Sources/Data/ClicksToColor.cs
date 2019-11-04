using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Game, CreateAssetMenu(fileName = "ClicksToColourDividers")]
public class ClicksToColor: ScriptableObject
{
    public int clicksNumber;
    public Color color;

    public void Describe() {
        Debug.Log("The total number of clicks is a multiple of " + clicksNumber + ".\n" + color + " color is used");
    }
}
