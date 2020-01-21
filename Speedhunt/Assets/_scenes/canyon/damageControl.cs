using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageControl : MonoBehaviour
{
    [SerializeField] RectTransform damageLine;
    [SerializeField] AudioClip[] crashSounds;
    [SerializeField] GameObject crashScene;

    float enemyHealth = 1000;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(crashSounds[Random.Range(0, crashSounds.Length)], this.transform.position);
        enemyHealth-=collision.relativeVelocity.magnitude;
        if(enemyHealth <= 0)
        {
            crashScene.SetActive(true);
        }
        damageLine.localScale = new Vector3(enemyHealth/1000, 1, 1);

    }
}
