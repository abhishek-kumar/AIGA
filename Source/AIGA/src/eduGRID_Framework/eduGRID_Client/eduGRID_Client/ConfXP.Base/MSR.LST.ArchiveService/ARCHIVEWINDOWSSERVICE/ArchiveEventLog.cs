using System;
using System.Diagnostics;

namespace MSR.LST.ConferenceXP.Archive
{
    /// <summary>
    /// Summary description for ArchiveEventLog.
    /// </summary>
    public class ArchiveEventLog
    {
        private ArchiveEventLog()
        {
        }

        private static EventLog eventLog = null;

        private static void WriteIt( string s, EventLogEntryType t)
        {
            if ( eventLog == null)
                OpenEventLog();

            try
            {
                eventLog.WriteEntry( s, t);
            }
            catch 
            {}
        }

        private static void OpenEventLog()
        {
            if(!EventLog.SourceExists(Constants.PersistenceName))
            {
                EventLog.CreateEventSource(Constants.PersistenceName, "CXPArchive");

            }
                
            // Create an EventLog instance and assign its source.
            eventLog = new EventLog();
            eventLog.Source = Constants.PersistenceName;
        }

        public static void WriteInformation( string s )
        {
            WriteIt( s, EventLogEntryType.Information);

        }

        public static void WriteWarning( string s )
        {
            WriteIt( s, EventLogEntryType.Warning);

        }

        public static void WriteError( string s )
        {
            WriteIt( s, EventLogEntryType.Error);

        }

    }
}
