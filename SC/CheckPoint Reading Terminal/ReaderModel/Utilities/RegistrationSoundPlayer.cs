using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ReaderModel.Utilities
{
    public class RegistrationSoundPlayer
    {
        public static void Play()
        {
            var registrationsound = new SoundPlayer(Properties.Resources.registrationBeep);
            registrationsound.Play();
        }
    }
}
