using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEvent : MonoBehaviour
{
    public static Vector3 spacer = new Vector3(0, 0.1f, 0);
    private PlayerController targetedPlayer;
    public AudioSource audioSrc;
    public AudioClip explosionClip;
    public AudioClip fuseClip;

    // For fuse animation
    private Vector3 Direction;
    private float scalar;
    private int count = 0;

    public void OnEnable()
    {
        EventManager.OnBombPull += BombEventStart;
        EventManager.OnBombDefused += BombEventDefuse;
        EventManager.OnBombExplode += BombEventExplode;
    }

    public void OnDisable()
    {
        EventManager.OnBombPull -= BombEventStart;
        EventManager.OnBombDefused -= BombEventDefuse;
        EventManager.OnBombExplode -= BombEventExplode;

    }

    public string GetPlayerName()
    {
        return targetedPlayer.player.getID();
    }

    public PlayerController GetPlayerController()
    {
        return targetedPlayer;
    }

    private void BombAppear()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        foreach (CapsuleCollider collider in gameObject.GetComponents<CapsuleCollider>())
            collider.enabled = true;
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void BombDisappear()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        foreach (CapsuleCollider collider in gameObject.GetComponents<CapsuleCollider>())
            collider.enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void StartFuse()
    {
        Vector3 startPoint = transform.GetChild(0).position;
        Vector3 endPoint = transform.GetChild(1).position;
        Direction = (startPoint - endPoint).normalized;
        scalar = (startPoint - endPoint).magnitude / 10f;
        transform.GetChild(2).position = startPoint + (Direction * scalar);
        transform.GetChild(2).gameObject.SetActive(true);

        InvokeRepeating("FuseAnimate", 1f, 1.2f);
    }

    private void FuseAnimate()
    {
        transform.GetChild(2).position -= Direction * scalar;
        count++;


        if (count >= 10)
        {
            CancelInvoke();
            BombDisappear();
            transform.GetChild(2).gameObject.SetActive(false);
            count = 0;
            BombExplode();
        }

    }

    private void BombExplode()
    {
        audioSrc.PlayOneShot(explosionClip);
        GameObject explosion = gameObject.transform.GetChild(3).gameObject;
        explosion.SetActive(true);
        EventManager.OnBombExploded.Invoke(targetedPlayer);
    }

    public void BombEventStart(PlayerController playerController)
    {
        Vector3 euler = playerController.cardSpawn.transform.eulerAngles;
        euler.x += 180;
        euler.y -= 90;
        gameObject.transform.position = playerController.cardSpawn.transform.position + PlayerController.objSpawnHeight + spacer;
        gameObject.transform.eulerAngles = euler;

        targetedPlayer = playerController;

        BombAppear();
    }

    public void BombEventExplode(PlayerController playerController)
    {
        audioSrc.PlayOneShot(fuseClip);
        StartFuse();
    }

    public void BombEventDefuse(PlayerController playerController)
    {
        BombDisappear();
    }

}
