using UnityEngine;

[ExecuteInEditMode]
public class ShaderCamera : MonoBehaviour
{
    public Material Mat;
    private Transform playerTransform;
    private bool isMin = false;
    public float max_light = 0.5f;
    public float decrease_rate = .01f;
    public float min_light = 0.05f;
    //GameObject player;
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("player");
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //Cursor.visible = false;
    }
    

    public void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        //Debug.Log(mousePos);
        Vector3 playerPos = playerTransform.position;
        Vector3 playerPosScreen = Camera.main.WorldToScreenPoint(playerPos);
        //Shader.Find(Spotlight);

        float xPos = playerPosScreen.x / Screen.width * 0.5f;
        float yPos = (Screen.height - playerPosScreen.y) / Screen.height * (0.5f * 9)/16;
        Mat.SetFloat(Shader.PropertyToID("_CenterX"), xPos);
        Mat.SetFloat(Shader.PropertyToID("_CenterY"), yPos - .04f);
        if (!isMin)
        {
            max_light -= decrease_rate * Time.deltaTime;
            Mat.SetFloat(Shader.PropertyToID("_Radius"), max_light);
            //Debug.Log(max_light);
            if (max_light < min_light)
            {
                Debug.Log("im inside");
                isMin = true;
            }
        }
    }

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, Mat);
    }
}
