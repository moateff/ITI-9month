namespace Task5
{
    public class Ground
    {
        private List<string> _parts = new List<string>();

        public void AddPart(string part)
        {
            _parts.Add(part);
        }

        public void Display()
        {
            Console.WriteLine("Ground built with:");
            foreach (var part in _parts)
            {
                Console.WriteLine("- " + part);
            }
        }
    }
}