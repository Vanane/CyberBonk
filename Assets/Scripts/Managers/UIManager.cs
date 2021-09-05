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

    
    private Dictionary<Panels, UIPanel> panels;    
    private List<UIPanel> activePanels;

    public UIPanel pausePanel, inventoryPanel, skillsPanel, missionsPanel;

    public bool hasPanelsActive { get { return activePanels.Count > 0; } }

    // Start is called before the first frame update
    void Start()
    {
        activePanels = new List<UIPanel>();

        // Since Unity can't handle dictionaries in the editor,
        // the dicionary is built from several isolated references.
        panels = new Dictionary<Panels, UIPanel>
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
        if (activePanels.Contains(panels[panel]))
            ClosePanel(panel);
        else
            OpenPanel(panel);
    }


    public void OpenPanel(Panels panel)
    {
        if (!activePanels.Contains(panels[panel]))
        {
            panels[panel].gameObject.SetActive(true);
            activePanels.Add(panels[panel]);
            panels[panel].OnOpen();
        }
    }


    public void ClosePanel(Panels panel)
    {
        if (activePanels.Contains(panels[panel]))
            ClosePanel(panels[panel]);
    }


    private void ClosePanel(UIPanel panel)
    {
        activePanels.Remove(panel);
        panel.gameObject.SetActive(false);
        panel.OnClose();
    }


    public void CloseLastPanel()
    {
        if (hasPanelsActive)
        {
            activePanels[activePanels.Count - 1].gameObject.SetActive(false);
            activePanels.RemoveAt(activePanels.Count - 1);
        }
    }


    public void CloseAllPanels()
    {
        foreach (UIPanel panel in activePanels)
            ClosePanel(panel);
    }


}
