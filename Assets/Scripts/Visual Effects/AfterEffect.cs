using System.Collections;
using UnityEngine;

public class AfterEffect : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 0.5f;
    [SerializeField]
    private float rate = 0.2f;
    [SerializeField]
    private float cooldownRate;
    private float cooldown;

    private float maxTrailAmount;
    

    private SpriteRenderer trailRenderer; // reference to the trail part renderer so it can be used in other classes
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cooldown = cooldownRate;
    }
 
    // Update is called once per frame
    void FixedUpdate()
    {
        cooldown -= 1;
        if(cooldown <= 0)
        {
            InvokeRepeating("SpawnTrail", 0, rate * Time.deltaTime);
            cooldown = cooldownRate;
            
        }
        
    }

    void SpawnTrail()
    {
        GameObject trailPart = new GameObject();
        SpriteRenderer trailRenderer = trailPart.AddComponent<SpriteRenderer>();
        trailRenderer.sprite = GetComponent<SpriteRenderer>().sprite;
        Color color = trailRenderer.color;
        color.a = 0.3f;
        trailRenderer.color = color;
        trailPart.transform.position = transform.position;
        trailPart.transform.localScale = transform.localScale;

        Destroy(trailPart, lifeTime * Time.deltaTime);


        
    }

    // IEnumerator FadeTrailPart()
    // {
    //     Color color = trailRenderer.color;
    //     color.a -= 0.5f;
    //     trailRenderer.color = color;

    //     yield return new WaitForEndOfFrame();
    // }

}