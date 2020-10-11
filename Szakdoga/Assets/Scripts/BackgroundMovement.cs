using UnityEngine;
using UnityEngine.UI;

public class BackgroundMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.lostALife)
        {
            BGMove();
        }
    }

    void BGMove()
    {
        Material mat = GetComponent<Image>().material;
        mat.SetTextureOffset("_MainTex", mat.mainTextureOffset + new Vector2(0f, Time.deltaTime / 14f));
    }
}
