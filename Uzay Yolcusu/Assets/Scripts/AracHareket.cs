using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AracHareket : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject character;
    public Sprite cokCan;
    public Sprite tekCan;

    Rigidbody2D rb;

    public AudioSource[] sounds;
    public AudioSource HealthPlus;
    public AudioSource HealthMinus;
     
     //cokCan ve tekCan nesnelerimizi oyun içinde karakterimizin görünümünü değiştirebilmek için oluşturduk.
     //rb adın fizik öğesi tanımladık. Karakterimizin fiziksel olaylarını yönetirken kullanacağız.
     //AudioSource, ses dosyalarımızı yöneteceğimiz öğelerdir. sounds adında ses dizisi ve HealthPlus ve HealtMinus adında iki ses değişkenimizi tanımladık.
    
    public static int can;
    //can değişkenimiz karakterimizin mevcut canını ve can durumuna göre oluşacak durumları yönetmemizde kullanacağız.
    private void Start()
    {
        can=0;
        Time.timeScale = 1;
        rb=GetComponent<Rigidbody2D>();

        sounds=GetComponents<AudioSource>();
        HealthPlus = sounds[1];
        HealthMinus = sounds[0];

        //Bu kod dosyasını atayacağımız karakterimizin bulunduğu sahnemizde Start fonksiyonu ilk olarak çalışacaktır.
        //Oyunumuzun başında canımızı sıfıra eşitledik
        //Time.timeScale oyunumuzun genel hızıdır bu hız değiştikçe kodlarla tanımladığımız nesne hızları da aynı oranda değişecektir. 
        //rb değişkenine karakterimizin fiziğini tanımladık.
        //sounds dizimize ses bileşenlerimizi ekledik.
        //HealthPlus ve HealthMinus adlarında iki ses dosyamızı ses dizisine atadık.
        
    }
    // Update is called once per frame
    void Update()
    {
        rb.constraints=RigidbodyConstraints2D.FreezeAll;
        //FreezeAll komutumuz ile karakterimizin diğer öğelerle temas etmesi halinde kıpırdamamasını sağladık.(Artık bir nesneye çarptığında çarpma etkisiyle sağa sola dönmüyor.)
        if(Input.touchCount>0)
            //Ekrana dokunup dokunmadığımızı kontrol ettik. Dokunma algıladığında değer sıfırdan büyük çıkar
            //Eğer ekrana dokunulduysa alttaki işlemleri uygulaması komutunu verdik.
        {
            Touch dokunma = Input.GetTouch(0);
            character.transform.position = new Vector2(mainCamera.ScreenToWorldPoint(dokunma.position).x, -3);
            /*Karakterimizin ışınlanacağı posizyonu tanımlamak için x eksenine ekranda dokunduğumuz yerin x eksenindeki
            karşılığını tanımladık. Aracımızın yukarı aşağı gitmeyeceği için y ekseni olarak da mevcut yerindeki 
            y eksenine karşılık gelen noktasını yani -3'ü yazdık.*/
        }

        if(can>=1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cokCan;
            //Karakterimizin canı 1 veya üzerinde ise karakterimizin görüntüsü cokCan değişkenine tanımlayacağımız görüntüye dönüşecektir.(Bu projemizde kırmızı ufoyu kullandık)
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = tekCan;
            //Eğer karakterimizin canı 0 ce altında ise görünümü tekCan değişkenine tanımladığımız görüntü şekline oalcaktır.(Bu projemizde mavi uzay aracı)
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            //Çarpışma sonucu oluşacak işlemler için OnCollisionEnter fonksiyonunu kullanırız.
            //Basit anlatımla OnCollisionEnter, çarpışma başladı demektir. Herhangi bir fiziksel öğeye dokunduğu an fonksiyon çalışır.
            if(collision.gameObject.tag=="meteor")
            {
                
                can--;
                //"meteor" tagına sahip öğelere çarptığı an bu döngü çalışacaktır ve can değerimizi bir azaltacaktır.
                //Bu sayede meteorlara çarptığında can değerimizi bir düşürdük.

                if(can>=0)
                {
                    HealthMinus.Play();
                    //can değerimizin 0 ve üzeri olduğu durumda HealthMinus ses dosyamızın çalışması komutunu verdik.
                    //Yani çarpışma gerçekleştiğinde ses dosyamız çalışacak.(Meteora çarpınca çıkan azalma sesi)
                }

                if(can<0)
                {
                    //can değerimizin 0'ın altında kaldığı durumda yani oyunu kaybettiğimizde oluşacak durumları bu döngümüzün içerisine yazdık.

                    if(PlayerPrefs.GetInt("puan") > PlayerPrefs.GetInt("yuksek_skor") )
                    {
                        PlayerPrefs.SetInt("yuksek_skor", PlayerPrefs.GetInt("puan"));
                        //PlayerPrefs, verilerimizi kaydetmemize ve bu verilere erişmemize yarar.
                        //GetInt ile verimizi çağırırız, SenInt ile kaydederiz.
                        //Eğer puan verimiz yuksek_skor verimizden büyük ise yuksek_skor değişkenimizin değerine puan değişkenimizin değerini atadık.
                        //Yüksek skor verimizi de bu şekilde kaydetmiş olduk.
                    }
                        
                    MeteorHareket.artir=10;
                    //MeteorHareket scriptimiz içerisindeki artir değişkenimizin değerini 10 yaptık. Oyunumuz bitip tekrar başladığımızda en baştaki değerimize sabitlemek için bu yöntemi uyguladık.
                    SceneManager.LoadScene(2);
                    //SceneManager sahnelerimizi kontrol etmemizi sağlar.
                    //LoanScene komutu ile parantez arasına yazdığımız dizi sırasındaki sahnemizin yüklenmesini sağladık.
                    //Yani oyunu kaybettiğimizde 3. sahnemize geçiş yapmış olduk.
                }    
            }
            else
            {   
                //Karakterimiz harici yalnızca meteor ve nitro nesnelerimiz var. Döngümüzün başında Meteor'a çarpınca oluşacak olayları belirledik.
                //Else ile yani meteor haricinde oluşacak çarpışmalarda yani nitrolara dokunduğumuzda bu kısım çalışacak.
                HealthPlus.Play();
                can++;
                //HealthPlus ses dosyamız çalışacak yani can toplama seslerimiz bu komut ile sağlanacak.
                //Ayrıca canımızı da bir artırdık.
            }
            
            
            
            
            //Destroy(this.gameObject);
            //Time.timeScale = 0;
            
            //DataManager.Instance.skor=0;
        
        


    }
}
