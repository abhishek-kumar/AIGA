using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;


namespace MSR.LST.ConferenceXP.VenueService
{
    public class FileStorage: IDisposable
    {
        #region Private variables
        /// <summary>
        /// The FileInfo object for the file we're reading from & writing to.
        /// </summary>
        FileInfo info;

        /// <summary>
        /// Constantly tracks the last edit on the file by tracking its length.  Unfortunately,
        /// LastWriteTime could not be used because it returns null when the internet guest account
        /// is reading from the file (for reasons not understood).  The last file length should be
        /// sufficient for our purposes.
        /// </summary>
        long lastLength;

        /// <summary>
        /// The file for reading & writing the venue service data to.
        /// </summary>
        FileStream file = null;

        /// <summary>
        /// The serialization formatter for writing to/from the file.
        /// </summary>
        IFormatter formatter = null;

        /// <summary>
        /// In-memory, cached set of participants this venue service holds.
        /// </summary>
        SortedList participants = null;

        /// <summary>
        /// In-memory, cached set of venues this venue service holds.
        /// </summary>
        SortedList venues = null;

        /// <summary>
        /// If this is true, all write operations are cached in memory & not written to disk
        /// until it's turned off.
        /// </summary>
        bool cacheWriteOps = false;
        #endregion

        #region Ctor / Init
        public FileStorage( string path )
        {
            // Open the file
            file = new FileStream(path, FileMode.OpenOrCreate);

            // Create the info object
            info = new FileInfo(path);
            lastLength = info.Length;

            try
            {
                // Check for read & write ability
                if( !(file.CanRead && file.CanWrite) )
                    throw new IOException("File filePath could not be opened for both read & write.");

                // Create our formatter
                formatter = new BinaryFormatter();

                InitializeDataStructures();
            }
            finally
            {
                file.Close();
            }
        }

        /// <summary>
        /// Reads the data from the file & writes it to the data structures.
        /// </summary>
        private void InitializeDataStructures()
        {
            lock(file)
            {
                // Read in the list of venues, and if none exists, create a new SortedList
                try
                {
                    venues = (SortedList)formatter.Deserialize(file);
                }
                catch
                {
                    venues = new SortedList(CaseInsensitiveComparer.Default);
                }

                // Read in the list of participants, and if none exists, create a new SortedList
                try
                {
                    participants = (SortedList)formatter.Deserialize(file);
                }
                catch
                {
                    participants = new SortedList(CaseInsensitiveComparer.Default);
                }

                // Make sure both lists are thread-safe
                venues = SortedList.Synchronized(venues);
                participants = SortedList.Synchronized(participants);
            }
        }
        #endregion

        #region IVenueServiceStorage Members
        public void AddVenue(Venue v)
        {
            this.UpdateFromFile();

            venues.Add( v.Identifier, v );

            WriteCacheToFile();
        }

        public void UpdateVenue(Venue v)
        {
            this.UpdateFromFile();

            venues[v.Identifier] = v;

            WriteCacheToFile();
        }

        public void DeleteVenue(string venueIdentifier)
        {
            this.UpdateFromFile();

            venues.Remove(venueIdentifier);

            WriteCacheToFile();
        }

        public Venue GetVenue(string venueIdentifier)
        {
            this.UpdateFromFile();

            return (Venue)venues[venueIdentifier];
        }

        public Venue[] GetVenues()
        {
            this.UpdateFromFile();

            ICollection vals = venues.Values;
            Venue[] venueArray = new Venue[vals.Count];
            vals.CopyTo(venueArray, 0);
            return venueArray;
        }

        public void AddParticipant(Participant part)
        {
            this.UpdateFromFile();

            participants.Add(part.Identifier, part);

            WriteCacheToFile();
        }

        public void UpdateParticipant(Participant part)
        {
            this.UpdateFromFile();

            participants[part.Identifier] = part;

            WriteCacheToFile();
        }

        public void DeleteParticipant(string participantIdentifier)
        {
            this.UpdateFromFile();

            participants.Remove(participantIdentifier);

            WriteCacheToFile();
        }

        public Participant GetParticipant(string participantIdentifier)
        {
            this.UpdateFromFile();

            return (Participant)participants[participantIdentifier];
        }

        public Participant[] GetParticipants()
        {
            this.UpdateFromFile();

            ICollection vals = participants.Values;
            Participant[] partArray = new Participant[vals.Count];
            vals.CopyTo(partArray, 0);
            return partArray;
        }
        #endregion

        #region Caching
        /// <summary>
        /// If this is true, all write operations are cached in memory & not written to disk
        /// until it's turned off.
        /// </summary>
        public bool WriteCaching
        {
            get
            {
                return this.cacheWriteOps;
            }
            set
            {
                this.cacheWriteOps = value;

                if (!value)
                    this.WriteCacheToFile();
            }
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Checks that the last time the file was written to has not been updated, and if it has, then
        /// reads the data from the file.
        /// </summary>
        private void UpdateFromFile()
        {
            info.Refresh();
            long latestLength = info.Length;
            if (this.lastLength != latestLength)
            {
                this.lastLength = latestLength;
                Console.WriteLine("Updating data structures after external write.  LastWriteTime: {0}", this.lastLength.ToString());

                lock(info)
                {
                    file = new FileStream(info.FullName, FileMode.OpenOrCreate);
                    InitializeDataStructures();
                    file.Close();
                }
            }
        }

        /// <summary>
        /// Writes the contents of the cached venues & participants back to the file
        /// </summary>
        private void WriteCacheToFile()
        {
            if (this.cacheWriteOps)
                return;

            lock(info)
            {
                Trace.WriteLine("Writing cached to file.  Time: "+DateTime.Now.ToLongTimeString());

                file = new FileStream(info.FullName, FileMode.OpenOrCreate);
                long startLength = file.Length;
                try
                {

                    file.Position = 0;
                    formatter.Serialize(file, venues);
                    formatter.Serialize(file, participants);
                    file.SetLength(file.Position); // shortens the file, if necessary

                    Trace.WriteLine("Finished writing cache to file.  Time: "+DateTime.Now.ToLongTimeString());
                }
                finally
                {
                    file.Close();
                }

                info.Refresh();
                long endLength = info.Length;
                this.lastLength = endLength;
                Trace.WriteLine(string.Format("Old file size: {0}, New file size: {1}", startLength, endLength));
            }
        }
        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            file.Close();
        }

        #endregion
    }
}