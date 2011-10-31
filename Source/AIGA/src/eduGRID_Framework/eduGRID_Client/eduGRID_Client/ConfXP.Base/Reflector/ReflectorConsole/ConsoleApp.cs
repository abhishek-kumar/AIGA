using System;
using MSR.LST.ConferenceXP.ReflectorService;
using System.Collections;
using System.Configuration;
using System.Net;
using MSR.LST.Net;
using ReflectorCommonLib;

namespace MSR.LST.ConferenceXP.ReflectorService
{
    /// <summary>
    /// This class provides a console executable for the Reflector.
    /// </summary>
    class ConsoleApp
    {
        private static ReflectorMgr refMgr;

        [STAThread]
        static void Main(string[] args)
        {
            MSR.LST.UnhandledExceptionHandler.Register();

            refMgr = new ReflectorMgr();
            StartService();
            while (true)
            {
                Console.Write("Reflector Console> ");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "p":
                        Console.WriteLine();
                        PrintTable();
                        Console.WriteLine();
                        break;
                    case "q":
                        Console.WriteLine();
                        StopService();
                        Console.WriteLine();
                        return;
                    case "h":
                        Console.WriteLine();
                        PrintHelp();
                        Console.WriteLine();
                        break;
                    case "d":
                        Console.WriteLine();
                        DeleteClient();
                        Console.WriteLine();
                        break;
                    case "s":
                        Console.WriteLine();
                        StartService();
                        Console.WriteLine();
                        break;
                    case "u":
                        Console.WriteLine();
                        ServiceStatus();
                        Console.WriteLine();
                        break;
                    case "t":
                        Console.WriteLine();
                        StopService();
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid Command");
                        Console.WriteLine();
                        PrintHelp();
                        Console.WriteLine();
                        break;
                }
            }
        }

        static void PrintTable()
        {
            if (refMgr.IsRunning)
            {
                Console.WriteLine("No.\tClient IP\tGroup IP\tGroup Port\tJoint Time\t\tConfirm. No.");
                Console.WriteLine("______________________________________________________________________________________________");
                
                int i = 0;
                lock (RegistrarServer.ClientRegTable.SyncRoot)
                {
                    ICollection values = RegistrarServer.ClientRegTable.Values;
                    foreach (ClientEntry entry in values)
                    {
                        Console.Write(i + ".\t");
                        Console.Write(entry.ClientIP + "\t" + entry.GroupEP + "\t\t\t"
                            + entry.JoinTime + "\t" + entry.ConfirmNumber);
                        Console.WriteLine();
                        i++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Service not running. Start the service first.");
            }
        }

        static void PrintHelp()
        {
            Console.WriteLine("Enter");
            Console.WriteLine("\t p: to print the client table");
            Console.WriteLine("\t s: to start the service");
            Console.WriteLine("\t t: to stop the service");
            Console.WriteLine("\t u: to see the status of the service");
            Console.WriteLine("\t d: to delete a client from the client table (force leave)");
            Console.WriteLine("\t q: to stop the service and quit the console");
            Console.WriteLine("\t h: to get this help message");
        }

        static void StartService()
        {
            if (!refMgr.IsRunning)
            {
                refMgr.StartReflector();
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Service started successfully.");
                if ((ReflectorMgr.EnabledTrafficTypes & TrafficType.IPv4) == TrafficType.IPv4)
                {
                    Console.WriteLine("Unicast side RTP EndPoint: " + ReflectorMgr.Sockets.SockUCv4RTP.LocalEndPoint);
                    Console.WriteLine("Unicast side RTCP EndPoint: " + ReflectorMgr.Sockets.SockUCv4RTCP.LocalEndPoint);
                    Console.WriteLine("Multicast side RTP EndPoint: " + ReflectorMgr.Sockets.SockMCv4RTP.LocalEndPoint);
                    Console.WriteLine("Multicast side RTCP EndPoint: " + ReflectorMgr.Sockets.SockMCv4RTCP.LocalEndPoint);
                } 
                if ((ReflectorMgr.EnabledTrafficTypes & TrafficType.IPv6) == TrafficType.IPv6)
                {
                    Console.WriteLine("IPv6 Unicast side RTP EndPoint: " + ReflectorMgr.Sockets.SockUCv6RTP.LocalEndPoint);
                    Console.WriteLine("IPv6 Unicast side RTCP EndPoint: " + ReflectorMgr.Sockets.SockUCv6RTCP.LocalEndPoint);
                    Console.WriteLine("IPv6 Multicast side RTP EndPoint: " + ReflectorMgr.Sockets.SockMCv6RTP.LocalEndPoint);
                    Console.WriteLine("IPv6 Multicast side RTCP EndPoint: " + ReflectorMgr.Sockets.SockMCv6RTCP.LocalEndPoint);
                }
                Console.WriteLine();
                PrintHelp();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Service already started.");
                if ((ReflectorMgr.EnabledTrafficTypes & TrafficType.IPv4) == TrafficType.IPv4)
                {
                    Console.WriteLine("Unicast side RTP EndPoint: " + ReflectorMgr.Sockets.SockUCv4RTP.LocalEndPoint);
                    Console.WriteLine("Unicast side RTCP EndPoint: " + ReflectorMgr.Sockets.SockUCv4RTCP.LocalEndPoint);
                    Console.WriteLine("Multicast side RTP EndPoint: " + ReflectorMgr.Sockets.SockMCv4RTP.LocalEndPoint);
                    Console.WriteLine("Multicast side RTCP EndPoint: " + ReflectorMgr.Sockets.SockMCv4RTCP.LocalEndPoint);
                } 
                if ((ReflectorMgr.EnabledTrafficTypes & TrafficType.IPv6) == TrafficType.IPv6)
                {
                    Console.WriteLine("IPv6 Unicast side RTP EndPoint: " + ReflectorMgr.Sockets.SockUCv6RTP.LocalEndPoint);
                    Console.WriteLine("IPv6 Unicast side RTCP EndPoint: " + ReflectorMgr.Sockets.SockUCv6RTCP.LocalEndPoint);
                    Console.WriteLine("IPv6 Multicast side RTP EndPoint: " + ReflectorMgr.Sockets.SockMCv6RTP.LocalEndPoint);
                    Console.WriteLine("IPv6 Multicast side RTCP EndPoint: " + ReflectorMgr.Sockets.SockMCv6RTCP.LocalEndPoint);
                }
            }
        }

        static void StopService()
        {
            if (refMgr.IsRunning)
            {
                refMgr.StopReflector();
                Console.WriteLine("Service stopped successfully.");
            }
            else
            {
                Console.WriteLine("Service is not running.");
            }
        }

        static void ServiceStatus()
        {
            if (refMgr.IsRunning)
            {
                Console.WriteLine("Service is running.");
                if ((ReflectorMgr.EnabledTrafficTypes & TrafficType.IPv4) == TrafficType.IPv4)
                {
                    Console.WriteLine("Unicast side RTP EndPoint: " + ReflectorMgr.Sockets.SockUCv4RTP.LocalEndPoint);
                    Console.WriteLine("Unicast side RTCP EndPoint: " + ReflectorMgr.Sockets.SockUCv4RTCP.LocalEndPoint);
                    Console.WriteLine("Multicast side RTP EndPoint: " + ReflectorMgr.Sockets.SockMCv4RTP.LocalEndPoint);
                    Console.WriteLine("Multicast side RTCP EndPoint: " + ReflectorMgr.Sockets.SockMCv4RTCP.LocalEndPoint);
                } 
                if ((ReflectorMgr.EnabledTrafficTypes & TrafficType.IPv6) == TrafficType.IPv6)
                {
                    Console.WriteLine("IPv6 Unicast side RTP EndPoint: " + ReflectorMgr.Sockets.SockUCv6RTP.LocalEndPoint);
                    Console.WriteLine("IPv6 Unicast side RTCP EndPoint: " + ReflectorMgr.Sockets.SockUCv6RTCP.LocalEndPoint);
                    Console.WriteLine("IPv6 Multicast side RTP EndPoint: " + ReflectorMgr.Sockets.SockMCv6RTP.LocalEndPoint);
                    Console.WriteLine("IPv6 Multicast side RTCP EndPoint: " + ReflectorMgr.Sockets.SockMCv6RTCP.LocalEndPoint);
                }
            }
            else
            {
                Console.WriteLine("Service is not running.");
            }
        }

        static void DeleteClient()
        {
            if (refMgr.IsRunning)
            {
                Console.Write("Please enter the client IP address to be deleted: ");
                String entry = Console.ReadLine();

                IPAddress address;
                try
                {
                    address = IPAddress.Parse(entry);
                }
                
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Entry: " + e.Message);
                    return;
                }

                if (RegistrarServer.ClientRegTable.ContainsKey(address))
                {
                    lock (RegistrarServer.ClientRegTable.SyncRoot)
                    {
                        RegistrarServer.ClientRegTable.Remove(address);
                    }
                    Console.WriteLine("The client IP address {0} deleted successfully", address);
                }
                else
                {
                    Console.WriteLine("The client IP address you provided doesn't exist!");
                } 
            }
            else
            {
                Console.WriteLine("Service is not running.");
            }
        }
    }
}
