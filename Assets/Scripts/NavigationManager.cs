using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Navigation {
    public class NavigationManager {
        public List<IScreen> Screens { get; private set; }

        public void Initialize(List<IScreen> screens) {
            if (screens == null || screens.Count == 0) {
                throw new Exception("Invalid List");
            }
            CheckScreensDuplicatedId(screens);
            Screens = screens;
            Screens.ForEach(screen => {
                screen.Initialize();
            });
        }
        
        private void CheckScreensDuplicatedId(List<IScreen> screens) {
            var duplicatedIds = screens.Count != screens.Select(x=>x.Id).Distinct().Count();
            if (duplicatedIds) {
                throw new Exception("Duplicated Ids");
            }
        }
    }
}


