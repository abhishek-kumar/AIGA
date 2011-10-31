using System;

namespace MSR.LST.ConferenceXP
{
    internal class AppConfig
    {
        // Pri 2: When merginging with the new app config code for CXP,
        // we might have to move this code or use a root constant for
        // CXP_Capability containing CXP + "Capability."
        private const string PRES = "MSR.LST.ConferenceXP.Capability.Presentation.";

        // This key allow to enable the open remote feature (settings on
        // initiator only)
        public const string PRES_OpenRemote = PRES + "OpenRemote";

        // This key allow an initiator to ask viewers to exit when it exits
        // Pri1: This will be taking care at the network level (settings on
        // initiator only)
        public const string PRES_ExitRemote = PRES + "ExitRemote";
    }
}
