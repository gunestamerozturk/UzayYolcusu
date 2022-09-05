using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nitroOlustur : MonoBehaviour
{
    public GameObject nitro;
    float konum;
    public float olusmaHizi=20f;
    


    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("olusum", 9.5f, olusmaHizi);
        //InvokeRepeating ile olusum fonksiyonumuzu olusmaHizi değişkenimizin değerine bağlı olarak aralıklı halde çalışmasını sağladık.
    }

    void olusum()
    {
        konum = Random.Range(-2.15f, 2.15f);
        //konum değişkenimize -2.15 ile 2.15 değerleri arasında rastgele bir değer atadık.
        //Ekranımızın bir tarafından diğer tarafına olan uzaklıktan dolayı.
        
        Instantiate(nitro, new Vector2(konum, 6.50f), Quaternion.identity);
        //Instantiate komutunu kullanarak oluşturacağımız nesnemiz ve konum bilgileri ile nesnemizi oluşturduk.
        
        

    }
}
