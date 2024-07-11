using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContadorBnanas : MonoBehaviour
{
    public TextMeshProUGUI bananaText; // Assign this in the Inspector
    private int bananaCount = 0;

    public void IncrementBananaCount()
    {
        bananaCount++;
        bananaText.text = "" + bananaCount;
    }
}
