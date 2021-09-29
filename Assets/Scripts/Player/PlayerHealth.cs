using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    bool isDead;                                                
    bool damaged;                                               


    void Awake()
    {
        //Mendapatkan reference komponen
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();

        playerShooting = GetComponentInChildren<PlayerShooting>();
        currentHealth = startingHealth;
    }


    void Update()
    {
        //Jika player terkena damage
        if (damaged)
        {
            //Merubah warna gambar menjadi value dari flashColour
            damageImage.color = flashColour;
        }
        //jika tidak
        else
        {
            //Mengaburkan gambar
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        //set damage menjadi false
        damaged = false;
    }

    //Fungsi untuk menerima damage
    public void TakeDamage(int amount)
    {
        damaged = true;

        //Mengurangi health
        currentHealth -= amount;

        //merubah tampilan health slider
        healthSlider.value = currentHealth;

        //memutar suara ketika terkena damage
        playerAudio.Play();

        //memanggil method death jika darah kurang <= 0 dan belum mati
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        playerShooting.DisableEffects();

        //men-trigger animasi Die
        anim.SetTrigger("Die");

        //memutar suara ketika player mati
        playerAudio.clip = deathClip;
        playerAudio.Play();

        //mematikan script PlayerMovement
        playerMovement.enabled = false;

        playerShooting.enabled = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
