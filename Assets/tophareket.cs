using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class tophareket : MonoBehaviour

{
    public Rigidbody2D top;
    public float xhizi,yhizi;
    public TextMeshProUGUI player1skoryazi,player2skoryazi,player1win,player2win,bitisyazisi;
    private int player1skor,player2skor;
    public int maxskor;

    public AudioSource arkaplan,skor,alkis;
    
    void Start()
    {
        arkaplan.Play();
    }

    
    void Update()
    {
        player1skoryazi.text=player1skor.ToString();
        player2skoryazi.text=player2skor.ToString();

        if(player2skor==maxskor)
        {
            player1win.text="PLAYER2 WİN!";
            bitisyazisi.text="OYUN BİTTİ TEKRAR OYNAMAK İÇİN ENTER TUŞUNA BASIN";
            alkis.Play();
           Time.timeScale=0;
           
            
        }
        else if(player1skor==maxskor)
        {
           player1win.text="PLAYER1 WİN!";
           bitisyazisi.text="OYUN BİTTİ TEKRAR OYNAMAK İÇİN ENTER TUŞUNA BASIN";
           alkis.Play();
           Time.timeScale=0;
           
           
        }
        if(Time.timeScale==0)
        { 
            if(Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale=1;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D temas) 
    {
        if(temas.gameObject.tag=="player1")
        {
        top.velocity=new Vector2(-xhizi,Random.Range(-2.2f,2.2f));
        }
        else if (temas.gameObject.tag=="player2")
        {
            top.velocity=new Vector2(xhizi,Random.Range(-2.2f,2.2f));
        }
        if(temas.gameObject.tag=="Ustduvar")
        {
            top.velocity=new Vector2(top.velocity.x,-yhizi);
        }
        else if (temas.gameObject.tag=="Altduvar")
        {
            top.velocity=new Vector2(top.velocity.x,yhizi);
        }
        if(temas.gameObject.tag=="Solduvar")
        {
            player1skor++;
            transform.position=new Vector2(-7.4363f,0f);
            skor.Play();
        }
        else if(temas.gameObject.tag=="Sagduvar")
        {
            player2skor++;
            skor.Play();
            transform.position=new Vector2(7.4363f,0f);
        }
        
        
        
    }
}
