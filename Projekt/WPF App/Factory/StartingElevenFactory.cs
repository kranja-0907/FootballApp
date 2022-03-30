using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_App.ViewModels;

namespace WPF_App.Factory
{
    public class StartingElevenFactory
    {
        public StartingElevenViewModel GetStartingEleven(StartingEleven se)
        {
            return new StartingElevenViewModel(new StartingEleven
            {
                Name = se.Name,
                Position = se.Position,
                ShirtNumber = se.ShirtNumber
            });
        }
    }
}
