using System;

namespace Task3
{
    public class Program
    {
        public static void Execute()
        {
            NetworkInterfaceController NIC1 = NetworkInterfaceController.GetInstance;
            NetworkInterfaceController NIC2 = NetworkInterfaceController.GetInstance;

            Console.WriteLine($"NIC1 HashCode = {NIC1.GetHashCode()}");
            Console.WriteLine($"NIC2 HashCode = {NIC2.GetHashCode()}");
        }

        public enum NetworkInterfaceControllerType
        {
            Ethernet,
            TokenRing
        }

        public class NetworkInterfaceController
        {
            public DateTime Manufacture { get; set; }
            public string? MACAddress { get; set; }
            public NetworkInterfaceControllerType InterfaceType { get; set; }
            public readonly static NetworkInterfaceController GetInstance = new NetworkInterfaceController();
            private NetworkInterfaceController() { }

            /*
            private static NetworkInterfaceController instance;

            public static NetworkInterfaceController GetInstance()
            {
                if (instance == null)
                    instance = new NetworkInterfaceController();
                return instance;
            }
            */
        }
    }
}