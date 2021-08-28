using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gold : MonoBehaviour
{
    [SerializeField] private UnityEvent grabCoinEvent = new UnityEvent();
    private GoldCounter goldCounter;
    private bool grabbed = false;

    private void Start()
    {
        goldCounter = GameObject.FindObjectOfType<GoldCounter>();
        grabCoinEvent.AddListener(goldCounter.AddGold);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!grabbed && collision.gameObject.CompareTag("Player"))
        {
            grabCoinEvent.Invoke();
            grabbed = true;
            Destroy(gameObject);
        }
    }
}
