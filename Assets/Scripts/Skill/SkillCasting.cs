using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class SkillCasting : MonoBehaviour
{
    [Header("SKILL PREFABS")]
    [SerializeField] private GameObject lightning;
    [SerializeField] private GameObject fireBomb;

    [Header("SKILL BUTTONS")]
    [SerializeField] private RectTransform lightningButton;
    [SerializeField] private RectTransform fireBombButton;

    [Header("SKILL COUNTERS")]
    [SerializeField] private TextMeshProUGUI lightningText;
    [SerializeField] private TextMeshProUGUI fireBombText;


    private int lightningRemaining = 3;
    private int fireBombRemaining = 3;

    private RectTransform selectedButton;
    private GameObject selectedSkill;

    private bool isSelected;

    private void Start()
    {
        UpdateSkillCountUI();
    }

    private void UpdateSkillCountUI()
    {
        lightningText.text = "x" + lightningRemaining.ToString();
        fireBombText.text = "x" + fireBombRemaining.ToString();
    }


    private void Update()
    {
        if (isSelected && Input.GetMouseButtonDown(0) && !IsPointerOverUI())
        {
            Vector3 castPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //assign mouse position to castPosition
            GameObject skill = Instantiate(selectedSkill , new Vector3(castPosition.x,castPosition.y,-5) , Quaternion.identity);
            //instantiate the skill 
            skill.GetComponent<Skill>().InitializeSkill(selectedSkill.name);
            //Cast the skill
            isSelected = false;
            selectedButton.DOLocalMoveY(selectedButton.localPosition.y - 15, 0.1f);
            //Move button to its place
            SkillUsed();
        }
    }

    public void SelectSkill(GameObject skillPrefab, RectTransform button)
    {
        if(!isSelected && SkillCanBeUsed(skillPrefab))
        {
            isSelected = true;
            selectedSkill = skillPrefab;
            selectedButton = button;
            selectedButton.DOLocalMoveY(button.localPosition.y + 15, 0.1f);
        }
        else if(isSelected)
        {
            isSelected = false;
            selectedButton.DOLocalMoveY(selectedButton.localPosition.y - 15, 0.1f);
            //Move button to its place
        }
    }

    bool SkillCanBeUsed(GameObject skill)
    {
        if (skill.Equals(lightning) && lightningRemaining != 0)
        {
            return true;
        }
        else if (skill.Equals(fireBomb) && fireBombRemaining != 0)
        {
            return true;
        }

        return false;
    }



    void SkillUsed()
    {
        if (selectedSkill.Equals(lightning))
        {
            lightningRemaining--;
        }
        else if (selectedSkill.Equals(fireBomb))
        {
            fireBombRemaining--;
        }

        UpdateSkillCountUI();
    }




    public void SelectFireBomb() // will be called  when fire bomb button is pressed.
    {
        SelectSkill(fireBomb, fireBombButton);
    }

    public void SelectLightning() // will be called when lightning button is pressed.
    {
        SelectSkill(lightning, lightningButton);
    }
    

    private bool IsPointerOverUI()
    {
        // Check if the pointer is over a UI element
        return EventSystem.current.IsPointerOverGameObject();
    }
}
