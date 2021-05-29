using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    public List<AudioClip> audioClips;
    private PlayerMovement player;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        StartCoroutine(PlayDialouge());
       
    }

    IEnumerator PlayDialouge(){
     
            while(!player.isGameOver){
            
                int waitingTime = Random.Range(5,15);

                yield return new WaitForSeconds(waitingTime);
            
                int randomPlay = Random.Range(0,audioClips.Count);
                audioSource.PlayOneShot(audioClips[randomPlay]);
              
            }
        

    }
}
