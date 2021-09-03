using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public enum Panels
    {
        Pause,
        Inventory,
        Skills,
        Missions
    }

    
    private Dictionary<Panels, GameObject> panels;    
    private List<GameObject> activePanels;

    public GameObject pausePanel, inventoryPanel, skillsPanel, missionsPanel;

    public bool isPanelActive { get { return activePanels.Count > 0; } }

    // Start is called before the first frame update
    void Start()
    {
        activePanels = new List<GameObject>();

        // Since Unity can't handle dictionaries in the editor,
        // the dicionary is built from several isolated references.
        panels = new Dictionary<Panels, GameObject>
        {
            {Panels.Pause, pausePanel },
            {Panels.Inventory, inventoryPanel },
            {Panels.Skills, skillsPanel },
            {Panels.Missions, missionsPanel },
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TogglePanel(Panels panel)
    {
        if (panels[panel].activeSelf)
            ClosePanel(panel);
        else
            OpenPanel(panel);
    }


    public void OpenPanel(Panels panel)
    {
        if(!activePanels.Contains(panels[panel]))
        {
            panels[panel].SetActive(true);
            activePanels.Add(panels[panel]);
        }
    }


    public void ClosePanel(Panels panel)
    {
        if (activePanels.Contains(panels[panel]))
        {
            activePanels.Remove(panels[panel]);
            panels[panel].SetActive(false);
        }
    }


    public void CloseLastPanel()
    {
        if (isPanelActive)
        {
            activePanels[activePanels.Count - 1].SetActive(false);
            activePanels.RemoveAt(activePanels.Count - 1);
        }
    }
}
