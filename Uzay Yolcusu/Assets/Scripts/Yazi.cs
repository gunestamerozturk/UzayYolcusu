using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Yazi : MonoBehaviour
{
    
    public UnityEngine.UI.Text text;
    
    

    // Update is called once per frame
    void Update()
    {
        text.text="Skor : "+PlayerPrefs.GetInt("puan").ToString();
        //puan eğişkenimizin değerini PlayerPrefs ile çekip yazdırdık.
        //Text öğemiz Ekranın neresinde konumlandıysa yukarıda belirlediğimiz yazımız da orada yazacaktır.
        
    }

    
}
