using UnityEngine;

[ExecuteInEditMode]
public class ShaderCamera : MonoBehaviour
{
    public Material Mat;
    private Transform playerTransform;
    //private bool isMin = false;
    //public float max_light = 0.5f;
    //public static float current_light = 0.5f;
    //public float decrease_rate = .01f;
    //public float min_light = 0.05f;
    //GameObject player;
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("player");
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //Cursor.visible = false;
    }
    

    public void Update()
    {
        
        if (ItemScript.battery_count > 0)
        {
            
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("Battery used");
                ItemScript.isMin = false;
                
                ItemScript.current_light = ItemScript.max_light;
                Mat.SetFloat(Shader.PropertyToID("_Radius"), ItemScript.current_light);
                
                ItemScript.items.decBattery();
            }
        }
        Vector3 mousePos = Input.mousePosition;
        //Debug.Log(mousePos);
        Vector3 playerPos = playerTransform.position;
        Vector3 playerPosScreen = Camera.main.WorldToScreenPoint(playerPos);
        //Shader.Find(Spotlight);

        float xPos = playerPosScreen.x / Screen.width * 0.5f;
        float yPos = (Screen.height - playerPosScreen.y) / Screen.height * (0.5f * 9)/16;
        Mat.SetFloat(Shader.PropertyToID("_CenterX"), xPos);
        Mat.SetFloat(Shader.PropertyToID("_CenterY"), yPos - .04f);
        if (!ItemScript.isMin)
        {
            ItemScript.current_light -= ItemScript.decrease_rate * Time.deltaTime;
            Mat.SetFloat(Shader.PropertyToID("_Radius"), ItemScript.current_light);
            //Debug.Log(max_light);
            if (ItemScript.current_light < ItemScript.min_light)
            {
                Debug.Log("im inside");
                ItemScript.isMin = true;
            }
        }
    }

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, Mat);
    }
}
