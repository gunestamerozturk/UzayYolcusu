using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DataManager.Instance.SaveData();
    }

    public void PlayButton()
    {
        
        //PlayButton fonksiyonumuzu Ekrandaki Play butonuna bastığımızda oluşacak işlemler için oluşturduk.
        SceneManager.LoadScene(1);
        //Play butonuna basıldığında 2. sahnemize yani oyunu oynadığımız sahnemize geçmek için kullandık.

    }
}
