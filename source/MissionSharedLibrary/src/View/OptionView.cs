﻿using System;
using MissionLibrary.View;
using MissionSharedLibrary.HotKey.Category;

namespace MissionSharedLibrary.View
{
    public class OptionView : MissionMenuViewBase
    {
        public OptionView(int viewOrderPriority, Version version)
            : base(viewOrderPriority, "MissionLibrary" + nameof(OptionView) + "-" + version)
        {
        }

        public override void OnMissionScreenTick(float dt)
        {
            base.OnMissionScreenTick(dt);
            if (IsActivated)
            {
                if (GauntletLayer.Input.IsKeyReleased(GeneralGameKeyCategories.GetKey(GeneralGameKey.OpenMenu)))
                    DeactivateMenu();
            }
            else if (Input.IsKeyReleased(GeneralGameKeyCategories.GetKey(GeneralGameKey.OpenMenu)))
                ActivateMenu();
        }

        public override void OnMissionScreenFinalize()
        {
            base.OnMissionScreenFinalize();
            
            AMenuManager.Get().MenuClassCollection.Clear();
        }

        protected override MissionMenuVMBase GetDataSource()
        {
            return new OptionVM(AMenuManager.Get().MenuClassCollection, OnCloseMenu);
        }
    }
}
