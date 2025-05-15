using UnityEngine;

public class shot : MonoBehaviour
{
    // ...
}

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(audioSource.clip); // เล่นแบบไม่ทับเสียงเดิม
    }
}
