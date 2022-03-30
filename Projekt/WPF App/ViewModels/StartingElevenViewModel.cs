using DAL.Enums;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App.ViewModels
{
    public class StartingElevenViewModel
    {
        private StartingEleven startingEleven;

        public StartingElevenViewModel(StartingEleven startingEleven)
        {
            this.startingEleven = startingEleven;
        }

        public string Name
        {
            get => startingEleven.Name;
            set => startingEleven.Name = value;
        }

        public bool Captain
        {
            get => startingEleven.Captain;
            set => startingEleven.Captain = value;
        }

        public long ShirtNumber
        {
            get => startingEleven.ShirtNumber;
            set => startingEleven.ShirtNumber = value;
        }

        public Position Position
        {
            get => startingEleven.Position;
            set => startingEleven.Position = value;
        }

        public int Goals
        {
            get => startingEleven.Goals;
            set => startingEleven.Goals = value;
        }

        public int YellowCards
        {
            get => startingEleven.YellowCards;
            set => startingEleven.YellowCards = value;
        }

    }
}
