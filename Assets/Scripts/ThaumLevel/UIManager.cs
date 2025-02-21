using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private int[] selectedButtons = new int[3] { 0, 0, 0 };
    private Dictionary<int, int> combinationUses = new Dictionary<int, int>();
    private int lastUsedSeed = -1;
    public Sprite[] symbolsSprites;
    public SpriteRenderer[] columnDisplays;
    public BubbleGenome genomeController;
    public BubbleRenderer bubbleRenderer;
    public IndicatorManager indicatorManager;

    public AudioSource audioSourceFailure;
    public AudioSource audioSourceWinning;
    public AudioSource audioSourceInvalid;
    public AudioSource audioSource;

    void Start()
    {
        indicatorManager.UpdateIndicators(genomeController.CurrentGene);
    }

    public void SelectButton(int column, int row)
    {
        audioSource.Play();
        selectedButtons[column] = row;
        UpdateColumnDisplay();
    }

    public void OnCombinePressed()
    {
        int seed = CalculateSeed();
        
        if (seed == lastUsedSeed)
        {
            HandleInvalidCombination(isConsecutive: true);
            return;
        }
        
        if (combinationUses.TryGetValue(seed, out int uses) && uses >= 3)
        {
            HandleInvalidCombination(isConsecutive: false);
            return;
        }

        if (combinationUses.ContainsKey(seed))
            combinationUses[seed]++;
        else
            combinationUses.Add(seed, 1);
        
        lastUsedSeed = seed;
        genomeController.CurrentGene.Mutate(seed);
        indicatorManager.UpdateIndicators(genomeController.CurrentGene);
        bubbleRenderer.GenerateBubble();
        audioSource.Play();
        CheckWinLoseConditions();
    }

    private int CalculateSeed()
    {
        return selectedButtons[0] * 100 + selectedButtons[1] * 10 + selectedButtons[2];
    }

    private void HandleInvalidCombination(bool isConsecutive)
    {
        if (isConsecutive)
        {
            audioSourceInvalid.Play();
            Debug.Log("Same combination consecutively");
        }
        else
        {
            audioSourceInvalid.Play();
            Debug.Log("This combination has been used maximum times");
        }
    }

    private void CheckWinLoseConditions()
    {
        int onesCount = 0;
        int twelvesCount = 0;

        var gene = genomeController.CurrentGene;
        if (gene.Size == 1) onesCount++;
        if (gene.Elasticity == 1) onesCount++;
        if (gene.Opacity == 1) onesCount++;
        if (gene.SurfaceTension == 1) onesCount++;
        if (gene.Stickiness == 1) onesCount++;
        if (gene.Buoyancy == 1) onesCount++;
        if (gene.Luminosity == 1) onesCount++;
        if (gene.Reflectivity == 1) onesCount++;

        if (gene.Size == 12) twelvesCount++;
        if (gene.Elasticity == 12) twelvesCount++;
        if (gene.Opacity == 12) twelvesCount++;
        if (gene.SurfaceTension == 12) twelvesCount++;
        if (gene.Stickiness == 12) twelvesCount++;
        if (gene.Buoyancy == 12) twelvesCount++;
        if (gene.Luminosity == 12) twelvesCount++;
        if (gene.Reflectivity == 12) twelvesCount++;

        if (onesCount >= 4)
        {
            HandleLoseCondition();
        }
        else if (twelvesCount >= 3)
        {
            HandleWinCondition();
        }
    }

    private void HandleWinCondition()
    {
        audioSourceWinning.Play();
        new WaitForSeconds(1);
        Debug.Log("WIN CONDITION MET");
    }

    private void HandleLoseCondition()
    {
        audioSourceFailure.Play();
        Debug.Log("LOSE CONDITION MET");
        new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    private void UpdateColumnDisplay()
    {
        for (int i = 0; i < 3; i++)
            columnDisplays[i].sprite = GetButtonSprite(i, selectedButtons[i]);
    }
    
   private Sprite GetButtonSprite(int column, int row)
    {
        return symbolsSprites[column*5 + row];
    }
}
