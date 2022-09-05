using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skor_kodu : MonoBehaviour
{
    //Skor değişkenimizin değerini bu dosya içerisinde kaydedip yazdırma işlemlerini yapacaktık fakat sonradan ayrı ayrı yazmayı tercih ettiğimiz için
    //Yalnızca yüksek skor kayıt ve yazdırma işlemlerimizi burada yapmayı uygun gördük. Bu yüzden yalnızca yüksek skor için açıklamalar yazacağım.
    public Text text_Skor;
    public Text text_Yuksek_Skor;
    //text_Yuksek_Skor adında yazı öğesi oluşturduk.
    void Start()
    {
        text_Yuksek_Skor.text="Yüksek Skor : "+PlayerPrefs.GetInt("yuksek_skor");
        //Başlangıçta değişkenimizin değerini PlayerPrefs ile çekip yazdırdık.
        //Text öğemiz Ekranın neresinde konumlandıysa yukarıda belirlediğimiz yazımız da orada yazacaktır.
    }

    

    /*public void skor_kaydet()
    {
         
        
        //PlayerPrefs.SetInt("skor", puan);


    }

    public void yuksekskor_kaydet()
    {
        if(PlayerPrefs.GetInt("puan") > PlayerPrefs.GetInt("yuksek_skor") )
        {
            PlayerPrefs.SetInt("yuksek_skor", PlayerPrefs.GetInt("puan"));
            //PlayerPrefs, verilerimizi kaydetmemize ve bu verilere erişmemize yarar.
            //GetInt ile verimizi çağırırız, SenInt ile kaydederiz.
            //Eğer puan verimiz yuksek_skor verimizden büyük ise yuksek_skor değişkenimizin değerine puan değişkenimizin değerini atadık.
            //Yüksek skor verimizi de bu şekilde kaydetmiş olduk.

        }

    }


    public void skor_yazdir ()
    {
        text_Skor.text = "Skor: " + PlayerPrefs.GetInt("skor");

        text_Yuksek_Skor.text = "Yüksek Skor" + PlayerPrefs.GetInt("yuksek_skor");
        //
    }
*/
   
}
