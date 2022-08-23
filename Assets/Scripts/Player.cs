using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    public AudioClip firearm;
    AudioSource asource;
    public float hp = 100;
    Image imgHP;
    public GameObject text2, button1;

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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Zombie"))
                {
                    asource.PlayOneShot(firearm);
                }
            }
        }
        imgHP.fillAmount = hp / 100;
        if (hp <= 0)
        {
            text2.SetActive(true);
            button1.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            hp -= 20;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            hp -= 1f;
        }
    }
}
