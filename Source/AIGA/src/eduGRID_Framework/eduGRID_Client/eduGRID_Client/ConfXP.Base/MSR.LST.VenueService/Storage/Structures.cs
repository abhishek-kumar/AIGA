using System;


namespace MSR.LST.ConferenceXP.VenueService
{
    /// <summary>
    /// Represents a venue as stored in the VenueService database.
    /// </summary>
    /// /// <example>
    /// using MSR.LST.ConferenceXP.VenueService
    /// class Test
    /// {
    ///     public static void Main()
    ///     {
    ///         VenueService vs = new VenueService();
    ///
    ///         Venue v = vs.GetVenue("test@test.com");
    ///         Console.WriteLine(v.Name);
    ///
    ///     }
    /// }
    /// </example>
    [Serializable]
    public class Venue
    {
        /// <summary>
        /// The unique identifier for this venue, not to exceed 255 bytes.  In our application, we use the email address of the venue as the identifier in order to facilitate some form of Instant Message integration with a Venue in the future.
        /// </summary>
        public  string      Identifier;
        /// <summary>
        /// The venue's ip address for multicast listening in dot notation (eg "111.222.111.222").
        /// </summary>
        public  string      IPAddress;
        /// <summary>
        /// The port the venue is active on, a 16 bit unsigned integer from 0 to 65535.
        /// </summary>
        public  int         Port;
        /// <summary>
        /// The descriptive name for the venue, not to exceed 255 bytes.
        /// </summary>
        public  string      Name;
        /// <summary>
        /// The venue's icon, a graphical representation of the venue.  This is a byte[] representation of a PNG image.
        /// </summary>
        public  byte[]      Icon;
        /// <summary>
        /// A set of regular expressions defining who can and cannot enter the venue.  If null, the
        /// venue can be accessed by anyone (it's public)
        /// </summary>
        public  SecurityPatterns AccessList;

        //needed for serialisation
        public Venue() 
        {
            Port = 5004;
        }

        /// <summary>
        /// Constructs a new venue.
        /// </summary>
        /// <param name="identifier">the identifier of the venue</param>
        /// <param name="ipAddress">the ipaddress of the venue</param>
        /// <param name="port">the port the venue is active on</param>
        /// <param name="name">the name of the venue</param>
        /// <param name="isPublic">is this a public venue</param>
        /// <param name="icon">the venue's icon</param>
        public Venue( string identifier,  string ipAddress, int port, string name, byte[] icon, SecurityPatterns accessList)
        {
            this.Identifier = identifier;
            this.Name = name;
            this.IPAddress = ipAddress;
            this.Port = port;
            this.Icon = icon;
            this.AccessList = accessList;
        }

    }

    /// <summary>
    /// Represents a participant - an entity that takes part in a conference
    /// </summary>
    /// <example>
    /// using MSR.LST.ConferenceXP.VenueService
    /// class Test
    /// {
    ///     public static void Main()
    ///     {
    ///         VenueService vs = new VenueService()
    ///         Participant p = new Participant();
    ///         p.Identifier = "someone@somewhere.com";
    ///         p.Name ="test";
    ///         p.Email = null;
    ///         p.Phone = null;
    ///         p.Icon = null;
    ///         vs.AddParticipant(p);
    ///
    ///     }
    /// }
    /// </example>
    [Serializable]
    public class Participant
    {
        /// <summary>
        /// The unique identifier for this participant.  This must be globally unique and is equivalent in definition to the RTP SDES CNAME field, not to exceed 255 bytes.  In our application, we use the email address of the participant as the identifier in order to facilitate some form of Instant Message integration with a Participant in the future.
        /// </summary>
        public  string      Identifier;
        /// <summary>
        /// The descriptive name for the participant, not to exceed 255 bytes.
        /// </summary>
        public  string      Name;
        /// <summary>
        /// The email address of the participant
        /// </summary>
        public  string      Email;
        /// <summary>
        /// The participant's icon, a graphical representation of the venue.  This is a byte[] representation of a PNG image.
        /// </summary>
        public  byte[]      Icon;

        public  DateTime    LastAccessed;

        // needed for serialisation
        public Participant() {}

        /// <summary>
        /// Construct a participant
        /// </summary>
        /// <param name="identifier">The unique identifier for the participant</param>
        /// <param name="name">The name of the participant</param>
        /// <param name="phone">and their phone..</param>
        /// <param name="email">...and email address</param>
        /// <param name="icon">The online representation of the participant</param>
        /// <param name="notify">Does the participant want to be notified of software updates</param>
        public Participant( string identifier, string name, string email, byte[] icon)
        {
            this.Identifier     = identifier;
            this.Name           = name;
            this.Email          = email;
            this.Icon           = icon;
        }

    }

}
