using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blastScript : MonoBehaviour
{

    public static AudioClip blastSound;
    static AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        blastSound = Resources.Load<AudioClip>("blast");
        audiosrc = GetComponent<AudioSource> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Playsound( string str)
    {
        switch (str)
        {
            case "blast":
                audiosrc.PlayOneShot(blastSound);
                break;
        }
    }
}
