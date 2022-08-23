using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public AudioClip firearm;
    AudioSource asource;
    float hp = 100;
    Image imgHP;
    
    // Start is called before the first frame update
    void Start()
    {
        asource = GetComponent<AudioSource>();
        imgHP =  GameObject.Find("HP").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            asource.PlayOneShot(firearm);
        }
        imgHP.fillAmount = hp / 100;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            hp -= 20;
        }
    }
}
