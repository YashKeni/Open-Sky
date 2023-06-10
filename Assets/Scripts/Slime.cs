using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] float respawnTime = 5f;
    [SerializeField] float despawnTime = 2f;
    [SerializeField] GameObject slime;
    Animator slimeAnimator;
    CircleCollider2D circleCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        slimeAnimator = GetComponent<Animator>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        circleCollider2D.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sword" && gameObject.tag == "Enemy")
        {
            slimeAnimator.SetTrigger("isDead");
            circleCollider2D.enabled = false;
            StartCoroutine(Respawn());
            // Destroy(other.gameObject);
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        Instantiate(slime, transform.localPosition, Quaternion.identity);
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }
}
