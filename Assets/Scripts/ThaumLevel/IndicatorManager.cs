using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorManager : MonoBehaviour
{
    public Sprite[] numberSprites; // 1-12 sprites
    public SpriteRenderer[] indicators; // 8 indicators

    public void UpdateIndicators(BubbleGenome.Gene gene)
    {
        indicators[0].sprite = numberSprites[gene.Size - 1];
        indicators[1].sprite = numberSprites[gene.Elasticity - 1];
        indicators[2].sprite = numberSprites[gene.Opacity - 1];
        indicators[3].sprite = numberSprites[gene.SurfaceTension - 1];
        indicators[4].sprite = numberSprites[gene.Stickiness - 1];
        indicators[5].sprite = numberSprites[gene.Buoyancy - 1];
        indicators[6].sprite = numberSprites[gene.Luminosity - 1];
        indicators[7].sprite = numberSprites[gene.Reflectivity - 1];
    }
}