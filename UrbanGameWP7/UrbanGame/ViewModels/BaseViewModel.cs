﻿using Caliburn.Micro;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrbanGame.ViewModels
{
    public class BaseViewModel : Screen
    {
        protected INavigationService _navigationService;
        protected Func<IUnitOfWork> _unitOfWorkLocator;
        bool _creating = true;

        public BaseViewModel(INavigationService navigationService, Func<IUnitOfWork> unitOfWorkLocator)
        {
            _navigationService = navigationService;
            _unitOfWorkLocator = unitOfWorkLocator;
        }

        protected override void OnActivate()
        {
            bool resurecting = AppBootstrapper.Resurecting;

            AppBootstrapper.Resurecting = false;
            base.OnActivate();
            if (resurecting)
            {
                LoadState();
            }
            else if (_creating)
            {
                OnCreated();
                _creating = false;
            }

        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            if (!close)
            {
                SaveState();
            }
        }

        protected virtual void LoadState()
        {

        }

        protected virtual void SaveState()
        {

        }

        protected virtual void OnCreated()
        {

        }

        protected void GoBack()
        {
            if (_navigationService.CanGoBack)
            {
                _navigationService.GoBack();
            }
        }
    }
}