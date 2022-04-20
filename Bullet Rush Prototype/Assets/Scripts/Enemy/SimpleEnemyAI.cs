using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyAI : MonoBehaviour
{
    GameObject player;
    public float speed;
    private void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(MoveToPlayer(player, speed));
    }

    IEnumerator MoveToPlayer(GameObject player, float speedTranslation) // move directly to player
    {
        while(gameObject.transform.position != player.transform.position)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speedTranslation * Time.deltaTime);
            yield return null;
        }
    }
}
