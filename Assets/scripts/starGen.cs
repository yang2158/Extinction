using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starGen : MonoBehaviour
{
    // Start is called before the first frame update
    public Object star;
    List<chunk> chunks = new List<chunk>();
    public int chunkSize = 50;
    public float densitys = 0.1f;
    public float maxSize = 1f;
    public float minSize = 0.3f;
    public class chunk
    {
        public Vector2 cords;
        public chunk(Vector2 cord)
        {
            cords = cord;
        }
    }
    void Start()
    {
        getChunk();
    }
    public void getChunk()
    {
        generateStars(new Vector2(getCord(getVectorPoint(0, 0).x) , getCord(getVectorPoint(0, 0).y)), new Vector2(chunkSize, chunkSize), densitys);

        generateStars(new Vector2(getCord(getVectorPoint(0, Screen.height).x), getCord(getVectorPoint(0, Screen.height).y)), new Vector2(chunkSize, chunkSize), densitys);
        
        generateStars(new Vector2(getCord(getVectorPoint(Screen.width, Screen.height).x), getCord(getVectorPoint(Screen.width, Screen.height).y)), new Vector2(chunkSize, chunkSize), densitys);
        generateStars(new Vector2(getCord(getVectorPoint(Screen.width, 0).x), getCord(getVectorPoint(Screen.width, 0).y)), new Vector2(chunkSize, chunkSize), densitys);
    }
    public Vector3 getVectorPoint(float x, float y)
    {

        return Camera.main.ScreenToWorldPoint(new Vector3(x,y , 0));
    }
    // Update is called once per frame
    public float getCord(float num)
    {
        return num - (modu(num,chunkSize) );

    }
    public float modu(float num, float num1)
    {
        while ( num < 0)
        {
            num += num1*10;
        }
        return num % num1;
    }
    void FixedUpdate()
    {
        getChunk();
    }
    public void generateStars(Vector2 pos, Vector2 size, float density)
    {
        if (!containChunkPos(pos))
        {
            chunks.Add(new chunk(pos) );
            int numstars = (int)((size.x * size.y) * density);
            for (int i = 0; i < numstars; i++)
            {
                GameObject go = (GameObject)GameObject.Instantiate(star, new Vector3(Random.Range(pos.x, pos.x + size.x), Random.Range(pos.y, pos.y + size.y), 0), Quaternion.identity, transform);
                go.transform.localScale *= Random.Range(minSize, maxSize);
            }
        }
    }
    public bool containChunkPos(Vector2 pos)
    {
        for( int i = 0; i <chunks.Count ; i ++)
        {
            if ((int)chunks[i].cords.x == (int)pos.x && (int)chunks[i].cords.y == (int)pos.y) 
            {
                return true;
            }
        }
        return false;




    }
}
