using GalaSoft.MvvmLight;

namespace NutriFit.ViewModel
{
    public class MainViewModel 
    {
        public JelaViewModel JelaViewModel { get; }
        public PorudzbineViewModel PorudzbineViewModel { get; }

        public MainViewModel()
        {

            JelaViewModel = new JelaViewModel();
            PorudzbineViewModel = new PorudzbineViewModel();
        }
    }
}