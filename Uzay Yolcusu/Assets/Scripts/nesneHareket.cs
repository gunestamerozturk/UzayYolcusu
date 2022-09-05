using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nesneHareket : MonoBehaviour
{
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        //fizik değişkenimize öğemizin fiziki özelliklerini tanımladık.
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0.0f, -2.0f);
        //öğemizin hızı için iki boyutlu vektör oluşturduk ve hızı ile yönünü belirledik.
        //parantez arasındaki virgülden önceki kısım x ekseni üzerindeki yönü ve hızı, virgülden sonra ise y ekseni üzerindeki yönü ve hızı.
        //öğemiz yukarıdan aşağı doğru hareket edeceği için x eksenini 0 diyerek y eksenine ise eksi yönlü 2 birimlik hız tanımladık.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            Destroy(this.gameObject);
            //Nesnemizin herhangi bir çarpışmada öğenin kaybolması/silinmesi komutunu verdik.
        
    }
}
