using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModificarFinal : MonoBehaviour
{
    public TextMeshProUGUI FinalB;
    public TextMeshProUGUI FinalS;
    [SerializeField] public ContadorBnanas ContadorB;
    [SerializeField] public Score ContadorS;


    public void ContarFinal()
    {
        FinalB.text = "" + ContadorB.RegresarContador();
        FinalS.text = "" + ContadorS.RegresarScore();
    }
}
