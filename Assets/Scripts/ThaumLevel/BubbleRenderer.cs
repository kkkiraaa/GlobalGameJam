using UnityEngine;

public class BubbleRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BubbleGenome genome;
    private ParticleSystem particles;
    private float animationTime;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        genome = GetComponent<BubbleGenome>();
        particles = GetComponent<ParticleSystem>();
        GenerateBubble();
    }

    void Update()
    {
        if (genome.CurrentGene.Elasticity > 4)
        {
            animationTime += Time.deltaTime;
            UpdateElasticityDeformation();
        }
    }

    float SDFCircle(Vector2 p, float r, float deformation = 0)
    {
        float angle = Mathf.Atan2(p.y, p.x);
        float deform = Mathf.Sin(angle * (genome.CurrentGene.Elasticity+3) + animationTime * (genome.CurrentGene.Elasticity+3)) * deformation;
        return Mathf.Sqrt(p.x * p.x + p.y * p.y) - r - deform;
    }

    public void GenerateBubble()
    {
        int baseSize = 24 + genome.CurrentGene.Size * 8;
        float deformation = genome.CurrentGene.Elasticity * genome.CurrentGene.SurfaceTension / 1440f;
        float surfaceSmoothness = Mathf.Lerp(0.5f, 0.1f, genome.CurrentGene.SurfaceTension / 12f);
        Color baseColor = Color.HSVToRGB(
            genome.CurrentGene.Reflectivity / 12f,
            Mathf.Lerp(0.3f, 0.8f, genome.CurrentGene.Luminosity / 12f),
            Mathf.Lerp(0.5f, 1f, genome.CurrentGene.Luminosity / 12f)
        );

        int texSize = Mathf.CeilToInt(baseSize * 3f);
        Texture2D tex = new Texture2D(texSize, texSize);
        Vector2 center = new Vector2(texSize / 2, texSize / 2);

        for (int x = 0; x < texSize; x++)
        {
            for (int y = 0; y < texSize; y++)
            {
                Vector2 pos = new Vector2(x, y) - center;
                float distance = SDFCircle(pos, baseSize, deformation * baseSize);
                
                Color pixelColor = baseColor;
                
                float alpha = Mathf.SmoothStep(0, 1, 1 - Mathf.Clamp01(distance / surfaceSmoothness));
                
                alpha *= genome.CurrentGene.Opacity / 12f;
                
                float verticalGradient = Mathf.Lerp(0.8f, 1.2f, genome.CurrentGene.Buoyancy / 12f);
                alpha *= Mathf.Lerp(0.8f, 1f, (y / (float)texSize) * verticalGradient);
                
                if (distance > -1 && distance < 1)
                {
                    float highlight = Mathf.Pow(Mathf.Abs(pos.normalized.x), 10) * 
                                    (genome.CurrentGene.Reflectivity / 12f);
                    pixelColor = Color.Lerp(pixelColor, Color.white, highlight);
                }

                pixelColor.a = alpha;
                tex.SetPixel(x, y, pixelColor);
            }
        }

        tex.Apply();
        tex.filterMode = FilterMode.Point;
        spriteRenderer.sprite = Sprite.Create(tex, new Rect(0, 0, texSize, texSize), Vector2.one * 0.5f);

        UpdateParticles();
    }

    void UpdateElasticityDeformation()
    {
        var scale = transform.localScale;
        float deform = Mathf.Sin(animationTime * 2) * 0.1f * (genome.CurrentGene.Elasticity / 12f);
        transform.localScale = new Vector3(
            1 + deform,
            1 - deform * 0.5f,
            1
        );
    }

    void UpdateParticles()
    {
        if (particles == null) return;

        var emission = particles.emission;
        emission.rateOverTime = Mathf.Lerp(0, 20, genome.CurrentGene.Stickiness / 12f);

        var main = particles.main;
        main.startColor = new Color(1, 1, 1, Mathf.Lerp(0.1f, 0.4f, genome.CurrentGene.Stickiness / 12f));
    }
}