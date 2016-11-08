using UnityEngine;

[ExecuteInEditMode]
public class ShaderCamera : MonoBehaviour
{
    public Material Mat;

    void Start()
    {
        Cursor.visible = false;
    }
    

    public void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        //Shader.Find(Spotlight);
        Debug.Log(Mat.shader);
        Debug.Log("Hello?");

        float xPos = mousePos.x / Screen.width * 0.5f;
        float yPos = (Screen.height - mousePos.y) / Screen.height * (0.5f * 9)/16;
        Mat.SetFloat(Shader.PropertyToID("_CenterX"), xPos);
        Mat.SetFloat(Shader.PropertyToID("_CenterY"), yPos);
    }

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, Mat);
    }
}
