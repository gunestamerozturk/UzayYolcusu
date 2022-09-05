using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meteor : MonoBehaviour
{

    public GameObject meteor;
    float konum;
    public float olusmaHizi=1;

    public static int skor=0;
    public static int maxSkor;

    public int artir=0;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("olusum", 0.1f, olusmaHizi);
        /*InvokeRepeating fonksiyonu 3 parametre alır.
        İlki çalışacak fonksiyonu, ikincisi kaç saniye sonra çalışacağı ve son olarak ne kadar süre aralıkla çalışacağı.*/
        
        /*Yani olusum() fonksiyonumuzu 0.1 saniye sonra olusmaHizi değişkenimizin değeri kadar süre aralıklarla 
        Çalışması komutunu verdik.*/
        PlayerPrefs.SetInt("puan",0);
        //PlayerPrefs ile kaydettiğimiz puan değişkenimizin değerini oyun başında 0'a eşitledik.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void olusum()
    {
        konum = Random.Range(-2.15f, 2.15f);
        //konum değişkenimize -2.15 ile 2.15 değerleri arasında rastgele bir değer atadık.
        //Ekranımızın bir tarafından diğer tarafına olan uzaklıktan dolayı.
        
        Instantiate(meteor, new Vector2(konum, 5.50f), Quaternion.identity);
        //Instantiate komutunu nesne yaratmak için kullanırız.
        //3 parametre alır ve bunlardan ilki oluşacak nesnemiz ikincisi konumumuz ve son olarak objemizin doğrultusu.
        //X ekseninde nesnemizin rastgele bir konumda oluşması için konum değişkenimize rastgele bir değer tanımlamıştık.


        PlayerPrefs.SetInt("puan",PlayerPrefs.GetInt("puan")+1);
        //fonksiyonumuz her çalıştığında puan değerimizi bir artırdık.
        //Yani bu sayede oyunumuzun puan sistemini de meteorun oluşmasıyla orantılı olmasını sağlamış olduk.
        
        

    }
}

