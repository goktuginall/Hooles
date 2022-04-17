using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CamBlur : MonoBehaviour
{
    [SerializeField] public Material BlurMaterial;
    [Range(0, 10)] private int Entegrasyon;
    [Range(0, 4)] private int DownR;
    private RenderTexture source, destination;
    // Start is called before the first frame update
    public void ChangeBlurValue(int Entegre, int DownRR)
    {
        Entegrasyon = Entegre;
        DownR = DownRR;
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        int width = source.width >> DownR;
        int height = source.height >> DownR;

        RenderTexture Rtexture = RenderTexture.GetTemporary(width, height);
        Graphics.Blit(source, Rtexture);
        for (int i = 0; i < Entegrasyon; i++)
        {
            RenderTexture Rtexture2 = RenderTexture.GetTemporary(width, height);
            Graphics.Blit(Rtexture, Rtexture2, BlurMaterial);
            RenderTexture.ReleaseTemporary(Rtexture);
            Rtexture = Rtexture2;
        }
        Graphics.Blit(Rtexture, destination);
        RenderTexture.ReleaseTemporary(Rtexture);
    }
}
