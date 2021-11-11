using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WK.Libraries.BootMeUpNS;

namespace CheatSheet_Win.Util
{
    public class Boot_Up
    {
        private BootMeUp bootMeUp = new();

        public void Register()
        {
            bootMeUp.UseAlternativeOnFail = true;
            bootMeUp.BootArea = BootMeUp.BootAreas.StartupFolder;
            bootMeUp.TargetUser = BootMeUp.TargetUsers.CurrentUser;

            // Enable auto-booting.
            bootMeUp.Enabled = true;
        }

        public void UnRegister()
        {
            bootMeUp.UseAlternativeOnFail = true;
            bootMeUp.BootArea = BootMeUp.BootAreas.StartupFolder;
            bootMeUp.TargetUser = BootMeUp.TargetUsers.CurrentUser;

            // Enable auto-booting.
            bootMeUp.Enabled = false;
        }
    }
}
