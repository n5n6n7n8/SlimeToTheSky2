

using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    //current height var for the platforms to generate up to (5 above player Y)
    //start with a preset platform above the player. save as previous platform
    //loop: randomize position for the next platform to be. Then, instantiate platform and save it as previous platform
    //repeat until the height is reached
    public Transform player;
    [SerializeField] GameObject startPlatform;
    [SerializeField] GameObject platformPrefab;
    float height = 10f;
    //from 0.4 to 1.0
    void Start()
    {
        height = startPlatform.transform.position.y + 10f;
    }

    // Update is called once per frame
    void Update()
    {
        while(height > startPlatform.GetComponent<Platform>().getY())
        {
            float x = Random.Range(-2.5f, 1.0f);
            float y = Random.Range(1.0f, 3.0f);
            y += startPlatform.GetComponent<Platform>().getY();
            Vector2 spawnPos = new Vector2(x, y);
            startPlatform = Instantiate(platformPrefab, spawnPos, Quaternion.identity);
            
        }
        if(player.position.y + 10f > height)
        {
            height = player.position.y + 5f;
        }
    }
}
