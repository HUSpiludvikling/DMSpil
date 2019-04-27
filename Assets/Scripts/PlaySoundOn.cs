using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum SoundOnTypes
{
    Jump, 
    Spec
}

[RequireComponent(typeof(AudioSource))]
public class PlaySoundOn : MonoBehaviour
{
    AudioSource _as;

    [SerializeField] SoundOnTypes SoundOn;

    UnityEvent soundTrigger;
    // Start is called before the first frame update
    void Start()
    {
        _as = GetComponent<AudioSource>();

        switch (SoundOn)
        {
            case SoundOnTypes.Jump:
                GetComponentInParent<ActorMovementManager>().jumpEvent.AddListener(PlaySound); break;
            case SoundOnTypes.Spec:
                GetComponentInParent<ActorMovementManager>().specEvent.AddListener(PlaySound); break;
            default:
                break;
        }

    }

    void PlaySound()
    {
        if(!_as.isPlaying)
        {
            _as.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
