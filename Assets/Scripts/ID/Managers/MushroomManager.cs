using System;
using System.Collections.Generic;
using System.Linq;
using ID.Core;
using ID.Utilities;

namespace ID.Managers
{
    public class MushroomManager : Singleton<MushroomManager>
    {
        
        public List<Mushroom> mushrooms;
        public List<Mushroom> killedMushrooms;

        public static event Action<Mushroom> OnKilledMushroom;
        private void Start()
        {
            mushrooms = GetMushroomsInScene();
        }

        private List<Mushroom> GetMushroomsInScene()
        {
            return FindObjectsOfType<Mushroom>().ToList();
        }

        public void AddMushroom(Mushroom mushroom)
        {
            if (!mushrooms.Contains(mushroom))
            {
                mushrooms.Add(mushroom);
            }
        }

        public void ActivateAllMushrooms()
        {
            foreach (Mushroom mushroom in mushrooms)
            {
                mushroom.Activate();
            }
            killedMushrooms = new List<Mushroom>();
        }
        
        public void DeActivateAllMushrooms()
        {
            foreach (Mushroom mushroom in mushrooms)
            {
                mushroom.Deactivate();
            }
        }

        public void KillMushroom(Mushroom mushroom)
        {
            killedMushrooms.Add(mushroom);
            mushroom.Deactivate();
            OnKilledMushroom?.Invoke(mushroom);
        }
    } 
}

