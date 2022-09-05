using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHareket : MonoBehaviour
{
    public float hiz = 300.0f;
    Rigidbody2D rb;
    public float yokOlmaHizi = 12.0f;
    public static int artir=10;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity=new Vector2(0,-hiz);
        // Hareket için öncelikle Transform.Translate komutu kullanmıştım fakat komutu yorum satırına alıp onun yerine velocity kullandık.
        //Nesnemize y ekseninde negatif yönlü bir kuvvet uyguladık.
        if(PlayerPrefs.GetInt("puan")==artir)
        {
            Time.timeScale+=0.2f;
            artir+=10;
            //artir değişkenimizi oyunumuza seviye sistemi katmak için dahil ettik.
            //Skorun 10 olmasıyla birlikte artir değerimizle eşitlendi ve Time.timescale ile oyunumuzun hızı 0.2 arttı ve artir değişkenimizin değerini de 10 artırdık.
            //Skorumuzun her 10 artmasıyla birlikte oyunumuzun hızlanmasını sağlamış olduk.
        }

        //transform.Translate(new Vector2(0, hiz*-Time.deltaTime));
        Destroy(this.gameObject,yokOlmaHizi);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(AracHareket.can>0)
        {
            Destroy(this.gameObject);
            //AracHareket scriptimizdeki can değerinin 0'dan büyük olması halinde herhangi bir çarpışmada meteor öğemizin yok olmasını/silinmesini sağladık.
        }
    }

}
