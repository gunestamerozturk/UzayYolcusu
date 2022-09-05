using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Can : MonoBehaviour
{

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text=(AracHareket.can+1).ToString();
        //Bu scriptimizi yalnızca ekrandaki can değişkeninin değerini yazdırmak için oluşturduk.
        //yazı objemize Arachareket scriptindeki can değişkenimize 1 ekleyip string değerine çevirerek ekrana yazdırmış olduk.
        //1 eklememizin sebebi; karakterimizin başlangıç canının 0 olması fakat oyuncuda karışıklık yaratmaması için 1 can olarak göstermektir.
    }
}
