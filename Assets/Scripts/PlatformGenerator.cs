


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
    [SerializeField] GameObject pizzaPrefab;
    float height = 10f;
    int platformsGenerated = 0;
    float platformOffset = 0.0f;
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
            float y = Random.Range(1.4f + platformOffset, 2.3f + platformOffset);
            y += startPlatform.GetComponent<Platform>().getY();
            Vector2 spawnPos = new Vector2(x, y);
            
            startPlatform = Instantiate(platformPrefab, spawnPos, Quaternion.identity);
            platformsGenerated++;
            //Debug.Log("platform generated" + platformsGenerated);
            if(platformsGenerated % 5 == 0)
            {   
                if(platformOffset < 0.5f)
                {
                    platformOffset += 0.03f;
                }
                //Debug.Log("pizza generated");
                Instantiate(pizzaPrefab, new Vector2(x, y + 0.5f), Quaternion.identity);
            }
            
        }
        if(player.position.y + 10f > height)
        {
            height = player.position.y + 5f;
        }
    }
}
